using Microsoft.AspNetCore.Mvc;
using RestaurantesFrontend.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RestaurantesFrontend.Controllers
{
    public class RestaurantesController : Controller
    {
        private readonly HttpClient _httpClient;

        public RestaurantesController(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("RestaurantesAPI");
        }

        // GET: Restaurantes
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("");

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var json = await response.Content.ReadAsStringAsync();
            var restaurantes = JsonSerializer.Deserialize<List<Restaurante>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return View(restaurantes);
        }

        // POST: Agregar Restaurante
        [HttpPost]
        public async Task<IActionResult> Agregar(Restaurante restaurante)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var json = JsonSerializer.Serialize(restaurante);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("", content);

            return RedirectToAction("Index");
        }

        // POST: Eliminar Restaurante
        [HttpPost("Eliminar")]
        public async Task<IActionResult> Eliminar([FromForm] int id)
        {
            Console.WriteLine($"🟡 Enviando solicitud DELETE para el restaurante con ID: {id}");

            var response = await _httpClient.DeleteAsync($"https://localhost:7165/api/restaurantes/{id}");

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"🔴 Error al eliminar restaurante con ID: {id}, Código: {response.StatusCode}");
                return BadRequest($"No se pudo eliminar el restaurante con ID {id}.");
            }

            Console.WriteLine($"✅ Restaurante con ID {id} eliminado correctamente.");
            return RedirectToAction("Index");
        }


    }
}
