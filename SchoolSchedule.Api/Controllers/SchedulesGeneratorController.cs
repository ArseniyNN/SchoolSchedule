using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSchedule.Core.Interfaces;

namespace SchoolSchedule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesGeneratorController : ControllerBase
    {
        private readonly IScheduleGenerator _scheduleGenerator;
        public SchedulesGeneratorController (IScheduleGenerator scheduleGenerator)
        {
            _scheduleGenerator = scheduleGenerator;
        }
        [HttpGet("generate")]
        public async Task<IActionResult> Generate()
        {
            var schedule = await _scheduleGenerator.GenerateLessonSlotsAsync();
            return Ok(schedule);
        }
    }
}
