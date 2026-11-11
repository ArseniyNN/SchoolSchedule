using Microsoft.EntityFrameworkCore;
using SchoolSchedule.Core.Entities;
using SchoolSchedule.Core.Interfaces;
using SchoolSchedule.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolSchedule.Core.Enums;

namespace SchoolSchedule.Infrastructure.Services
{
    public class RoomService : IRoomService
    {
        private readonly AppDbContext _context;
        public RoomService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Room?> GetRoomByIdAsync(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if(room == null)
            {
                return null;
            }
            else
            {
                return room;
            }
        }

        public async Task<IEnumerable<Room>> GetAllRoomsAsync()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return rooms;
        }

        public async Task<IEnumerable<Room>> GetRoomsByTypeAsync(RoomType type)
        {
            var rooms = await _context.Rooms.Where(r => r.Type == type).ToListAsync();
            return rooms;
        }
            
        public async Task<bool> IsRoomAvailableAsync(int roomId , int lessonNumber , LessonDay dayOfWeek) 
        {
            bool isAvailable  = await _context.LessonSlots.AnyAsync(l => l.RoomId == roomId && l.LessonNumber == lessonNumber && l.DayWeek == dayOfWeek);
            return isAvailable;
        }
    }
}
