using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSchedule.Core.Entities;
using SchoolSchedule.Core.Interfaces;
using System.Runtime.InteropServices;

namespace SchoolSchedule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectsController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var subjects = await _subjectService.GetAllSubjectsAsync();
            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var subj = await _subjectService.GetSubjectByIdAsync(id);
            if (subj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(subj);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(Subject subject)
        {
            if(subject == null)
            {
                return BadRequest();
            }
            else
            {
                await _subjectService.AddSubjectAsync(subject);
                return Ok();
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(Subject subject)
        {
            if( subject == null)
            {
                return BadRequest();
            }
            else
            {
                await _subjectService.UpdateSubjectAsync(subject);
                return NoContent();
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
                await _subjectService.DeleteSubjectAsync(id);
                return NoContent();
            }
        }


    }
}
