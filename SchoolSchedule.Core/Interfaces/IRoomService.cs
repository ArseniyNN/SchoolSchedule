using SchoolSchedule.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolSchedule.Core.Interfaces
{
    public interface IRoomService
    {
        Task<Room> GetRoomByIdAsync(int roomId);
        Task<IEnumerable<Room>> GetAllRoomsAsync();
        Task<IEnumerable<Room>> GetRomsByTypeAsync(string roomtype);
        Task<bool> IsRoomAvailableAsync(int roomId , int lessonNember , int dayofWeek);
    }
}
