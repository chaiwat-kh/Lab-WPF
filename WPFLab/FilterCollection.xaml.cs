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
using WPFLab.Services;
using System.ComponentModel;
using WPFLab.Extension;

namespace WPFLab
{
    /// <summary>
    /// Interaction logic for FilterCollection.xaml
    /// </summary>
    public partial class FilterCollection : Window
    {
        ProductStore mStore;
        ProductByPriceFilter filter;

        public FilterCollection()
        {
            InitializeComponent();
            mStore = new ProductStore();
        }

        private void cmdGetProduct_Click(object sender, RoutedEventArgs e)
        {
            lstProducts.ItemsSource = mStore.GetAll();

            //ICollectionView view = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource);
            //view.GroupDescriptions.Add(new PropertyGroupDescription("CategoryType"));

            ICollectionView view = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource);
            view.SortDescriptions.Add(new SortDescription("UnitCost", ListSortDirection.Ascending));
            PriceRangeProductGrouper grouper = new PriceRangeProductGrouper();
            grouper.GroupInterval = 100000;
            view.GroupDescriptions.Add(new PropertyGroupDescription("UnitCost", grouper));
        }

        private void cmdFilter_Click(object sender, RoutedEventArgs e)
        {
            decimal minimumPrice;
            if (Decimal.TryParse(txtMinPrice.Text, out minimumPrice))
            {
                ListCollectionView view = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource)
                                                as ListCollectionView;
                if (view != null)
                {
                    filter = new ProductByPriceFilter(minimumPrice);
                    view.Filter = new Predicate<object>(filter.FilterItem);
                   
                }
                //BindingListCollectionView view = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource)
                //                                        as BindingListCollectionView;
                //if (view != null)
                //    view.CustomFilter = "UnitCost > " + minimumPrice.ToString();
            }
        }
        private void txtMinPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListCollectionView view = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource) as ListCollectionView;
            if (view != null)
            {
                decimal minimumPrice;
                if (Decimal.TryParse(txtMinPrice.Text, out minimumPrice) &&
                (filter != null))
                {
                    filter.MinimumPrice = minimumPrice;
                    view.Refresh();
                }
            }
        }

        private void cmdRemoveFilter_Click(object sender, RoutedEventArgs e)
        {
            ListCollectionView view = CollectionViewSource.GetDefaultView(lstProducts.ItemsSource) as ListCollectionView;
            if (view != null)
            {
                view.Filter = null;
            }
        }
    }
}
