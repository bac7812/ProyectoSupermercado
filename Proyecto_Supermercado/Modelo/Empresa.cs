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
    [Table("Empresa")]
    public class Empresa
    {
        public Empresa()
        {
            pedido = new HashSet<Pedido>();
        }
        [Key]
        public int empresaId { get; set; }
        [Required(ErrorMessage = "El campo CIF no se puede estar vacío")]
        public string cif { get; set; }
        [Required(ErrorMessage = "El campo nombre no se puede estar vacío")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "El campo dirección no se puede estar vacío")]
        public string direccion { get; set; }
        [Required(ErrorMessage = "El campo ciudad no se puede estar vacío")]
        public string ciudad { get; set; }
        [Phone(ErrorMessage = "El campo télefono de contacto no es número de télefono válido")]
        [DisplayName("Teléfono")]
        public string telefono { get; set; }
        [EmailAddress]
        [DisplayName("E-mail")]
        public string email { get; set; }
        [Required(ErrorMessage = "El campo devolución no se puede estar vacío")]
        public int devolucion { get; set; }
        public virtual ICollection<Pedido> pedido { get; set; }
    }
}
