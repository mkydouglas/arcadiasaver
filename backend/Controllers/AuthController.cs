using System.Threading.Tasks;
using backend.Data;
using backend.Dtos.Player;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        public AuthController(IAuthRepository authRepo)
        {
            this._authRepo = authRepo;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(PlayerRegisterDto request)
        {
            ServiceResponse<int> response = await _authRepo.Register(
                new Player { Login = request.Login }, request.Password);
            if(!response.Success) {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(PlayerLoginDto request)
        {
            ServiceResponse<string> response = await _authRepo.Login(
                request.Login, request.Password);
            if(!response.Success) {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}