using SchoolSchedule.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSchedule.Core.Interfaces
{
    public interface IScheduleGenerator
    {
        Task<IEnumerable<LessonSlot>> GenerateLessonSlotsAsync();
    }
}
