using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace cafe_system
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-VR5EFC4;Initial Catalog=Cafe_system_DB;Integrated Security=True");

        public bool isValid()
        {
            if (UserType_txt.Text == string.Empty || Name_txt.Text == string.Empty || IdentDoc_txt.Text == string.Empty || Date_txt.Text == string.Empty || Adress_txt.Text == string.Empty || login_txt.Text == string.Empty || password_txt.Text == string.Empty)
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isValid())
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO tbCafeStuff VALUES (@UserType, @Name, @IdentDoc, @Date, @Place, @login, @password, @Status)", sqlConnection);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@UserType", UserType_txt.Text);
                    cmd.Parameters.AddWithValue("@Name", Name_txt.Text);
                    cmd.Parameters.AddWithValue("@IdentDoc", IdentDoc_txt.Text);
                    cmd.Parameters.AddWithValue("@Date", Date_txt.Text);
                    cmd.Parameters.AddWithValue("@Place", Adress_txt.Text);
                    cmd.Parameters.AddWithValue("@login", login_txt.Text);
                    cmd.Parameters.AddWithValue("@password", password_txt.Text);
                    cmd.Parameters.AddWithValue("@Status", Status_txt.Text);
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("Данные успешно сохранены!", "Сохранено!", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
