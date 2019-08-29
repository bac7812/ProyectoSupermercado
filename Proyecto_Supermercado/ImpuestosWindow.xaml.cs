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
    /// Lógica de interacción para ImpuestosWindow.xaml
    /// </summary>
    public partial class ImpuestosWindow : Window
    {
        Label labelProcentaje;
        Label labelTotal;
        List<Impuesto> listaImpuestos = new List<Impuesto>();
        Impuesto impuesto = new Impuesto();
        MainWindow mainWindow = new MainWindow();
        public ImpuestosWindow(Label labelProcentaje, Label labelTotal)
        {
            InitializeComponent();
            this.labelProcentaje = labelProcentaje;
            this.labelTotal = labelTotal;
            listaImpuestos = MainWindow.unidadTrabajo.RepositorioImpuesto.getGeneral();
            consultarImpuestosDataGrid.ItemsSource = listaImpuestos.Select(i => new { i.tipo, i.procentaje });
        }

        private void consultarImpuestosDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (consultarImpuestosDataGrid.SelectedIndex != -1)
            {
                string tipoImpuesto = listaImpuestos[consultarImpuestosDataGrid.SelectedIndex].tipo;
                int procentaje = listaImpuestos[consultarImpuestosDataGrid.SelectedIndex].procentaje;
                labelProcentaje.Content = Convert.ToString(procentaje) + "%";
                MainWindow.impuesto = MainWindow.unidadTrabajo.RepositorioImpuesto.singular(i => i.tipo == tipoImpuesto);
                MainWindow.totalProcentaje = (MainWindow.total * Convert.ToDecimal(MainWindow.impuesto.procentaje)) / 100;
                MainWindow.totalFinal = MainWindow.total + MainWindow.totalProcentaje;
                labelTotal.Content = "Total: " + MainWindow.totalFinal.ToString().Replace('.', ',') + "€";
                MainWindow.tipoImpuestoCliente = "Total: " + MainWindow.totalFinal.ToString().Replace('.', ',') + "€";
                Close();
            }
        }
    }
}
