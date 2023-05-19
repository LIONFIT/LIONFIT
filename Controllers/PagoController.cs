using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using LIONFIT.Data;
using LIONFIT.Models;
using Microsoft.EntityFrameworkCore;

namespace LIONFIT.Controllers

{
    [Route("[controller]")]
    public class PagoController : Controller
    {
        private readonly ILogger<PagoController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;

        public PagoController(ILogger<PagoController> logger, UserManager<IdentityUser> userManager, ApplicationDbContext context)
        {
            _logger = logger;
             _userManager = userManager;
            _context = context;
        }

      
        [Route("Create")]
       public IActionResult Create(Decimal monto)
        {

            Pago pago = new Pago();
            pago.UserId = _userManager.GetUserName(User);
            pago.MontoTotal = monto;
            return View(pago);
        }

         [HttpPost]
         [Route("Create/Pagar")]
        public IActionResult Pagar(Pago pago)
        {
            pago.PaymenDate = DateTime.UtcNow;
            _context.Add(pago);
            
            var itemsBoleta = from o in _context.Databoleta select o;
            itemsBoleta = itemsBoleta.
                Include(p => p.Producto).
                Where(s => s.UserID.Equals(pago.UserId) && s.Status.Equals("PENDIENTE"));

            Pedido pedido = new Pedido();
            pedido.UserID = pago.UserId;
            pedido.Total = pago.MontoTotal;
            pedido.pago = pago;
            pedido.Status = "PENDIENTE";
            _context.Add(pedido);

            List<DetallePedido> itemsPedido = new List<DetallePedido>();
            foreach(var item in itemsBoleta.ToList()){
                DetallePedido detallePedido = new DetallePedido();
                detallePedido.pedido=pedido;
                detallePedido.Precio = item.Precio;
                detallePedido.Producto = item.Producto;
                detallePedido.Cantidad = item.Cantidad;
                itemsPedido.Add(detallePedido);
            }


            _context.AddRange(itemsPedido);

            foreach (Boleta p in itemsBoleta.ToList())
            {
                p.Status="PROCESADO";
            }

            _context.UpdateRange(itemsBoleta);

            _context.SaveChanges();

            ViewData["Message"] = "El pago se ha registrado y su pedido nro "+ pedido.ID +" esta en camino";
            return View("Create");
        }

    
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}