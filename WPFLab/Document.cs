using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace WPFLab
{
    public class Document
    {
        private Window owner;
        private string detail;

        public Window Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public String Detail
        {
            get { return detail; }
            set { detail = value; }
        }

        public void Show()
        {
            owner.Show();
        }

        public void SetContent(string detail)
        {
            this.detail = detail;
        }
    }
}
