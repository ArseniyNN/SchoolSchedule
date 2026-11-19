using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SchoolSchedule.Core.Entities;
using SchoolSchedule.Core.Interfaces;

namespace SchoolSchedule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private readonly IClassService _classServices;
        public ClassesController(IClassService classServices)
        {
            _classServices = classServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var classes = await _classServices.GetAllClassesAsync();
            return Ok(classes);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var classEntity = await _classServices.GetClassByIdAsync(id);
            if (classEntity != null)
            {
                return Ok(classEntity);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(Class entity)
        {
            if(entity == null)
            {
                return BadRequest();
            }
            await _classServices.AddClassAsync(entity);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Class entity)
        {
            if( entity == null)
            {
                return BadRequest();
            }
            await _classServices.UpdateClassAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }
            await _classServices.DeleteClassAsync(id);
            return NoContent();
        }
    }
}
