//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proyecto_Supermercado
{
    using System;
    using System.Collections.Generic;
    
    public partial class LineaPedidos
    {
        public int lineaPedidoId { get; set; }
        public int cantidad { get; set; }
        public Nullable<int> impuesto_impuestoId { get; set; }
        public Nullable<int> pedido_pedidoId { get; set; }
        public Nullable<int> producto_productoId { get; set; }
    
        public virtual Impuestos Impuestos { get; set; }
        public virtual Pedidos Pedidos { get; set; }
        public virtual Productos Productos { get; set; }
    }
}
