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
    /// Interaction logic for DataTemplateList5.xaml
    /// </summary>
    public partial class DataTemplateList5 : Window
    {
        ProductStore mStore;
        public DataTemplateList5()
        {
            InitializeComponent();
            mStore = new ProductStore();
            lstProducts.ItemsSource = mStore.GetAll();
        }
    }
}
