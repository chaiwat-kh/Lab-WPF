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
    /// Interaction logic for DocWindow.xaml
    /// </summary>
    public partial class DocWindow : Window
    {
        public DocWindow()
        {
            InitializeComponent();
        }

        private void cmdCreate_Click(object sender, RoutedEventArgs e)
        {            
            Document doc = new Document();
            doc.Owner = this;
            doc.Show();
            doc.Owner.Activate();
            ((App)Application.Current).Documents.Add(doc);

        }

        private void cmdUpdate_Click(object sender, RoutedEventArgs e)
        {
            foreach (Document doc in ((App)Application.Current).Documents)
            {
                doc.SetContent("Refreshed at " + DateTime.Now.ToLongTimeString() + ".");
            }
        }
    }
}
