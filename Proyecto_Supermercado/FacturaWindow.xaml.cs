using Proyecto_Supermercado.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Proyecto_Supermercado
{
    /// <summary>
    /// Lógica de interacción para FacturaWindow.xaml
    /// </summary>
    public partial class FacturaWindow : Window
    {
        Empresa empresa = new Empresa();
        public FacturaWindow()
        {
            InitializeComponent();
            lineaPedidosDataGrid.ItemsSource = MainWindow.pedido.lineaPedido;
            impuestoLabel.Content = "Impuesto: " + MainWindow.tipoImpuestoCliente;
            totalLabel.Content = "Total: " + MainWindow.totalFinal.ToString().Replace('.', ',') + "€";
            clienteLabel.Content = "Cliente: " + MainWindow.nombreCompletoCliente;
            empleadoLabel.Content = "Empleado: " + MainWindow.empleado.nombre + " " + MainWindow.empleado.apellidos;

            empresa = MainWindow.unidadTrabajo.RepositorioEmpresa.getGeneral().First();
            nombreLabel.Content = "Empresa: " + empresa.nombre;
            direccionCiudadLabel.Content = "Dirección: " + empresa.direccion + ", " + empresa.ciudad;
            telefonoEmailLabel.Content = "Teléfono: " + empresa.telefono + " E-mail: " + empresa.email;
            cifLabel.Content = "CIF: " + empresa.cif;

            fechaLabel.Content = "Fecha de hoy: " + MainWindow.pedido.fechaPedido.ToString("dd/MM/yyyy");

            devolucionTextBlock.Text = "Plazo para cambio o devolución, " + empresa.devolucion + " días desde la fecha del presente";
        }
    }
}
