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
    
    public partial class Pedidos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pedidos()
        {
            this.LineaPedidos = new HashSet<LineaPedidos>();
        }
    
        public int pedidoId { get; set; }
        public decimal precio { get; set; }
        public System.DateTime fechaPedido { get; set; }
        public System.DateTime fechaEnvio { get; set; }
        public string hora { get; set; }
        public string cliente_dni { get; set; }
        public string empleado_dni { get; set; }
        public Nullable<int> empresa_empresaId { get; set; }
        public Nullable<int> pago_pagoId { get; set; }
    
        public virtual Clientes Clientes { get; set; }
        public virtual Empleados Empleados { get; set; }
        public virtual Empresa Empresa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LineaPedidos> LineaPedidos { get; set; }
        public virtual Pagos Pagos { get; set; }
    }
}