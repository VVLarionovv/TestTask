using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using static TestTask.Class1;

namespace TestTask
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Request> requests;

        public MainWindow()
        {
            InitializeComponent();
            requests = new ObservableCollection<Request>();
            RequestsDataGrid.ItemsSource = requests;
        }

        private void RegisterRequest_Click(object sender, RoutedEventArgs e)
        {
            var newRequest = new Request
            {
                Id = requests.Count + 1,
                Title = "",
                Description = "",
                Status = "New"
            };

            var requestWindow = new RequestWindow(newRequest);
            if (requestWindow.ShowDialog() == true)
            {
                requests.Add(newRequest);
            }
        }

        private void EditRequest_Click(object sender, RoutedEventArgs e)
        {
            if (RequestsDataGrid.SelectedItem is Request selectedRequest && selectedRequest.Status == "New")
            {
                var requestWindow = new RequestWindow(selectedRequest);
                if (requestWindow.ShowDialog() == true)
                {
                    RequestsDataGrid.Items.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Вы можете редактировать только запросы со статусом 'New'.", "Редактировать запрос", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteRequest_Click(object sender, RoutedEventArgs e)
        {
            if (RequestsDataGrid.SelectedItem is Request selectedRequest)
            {
                requests.Remove(selectedRequest);
            }
        }

        private void SearchRequest_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();
            var filteredRequests = requests.Where(r => r.Id.ToString().Contains(searchText) ||
                                                       r.Title.ToLower().Contains(searchText) ||
                                                       r.Description.ToLower().Contains(searchText) ||
                                                       r.Status.ToLower().Contains(searchText) ||
                                                       r.Courier.ToLower().Contains(searchText)).ToList();
            RequestsDataGrid.ItemsSource = filteredRequests;
        }
    }
}
