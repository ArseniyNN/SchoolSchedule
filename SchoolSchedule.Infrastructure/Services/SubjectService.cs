using SchoolSchedule.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolSchedule.Core.Entities;

namespace SchoolSchedule.Infrastructure.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly IRepository<Subject> _repository;
        public SubjectService(IRepository<Subject> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            var subjects = await _repository.GetAllAsync();
            return subjects;
        }
        public async Task<Subject?> GetSubjectByIdAsync(int id)
        {
            var subj = await _repository.GetByIdAsync(id);
            if(subj != null)
            {
                return subj;
            }
            else
            {
                return null;
            }
        }
        public async Task AddSubjectAsync(Subject subject)
        {
            if(subject != null)
            {
               await _repository.AddAsync(subject);
            }
        }
        public async Task UpdateSubjectAsync(Subject subject)
        {
            if( subject != null)
            {
                await _repository.UpdateAsync(subject);
            }
        }

        public async Task DeleteSubjectAsync(int id)
        {
            if (id > 0)
            {
                await _repository.DeleteAsync(id);
            }
        }
    }
}
