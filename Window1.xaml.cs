using MySql.Data.MySqlClient;
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

namespace ConecttionBBDDPractica
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void EnviarClient_Click(object sender, RoutedEventArgs e)
        {
            String nombre = name.Text;

            //String id = id.ToString().Text;
            //int numero = num.Text;
            String apellido = surname.Text;
            String direccion = direction.Text;
            int num = 0;
            if ((nombre.Length > 0 && apellido.Length > 0 && direccion.Length > 0)) {
                addUser(nombre, apellido, num, direccion);
            }
            else
            {
                MessageBox.Show("Error: los datos del usuario son invalidos");
            }

        }
        private void addUser(String name, String surname, int num, String dirrection)
        {
            //demanar al usuari que 
            string connectionString = null;
            string sqlI = "INSERT INTO clients VALUES('"+name+"','"+surname+"','"+num+"'"+dirrection+"')";
            connectionString = "Server=localhost;Database=practica;Uid=root;Pwd=;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sqlI, conn))
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        MessageBox.Show(" ExecuteNonQuery in SqlCommand executed !!");
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
