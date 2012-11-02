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
using System.ComponentModel;

namespace WPFLab
{
    /// <summary>
    /// Interaction logic for BackgroundWorkerTest.xaml
    /// </summary>
    public partial class BackgroundWorkerTest : Window
    {
        private BackgroundWorker backgroundWorker;

        public BackgroundWorkerTest()
        {
            InitializeComponent();
            backgroundWorker = ((BackgroundWorker)this.FindResource("backgroundWorker"));
        }
    }
}
