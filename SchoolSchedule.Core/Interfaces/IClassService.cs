using System;
using System.Collections.Generic;
using System.Text;
using SchoolSchedule.Core.Entities;

namespace SchoolSchedule.Core.Interfaces
{
    public interface IClassService
    {
        Task<Class?> GetClassByIdAsync(int id);
        Task<IEnumerable<Class>> GetAllClassesAsync();
        Task AddClassAsync(Class entity);
        Task UpdateClassAsync(Class entity);
        Task DeleteClassAsync(int id);
    }
}
