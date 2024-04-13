using BackendDiligenciaProveedores.Models;
using BackendDiligenciaProveedores.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendDiligenciaProveedores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService _proveedorService;

        public ProveedorController(IProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Proveedor>> GetProveedores()
        {
            var proveedores = _proveedorService.ObtenerTodos();
            return Ok(proveedores);
        }

        [HttpGet("{id}")]
        public ActionResult<Proveedor> GetProveedor(int id)
        {
            var proveedor = _proveedorService.ObtenerPorId(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return Ok(proveedor);
        }

        [HttpPost]
        public ActionResult<Proveedor> PostProveedor(Proveedor proveedor)
        {
            _proveedorService.CrearProveedor(proveedor);
            return CreatedAtAction(nameof(GetProveedor), new { id = proveedor.ProveedorId }, proveedor);
        }

        [HttpPut("{id}")]
        public ActionResult<Proveedor> PutProveedor(int id, Proveedor proveedor)
        {
            _proveedorService.ActualizarProveedor(id, proveedor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<Proveedor> DeleteProveedor(int id)
        {
            _proveedorService.EliminarProveedor(id);
            return Ok();
        }
    }
}

