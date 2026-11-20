using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSchedule.Core.Interfaces;
using SchoolSchedule.Core.Entities;

namespace SchoolSchedule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;
        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rooms = await _roomService.GetAllRoomsAsync();
            return Ok(rooms);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var room = await _roomService.GetRoomByIdAsync(id);
            if(room != null)
            {
                return Ok(room);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(Room room)
        {
            if(room != null)
            {
                await _roomService.AddRoomAsync(room);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id > 0)
            {
                await _roomService.DeleteRoomAsync(id);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(Room room)
        {
            if( room != null)
            {
                await _roomService.UpdateRoomAsync(room);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
