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
    /// Interaction logic for NavigateDataView.xaml
    /// </summary>
    public partial class NavigateDataView : Window
    {
        private ListCollectionView view;
        ProductStore mStore;

        public NavigateDataView()
        {
            InitializeComponent();
            mStore = new ProductStore();

            ICollection<Product> products = mStore.GetAll();
            this.DataContext = products;

            view = (ListCollectionView)CollectionViewSource.GetDefaultView(this.DataContext);
            view.CurrentChanged += new EventHandler(view_CurrentChanged);

            lstProducts.ItemsSource = products;
        }
        private void view_CurrentChanged(object sender, EventArgs e)
        {
            lblPosition.Text = "Record " + (view.CurrentPosition + 1).ToString() +
            " of " + view.Count.ToString();
            cmdPrev.IsEnabled = view.CurrentPosition > 0;
            cmdNext.IsEnabled = view.CurrentPosition < view.Count - 1;
        }

        private void cmdPrev_Click(object sender, RoutedEventArgs e)
        {
            view.MoveCurrentToPrevious();
        }

        private void cmdNext_Click(object sender, RoutedEventArgs e)
        {
            view.MoveCurrentToNext();
        }

        private void lstProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            view.MoveCurrentTo(lstProducts.SelectedItem);
        }

    }
}
