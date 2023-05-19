using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using LIONFIT.Models;
using LIONFIT.Data;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Identity;

namespace LIONFIT.Controllers
{
   
    public class ProductosController : Controller
    {
        private readonly ILogger<ProductosController> _logger;
        private readonly ApplicationDbContext _dbcontext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IDistributedCache _cache;
//aca inyectamos la dependencias de bd  para que el controller producto pueda usar la bd
        public ProductosController(ILogger<ProductosController> logger,ApplicationDbContext context, UserManager<IdentityUser> userManager, IDistributedCache cache)
        {
            _logger = logger;
            _dbcontext= context;
            _cache = cache;
            _userManager= userManager;
        }

        
        public async Task<IActionResult> Index( string? searchString)
        {
           var productos = from o in _dbcontext.Dataproducto select o;
            //SELECT * FROM t_productos -> &
            if(!String.IsNullOrEmpty(searchString)){
                searchString=searchString.ToLower();
                productos = productos.Where(s => s.NomProducto.ToLower().Contains(searchString) && s.Status.Equals("activo") ) ; 
            }
            
            return View(await productos.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id){
            Producto objProduct = await _dbcontext.Dataproducto.FindAsync(id);
            if(objProduct == null){
                return NotFound();
            }
            return View(objProduct);
        }

        public async Task<IActionResult> Add(int? id){
            var userID = _userManager.GetUserName(User); //sesion
            if(userID == null){
                ViewData["Message"] = "Por favor debe loguearse antes de agregar un producto";
                List<Producto> productos = new List<Producto>();
                return  View("Index",productos);
            }else{
                var producto = await _dbcontext.Dataproducto.FindAsync(id);

                Boleta boleta = new Boleta();
                boleta.Producto = producto;
                boleta.Precio = producto.Precio; //precio del producto en ese momento
                boleta.Cantidad = 1;
                boleta.UserID = userID;
                _dbcontext.Add(boleta);
                await _dbcontext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

        }
    
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}