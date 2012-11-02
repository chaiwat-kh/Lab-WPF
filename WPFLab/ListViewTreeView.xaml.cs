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
using System.Data;
using WPFLab.Extension;

namespace WPFLab
{
    /// <summary>
    /// Interaction logic for ListViewTreeView.xaml
    /// </summary>
    public partial class ListViewTreeView : Window
    {
        ProductStore mStore;
        public ListViewTreeView()
        {
            InitializeComponent();
            mStore = new ProductStore();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataSet ds = GetCategoriesAndProductsDataSet();
            treeCategories.ItemsSource = ds.Tables["Categories"].DefaultView;
        }

        public DataSet GetCategoriesAndProductsDataSet()
        {
            DataSet ds = new DataSet();
            DataTable products = Convertor.ToDataTable(mStore.GetAll());
            products.TableName = "Products";
            DataTable categories = mStore.GetCategories();

            ds.Tables.Add(categories);
            ds.Tables.Add(products);

            DataRelation relCategoryProduct = new DataRelation("CategoryProduct",
                                                ds.Tables["Categories"].Columns["CategoryType"],
                                                ds.Tables["Products"].Columns["CategoryType"]);
            ds.Relations.Add(relCategoryProduct);

            return ds;
        }
    }
}
