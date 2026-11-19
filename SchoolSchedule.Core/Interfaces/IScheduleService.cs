using SchoolSchedule.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSchedule.Core.Interfaces
{
    public interface IScheduleService
    {
        Task<IEnumerable<Schedule>> GetAllServiceAsync();
        Task<Schedule> GetServiceByIdAsync(int id);
        Task DeleteScheduleAsync(int  scheduleId);
        Task AddScheduleAsync(Schedule schedule);

    }
}
