using SchoolSchedule.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolSchedule.Core.Enums;

namespace SchoolSchedule.Core.Interfaces
{
    public interface IRoomService
    {
        Task<Room?> GetRoomByIdAsync(int roomId);
        Task<IEnumerable<Room>> GetAllRoomsAsync();
        Task<IEnumerable<Room>> GetRoomsByTypeAsync(RoomType roomtype);
        Task<bool> IsRoomAvailableAsync(int roomId , int lessonNember , LessonDay dayOfWeek);
    }
}
