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

namespace Event_accounting_system
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private OfflineEvent? lastSelectedOfflineEvent;
        private OnlineEvent? lastSelectedOnlineEvent;

        public MainWindow()
        {
            InitializeComponent();
            offlineEventsGrid.ItemsSource = EventsRepository.GetOfflineEvents();
            onlineEventsGrid.ItemsSource = EventsRepository.GetOnlineEvents();
        }

        private void CreateButtonClick(object sender, RoutedEventArgs e)
        {
            CreateEventWindow createEventWindow = new CreateEventWindow();
            createEventWindow.Show();
        }

        private void UpdateDataGrids()
        {
            offlineEventsGrid.Items.Refresh();
            onlineEventsGrid.Items.Refresh();
        }

        private void UpdateButtonClick(object sender, RoutedEventArgs e)
        {
            UpdateDataGrids();
        }

        private void OfflineEventsGridMouseUp(object sender, MouseButtonEventArgs e)
        {
            OfflineEvent? offlineEvent = offlineEventsGrid.SelectedItem as OfflineEvent;
            if (offlineEvent != null)
            {
                FillEventInfotmation(offlineEvent);
                formatTextBlock.Text = offlineEvent.Address;

                lastSelectedOfflineEvent = offlineEvent;
                lastSelectedOnlineEvent = null;
            }
        }

        private void OnlineEventsGridMouseUp(object sender, MouseButtonEventArgs e)
        {
            OnlineEvent? onlineEvent = onlineEventsGrid.SelectedItem as OnlineEvent;
            if (onlineEvent != null)
            {
                FillEventInfotmation(onlineEvent);
                formatTextBlock.Text = onlineEvent.Url;

                lastSelectedOnlineEvent = onlineEvent;
                lastSelectedOfflineEvent = null;
            }
        }

        private void FillEventInfotmation(Event _event)
        {
            titleTextBlock.Text = _event.Title;
            descriptionTextBlock.Text = _event.Description;
            dateTextBlock.Text = _event.Date.ToString();
            maxParticipatorsTextBlock.Text = $"Максимальное количество участников: {_event.MaxParticipants.ToString()}";
        }

        private void RemoveEventButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lastSelectedOfflineEvent != null)
                {
                    EventsRepository.Remove(lastSelectedOfflineEvent);
                }
                else if (lastSelectedOnlineEvent != null)
                {
                    EventsRepository.Remove(lastSelectedOnlineEvent);
                }

                UpdateDataGrids();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("ff");
            }
        }
    }
}