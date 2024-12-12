using Google.Protobuf.WellKnownTypes;
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
  
    public partial class Window1 : Window
    {
        bool validarNombre;
        bool validarApellido;
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
            String numero = telefon.Text;
            String apellido = surname.Text;
            String direccion = direction.Text;
            validarNombre = nombre.Any(char.IsDigit);
            validarApellido = apellido.Any(char.IsDigit);


            if (int.TryParse(numero, out int tel))
            {
                if (!(string.IsNullOrWhiteSpace(nombre) && string.IsNullOrWhiteSpace(apellido)&& string.IsNullOrWhiteSpace(direccion)&&tel>0))
                {
                    if (!(validarNombre||validarApellido)) {
                        int id = 0;
                        addUser(id, nombre, apellido, tel, direccion);
                    }
                    else
                    {
                        MessageBox.Show("No puedes introducir un numero dentro de un String");
                    }
                }
                else
                {
                    MessageBox.Show("Error: los datos del usuario son invalidos, NO PUEDEN ESTAR VACIOS");
                }
            }
            else
            {
                MessageBox.Show("Error: El telefono debe ser un entero");
            }

        }
        private void addUser(int id, String name, String surname, int num, String dirrection)
        {
            string connectionString = null;
            string sqlI = "INSERT INTO clients VALUES('"+id+"','"+name+"','"+surname+"','"+num+"','"+dirrection+"')";
            connectionString = "Server=localhost;Database=practica;Uid=root;Pwd=;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sqlI, conn))
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        MessageBox.Show("Client succesfully added");
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
