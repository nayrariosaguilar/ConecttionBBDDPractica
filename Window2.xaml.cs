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
   
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String idIntroducido = nombre.Text;
            if (int.TryParse(idIntroducido, out int id))
            {
                if (id > 0)
                {
                    deleteUser(id);
                }
                else
                {
                    MessageBox.Show("Error: los datos del usuario son invalidos");
                }
            }
            
        }
        private void deleteUser(int id)
        {
            string connectionString = null;
            string sqlD = "DELETE FROM clients WHERE idClient='"+ id +"';";
            connectionString = "Server=localhost;Port=3307;Database=practica;Uid=root;Pwd=;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sqlD, conn))
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            MessageBox.Show("La id no existe");
                        }
                        else
                        {
                            MessageBox.Show(" delete ok");
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
