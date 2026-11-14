using Microsoft.EntityFrameworkCore;
using SchoolSchedule.Core.Entities;
using SchoolSchedule.Core.Interfaces;
using SchoolSchedule.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSchedule.Infrastructure.Services
{
    public class ClassService : IClassService
    {
        private readonly AppDbContext _context;

        public ClassService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Class?> GetClassByIdAsync(int id)
        {
            var clas = await _context.Classes.FindAsync(id);
            if(clas != null)
            {
                return clas;
            }
            else
            {
                return null;
            }
        }

        public async Task<IEnumerable<Class>> GetAllClassesAsync()
        {
            var classes = await _context.Classes.ToListAsync();
            return classes;
        }

    }
}
