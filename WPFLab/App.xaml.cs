using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

using System.Windows.Threading;
using System.Threading;
using System.Globalization;

using WPFLab.Services;

namespace WPFLab
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {        
        private bool unsavedData = false;
        public bool UnsavedData
        {
            get { return unsavedData; }
            set { unsavedData = value; }
        }
        private static StoreDB storeDB = new StoreDB();
        public static StoreDB StoreDB
        {
            get { return storeDB; }
        }

        public App()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");
        }

        private List<Document> documents = new List<Document>();
        public List<Document> Documents
        {
            get { return documents; }
            set { documents = value; }
        }

        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled " + e.Exception.GetType().ToString() +
            " exception was caught and ignored.");
            e.Handled = true;
        }
            
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            UnsavedData = true;
        }

        protected override void OnSessionEnding(SessionEndingCancelEventArgs e)
        {
            base.OnSessionEnding(e);
            if (UnsavedData)
            {
                e.Cancel = true;
                MessageBox.Show(
                        "The application attempted to be closed as a result of " +
                        e.ReasonSessionEnding.ToString() +
                        ". This is not allowed, as you have unsaved data.");
            }
        }

    }
}
