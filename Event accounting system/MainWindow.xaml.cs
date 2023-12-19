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
        private EventsRepository<OfflineEvent> offlineEvents = new EventsRepository<OfflineEvent>();
        private EventsRepository<OnlineEvent> onlineEvents = new EventsRepository<OnlineEvent>();

        private OfflineEvent? lastSelectedOfflineEvent;
        private OnlineEvent? lastSelectedOnlineEvent;
        public int a;

        public MainWindow()
        {
            InitializeComponent();
            offlineEvents.AddEventsList(SaveManager.LoadOfflineEvents());
            onlineEvents.AddEventsList(SaveManager.LoadOnlineEvents());

            offlineEventsGrid.ItemsSource = offlineEvents.GetEvents();
            onlineEventsGrid.ItemsSource = onlineEvents.GetEvents();
        }

        private void CreateButtonClick(object sender, RoutedEventArgs e)
        {
            CreateEventWindow createEventWindow = new CreateEventWindow();
            createEventWindow.Owner = this;
            createEventWindow.Show();
        }

        public void UpdateDataGrids()
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
            string[] date = _event.Date.ToString()?.Split(new char[] { ' ' });
            dateTextBlock.Text = date[0] ?? "No Date";
            maxParticipatorsTextBlock.Text = $"Максимальное количество участников: {_event.MaxParticipants.ToString()}";
        }

        private void RemoveEventButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lastSelectedOfflineEvent != null)
                {
                    offlineEvents.Remove(lastSelectedOfflineEvent);
                }
                else if (lastSelectedOnlineEvent != null)
                {
                    onlineEvents.Remove(lastSelectedOnlineEvent);
                }

                UpdateDataGrids();
                SaveManager.SaveEvents(offlineEvents.GetEvents(), onlineEvents.GetEvents());
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("ff");
            }
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            EditWindow? editWindow = null;
            editWindow.Owner = this;

            if (lastSelectedOfflineEvent != null)
            {
                editWindow = new EditWindow(lastSelectedOfflineEvent.Id);
            }
            else if (lastSelectedOnlineEvent != null)
            {
                editWindow = new EditWindow(lastSelectedOnlineEvent.Id);
            }

            if (editWindow != null)
                editWindow.Show();
        }
    }
}