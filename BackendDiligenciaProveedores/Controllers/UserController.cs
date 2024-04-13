using BackendDiligenciaProveedores.Models;
using BackendDiligenciaProveedores.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackendPruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly BddiligenciaProvContext _baseDatos;
        private readonly IUserService _userService;

        public UsuarioController(BddiligenciaProvContext baseDatos, IUserService userService)
        {
            _baseDatos = baseDatos;
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsuarioes()
        {
            var Usuarioes = _userService.ObtenerTodos();
            return Ok(Usuarioes);
        }
        [HttpGet("{id}")]
        public ActionResult<User> GetUsuario(int id)
        {
            var Usuario = _userService.ObtenerPorId(id);
            if (Usuario == null)
            {
                return NotFound();
            }
            return Ok(Usuario);
        }

        [HttpPost]
        public ActionResult<User> PostUsuario(User Usuario)
        {
            _userService.CrearUsuario(Usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = Usuario.UsuarioId }, Usuario);
        }

        [HttpPut("{id}")]
        public ActionResult<User> PutUsuario(int id, User Usuario)
        {
            _userService.ActualizarUsuario(id, Usuario);
            return CreatedAtAction(nameof(GetUsuario), new { id = Usuario.UsuarioId }, Usuario);
        }

        [HttpDelete("{id}")]
        public ActionResult<User> DeleteUsuario(int id)
        {
            _userService.EliminarUsuario(id);
            return Ok();
        }
    }
}
