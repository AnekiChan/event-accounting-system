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
    /// Логика взаимодействия для CreateEventWindow.xaml
    /// </summary>
    public partial class CreateEventWindow : Window
    {
        private EventsRepository<OfflineEvent> offlineEvents = new EventsRepository<OfflineEvent>();
        private EventsRepository<OnlineEvent> onlineEvents = new EventsRepository<OnlineEvent>();

        public CreateEventWindow()
        {
            InitializeComponent();
        }

        private void CreateNewEventButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (offlineRadioButton.IsChecked == true)
                {
                    offlineEvents.Add(new OfflineEvent(titleTextBox.Text, descriptionTextBox.Text, eventDatePicker.SelectedDate, organizerTextBox.Text, Int32.Parse(maxParticipantsTextBox.Text), addressTextBox.Text));
                }
                else
                    onlineEvents.Add(new OnlineEvent(titleTextBox.Text, descriptionTextBox.Text, eventDatePicker.SelectedDate, organizerTextBox.Text, Int32.Parse(maxParticipantsTextBox.Text), urlTextBox.Text));

                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).UpdateDataGrids();
                        break;
                    }
                }

                Close();
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Какое-то из значений не было введено.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Какое-то из значений введено неверно.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
