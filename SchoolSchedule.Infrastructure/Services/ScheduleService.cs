using SchoolSchedule.Core.Entities;
using SchoolSchedule.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSchedule.Infrastructure.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IRepository<Schedule> _repository;
        public ScheduleService(IRepository<Schedule> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Schedule>> GetAllSchedulesAsync()
        {
            var schedule = await _repository.GetAllAsync();
            return schedule;
        }

        public async Task<Schedule?> GetScheduleByIdAsync(int scheduleId)
        {
            if (scheduleId > 0)
            {
                var scedule = await _repository.GetByIdAsync(scheduleId);
                return scedule;
            }
            else
            {
                return null;
            }
        }
        public async Task DeleteScheduleAsync(int scheduleId)
        {
            if(scheduleId > 0)
            {
                await _repository.DeleteAsync(scheduleId);
            }
        }
        public async Task AddScheduleAsync(Schedule schedule)
        {
            if( schedule != null)
            {
                await _repository.AddAsync(schedule);
            }
        }

    }
}
