using System;
using System.Collections.Generic;
using System.Text;
using SchoolSchedule.Core.Entities;

namespace SchoolSchedule.Core.Interfaces
{
    public interface ICurriculumItemService
    {
        Task<CurriculumItem?> GetCurrilicumItemByIdAsync(int ClassId);
        Task<IEnumerable<CurriculumItem>> GetAllCurrilicumItemsAsync();
        Task<IEnumerable<CurriculumItem>> GetClassesCurriculumItemsAsync(int classId);
        Task<int> ValidateClassHoursAsync(int classId);

    }
}
