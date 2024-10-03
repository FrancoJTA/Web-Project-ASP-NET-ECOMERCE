using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EComerce.Data;

public class Producto
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Nombre { get; set; }

    public string Genero { get; set; }

    public string Descripcion { get; set; }

    [Required]
    public decimal Precio { get; set; }

    [Required]
    public int Stock { get; set; }

    [ForeignKey("Categoria")]
    public int CategoriaId { get; set; }

    public Categoria Categoria { get; set; }

    public List<ProductosCaracteristicas> Caracteristicas { get; set; } = new List<ProductosCaracteristicas>();
    public List<DetalleNotaDeVenta> DetallesNotaDeVenta { get; set; } = new List<DetalleNotaDeVenta>();
    public List<DetalleCarritoVenta> DetallesCarritoDeVenta { get; set; } = new List<DetalleCarritoVenta>();
}