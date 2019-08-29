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
    [Table("Clientes")]
    public class Cliente : PropiedadValidarModelo
    {
        public Cliente()
        {
            pedidos = new HashSet<Pedido>();
        }
        [Key]
        [Required(ErrorMessage = "El campo DNI no se puede estar vacío")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "El campo DNI no es válido")]
        public string dni { get; set; }
        [Required(ErrorMessage = "El campo nombre no se puede estar vacío")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "El campo ápellidos no se puede estar vacío")]
        public string apellidos { get; set; }
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
        public virtual ICollection<Pedido> pedidos { get; set; }
    }
}
