using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSchedule.Core.Interfaces;
using SchoolSchedule.Core.Entities;

namespace SchoolSchedule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;
        public SchedulesController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var schedules = await _scheduleService.GetAllSchedulesAsync();
            return Ok(schedules);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var schedule = await _scheduleService.GetScheduleByIdAsync(id);
            if(schedule == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(schedule);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(Schedule schedule)
        {
            if(schedule == null)
            {
                return BadRequest();
            }
            else
            {
                await _scheduleService.AddScheduleAsync(schedule);
                return Ok();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            else
            {
                await _scheduleService.DeleteScheduleAsync(id);
                return NoContent();
            }
        }
    }
}
