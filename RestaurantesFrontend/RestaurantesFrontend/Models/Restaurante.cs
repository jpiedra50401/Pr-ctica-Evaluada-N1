using System.ComponentModel.DataAnnotations;

namespace RestaurantesFrontend.Models
{
    public class Restaurante
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Dueño { get; set; }

        [Required]
        public string Provincia { get; set; }

        [Required]
        public string Canton { get; set; }

        [Required]
        public string Distrito { get; set; }

        [Required]
        public string DireccionExacta { get; set; }
    }
}
