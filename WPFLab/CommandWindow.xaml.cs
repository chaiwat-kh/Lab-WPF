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
    /// Interaction logic for CommandWindow.xaml
    /// </summary>
    public partial class CommandWindow : Window
    {
        private bool isDirty = false;

        public CommandWindow()
        {
            InitializeComponent();

            // Create the binding.
            CommandBinding binding = new CommandBinding(ApplicationCommands.New);
            // Attach the event handler.
            binding.Executed += NewCommand_Executed;
            // Register the binding.
            this.CommandBindings.Add(binding);

            this.CommandBindings[0].Command.Execute(null);
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("New command triggered by " + e.Source.ToString());
        }
    }
}
