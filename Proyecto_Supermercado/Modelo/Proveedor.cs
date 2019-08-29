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
    [Table("Proveedores")]
    public class Proveedor : PropiedadValidarModelo
    {
        public Proveedor()
        {
            producto = new HashSet<Producto>();
        }
        [Key]
        [Required(ErrorMessage = "El campo CIF no se puede estar vacío")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "El campo CIF no es válido")]
        public string cif { get; set; }
        [Required(ErrorMessage = "El campo nombre no se puede estar vacío")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "El campo dirección no se puede estar vacío")]
        public string direccion { get; set; }
        [Required(ErrorMessage = "El campo ciudad no se puede estar vacío")]
        public string ciudad { get; set; }
        [Phone(ErrorMessage = "El campo teléfono de contacto no es número de télefono válido")]
        [DisplayName("Teléfono")]
        public string telefono { get; set; }
        public string persona { get; set; }
        public virtual ICollection<Producto> producto { get; set; }
    }
}
