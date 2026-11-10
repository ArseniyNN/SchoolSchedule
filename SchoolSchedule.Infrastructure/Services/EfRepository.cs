using Microsoft.EntityFrameworkCore;
using SchoolSchedule.Core.Interfaces;
using SchoolSchedule.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSchedule.Infrastructure.Services
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        public EfRepository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            IEnumerable<T> result = new List<T>();
            result = await _context.Set<T>().ToListAsync();
            return result;
        }
        public async Task<T?> GetByIdAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if(entity == null)
            {
                return null;
            }
            return entity;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        
        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if(entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
