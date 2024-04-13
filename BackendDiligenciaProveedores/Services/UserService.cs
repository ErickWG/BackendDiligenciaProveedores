using BackendDiligenciaProveedores.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BackendDiligenciaProveedores.Services
{
    public class UserService : IUserService
    {
        private readonly BddiligenciaProvContext _baseDatos;
        private readonly string secretKey;

        public UserService(BddiligenciaProvContext baseDatos, IConfiguration config)
        {
            _baseDatos = baseDatos;
            secretKey = config.GetSection("settings").GetSection("secretkey").ToString();
        }

        public async Task<string> Autenticar(UserRequest request)
        {
            var usuarios = await _baseDatos.Users.ToListAsync();
            User usuario = usuarios.Where(x => x.Usuario == request.Usuario && x.Contrasenia == request.Contrasenia).FirstOrDefault();
            if (usuario == null)
            {
                return null; ;
            }
            var keyBytes = Encoding.ASCII.GetBytes(secretKey);
            var claims = new ClaimsIdentity();

            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, usuario.Usuario));
            claims.AddClaim(new Claim(ClaimTypes.Role, usuario.Rol));


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);

            string tokenCreado = tokenHandler.WriteToken(tokenConfig);
            return tokenCreado;

        }

        public IEnumerable<User> ObtenerTodos()
        {
            return _baseDatos.Users.ToList();

        }

        public User ObtenerPorId(int id)
        {
            return _baseDatos.Users.Find(id);
        }
        public void CrearUsuario(User Usuario)
        {
            _baseDatos.Users.Add(Usuario);
            _baseDatos.SaveChanges();
        }

        public void ActualizarUsuario(int id, User Usuario)
        {
            var UsuarioExistente = _baseDatos.Users.Find(id);
            if (UsuarioExistente != null)
            {
                // Realiza la actualización de los campos según tus necesidades
                UsuarioExistente.Usuario = Usuario.Usuario;
                UsuarioExistente.Contrasenia = Usuario.Contrasenia;
                //agregar los campos que faltan
                // Actualiza los demás campos...

                _baseDatos.SaveChanges();
            }
        }


        public void EliminarUsuario(int id)
        {
            var Usuario = _baseDatos.Users.Find(id);
            if (Usuario != null)
            {
                _baseDatos.Users.Remove(Usuario);
                _baseDatos.SaveChanges();
            }
        }
    }
}
