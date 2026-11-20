using Microsoft.EntityFrameworkCore;
using SchoolSchedule.Core.Entities;
using SchoolSchedule.Core.Interfaces;
using SchoolSchedule.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSchedule.Infrastructure.Services
{
    public class CurriculumItemService : ICurriculumItemService
    {
        private readonly AppDbContext _context;
        private readonly IRepository<CurriculumItem> _repository;
            public CurriculumItemService(AppDbContext context , IRepository<CurriculumItem> repository)
            {
            _repository = repository;
            _context = context;
            }
        public async Task<CurriculumItem?> GetCurrilicumItemByClassIdAsync(int id)
        {
            var curilicumItem = await _context.CurriculumItems.FindAsync(id);
            if(curilicumItem != null)
            {
                return curilicumItem;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<CurriculumItem>> GetAllCurrilicumItemsAsync()
        {
            var curilicumItem = await _repository.GetAllAsync();
            return curilicumItem;
        }

        public async Task<IEnumerable<CurriculumItem>> GetClassesCurriculumItemsAsync(int classId)
        {
            var curriculumItems = await _context.CurriculumItems.Where(c => c.ClassId == classId).ToListAsync();
            return curriculumItems;
        }
        public async Task<int> ValidateClassHoursAsync(int classId)
        {
            var hours = await _context.CurriculumItems.Where(c => c.ClassId == classId).SumAsync(c => c.HoursPerWeek);
            return hours;
        }

        public async Task<CurriculumItem?> GetCurrilicumItemByIdAsync(int id)
        {
            var currIt = await _repository.GetByIdAsync(id);
            if(currIt != null)
            {
                return currIt;
            }
            else
            {
                return null;
            }
        }
        public async Task AddCurriculumItemAsync(CurriculumItem curriculumItem)
        {
            if(curriculumItem != null)
            {
                await _repository.AddAsync(curriculumItem);
            }
        }
        public async Task UpdateCurriculumItemAsync(CurriculumItem currriculumItem)
        {
            if(currriculumItem != null)
            {
                await _repository.UpdateAsync(currriculumItem);
            }
        }
        public async Task DeleteCurriculumItemAsync(int id)
        {
            if(id > 0)
            {
                await _repository.DeleteAsync(id);
            }
        }
    }
}
