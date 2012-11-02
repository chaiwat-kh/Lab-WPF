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
    /// Interaction logic for StyleWindow.xaml
    /// </summary>
    public partial class StyleWindow : Window
    {
        public StyleWindow()
        {
            InitializeComponent();
        }

        private void cmd3_Click(object sender, RoutedEventArgs e)
        {
            cmd3.Style = (Style)cmd.FindResource("BigFontButtonStyle");

        }
        private void element_MouseEnter(object sender, MouseEventArgs e)
        {
            ((TextBlock)sender).Background =
            new SolidColorBrush(Colors.LightGoldenrodYellow);
        }
        private void element_MouseLeave(object sender, MouseEventArgs e)
        {
            ((TextBlock)sender).Background = null;
        }
    }
}
