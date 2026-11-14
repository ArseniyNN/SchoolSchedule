using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging.Abstractions;
using Npgsql.EntityFrameworkCore.PostgreSQL.Query.Expressions.Internal;
using SchoolSchedule.Core.Entities;
using SchoolSchedule.Core.Enums;
using SchoolSchedule.Core.Interfaces;
using SchoolSchedule.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SchoolSchedule.Infrastructure.Services
{
    public class ScheduleGeneratorService : IScheduleGenerator
    {
        private readonly ICurriculumItemService _curriculumItemService;
        private readonly IRoomService _roomService;
        private readonly ITeacherService _teacherService;
        private readonly IClassService _classService;
        private readonly IRepository<Subject> _subjects;
        public ScheduleGeneratorService(IRoomService roomService, ITeacherService teacherService , 
            ICurriculumItemService curriculumItemService, IClassService classService , IRepository<Subject> subjects)
        {
            _teacherService = teacherService;
            _roomService = roomService;
            _curriculumItemService = curriculumItemService;
            _classService = classService;
            _subjects = subjects;
        }

        public async Task<IEnumerable<LessonSlot>> GenerateLessonSlotsAsync()
        {
            var currilicumItems = (await _curriculumItemService.GetAllCurrilicumItemsAsync()).ToList();
            var rooms = (await _roomService.GetAllRoomsAsync()).ToList();
            var teachers = (await _teacherService.GetAllTeacherAsync()).ToList();
            var classes = (await _classService.GetAllClassesAsync()).ToList();
            var subjectBase = (await _subjects.GetAllAsync()).ToList();
            List<LessonSlot> slots = new List<LessonSlot>();
            Dictionary<int, int> teacherHours = new Dictionary<int, int>();
            List<(int ClassId, int SubjectId)> classSubject = new();
            foreach(var currIt in currilicumItems)
            {
                
                for(int i = 0; i < currIt.HoursPerWeek; i++)
                {
                    classSubject.Add((currIt.ClassId , currIt.SubjectId));
                }
            }
            var taskQueue = new Queue<(int ClassId, int SubjectId)>(classSubject);
            int count = 0;
            foreach(var teacher in teachers)
            {
                teacherHours.Add(teacher.Id, 0);
            }
            while(taskQueue.Count > 0)
            {
                if(count >= taskQueue.Count)
                {
                    break;
                }
                var temp = taskQueue.Dequeue();
                bool isPlaced = false;
                foreach(var day in Enum.GetValues<LessonDay>())
                {
                    if(slots.Any(s => s.ClassId == temp.ClassId && s.SubjectId == temp.SubjectId && s.DayWeek == day))
                    {
                        continue;
                    }
                    for(int lessonNum =1; lessonNum <= 7; lessonNum++)
                    {
                       bool isClassBusy =  slots.Any(s => s.DayWeek == day && s.ClassId == temp.ClassId && s.LessonNumber == lessonNum);
                        if (isClassBusy == false)
                        {
                            foreach (var teacher in teachers)
                            {
                                if (teacherHours[teacher.Id] <= teacher.MaxHoursPerWeek)
                                {
                                    bool teacherTeach = await _teacherService.CanTeacherTeachSubjectAsync(teacher.Id, temp.SubjectId);
                                    bool teacherDay = slots.Any(t => t.DayWeek == day && t.TeacherId == teacher.Id && t.LessonNumber == lessonNum);
                                    if (teacherTeach == true && teacherDay == false)
                                    {
                                        var search = subjectBase.FirstOrDefault(s => s.Id == temp.SubjectId);
                                        var roomst = rooms.Where(r => r.Type == search.RequiredRoomType);
                                        foreach (var room in roomst)
                                        {
                                            bool roomFree = slots.Any(r => r.RoomId == room.Id && r.DayWeek == day && r.LessonNumber == lessonNum);
                                            if (roomFree == false)
                                            {
                                                slots.Add(new LessonSlot
                                                {
                                                    ClassId = temp.ClassId,
                                                    SubjectId = temp.SubjectId,
                                                    TeacherId = teacher.Id,
                                                    RoomId = room.Id,
                                                    LessonNumber = lessonNum,
                                                    DayWeek = day
                                                });
                                                count = 0;
                                                teacherHours[teacher.Id]++;
                                                isPlaced = true;
                                                break;
                                            }
                                        }
                                    }
                                }
                                if (isPlaced)
                                {
                                    break;
                                }
                            }
                        }
                        if (isPlaced)
                        {
                            break;
                        }
                    }
                    if (isPlaced)
                    {
                        break;
                    }
                }
                if (isPlaced == false)
                {
                    taskQueue.Enqueue(temp);
                    count++;
                }
            }
            return slots;
        }
    }
}
