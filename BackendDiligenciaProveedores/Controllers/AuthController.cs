using BackendDiligenciaProveedores.Models;
using BackendDiligenciaProveedores.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendDiligenciaProveedores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly BddiligenciaProvContext _baseDatos;
        private readonly IUserService _userService;

        public AuthController(BddiligenciaProvContext baseDatos, IUserService userService)
        {
            _baseDatos = baseDatos;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Autenticar([FromBody] UserRequest request)
        {
            var tokenCreado = await _userService.Autenticar(request);

            if (tokenCreado == null)
            {
                return BadRequest("Credenciales Incorrectas");
            }

            return Ok(new { token = tokenCreado });
        }
    }
}
