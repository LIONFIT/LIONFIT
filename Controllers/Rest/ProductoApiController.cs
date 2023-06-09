using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LIONFIT.Service;
using LIONFIT.Models;

namespace LIONFIT.Controllers.Rest
{
    [ApiController]
    [Route("api/'producto'")]
    public class ProductoApiController : ControllerBase
    {
        private readonly ProductoService _productoService;


        public ProductoApiController(ProductoService productoService)
        {

            _productoService = productoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> ListProductos()
        {

            var producto = await _productoService.GetAll();
            if (producto == null)
                return NotFound();
            return Ok(producto);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int? id)
        {

            var producto = await _productoService.Get(id);
            if (producto == null)
                return NotFound();

            return Ok(producto);
        }


        [HttpPost("{id}")]
        public async Task<ActionResult<Producto>> CreateProducto([FromBody] Producto producto)
        {

            if (producto == null)
            {
                return BadRequest();

            }
            await _productoService.Create_Update(producto);
            return Ok(producto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Producto>> DeleteProducto(int? id)
        {
            await _productoService.Delete(id);
            return Ok();

        }


    }
}