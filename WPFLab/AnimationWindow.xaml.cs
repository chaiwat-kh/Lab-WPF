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
using System.Windows.Media.Animation;

namespace WPFLab
{
    /// <summary>
    /// Interaction logic for AnimationWindow.xaml
    /// </summary>
    public partial class AnimationWindow : Window
    {
        public AnimationWindow()
        {
            InitializeComponent();
        }

        private void cmdGrow_Click(object sender, RoutedEventArgs e)
        {
            double currentWidth = cmdGrow.Width;

            DoubleAnimation widthAnimation = new DoubleAnimation();
            widthAnimation.From = 160;
            widthAnimation.To = this.Width - 30;
            widthAnimation.Duration = TimeSpan.FromSeconds(5);
            widthAnimation.RepeatBehavior = new RepeatBehavior(2);

            DoubleAnimation heightAnimation = new DoubleAnimation();
            heightAnimation.From = 40;
            heightAnimation.To = this.Height - 50;
            heightAnimation.Duration = TimeSpan.FromSeconds(5);

            cmdGrow.BeginAnimation(Button.WidthProperty, widthAnimation);
            cmdGrow.BeginAnimation(Button.HeightProperty, heightAnimation);
                        
            cmdGrow.Width = currentWidth;
        }
    }
}
