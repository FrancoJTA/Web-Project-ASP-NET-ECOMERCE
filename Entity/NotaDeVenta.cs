using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EComerce.Data;

public class NotaDeVenta
{
    [Key]
    public int Id { get; set; }

    [ForeignKey("Usuario")]
    public int ClienteId { get; set; }

    public Usuario Cliente { get; set; }

    [Required]
    public DateTime FechaNotaDeVenta { get; set; }

    [Required]
    public decimal TotalNotaDeVenta { get; set; }

    public List<DetalleNotaDeVenta> Detalles { get; set; } = new List<DetalleNotaDeVenta>();
}