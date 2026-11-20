using System;
using System.Collections.Generic;
using System.Text;
using SchoolSchedule.Core.Entities;

namespace SchoolSchedule.Core.Interfaces
{
    public interface ICurriculumItemService
    {
        Task<CurriculumItem?> GetCurrilicumItemByClassIdAsync(int ClassId);
        Task<IEnumerable<CurriculumItem>> GetAllCurrilicumItemsAsync();
        Task<CurriculumItem?> GetCurrilicumItemByIdAsync(int curriculumItemId);
        Task<IEnumerable<CurriculumItem>> GetClassesCurriculumItemsAsync(int classId);
        Task<int> ValidateClassHoursAsync(int classId);
        Task AddCurriculumItemAsync(CurriculumItem curriculumItem);
        Task UpdateCurriculumItemAsync(CurriculumItem curriculumItem);
        Task DeleteCurriculumItemAsync(int curiculumItemId);

    }
}
