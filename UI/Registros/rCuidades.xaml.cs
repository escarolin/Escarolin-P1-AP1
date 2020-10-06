using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Escarolin_P1_AP1.BLL;
using Escarolin_P1_AP1.Entidades;

namespace Escarolin_P1_AP1.UI.Registros
{
    /// <summary>
    /// Interaction logic for rCuidades.xaml
    /// </summary>
    public partial class rCuidades : Window
    {
        private Cuidades ciudades = new Cuidades();
        public rCuidades()
        {
            InitializeComponent();
            this.DataContext = ciudades;
        }
        
            
            //LIMPIAR
            private void Limpiar()
            {
                this.ciudades = new Cuidades();
                this.DataContext = ciudades;
            }
            //VALIDAR
            private bool Validar()
            {
                bool esValido = true;
                if (NombreTextbox.Text.Length == 0)
                {
                    esValido = false;
                    MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                return esValido;
            }
            //BUSCAR
            private void BuscarButton_Click(object sender, RoutedEventArgs e)
            {
                var usuarios = CuidadesBLL.Buscar(Utilidades.ToInt(CiudadIdTextbox.Text));
                if (ciudades != null)
                    this.ciudades = usuarios;
                else
                    this.ciudades = new Cuidades ();

                this.DataContext = this.ciudades;
            }
            //NUEVO
            private void NuevoButton_Click(object sender, RoutedEventArgs e)
            {
                Limpiar();
            }
            //GUARDAR
            private void GuardarButton_Click(object sender, RoutedEventArgs e)
            {
                {
                    if (!Validar())
                        return;

                    var paso = CuidadesBLL.Guardar(ciudades);
                    if (paso)
                    {
                        Limpiar();
                        MessageBox.Show("Transaccion Exitosa!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                        MessageBox.Show("Transaccion Fallida", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            //ELIMINAR
            private void EliminarButton_Click(object sender, RoutedEventArgs e)
            {
                {
                    if (CuidadesBLL.Eliminar(Utilidades.ToInt(CiudadIdTextbox.Text)))
                    {
                        Limpiar();
                        MessageBox.Show("Registro Eliminado!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                        MessageBox.Show("No fue posible eliminar", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

    }


