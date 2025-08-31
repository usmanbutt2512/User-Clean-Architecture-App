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

        [HttpGet("{id:guid}")]//get user by ID
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await userService.GetUserByIdAsync(id);
            return user != null ? Ok(user) : NotFound();     
        }
        [HttpPost]//create a new user
        public async Task<IActionResult>Post([FromBody] UserCreateUpdateDto dto)
        {
            var user = await userService.CreateUserAsync(dto);
            return Ok(user);
        }
        [HttpPut("{id:guid}")]//update the full user
        public async Task<IActionResult>Update(Guid id, [FromBody] UserCreateUpdateDto dto)
        {
            var user = await userService.UpdateUserAsync(id, dto);
            return user!=null?Ok(user):NotFound() ;
        }
        [HttpPatch]//update only the email
        public async Task<IActionResult>PatchEmail(Guid id, [FromBody] UserEmailUpdateDto dto)
        {
            var user = await userService.UpdateUserEmail(id, dto);
            return user != null? Ok(user) : NotFound();            
        }
        [HttpDelete]//delete user by ID
        public async Task<IActionResult>Delete(Guid id)
        {
            var delete = await userService.DeleteUserAsync(id);
            return delete ? Ok() : NotFound();
        }
    }
}
