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
using WPFLab.Models;
using System.Collections.ObjectModel;

namespace WPFLab
{
    /// <summary>
    /// Interaction logic for ProductRad.xaml
    /// </summary>
    public partial class ProductRad : Window
    {
        ProductStore mStore;
        public ProductRad()
        {
            InitializeComponent();

            mStore = new ProductStore();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource productViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("productViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            productViewSource.Source = mStore.GetAll();          
        }

        private void cmdGetProduct_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Data.CollectionViewSource productViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("productViewSource")));
            productViewSource.Source = mStore.GetByNumber(txtID.Text);  
            
        }        

        private void validationError(object sender, ValidationErrorEventArgs e)
        {
            // Check that the error is being added (not cleared).
            if (e.Action == ValidationErrorEventAction.Added)
            {
                MessageBox.Show(e.Error.ErrorContent.ToString());
            }
        }

        private void cmdGetUpdate_Click(object sender, RoutedEventArgs e)
        {
            string message;
            if (FormHasErrors(out message))
            {
                // Errors still exist.
                MessageBox.Show(message);
            }
            else
            {
                // There are no errors. You can continue on to complete the task
                // (for example, apply the edit to the data source.).
            }
        }

        private bool FormHasErrors(out string message)
        {
            StringBuilder sb = new StringBuilder();
            GetErrors(sb, gridProductDetails);
            message = sb.ToString();
            return message != "";
        }

        private void GetErrors(StringBuilder sb, DependencyObject obj)
        {
            foreach (object child in LogicalTreeHelper.GetChildren(obj))
            {
                TextBox element = child as TextBox;
                if (element == null) continue;
                if (Validation.GetHasError(element))
                {
                    sb.Append(element.Text + " has errors:\r\n");
                    foreach (ValidationError error in Validation.GetErrors(element))
                    {
                        sb.Append(" " + error.ErrorContent.ToString());
                        sb.Append("\r\n");
                    }
                    // Check the children of this object for errors.
                    GetErrors(sb, element);
                }
            }
        }
        
    }
}
