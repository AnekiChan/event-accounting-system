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
        private EventsRepository<OfflineEvent> offlineEvents = new EventsRepository<OfflineEvent>();
        private EventsRepository<OnlineEvent> onlineEvents = new EventsRepository<OnlineEvent>();

        private Event? editingEvent;
        private string? address = null;
        private string? url = null;

        private int idOfEditingEvent;

        public EditWindow(int idOfEditingEvent)
        {
            InitializeComponent();
            this.idOfEditingEvent = idOfEditingEvent;
            editingEvent = offlineEvents.FindEventById(idOfEditingEvent);
            if (editingEvent == null)
            {
                editingEvent = onlineEvents.FindEventById(idOfEditingEvent);
            }
            else
                address = offlineEvents.FindEventById(idOfEditingEvent)?.Address;

            if (editingEvent == null)
            {
                Close();
            }
            else
                url = onlineEvents.FindEventById(idOfEditingEvent)?.Url;

            titleTextBox.Text = editingEvent.Title;
            descriptionTextBox.Text = editingEvent.Description;
            eventDatePicker.SelectedDate = editingEvent.Date;
            organizerTextBox.Text = editingEvent.Organizer;
            maxParticipantsTextBox.Text = editingEvent.MaxParticipants.ToString();
        }

        private void SaveEditButton(object sender, RoutedEventArgs e)
        {
            try
            {
                offlineEvents.Replace(idOfEditingEvent, titleTextBox.Text, descriptionTextBox.Text, eventDatePicker.SelectedDate, organizerTextBox.Text, Int32.Parse(maxParticipantsTextBox.Text));
                onlineEvents.Replace(idOfEditingEvent, titleTextBox.Text, descriptionTextBox.Text, eventDatePicker.SelectedDate, organizerTextBox.Text, Int32.Parse(maxParticipantsTextBox.Text));

                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).UpdateDataGrids();
                        break;
                    }
                }

                SaveManager.Save(offlineEvents.GetEvents(), onlineEvents.GetEvents());

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
