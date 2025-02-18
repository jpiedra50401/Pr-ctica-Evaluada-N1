using System.ComponentModel.DataAnnotations;

namespace RestaurantesAPI.Models
{
    public class Restaurante
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El dueño es obligatorio")]
        [StringLength(100)]
        public string Dueño { get; set; }

        [Required(ErrorMessage = "La provincia es obligatoria")]
        public string Provincia { get; set; }

        [Required(ErrorMessage = "El cantón es obligatorio")]
        public string Canton { get; set; }

        [Required(ErrorMessage = "El distrito es obligatorio")]
        public string Distrito { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        [StringLength(300)]
        public string DireccionExacta { get; set; }
    }
}
