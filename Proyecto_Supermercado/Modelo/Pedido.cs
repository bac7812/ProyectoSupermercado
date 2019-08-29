using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Supermercado.Modelo
{
    [Table("Pedidos")]
    public class Pedido : PropiedadValidarModelo
    {
        public Pedido()
        {
            lineaPedido = new HashSet<LineaPedido>();
        }
        [Key]
        public int pedidoId { get; set; }
        [Required(ErrorMessage = "El campo precio no se puede estar vacío")]
        [Range(0.01, 999999999, ErrorMessage = "El precio debe ser mayor que 0.00")]
        [DisplayName("Precio")]
        public decimal precio { get; set; }
        [Required(ErrorMessage = "El campo fecha no se puede estar vacío")]
        [DataType(DataType.Date, ErrorMessage = "Fecha no es valido")]
        [DisplayName("Fecha")]
        public DateTime fechaPedido { get; set; }
        [Required(ErrorMessage = "El campo fecha no se puede estar vacío")]
        [DataType(DataType.Date, ErrorMessage = "Fecha no es valido")]
        [DisplayName("Fecha")]
        public DateTime fechaEnvio { get; set; }
        [Required(ErrorMessage = "El campo hora no se puede estar vacío")]
        public string hora { get; set; }
        public virtual Empleado empleado { get; set; }
        public virtual Cliente cliente { get; set; }
        public virtual Empresa empresa { get; set; }
        public virtual Pago pago { get; set; }
        public virtual ICollection<LineaPedido> lineaPedido { get; set; }
    }
}
