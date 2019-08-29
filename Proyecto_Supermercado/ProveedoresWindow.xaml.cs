﻿using Proyecto_Supermercado.Modelo;
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
    /// Lógica de interacción para ProveedoresWindow.xaml
    /// </summary>
    public partial class ProveedoresWindow : Window
    {
        TextBox textBox;
        List<Proveedor> listaProveedores = new List<Proveedor>();
        public ProveedoresWindow(TextBox textBox)
        {
            InitializeComponent();
            this.textBox = textBox;
            listaProveedores = MainWindow.unidadTrabajo.RepositorioProveedor.getGeneral();
            consultarProveedoresDataGrid.ItemsSource = listaProveedores.Select(p => new { p.cif, p.nombre });
        }

        private void consultarProveedorDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (consultarProveedoresDataGrid.SelectedIndex != -1)
            {
                string nombreProveedor = listaProveedores[consultarProveedoresDataGrid.SelectedIndex].nombre;
                textBox.Text = nombreProveedor;
                Close();
            }
        }
    }
}
