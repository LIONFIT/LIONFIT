using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Dynamic;
using LIONFIT.Data;
using LIONFIT.Models;
namespace LIONFIT.Controllers
{

    public class CarritoController : Controller
    {
        private readonly ILogger<CarritoController> _logger;
        private readonly ApplicationDbContext _dbcontext;
        private readonly UserManager<IdentityUser> _userManager;

        public CarritoController(ILogger<CarritoController> logger, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _dbcontext = context;
            _userManager = userManager;

        }

        public IActionResult Index()
        {
            var userIDSession = _userManager.GetUserName(User);

            //SELECT * FROM Proforma p,Producto pr WHERE p.productId=pr.Id And p.UserId=? And p.status='PENDIENTE' 
            var items = from o in _dbcontext.Databoleta select o;
            items = items.Include(p => p.Producto).
                    Where(w => w.UserID.Equals(userIDSession));
            var itemsCarrito = items.ToList();
            //Fila1 1234, Shampo; Precio, Cantidad
            //Fila2 12345, Shampo3; Precio, Cantidad
            var total = itemsCarrito.Sum(c => c.Cantidad * c.Precio);

            //MEMORIA
            dynamic model = new ExpandoObject();
            model.montoTotal = total;
            model.elementosCarrito = itemsCarrito;

            //Carrito carrito = new Carrito();
            //carrito.total = total;
            //carrito.itemsCarrito = itemsCarrito;

            //return View(carrito);
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            // Busca el producto por su Id
            var product = _dbcontext.Databoleta.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound(); // Si el producto no existe, retorna un error 404
            }

            _dbcontext.Databoleta.Remove(product); // Elimina el producto del contexto de datos
            _dbcontext.SaveChanges(); // Guarda los cambios en la base de datos

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Boleta = await _dbcontext.Databoleta.FindAsync(id);
            if (Boleta == null)
            {
                return NotFound();
            }
            return View(Boleta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cantidad,Precio,UserID")] Boleta boleta)
        {
            if (id != boleta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbcontext.Update(boleta);
                    await _dbcontext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_dbcontext.Databoleta.Any(e => e.Id == id))
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
            return View(boleta);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}