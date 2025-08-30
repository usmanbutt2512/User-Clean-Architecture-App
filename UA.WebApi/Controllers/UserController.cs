using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UA.Application.Dtos;
using UA.Application.Interfaces;

namespace UA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {    

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(await userService.GetUserByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult>Post([FromBody] UserDto dto)
        {
            return Ok();
        }
        [HttpPut("{id:guid}")]
        public async Task<IActionResult>Put(Guid id, [FromBody] UserDto userDto)
        {
            return Ok();
        }
        [HttpPatch]
        public async Task<IActionResult>Patch(Guid id, string email)
        {
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult>Delete(Guid id)
        {
            return Ok();
        }
    }
}
