using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolSchedule.Core.Interfaces;
using SchoolSchedule.Core.Entities;
namespace SchoolSchedule.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrilicumItemsController : ControllerBase
    {
        private readonly ICurriculumItemService _curriculumItemService;
        public CurrilicumItemsController(ICurriculumItemService curriculumItemService)
        {
            _curriculumItemService = curriculumItemService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var currilicumItems = await _curriculumItemService.GetAllCurrilicumItemsAsync();
            return Ok(currilicumItems);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var curriculumItem = await _curriculumItemService.GetCurrilicumItemByIdAsync(id);
            if(curriculumItem != null)
            {
                return Ok(curriculumItem);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost] 
        public async Task<IActionResult> Add(CurriculumItem currilicumItem)
        {
            if(currilicumItem == null)
            {
                return BadRequest();
            }
            else
            {
                await _curriculumItemService.AddCurriculumItemAsync(currilicumItem);
                return Ok();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0)
            {
                return BadRequest();
            }
            else
            {
                await _curriculumItemService.DeleteCurriculumItemAsync(id);
                return NoContent();
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update(CurriculumItem curriculumItem)
        {
            if(curriculumItem == null)
            {
                return BadRequest();
            }
            else
            {
                await _curriculumItemService.UpdateCurriculumItemAsync(curriculumItem);
                return NoContent();
            }
        }
    }
}
