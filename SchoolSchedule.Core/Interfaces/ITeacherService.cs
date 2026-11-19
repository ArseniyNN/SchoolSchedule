using System;
using System.Collections.Generic;
using System.Text;
using SchoolSchedule.Core.Entities;

namespace SchoolSchedule.Core.Interfaces
{
    public interface ITeacherService
    {
        Task AssignSubjectToTeacherAsync(int teacherId, int subjectId);
        Task<bool> CanTeacherTeachSubjectAsync(int teacherId, int subjectId);
        Task<int> GetExceededMaxHoursAsync(int teacherId);
        Task<Teacher?> GetTeacherByIdAsync(int teacherId);
        Task<IEnumerable<Teacher>> GetAllTeacherAsync();
        Task AddTeacherAsync(Teacher teacher);
        Task DeleteTeacherAsync(int id);
        Task UpdateTeacherAsync(Teacher teacher);
    }
}
