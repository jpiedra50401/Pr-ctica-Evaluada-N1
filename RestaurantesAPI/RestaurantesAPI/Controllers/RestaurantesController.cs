using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantesAPI.Data;
using RestaurantesAPI.Models;

namespace RestaurantesAPI.Controllers
{
    [Route("api/restaurantes")]
    [ApiController]
    public class RestaurantesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RestaurantesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/restaurantes → Listar restaurantes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurante>>> GetRestaurantes()
        {
            try
            {
                return await _context.Restaurantes.ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al obtener restaurantes", details = ex.Message });
            }
        }


        // POST: api/restaurantes → Agregar un restaurante
        [HttpPost]
        public async Task<ActionResult<Restaurante>> PostRestaurante([FromBody] Restaurante restaurante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Restaurantes.Add(restaurante);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRestaurantes), new { id = restaurante.Id }, restaurante);
        }


        // DELETE: api/restaurantes/{id} → Eliminar un restaurante
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurante(int id)
        {
            try
            {
                var restaurante = await _context.Restaurantes.FindAsync(id);
                if (restaurante == null)
                {
                    return NotFound(new { message = "Restaurante no encontrado" });
                }

                _context.Restaurantes.Remove(restaurante);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Restaurante eliminado con éxito" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al eliminar restaurante", details = ex.Message });
            }
        }
    }
}
