using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EComerce.Data;

public class ProductosCaracteristicas
{
    [Key]
    public int Id { get; set; }

    public string Color { get; set; }

    public string Talla { get; set; }

    public string Tipo { get; set; }

    [ForeignKey("Producto")]
    public int ProductoId { get; set; }

    public Producto Producto { get; set; }
}