using System;
using System.Collections.Generic;
using System.Text;
using SchoolSchedule.Core.Entities;

namespace SchoolSchedule.Core.Interfaces
{
    public interface ICurriculumItemService
    {
        Task<Class> GetClassByIdAsync(int ClassId);
        Task<IEnumerable<Class>> GetAllClassAsync();
        Task<IEnumerable<CurriculumItem>> GetClassesCurriculumItemsAsync(int classId);
        Task<int> ValidateClassHoursAsync(int classId);

    }
}
