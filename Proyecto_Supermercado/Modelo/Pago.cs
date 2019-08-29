using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Supermercado.Modelo
{
    [Table("Pagos")]
    public class Pago
    {
        public Pago()
        {
            pedido = new HashSet<Pedido>();
        }
        [Key]
        public int pagoId { get; set; }
        [Required(ErrorMessage = "El campo tipo no se puede estar vacío")]
        public string tipo { get; set; }
        public virtual ICollection<Pedido> pedido { get; set; }
    }
}
