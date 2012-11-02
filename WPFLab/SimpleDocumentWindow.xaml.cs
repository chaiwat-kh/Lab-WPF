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
    /// Interaction logic for SimpleDocumentWindow.xaml
    /// </summary>
    public partial class SimpleDocumentWindow : Window
    {
        private bool isDirty = false;

        public SimpleDocumentWindow()
        {
            InitializeComponent();
            // Create the binding.
            CommandBinding binding = new CommandBinding(ApplicationCommands.New);
            // Attach the event handler.
            binding.Executed += NewCommand_Executed;
            // Register the binding.
            this.CommandBindings.Add(binding);

            binding = new CommandBinding(ApplicationCommands.Save);
            binding.Executed += SaveCommand_Executed;
            binding.CanExecute += SaveCommand_CanExecute;
            this.CommandBindings.Add(binding);

            CommandBinding commandBinding = new CommandBinding(ApplicationCommands.Cut, null, SuppressCommand);
            txt.CommandBindings.Add(commandBinding);

            // disable key controls 
            //KeyBinding keyBinding = new KeyBinding(ApplicationCommands.NotACommand, Key.C, ModifierKeys.Control);
            //txt.InputBindings.Add(keyBinding);
        }

        private void SuppressCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = false;
            e.Handled = true;            
        }

        private void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("New command triggered by " + e.Source.ToString());
        }
        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            isDirty = false;
        }
        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isDirty;
        }

        private void txt_TextChanged(object sender, RoutedEventArgs e)
        {
            isDirty = true;
        }

        private void RequeryCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

    }
}
