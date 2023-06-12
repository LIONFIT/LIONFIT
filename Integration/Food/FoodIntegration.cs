using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LIONFIT.Models;
using System.Text.Json;

namespace LIONFIT.Integration.Food
{
    public class FoodIntegration
    {
        public int Id { get; set; }

        private readonly ILogger<FoodIntegration> _logger;

         private const string API_URL = "https://spoonacular-recipe-food-nutrition-v1.p.rapidapi.com/recipes/complexSearch";
        private const string API_KEY = "231ad41d4cmsh0a8b886184382d6p1aed18jsn1c8e8cfe5e92";
        private const string API_HEADER_KEY = "X-RapidAPI-Key";

        private readonly HttpClient httpClient;

        public FoodIntegration(ILogger<FoodIntegration> logger){
            _logger=logger;
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add(API_HEADER_KEY,API_KEY);
        }

        public async Task<List<Alimento>> GetAlimentosAsync()
        {
            HttpResponseMessage response = await httpClient.GetAsync(API_URL);
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var jsonOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                List<Alimento> food = await JsonSerializer.DeserializeAsync<List<Alimento>>(responseStream, jsonOptions);
                return food;
            }
            else
            {
                throw new Exception("Error al obtener los datos de la API.");
            }
        }
    }
    
}