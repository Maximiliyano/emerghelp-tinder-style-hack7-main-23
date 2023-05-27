using Microsoft.AspNetCore.Mvc;
using VolonteerHelper.Api.BaseEntity;
using VolonteerHelper.Api.Services;

namespace VolonteerHelper.Api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : GlobalApiController
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}