using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Input;

namespace WPFLab
{
    public class DataCommands
    {
        private static RoutedUICommand requery;
        static DataCommands()
        {
            // Initialize the command.
            InputGestureCollection inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.R, ModifierKeys.Control, "Ctrl+R"));
            requery = new RoutedUICommand("Requery", "Requery", typeof(DataCommands), inputs);
        }
        public static RoutedUICommand Requery
        {
            get { return requery; }
        }
    }
}
