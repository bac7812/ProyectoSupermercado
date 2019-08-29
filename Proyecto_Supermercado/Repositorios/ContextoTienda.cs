using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Proyecto_Supermercado.Modelo;
using Proyecto_Supermercado.Migrations;

namespace Proyecto_Supermercado.Repositorios
{
    public class ContextoSupermercado : DbContext 
    {
        public ContextoSupermercado() : base("SupermercadoEntities")
        {
            if (Database.Exists())
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<ContextoSupermercado, Configuration>());
            }
            else
            {
                Database.SetInitializer(new createdb());
            }
        }

        class createdb : CreateDatabaseIfNotExists<ContextoSupermercado>
        {
            protected override void Seed(ContextoSupermercado context)
            {
                context.empleados.Add(
                  new Empleado
                  {
                      dni = "00000000A",
                      nombre = "Super",
                      apellidos = "Administrador",
                      usuario = "admin",
                      contrasena = "admin",
                      tipoCuenta = "Administrador"
                  }
                  );
            }
        }


        public DbSet<Empleado> empleados { get; set; }
        public DbSet<Proveedor> proveedores { get; set; }
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Producto> productos { get; set; }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Pedido> pedidos { get; set; }
        public DbSet<LineaPedido> lineasPedidos { get; set; }
        public DbSet<Pago> pago { get; set; }
        public DbSet<Impuesto> impuesto { get; set; }
        public DbSet<Empresa> empresa { get; set; }
        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            base.OnModelCreating(dbModelBuilder);
        }
    }
}
