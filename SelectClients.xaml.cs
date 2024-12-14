using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlTypes;
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
    /// Lógica de interacción para SelectClients.xaml
    /// </summary>
    public partial class SelectClients : Window
    {
        public SelectClients()
        {
            InitializeComponent();
            mostrarClients();
        }

        private void ListadoClientsGrilla_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        private void mostrarClients()
        {
            string connectionString = null;
            string sqlI = "SELECT * FROM clients";
           
            connectionString = "Server=localhost;Port=3307;Database=practica;Uid=root;Pwd='';";
            
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (MySqlCommand cmd = new MySqlCommand(sqlI, conn))
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                        MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        sda.Fill(table);
                        ListadoClientsGrilla.ItemsSource = table.DefaultView;

                        MessageBox.Show("Listado de clientes listo");
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
