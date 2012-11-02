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

namespace WPFLab
{
    /// <summary>
    /// Interaction logic for FirstWindow.xaml
    /// </summary>
    public partial class FirstWindow : Window
    {
        protected int eventCounter = 0;

        public FirstWindow()
        {
            InitializeComponent();
        }

        private void DoSomething(object sender, RoutedEventArgs e)
        {
            object tag = ((FrameworkElement)sender).Tag;
            MessageBox.Show((string)tag);

            //eventCounter++;
            //string message = "#" + eventCounter.ToString() + ":\r\n" +
            //" Sender: " + sender.ToString() + "\r\n" +
            //" Source: " + e.Source + "\r\n" +
            //" Original Source: " + e.OriginalSource;

            //if (e.Source == cmd1)
            //{
            //    tbk1.Text = "cmd1" + message;
            //}
            //else if (e.Source == cmd2)
            //{
            //    tbk1.Text = "cmd2" + message;
            //}
            //else if (e.Source == cmd3)
            //{
            //    tbk1.Text = "cmd3" + message;
            //}
        }

        private void SomethingClicked(object sender, MouseButtonEventArgs e)
        {
            eventCounter++;
            string message = "#" + eventCounter.ToString() + ":\r\n" +
            " Sender: " + sender.ToString() + "\r\n" +
            " Source: " + e.Source + "\r\n" +
            " Original Source: " + e.OriginalSource;
            lstMessages.Items.Add(message);
            e.Handled = (bool)chkHandle.IsChecked;
        }

        private void cmdClear_Click(object sender, RoutedEventArgs e)
        {
            eventCounter = 0;
            lstMessages.Items.Clear();
        }

        private void KeyEvent(object sender, KeyEventArgs e)
        {
            string message = "Event: " + e.RoutedEvent + " " +
            " Key: " + e.Key;
            lstMessages.Items.Add(message);

            if ((e.KeyboardDevice.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                lstMessages.Items.Add("You held the Control key.");
            }
        }
        
    }

}
