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
    /// Interaction logic for TwoDocumentWindow.xaml
    /// </summary>
    public partial class TwoDocumentWindow : Window
    {
        private Dictionary<Object, bool> isDirty = new Dictionary<Object, bool>();

        public TwoDocumentWindow()
        {
            InitializeComponent();
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string text = ((TextBox)sender).Text;
            MessageBox.Show("About to save: " + text);

            isDirty[sender] = false;
        }

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (isDirty.ContainsKey(sender) && isDirty[sender])
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        private void txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            isDirty[sender] = true;
        }

        private void SaveCommand(object sender, ExecutedRoutedEventArgs e)
        {
            SaveCommand_Executed(sender, e);
        }

        private void CanExecuteSave(object sender, CanExecuteRoutedEventArgs e)
        {
            SaveCommand_CanExecute(sender, e);
        }
    }
}
