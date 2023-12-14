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
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        private int idOfEditingEvent;
        public EditWindow(int idOfEditingEvent)
        {
            InitializeComponent();
            this.idOfEditingEvent = idOfEditingEvent;
        }

        private void SaveEditButton(object sender, RoutedEventArgs e)
        {
            try
            {
                OfflineEvent? offlineEvent = EventsRepository.FindOfflineEventById(idOfEditingEvent);
                OnlineEvent? onlineEvent = EventsRepository.FindOnlineEventById(idOfEditingEvent);
                if (offlineEvent != null)
                {
                    EventsRepository.ReplaceOfflineEvent(offlineEvent.Id, titleTextBox.Text, descriptionTextBox.Text, eventDatePicker.SelectedDate, organizerTextBox.Text, Int32.Parse(maxParticipantsTextBox.Text), formatTextBox.Text);
                }
                else if (onlineEvent != null)
                {
                    EventsRepository.ReplaceOnlineEvent(onlineEvent.Id, titleTextBox.Text, descriptionTextBox.Text, eventDatePicker.SelectedDate, organizerTextBox.Text, Int32.Parse(maxParticipantsTextBox.Text), formatTextBox.Text);
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
