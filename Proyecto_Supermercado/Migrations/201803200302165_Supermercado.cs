namespace Proyecto_Supermercado.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Supermercado : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        categoriaId = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.categoriaId);
            
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        productoId = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false),
                        descripcion = c.String(),
                        precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        stock = c.Int(nullable: false),
                        imagen = c.String(),
                        categoria_categoriaId = c.Int(),
                        proveedor_cif = c.String(maxLength: 9),
                    })
                .PrimaryKey(t => t.productoId)
                .ForeignKey("dbo.Categorias", t => t.categoria_categoriaId)
                .ForeignKey("dbo.Proveedores", t => t.proveedor_cif)
                .Index(t => t.categoria_categoriaId)
                .Index(t => t.proveedor_cif);
            
            CreateTable(
                "dbo.LineaPedidos",
                c => new
                    {
                        lineaPedidoId = c.Int(nullable: false, identity: true),
                        cantidad = c.Int(nullable: false),
                        impuesto_impuestoId = c.Int(),
                        pedido_pedidoId = c.Int(),
                        producto_productoId = c.Int(),
                    })
                .PrimaryKey(t => t.lineaPedidoId)
                .ForeignKey("dbo.Impuestos", t => t.impuesto_impuestoId)
                .ForeignKey("dbo.Pedidos", t => t.pedido_pedidoId)
                .ForeignKey("dbo.Productos", t => t.producto_productoId)
                .Index(t => t.impuesto_impuestoId)
                .Index(t => t.pedido_pedidoId)
                .Index(t => t.producto_productoId);
            
            CreateTable(
                "dbo.Impuestos",
                c => new
                    {
                        impuestoId = c.Int(nullable: false, identity: true),
                        tipo = c.String(nullable: false),
                        procentaje = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.impuestoId);
            
            CreateTable(
                "dbo.Pedidos",
                c => new
                    {
                        pedidoId = c.Int(nullable: false, identity: true),
                        precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        fechaPedido = c.DateTime(nullable: false),
                        fechaEnvio = c.DateTime(nullable: false),
                        hora = c.String(nullable: false),
                        cliente_dni = c.String(maxLength: 9),
                        empleado_dni = c.String(maxLength: 9),
                        empresa_empresaId = c.Int(),
                        pago_pagoId = c.Int(),
                    })
                .PrimaryKey(t => t.pedidoId)
                .ForeignKey("dbo.Clientes", t => t.cliente_dni)
                .ForeignKey("dbo.Empleados", t => t.empleado_dni)
                .ForeignKey("dbo.Empresa", t => t.empresa_empresaId)
                .ForeignKey("dbo.Pagos", t => t.pago_pagoId)
                .Index(t => t.cliente_dni)
                .Index(t => t.empleado_dni)
                .Index(t => t.empresa_empresaId)
                .Index(t => t.pago_pagoId);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        dni = c.String(nullable: false, maxLength: 9),
                        nombre = c.String(nullable: false),
                        apellidos = c.String(nullable: false),
                        direccion = c.String(nullable: false),
                        ciudad = c.String(nullable: false),
                        telefono = c.String(),
                        email = c.String(),
                    })
                .PrimaryKey(t => t.dni);
            
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        dni = c.String(nullable: false, maxLength: 9),
                        nombre = c.String(nullable: false),
                        apellidos = c.String(nullable: false),
                        usuario = c.String(nullable: false),
                        contrasena = c.String(nullable: false),
                        tipoCuenta = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.dni);
            
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        empresaId = c.Int(nullable: false, identity: true),
                        cif = c.String(nullable: false),
                        nombre = c.String(nullable: false),
                        direccion = c.String(nullable: false),
                        ciudad = c.String(nullable: false),
                        telefono = c.String(),
                        email = c.String(),
                        devolucion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.empresaId);
            
            CreateTable(
                "dbo.Pagos",
                c => new
                    {
                        pagoId = c.Int(nullable: false, identity: true),
                        tipo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.pagoId);
            
            CreateTable(
                "dbo.Proveedores",
                c => new
                    {
                        cif = c.String(nullable: false, maxLength: 9),
                        nombre = c.String(nullable: false),
                        direccion = c.String(nullable: false),
                        ciudad = c.String(nullable: false),
                        telefono = c.String(),
                        persona = c.String(),
                    })
                .PrimaryKey(t => t.cif);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productos", "proveedor_cif", "dbo.Proveedores");
            DropForeignKey("dbo.LineaPedidos", "producto_productoId", "dbo.Productos");
            DropForeignKey("dbo.Pedidos", "pago_pagoId", "dbo.Pagos");
            DropForeignKey("dbo.LineaPedidos", "pedido_pedidoId", "dbo.Pedidos");
            DropForeignKey("dbo.Pedidos", "empresa_empresaId", "dbo.Empresa");
            DropForeignKey("dbo.Pedidos", "empleado_dni", "dbo.Empleados");
            DropForeignKey("dbo.Pedidos", "cliente_dni", "dbo.Clientes");
            DropForeignKey("dbo.LineaPedidos", "impuesto_impuestoId", "dbo.Impuestos");
            DropForeignKey("dbo.Productos", "categoria_categoriaId", "dbo.Categorias");
            DropIndex("dbo.Pedidos", new[] { "pago_pagoId" });
            DropIndex("dbo.Pedidos", new[] { "empresa_empresaId" });
            DropIndex("dbo.Pedidos", new[] { "empleado_dni" });
            DropIndex("dbo.Pedidos", new[] { "cliente_dni" });
            DropIndex("dbo.LineaPedidos", new[] { "producto_productoId" });
            DropIndex("dbo.LineaPedidos", new[] { "pedido_pedidoId" });
            DropIndex("dbo.LineaPedidos", new[] { "impuesto_impuestoId" });
            DropIndex("dbo.Productos", new[] { "proveedor_cif" });
            DropIndex("dbo.Productos", new[] { "categoria_categoriaId" });
            DropTable("dbo.Proveedores");
            DropTable("dbo.Pagos");
            DropTable("dbo.Empresa");
            DropTable("dbo.Empleados");
            DropTable("dbo.Clientes");
            DropTable("dbo.Pedidos");
            DropTable("dbo.Impuestos");
            DropTable("dbo.LineaPedidos");
            DropTable("dbo.Productos");
            DropTable("dbo.Categorias");
        }
    }
}
