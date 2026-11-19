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
        private readonly IRepository<Room> _repository;
        public RoomService(AppDbContext context , IRepository<Room> repository)
        {
            _repository = repository;
            _context = context;
        }
        public async Task<Room?> GetRoomByIdAsync(int id)
        {
            var room = await _repository.GetByIdAsync(id);
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
            var rooms = await _repository.GetAllAsync();
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

        public async Task AddRoomAsync(Room room)
        {
            if(room != null)
            {
                await _repository.AddAsync(room);
            }
        }
        public async Task DeleteRoomAsync(int roomId)
        {
            if(roomId > 0)
            {
                await _repository.DeleteAsync(roomId);
            }
        }
        public async Task UpdateRoomAsync(Room room)
        {
            if( room != null)
            {
                await _repository.UpdateAsync(room);
            }
        }
    }
}
