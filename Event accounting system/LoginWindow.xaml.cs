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

namespace Event_accounting_system
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            UserRepository.AddListOfUser(SaveManager.LoadUsers());

            loginGrid.Visibility = Visibility.Visible;
            userInputInfoGrid.Visibility = Visibility.Hidden;
        }

        private void GiveAdminRightsButtonClick(object sender, RoutedEventArgs e)
        {
            OpenMainWindow();
        }

        private void GiveUsernRightsButtonClick(object sender, RoutedEventArgs e)
        {
            loginGrid.Visibility = Visibility.Hidden;
            userInputInfoGrid.Visibility = Visibility.Visible;

        }

        private void AcceptButtonClick(object sender, RoutedEventArgs e)
        {
            User user = new User(fullNameTextBlock.Text);
            UserRepository.CurrentUser = user;

            OpenMainWindow();
        }

        private void OpenMainWindow()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
