using System.ComponentModel.DataAnnotations;

namespace RestaurantesAPI.Models
{
    public class Restaurante
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del restaurante es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede tener más de 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El nombre del dueño es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del dueño no puede tener más de 100 caracteres.")]
        public string Dueño { get; set; }

        [Required(ErrorMessage = "La provincia es obligatoria.")]
        public string Provincia { get; set; }

        [Required(ErrorMessage = "El cantón es obligatorio.")]
        public string Canton { get; set; }

        [Required(ErrorMessage = "El distrito es obligatorio.")]
        public string Distrito { get; set; }

        [Required(ErrorMessage = "La dirección exacta es obligatoria.")]
        [StringLength(255, ErrorMessage = "La dirección no puede tener más de 255 caracteres.")]
        public string DireccionExacta { get; set; }
    }
}
