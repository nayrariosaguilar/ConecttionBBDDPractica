using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace ConecttionBBDDPractica
{
    
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();

        }
        public void connectar_clic(Object sender, RoutedEventArgs e)
        {
            string connectionString = null;
            MySqlConnection conn;

            connectionString = "Server=localhost;Port=3307;Database=practica;Uid=root;Pwd=;";
            conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                MessageBox.Show("Connection Open ! ");
                conn.Close();
                MessageBox.Show("Connection Close ! ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void botonInsert_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.ShowDialog();
            
        }
        private void botonSelect_Click(object sender, RoutedEventArgs e)
        {
           SelectClients window1 = new SelectClients();
            window1.ShowDialog();

        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.ShowDialog();
            
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}