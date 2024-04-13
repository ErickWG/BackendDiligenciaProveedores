using BackendDiligenciaProveedores.Models;

namespace BackendDiligenciaProveedores.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly BddiligenciaProvContext _baseDatos;

        public ProveedorService(BddiligenciaProvContext baseDatos)
        {
            _baseDatos = baseDatos;
        }

        public IEnumerable<Proveedor> ObtenerTodos()
        {
            return _baseDatos.Proveedores.ToList();
        }

        public Proveedor ObtenerPorId(int id)
        {
            return _baseDatos.Proveedores.Find(id);
        }

        public void CrearProveedor(Proveedor proveedor)
        {
            proveedor.FechaUltimaEdicion = null;
            _baseDatos.Proveedores.Add(proveedor);
            _baseDatos.SaveChanges();
        }

        public void ActualizarProveedor(int id, Proveedor proveedor)
        {
            var proveedorExistente = _baseDatos.Proveedores.Find(id);
            if (proveedorExistente != null)
            {
                // Realiza la actualización de los campos según tus necesidades
                proveedorExistente.RazonSocial = proveedor.RazonSocial;
                proveedorExistente.NombreComercial = proveedor.NombreComercial;
                proveedorExistente.IdentificacionTributaria = proveedor.IdentificacionTributaria;
                proveedorExistente.NumeroTelefonico = proveedor.NumeroTelefonico;
                proveedorExistente.CorreoElectronico = proveedor.CorreoElectronico;
                proveedorExistente.SitioWeb = proveedor.SitioWeb;
                proveedorExistente.DireccionFisica = proveedor.DireccionFisica;
                proveedorExistente.Pais= proveedor.Pais;
                proveedorExistente.FacturacionAnual = proveedor.FacturacionAnual;
                proveedorExistente.FechaUltimaEdicion = proveedor.FechaUltimaEdicion;

                _baseDatos.SaveChanges();
            }
        }

        public void EliminarProveedor(int id)
        {
            var proveedor = _baseDatos.Proveedores.Find(id);
            if (proveedor != null)
            {
                _baseDatos.Proveedores.Remove(proveedor);
                _baseDatos.SaveChanges();
            }
        }
    }
}
