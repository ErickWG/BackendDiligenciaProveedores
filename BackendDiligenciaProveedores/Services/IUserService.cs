using BackendDiligenciaProveedores.Models;

namespace BackendDiligenciaProveedores.Services
{
    public interface IUserService
    {
        Task<string> Autenticar(UserRequest request);
        IEnumerable<User> ObtenerTodos();
        User ObtenerPorId(int id);
        void CrearUsuario(User Usuario);
        void ActualizarUsuario(int id, User Usuario);
        void EliminarUsuario(int id);
    }
}
