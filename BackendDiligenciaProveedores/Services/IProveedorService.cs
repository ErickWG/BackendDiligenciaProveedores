using BackendDiligenciaProveedores.Models;

namespace BackendDiligenciaProveedores.Services
{
    public interface IProveedorService
    {
        IEnumerable<Proveedor> ObtenerTodos();
        Proveedor ObtenerPorId(int id);
        void CrearProveedor(Proveedor proveedor);
        void ActualizarProveedor(int id, Proveedor proveedor);
        void EliminarProveedor(int id);
    }
}
