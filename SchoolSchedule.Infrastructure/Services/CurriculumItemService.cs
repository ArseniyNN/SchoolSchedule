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
            public CurriculumItemService(AppDbContext context)
            {
            _context = context;
            }
        public async Task<CurriculumItem?> GetCurrilicumItemByIdAsync(int id)
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
            var curilicumItem = await _context.CurriculumItems.ToListAsync();
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
    }
}
