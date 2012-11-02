using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;

namespace WPFLab.Models
{
    public class Product : INotifyPropertyChanged, IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        public Product()
        {
        }

        private string modelNumber;
        public string ModelNumber
        {
            get { return modelNumber; }
            set { 
                modelNumber = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ModelNumber"));
            }
        }
        // Error handling takes place here.
        public string this[string propertyName]
        {
            get
            {
                if (propertyName == "ModelNumber")
                {
                    bool valid = true;
                    foreach (char c in ModelNumber)
                    {
                        if (!Char.IsLetterOrDigit(c))
                        {
                            valid = false;
                            break;
                        }
                    }
                    if (!valid)
                        return "The ModelNumber can only contain letters and numbers.";
                }
                return null;
            }
        }
        // WPF doesn't use this property.
        public string Error
        {
            get { return null; }
        }


        private string modelName;
        public string ModelName
        {
            get { return modelName; }
            set { 
                modelName = value;
                
            }
        }
        private decimal unitCost;
        public decimal UnitCost
        {
            get { return unitCost; }
            set {
                if (value < 0)
                    throw new ArgumentException("UnitCost cannot be negative.");
                else
                {
                    unitCost = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("UnitCost"));
                }
            }
        }
        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private string categoryType;
        public string CategoryType
        {
            get { return categoryType; }
            set { categoryType = value; }
        }

        private string productImage;
        public string ProductImage
        {
            get { return productImage; }
            set { productImage = value; }
        }

        private DateTime dateAdded;
        public DateTime DateAdded
        {
            get { return dateAdded; }
            set { dateAdded = value; }
        }   

        public Product(string modelNumber, string modelName, decimal unitCost, string description)
        {
            ModelNumber = modelNumber;
            ModelName = modelName;
            UnitCost = unitCost;
            Description = description;
            ProductImage = "Tattoo_wing.jpg";
        }

    }
    public class Category
    {
        private string categoryType;
        public string CategoryType
        {
            get { return categoryType; }
            set { categoryType = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
