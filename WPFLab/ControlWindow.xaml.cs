using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;

namespace WPFLab
{
    /// <summary>
    /// Interaction logic for ControlWindow.xaml
    /// </summary>
    public partial class ControlWindow : Window
    {
        public ControlWindow()
        {
            InitializeComponent();
        }

        private void lnk_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(((Hyperlink)sender).NavigateUri.ToString());
        }

        private void run_MouseEnter(object sender, MouseEventArgs e)
        {
            popLink.IsOpen = true;
        }

        private void lst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lst.SelectedItem == null) return;
            txtSelection.Text = String.Format("You chose item at position {0}.\r\nChecked state is {1}.",
                                                lst.SelectedIndex,
                                                ((CheckBox)lst.SelectedItem).IsChecked);
        }

        private void lst_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void btn_exm_all_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (CheckBox item in lst.Items)
            {
                if (item.IsChecked == true)
                {
                    sb.Append(item.Content);
                    sb.Append(" is checked.");
                    sb.Append("\r\n");
                }
            }
            txtSelection.Text = sb.ToString();

            //ListBoxItem itm = (ListBoxItem)lst.ContainerFromElement((DependencyObject)lst.SelectedItems[0]);
            //MessageBox.Show("Option 1 isSelected: " + itm.IsSelected.ToString());

        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            // Check all the newly added items.
            foreach (DateTime selectedDate in e.AddedItems)
            {
                if ((selectedDate.DayOfWeek == DayOfWeek.Saturday) ||
                (selectedDate.DayOfWeek == DayOfWeek.Sunday))
                {
                    lblError.Text = "Weekends are not allowed";
                    // Remove the selected date.
                    ((Calendar)sender).SelectedDates.Remove(selectedDate);
                }
            }
        }

        private void DatePicker_DateValidationError(object sender, DatePickerDateValidationErrorEventArgs e)
        {
            lblError.Text = "'" + e.Text + "' is not a valid value because " + e.Exception.Message;
        }

        
    }
}
