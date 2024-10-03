using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EComerce.Data;

public class CarritoVenta
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Usuario")]
    public int ClienteId { get; set; }

    public Usuario Cliente { get; set; }

    [Required]
    public DateTime FechaCarrito { get; set; }

    [Required]
    public decimal TotalCarrito { get; set; }

    public List<DetalleCarritoVenta> Detalles { get; set; } = new List<DetalleCarritoVenta>();
}