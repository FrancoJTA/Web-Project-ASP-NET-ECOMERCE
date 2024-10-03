using System.ComponentModel.DataAnnotations;

namespace EComerce.Data;

public class Rol
{
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [Required]
        public int Rango { get; set; }

        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();
}