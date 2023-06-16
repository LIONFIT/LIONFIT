using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LIONFIT.Models;
using LIONFIT.Integration.Food;

namespace LIONFIT.Controllers
{
    [Route("[controller]")]
    public class FoodController : Controller
    {
        private readonly ILogger<FoodController> _logger;
        private readonly FoodIntegration _food ;

        public FoodController(ILogger<FoodController> logger, FoodIntegration food)
    {
        _logger = logger;
        _food = food;
    }

    [HttpGet("")]
public async Task<IActionResult> Index(string search)
{
    try
    {
        var alimentos = await _food.GetAlimentosAsync();
        var dataComidas = new List<Alimento>();

        if (alimentos != null && alimentos.Count > 0)
        {
            if (string.IsNullOrEmpty(search))
            {
                dataComidas = alimentos;
            }
            else
            {
                dataComidas = alimentos.Where(p => p.Title.ToLower().Contains(search.ToLower())).ToList();
            }
        }

        ViewData["Search"] = search;
        return View("~/Views/Food/Index.cshtml", dataComidas);
    }
    catch (Exception ex)
    {
        // Manejar la excepción adecuadamente, por ejemplo, mostrar un mensaje de error en la vista
        ViewBag.ErrorMessage = $"Error al obtener los datos de la API: {ex.Message}";
        return View("Error");
    }
}

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [HttpGet("error")]
    public IActionResult Error()
    {
        return View("Error!");
    }

    }
}