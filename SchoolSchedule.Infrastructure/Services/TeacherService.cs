using SchoolSchedule.Core.Interfaces;
using System;
using SchoolSchedule.Infrastructure.Data;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SchoolSchedule.Core.Entities;

namespace SchoolSchedule.Infrastructure.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly IRepository<Teacher> _teacherRepository;
        private readonly AppDbContext _context;
        public TeacherService (AppDbContext context, IRepository<Teacher> teacherRepository)
        {
            _context = context;
            _teacherRepository = teacherRepository;
        }

        public async Task AssignSubjectToTeacherAsync(int teacherId,int subjectId)
        {
            var teacher = await _context.Teachers.FindAsync(teacherId);
            var subject = await _context.Subjects.FindAsync(subjectId);
            if(teacher != null && subject != null)
            {
                TeacherSubject teacherSubject = new TeacherSubject();
                teacherSubject.SubjectId = subjectId;
                teacherSubject.TeacherId = teacherId;
                await _context.TeacherSubjects.AddAsync(teacherSubject);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> CanTeacherTeachSubjectAsync(int teacherId , int subjectId)
        {
            bool teacherSub = await _context.TeacherSubjects.AnyAsync(t =>t.TeacherId == teacherId && t.SubjectId == subjectId);
            return teacherSub;  
        }

        public async Task<int> GetExceededMaxHoursAsync(int teacherId)
        {
            var teacher = await _context.Teachers.FindAsync(teacherId);
            if(teacher != null)
            {
                return teacher.MaxHoursPerWeek;
            }
            return 0;
        }
        public async Task<Teacher?> GetTeacherByIdAsync(int teacherId)
        {
            var teacher = await _teacherRepository.GetByIdAsync(teacherId);
            if(teacher!= null)
            {
                return teacher;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Teacher>> GetAllTeacherAsync()
        {
            var teachers = await _teacherRepository.GetAllAsync();
            return teachers;
        }
        public async Task AddTeacherAsync(Teacher teacher)
        {
            if(teacher != null)
            {
                await _teacherRepository.AddAsync(teacher);
            }
        }
        public async Task DeleteTeacherAsync(int teacherId)
        {
            if(teacherId > 0)
            {
                await _teacherRepository.DeleteAsync(teacherId);
            }
        }
        public async Task UpdateTeacherAsync(Teacher teacher)
        {
            if( teacher != null)
            {
                await _teacherRepository.UpdateAsync(teacher);
            }
        }
    }
}
