using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Webapi.Services.Models;
using Webapi.Services.Services.Helperservice;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelperController : ControllerBase
    {
        private readonly IHelperService _helperService;

        public HelperController(IHelperService helperService)
        {
            _helperService = helperService ?? throw new ArgumentNullException(nameof(helperService));
        }

        [HttpGet]
        public ActionResult<IEnumerable<HelperDto>> GetAllHelpers(bool? isActive = null)
        {
            var helpers = _helperService.GetAllHelpers(isActive);
            return Ok(helpers);
        }

        [HttpGet("{id}")]
        public ActionResult<HelperDto> GetHelperById(int id)
        {
            var helper = _helperService.GetHelperById(id);
            if (helper == null)
            {
                return NotFound();
            }
            return Ok(helper);
        }

        [HttpPost]
        public ActionResult<HelperDto> AddHelper([FromBody] HelperDto HelperDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newHelper = _helperService.AddHelper(HelperDto);
            return CreatedAtAction(nameof(GetHelperById), new { id = newHelper.HelperId }, newHelper);
        }

        [HttpPut("{id}")]
        public ActionResult<HelperDto> UpdateHelper(int id, [FromBody] HelperDto HelperDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedHelper = _helperService.UpdateHelper(id, HelperDto);
            if (updatedHelper == null)
            {
                return NotFound();
            }

            return Ok(updatedHelper);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteHelper(int id)
        {
            var deleted = _helperService.DeleteHelperById(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
