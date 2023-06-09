using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LIONFIT.Data;
using LIONFIT.Models;
using LIONFIT.Service;

namespace LIONFIT.Controllers
{
    public class ProductoController : Controller
    {

        private readonly ProductoService _productoService;


        public ProductoController(ProductoService productoService)
        {

            _productoService = productoService;
        }

        // GET: Producto
       [HttpGet]
        [Route("/Producto/")]
        public async Task<IActionResult> Index()
        {

            var productos = await _productoService.GetAll();
            return productos != null ?
                View(productos) :
                  Problem("Entity set 'ApplicationDbContext.Dataproducto'  is null.");

        }

        // GET: Producto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = _productoService.FirstOrDefault(id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Producto/Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomProducto,Precio,DesProducto,Imagen,Status")] Producto producto)
        {
            if (ModelState.IsValid)
            {

                await _productoService.Create_Update(producto);
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Producto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var producto = await _productoService.Get(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Producto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomProducto,Precio,DesProducto,Imagen,Status")] Producto producto)
        {
            if (id != producto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _productoService.Create_Update(producto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_productoService.ProductoExists(producto.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Producto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var producto = await _productoService.Get(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productoService.Delete(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
