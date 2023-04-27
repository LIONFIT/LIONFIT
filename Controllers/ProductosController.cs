using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LIONFIT.Models;
using LIONFIT.Data;

namespace LIONFIT.Controllers
{
   
    public class ProductosController : Controller
    {
        private readonly ILogger<ProductosController> _logger;

        private readonly ApplicationDbContext _dbcontext;

//aca inyectamos la dependencias de bd  para que el controller producto pueda usar la bd
        public ProductosController(ILogger<ProductosController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _dbcontext= context;
        }

        
        public IActionResult Index()
        {
           var productos= from o in _dbcontext.Dataproducto select o;
            return View(productos.ToList());
        }

    
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}