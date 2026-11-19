using SchoolSchedule.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSchedule.Core.Interfaces
{
    public interface ISubjectService
    {
        Task<IEnumerable<Subject>> GetAllSubjectsAsync();
        Task<Subject?> GetSubjectByIdAsync(int id);
        Task AddSubjectAsync(Subject subject);
        Task UpdateSubjectAsync(Subject subject);
        Task DeleteSubjectAsync(int id);
        
    }
}
