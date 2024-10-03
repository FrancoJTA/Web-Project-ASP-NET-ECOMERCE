using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EComerce.Data;

public class DetalleCarritoVenta
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int Cantidad { get; set; }

    [Required]
    public decimal PrecioUnitario { get; set; }

    // Subtotal calculado con setter privado
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal Subtotal { get; private set; }  // Setter privado

    [ForeignKey("CarritoVenta")]
    public int CarritoId { get; set; }

    public CarritoVenta CarritoVenta { get; set; }

    [ForeignKey("Producto")]
    public int ProductoId { get; set; }

    public Producto Producto { get; set; }
}