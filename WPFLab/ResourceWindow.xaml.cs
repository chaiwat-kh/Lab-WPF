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
    /// Interaction logic for ResourceWindow.xaml
    /// </summary>
    public partial class ResourceWindow : Window
    {
        public ResourceWindow()
        {
            InitializeComponent();
            //ImageBrush brush = (ImageBrush)this.Resources["TileBrush"];
            //brush.Viewport = new Rect(0, 0, 5, 5);

            //this.Resources["TileBrush"] = new SolidColorBrush(Colors.LightBlue);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var cmd = (Button)sender;
            ImageBrush brush = (ImageBrush)this.Resources["TileBrush"];
            brush.Viewport = new Rect(0, 0, 5, 5);

            this.Resources["TileBrush"] = new SolidColorBrush(Colors.LightBlue);
        }
    }
}
