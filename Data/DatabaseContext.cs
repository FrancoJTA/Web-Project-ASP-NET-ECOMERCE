using Microsoft.EntityFrameworkCore;

namespace EComerce.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la tabla roles
            modelBuilder.Entity<Rol>(e =>
            {
                e.Property(p => p.Nombre)
                    .HasMaxLength(50)
                    .IsRequired();

                e.Property(p => p.Rango)
                    .IsRequired();
            });

            // Configuración de la tabla usuario
            modelBuilder.Entity<Usuario>(e =>
            {
                e.Property(p => p.Nombre)
                    .HasMaxLength(50)
                    .IsRequired();

                e.Property(p => p.FechaRegistro)
                    .IsRequired();

                e.Property(p => p.Email)
                    .HasMaxLength(100)
                    .IsRequired();

                e.Property(p => p.Contrasena)
                    .HasMaxLength(100)
                    .IsRequired();

                e.HasOne(u => u.Rol)
                    .WithMany(r => r.Usuarios)
                    .HasForeignKey(u => u.RolId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de la tabla categoria
            modelBuilder.Entity<Categoria>(e =>
            {
                e.Property(p => p.Nombre)
                    .HasMaxLength(50)
                    .IsRequired();

                e.Property(p => p.Descripcion)
                    .HasMaxLength(100)
                    .IsRequired(false);
            });

            // Configuración de la tabla productos
            modelBuilder.Entity<Producto>(e =>
            {
                e.Property(p => p.Nombre)
                    .HasMaxLength(50)
                    .IsRequired();

                e.Property(p => p.Genero)
                    .HasMaxLength(50)
                    .IsRequired(false);

                e.Property(p => p.Descripcion)
                    .HasMaxLength(100)
                    .IsRequired(false);

                e.Property(p => p.Precio)
                    .HasColumnType("decimal(10, 2)")
                    .IsRequired();

                e.Property(p => p.Stock)
                    .IsRequired();

                e.HasOne(p => p.Categoria)
                    .WithMany(c => c.Productos)
                    .HasForeignKey(p => p.CategoriaId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de la tabla productos_caracteristicas
            modelBuilder.Entity<ProductosCaracteristicas>(e =>
            {
                e.Property(p => p.Color)
                    .HasMaxLength(50)
                    .IsRequired(false);

                e.Property(p => p.Talla)
                    .HasMaxLength(10)
                    .IsRequired(false);

                e.Property(p => p.Tipo)
                    .HasMaxLength(50)
                    .IsRequired(false);

                e.HasOne(pc => pc.Producto)
                    .WithMany(p => p.Caracteristicas)
                    .HasForeignKey(pc => pc.ProductoId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuración de la tabla nota_de_venta
            modelBuilder.Entity<NotaDeVenta>(e =>
            {
                e.Property(p => p.FechaNotaDeVenta)
                    .IsRequired();

                e.Property(p => p.TotalNotaDeVenta)
                    .HasColumnType("decimal(10, 2)")
                    .IsRequired();

                e.HasOne(nv => nv.Cliente)
                    .WithMany(u => u.NotasDeVenta)
                    .HasForeignKey(nv => nv.ClienteId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de la tabla detalle_nota_de_venta
            modelBuilder.Entity<DetalleNotaDeVenta>(e =>
            {
                e.Property(p => p.Cantidad)
                    .IsRequired();

                e.Property(p => p.PrecioUnitario)
                    .HasColumnType("decimal(10, 2)")
                    .IsRequired();

                e.Property(p => p.Subtotal)
                    .HasComputedColumnSql("[Cantidad] * [PrecioUnitario]");

                e.HasOne(dnv => dnv.NotaDeVenta)
                    .WithMany(nv => nv.Detalles)
                    .HasForeignKey(dnv => dnv.NotaDeVentaId)
                    .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(dnv => dnv.Producto)
                    .WithMany(p => p.DetallesNotaDeVenta)
                    .HasForeignKey(dnv => dnv.ProductoId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de la tabla carrito_venta
            modelBuilder.Entity<CarritoVenta>(e =>
            {
                e.Property(p => p.FechaCarrito)
                    .IsRequired();

                e.Property(p => p.TotalCarrito)
                    .HasColumnType("decimal(10, 2)")
                    .IsRequired();

                e.HasOne(cv => cv.Cliente)
                    .WithMany(u => u.Carritos)
                    .HasForeignKey(cv => cv.ClienteId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuración de la tabla detalle_carrito_venta
            modelBuilder.Entity<DetalleCarritoVenta>(e =>
            {
                e.Property(p => p.Cantidad)
                    .IsRequired();

                e.Property(p => p.PrecioUnitario)
                    .HasColumnType("decimal(10, 2)")
                    .IsRequired();

                e.Property(p => p.Subtotal)
                    .HasComputedColumnSql("[Cantidad] * [PrecioUnitario]");

                e.HasOne(dcv => dcv.CarritoVenta)
                    .WithMany(cv => cv.Detalles)
                    .HasForeignKey(dcv => dcv.CarritoId)
                    .OnDelete(DeleteBehavior.Cascade);

                e.HasOne(dcv => dcv.Producto)
                    .WithMany(p => p.DetallesCarritoDeVenta)
                    .HasForeignKey(dcv => dcv.ProductoId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
