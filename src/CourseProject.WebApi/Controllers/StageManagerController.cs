using Course_Project.Logic.Interfaces;
using Course_Project.Logic.Models;
using CourseProject.Web.Shared.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CourseProject.WebApi3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StageManagerController : ControllerBase
    {
        private readonly IStageManagerManager _stageManagerManager;

        public StageManagerController(IStageManagerManager stageManagerManager)
        {
            _stageManagerManager = stageManagerManager ?? throw new ArgumentNullException(nameof(stageManagerManager));
        }

        [HttpPost("addStageManager")]
        public async Task<IActionResult> CreateAsync([FromBody] StageManagerCreateRequest request)
        {
            StageManagerDto stageManagerDto = new()
            {
                StageManagers = request.StageManager
            };

            if (ModelState.IsValid)
            {
                await _stageManagerManager.CreateAsync(stageManagerDto);
            }

            return Ok();
        }

        [HttpGet("allStageManager")]
        public async Task<IActionResult> GetAllActor()
        {
            var countries = await _stageManagerManager.GetAllAsync();

            return Ok(countries);
        }

        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _stageManagerManager.DeleteAsync(id);
        }
    }
}