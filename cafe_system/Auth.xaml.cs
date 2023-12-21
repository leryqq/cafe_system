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
using System.Data.SqlTypes;
using System.Windows.Navigation;

namespace cafe_system
{
    public partial class Auth : Window
    {
        private string connectionString = @"Data Source=DESKTOP-VR5EFC4;Initial Catalog=Cafe_system_DB;Integrated Security=True"; // Замените на вашу строку подключения

        public Auth()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = Login_txt.Text;
            string password = Password_txt.Password;

            if (IsValidUser(login, password))
            {
                string job = GetJob(login);
                OpenMainForm(job);
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль. Попробуйте снова.");
            }
        }

        private bool IsValidUser(string login, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM tbCafeStuff WHERE Login = @Login AND Password = @Password";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Login", login);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
        }

        private string GetJob(string login)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT UserType FROM tbCafeStuff WHERE Login = @Login";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Login", login);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string job = reader["UserType"].ToString();
                            Console.WriteLine($"Job: {job}"); // Добавьте вывод должности (уровня доступа)
                            return job;
                        }
                    }
                }
            }

            return string.Empty;
        }

        private void OpenMainForm(string job)
        {
            string login = Login_txt.Text;
            UserDetails userDetails = GetUserDetails(login);
            switch (job.ToLower())
            {
                case "Admin":
                    MainWindow adminForm = new MainWindow();
                    adminForm.Show();
                    /*adminForm.SetUserDetails(userDetails);
                    NavigationService.Navigate(adminForm);*/
                    break;

                case "Off":
                    MainWindow adminForm2 = new MainWindow();
                    adminForm2.Show();
                    /*MainWindow mainWindow = new MainWindow();
                    mainWindow.SetUserDetails(userDetails);
                    NavigationService.Navigate(mainWindow);*/
                    break;

                case "Повар":
                    MainWindow adminForm3 = new MainWindow();
                    adminForm3.Show();
                    /*Chechevicchka waiterForm = new Chechevicchka();
                    waiterForm.SetUserDetails(userDetails);
                    NavigationService.Navigate(waiterForm);*/
                    break;

                default:
                    MessageBox.Show($"Неизвестная должность: {job}");
                    break;
            }
        }
        private UserDetails GetUserDetails(string login)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT Name FROM tbCafeStuff WHERE Login = @Login";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Login", login);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            UserDetails userDetails = new UserDetails
                            {
                                Name = reader["Name"].ToString(),
                                
                                //Status = reader["Status"].ToString()
                            };

                            return userDetails;
                        }
                    }
                }
            }

            return null;
        }
    }
}
