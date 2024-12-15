using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
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

namespace ConecttionBBDDPractica
{
    public partial class Preupdate : Window
    {
        public Preupdate()
        {
            InitializeComponent();
        }

        private void ComprobarId_Click(object sender, RoutedEventArgs e)
        {
            String idIntroducido = id.Text;
            if (int.TryParse(idIntroducido, out int idNum))
            {
                if (idNum > 0)
                {
                   bool resposta = SelectByIdMethod(idNum);
                    if (!resposta)
                    {
                        MessageBox.Show("Error: La id es inválida");
                    }
                }
                else
                {
                    MessageBox.Show("Error: los datos del usuario son invalidos");
                }
            }
        }
        private bool SelectByIdMethod(int Id)
        {
            string connectionString = null;
            string sqlI = "SELECT * FROM clients WHERE idClient='"+Id+"';";

            connectionString = "Server=localhost;Port=3307;Database=practica;Uid=root;Pwd='';";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(sqlI, conn))
                    {
                       using(MySqlDataReader reader = cmd.ExecuteReader()) 
                            //manera de leer si los datos de la id existen
                        {
                            if (reader.HasRows)
                            {

                                DataTable table = new DataTable();
                                //cargamos el DataReader en la table
                                table.Load(reader);
                                SelectById.ItemsSource = table.DefaultView;
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                            
                        }
                        
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }

        private void SelectById_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         
        }
        private void ActualizarClient_Click(object sender, RoutedEventArgs e)
        {
            var row = SelectById.SelectedItem as DataRowView;

            if (row != null)
            {
                //columnas modificadas, recogemos el nuevo calor
                string nuevoNombre = row["nom_cli"].ToString();
                string nuevoApellido = row["cognom_cli"].ToString();
                string nuevaDireccion = row["direccio_cli"].ToString();
                string nuevoTelefono = row["telf_cli"].ToString();
                //datos previos a modificar
                DataRow originalRow = row.Row;
                int id = Convert.ToInt32(originalRow["idClient", DataRowVersion.Original]);
                string nombreOriginal = originalRow["nom_cli", DataRowVersion.Original].ToString();
                string apellidoOriginal = originalRow["cognom_cli", DataRowVersion.Original].ToString();
                string direccionOriginal = originalRow["direccio_cli", DataRowVersion.Original].ToString();
                string telefonoOriginal = originalRow["telf_cli", DataRowVersion.Original].ToString();

                // Detecta cambios en las columnas
                if (nuevoNombre != nombreOriginal)
                {
                    UpdateCliente(id, "nom_cli", nuevoNombre);
                }else if (nuevoApellido != apellidoOriginal)
                {
                    UpdateCliente(id, "cognom_cli", nuevoApellido);
                }
                else if (nuevaDireccion != direccionOriginal)
                {
                    UpdateCliente(id, "direccio_cli", nuevaDireccion);
                }
                else if (nuevoTelefono != telefonoOriginal)
                {
                    UpdateCliente(id, "telf_cli", nuevoTelefono);
                }
                else
                {
                    MessageBox.Show("La id nose puede editar.");
                }

            }
            else
            {
                MessageBox.Show("No hay ningún cliente seleccionado.");
            }
        }


        private void UpdateCliente(int id, String columna, String nuevoValor)
        {

            string connectionString = null;
            string sqlI = $"UPDATE clients SET {columna} = '"+nuevoValor+"' WHERE idClient='" + id + "';";

            connectionString = "Server=localhost;Port=3307;Database=practica;Uid=root;Pwd='';";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(sqlI, conn))
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected==0)
                            {
                            MessageBox.Show("Los datos se actualizaron incorrectamente");
                            }
                            else
                            {
                            MessageBox.Show("Los datos se actualizaron correctamente");
                        }

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                   
                }
            }
        }
    }
}
