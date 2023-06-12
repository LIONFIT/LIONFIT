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

        public FoodController(ILogger<FoodController> logger,FoodIntegration food){
            _logger=logger;
            _food=food;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index(string search){

            var dataComidas  = await FetchApiData();

            if (!string.IsNullOrEmpty(search))
            {
                dataComidas = dataComidas.Where(p => p.Title.ToLower().Contains(search.ToLower())).ToList();
            }

            ViewData["Search"] = search;
            return View("~/Views/Food/Index.cshtml", dataComidas);
        }

        [HttpGet("FetchApi")]
        public async Task<List<Alimento>> FetchApiData(){
            var apiData = await _food.GetAlimentosAsync();
            return apiData;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet("error")]
        public IActionResult Error()
        {
            return View("Error!");
        }

    }
}