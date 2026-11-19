using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSchedule.Core.Entities;
using SchoolSchedule.Core.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace SchoolSchedule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teachers = await _teacherService.GetAllTeacherAsync();
            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var teacher = await _teacherService.GetTeacherByIdAsync(id);
            if (teacher != null)
            {
                return Ok(teacher);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Add(Teacher teacher)
        {
            if(teacher == null)
            {
                return BadRequest();
            }
            await _teacherService.AddTeacherAsync(teacher);
            return Ok();
        }

        [HttpPut] 
        public async Task<IActionResult> Update(Teacher teacher)
        {
            if(teacher == null)
            {
                return BadRequest();
            }
            await _teacherService.UpdateTeacherAsync(teacher);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }
            await _teacherService.DeleteTeacherAsync(id);
            return NoContent();
        }
    }
}
