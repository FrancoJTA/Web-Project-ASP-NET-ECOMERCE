using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EComerce.Data;

public class Usuario
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Nombre { get; set; }

    [Required]
    public DateTime FechaRegistro { get; set; }

    [Required]
    [EmailAddress]
    [StringLength(100)]
    public string Email { get; set; }

    [Required]
    [StringLength(100)]
    public string Contrasena { get; set; }

    [ForeignKey("Rol")]
    public int RolId { get; set; }

    public Rol Rol { get; set; }

    public string Direccion { get; set; }

    [StringLength(15)]
    public string Telefono { get; set; }

    public List<NotaDeVenta> NotasDeVenta { get; set; } = new List<NotaDeVenta>();
    public List<CarritoVenta> Carritos { get; set; } = new List<CarritoVenta>();
}