using System.ComponentModel.DataAnnotations;

namespace EComerce.Data;

public class Categoria
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Nombre { get; set; }

    public string Descripcion { get; set; }

    public List<Producto> Productos { get; set; } = new List<Producto>();
}