using Proyecto_Supermercado.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Supermercado.Repositorios
{
    public class RepositorioEmpleado : RepositorioGenerico<Empleado>
    {
        public RepositorioEmpleado(ContextoSupermercado contexto) : base(contexto)
        {

        }
    }
}
