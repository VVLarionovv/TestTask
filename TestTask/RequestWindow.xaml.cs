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
using static TestTask.Class1;

namespace TestTask
{
    /// <summary>
    /// Логика взаимодействия для RequestWindow.xaml
    /// </summary>
    public partial class RequestWindow : Window
    {
        public Request Request { get; set; }

        public RequestWindow(Request request)
        {
            InitializeComponent();
            Request = request;

            TitleTextBox.Text = Request.Title;
            DescriptionTextBox.Text = Request.Description;
            CourierTextBox.Text = Request.Courier;
            StatusComboBox.SelectedItem = StatusComboBox.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == Request.Status);
            CancellationReasonTextBox.Text = Request.CancellationReason;

            UpdateVisibility();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
 
            Request.Title = TitleTextBox.Text;
            Request.Description = DescriptionTextBox.Text;
            Request.Courier = CourierTextBox.Text;
            Request.Status = ((ComboBoxItem)StatusComboBox.SelectedItem).Content.ToString();
            Request.CancellationReason = CancellationReasonTextBox.Text;

            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void StatusComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateVisibility();
        }

        private void UpdateVisibility()
        {
            if (StatusComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                if (selectedItem.Content.ToString() == "Transferred")
                {
                    CourierLabel.Visibility = Visibility.Visible;
                    CourierTextBox.Visibility = Visibility.Visible;
                }
                else
                {
                    CourierLabel.Visibility = Visibility.Collapsed;
                    CourierTextBox.Visibility = Visibility.Collapsed;
                }

                if (selectedItem.Content.ToString() == "Cancelled")
                {
                    CancellationReasonLabel.Visibility = Visibility.Visible;
                    CancellationReasonTextBox.Visibility = Visibility.Visible;
                }
                else
                {
                    CancellationReasonLabel.Visibility = Visibility.Collapsed;
                    CancellationReasonTextBox.Visibility = Visibility.Collapsed;
                }
            }
        }
    }
}
