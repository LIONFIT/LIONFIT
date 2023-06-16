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
        private const string API_KEY = "c757288a3bmsh2bfcbcba76e87c3p16c5d8jsn5ac1593da03c";
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
        string jsonResponse = await response.Content.ReadAsStringAsync();
        var jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        var responseObject = JsonSerializer.Deserialize<JsonElement>(jsonResponse, jsonOptions);

        var results = responseObject.GetProperty("results");

        List<Alimento> alimentos = new List<Alimento>();

        foreach (var result in results.EnumerateArray())
        {
            Alimento alimento = new Alimento
            {
                Id = result.GetProperty("id").GetInt32(),
                Title = result.GetProperty("title").GetString(),
                Image = result.GetProperty("image").GetString(),
                ImageType = result.GetProperty("imageType").GetString()
            };

            alimentos.Add(alimento);
        }

        return alimentos;
    }
    else
    {
        throw new Exception("Error al obtener los datos de la API.");
    }
}
    }
    
}