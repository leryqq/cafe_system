using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace cafe_system
{
    /// <summary>
    /// Логика взаимодействия для Stuff.xaml
    /// </summary>
    public partial class Stuff : Page
    {
        public Stuff()
        {
            InitializeComponent();
            //DGStuff.ItemsSource = Cafe_system_DBEntities1.GetContext().tbCafeStuff.ToList();

            using (SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-VR5EFC4;Initial Catalog=Cafe_system_DB;Integrated Security=True"))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM tbCafeStuff", sqlConnection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                sqlConnection.Close();
                DGStuff.ItemsSource = dataTable.DefaultView;
            }
        }

        

    }
}
