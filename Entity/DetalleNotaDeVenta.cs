using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EComerce.Data;

public class DetalleNotaDeVenta
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int Cantidad { get; set; }

    [Required]
    public decimal PrecioUnitario { get; set; }

    // Setter privado para Subtotal
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public decimal Subtotal { get; private set; }  // Setter privado

    [ForeignKey("NotaDeVenta")]
    public int NotaDeVentaId { get; set; }

    public NotaDeVenta NotaDeVenta { get; set; }

    [ForeignKey("Producto")]
    public int ProductoId { get; set; }

    public Producto Producto { get; set; }
}
