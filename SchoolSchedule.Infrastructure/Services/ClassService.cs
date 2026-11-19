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
        private readonly IRepository<Class> _classRepository;

        public ClassService(IRepository<Class> classRepository )
        {
            _classRepository = classRepository;
        }

        public async Task<Class?> GetClassByIdAsync(int id)
        {
            var clas = await _classRepository.GetByIdAsync(id);
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
            var classes = await _classRepository.GetAllAsync();
            return classes;
        }

        public async Task AddClassAsync(Class classEntity)
        {
            if(classEntity != null)
            {
                await _classRepository.AddAsync(classEntity);
            }
        }
        public async Task UpdateClassAsync(Class classEntity)
        {
            if( classEntity != null)
            {
                await _classRepository.UpdateAsync(classEntity);
            }
        }

        public async Task DeleteClassAsync(int id)
        {
            if(id> 0)
            {
                await _classRepository.DeleteAsync(id);
            }
        }

    }
}
