using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Supermercado.Modelo
{
    [Table("Impuestos")]
    public class Impuesto
    {
        public Impuesto()
        {
            lineaPedido = new HashSet<LineaPedido>();
        }
        [Key]
        public int impuestoId { get; set; }
        [Required(ErrorMessage = "El campo nombre no se puede estar vacío")]
        public string tipo { get; set; }

        public int procentaje { get; set; }

        public virtual ICollection<LineaPedido> lineaPedido { get; set; }
    }


}
