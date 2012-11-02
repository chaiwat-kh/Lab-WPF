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

namespace WPFLab
{
    /// <summary>
    /// Interaction logic for ListViewDataGrid.xaml
    /// </summary>
    public partial class ListViewDataGrid : Window
    {
        ProductStore mStore;
        private SolidColorBrush highlightBrush = new SolidColorBrush(Colors.Orange);
        private SolidColorBrush normalBrush = new SolidColorBrush(Colors.White);

        public ListViewDataGrid()
        {
            InitializeComponent();
            mStore = new ProductStore();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            gridProducts.ItemsSource = mStore.GetAll();
            gridCombo.ItemsSource = mStore.GetCategoriesList();
        }
        private void gridProducts_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            if (e.Row.GetIndex() < gridProducts.Items.Count - 1)
            {
                // Check the data object for this row.
                Product product = (Product)e.Row.DataContext;
                // Apply the conditional formatting.
                if (product.UnitCost > 100000)
                {
                    e.Row.Background = highlightBrush;
                }
                else
                {
                    // Restore the default white background. This ensures that used,
                    // formatted DataGrid objects are reset to their original appearance.
                    e.Row.Background = normalBrush;
                }
            }
        }
    }
}
