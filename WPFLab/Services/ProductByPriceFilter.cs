using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPFLab.Models;

namespace WPFLab.Services
{
    public class ProductByPriceFilter
    {
        public decimal MinimumPrice
        {
            get;
            set;
        }
        public ProductByPriceFilter(decimal minimumPrice)
        {
            MinimumPrice = minimumPrice;
        }
        public bool FilterItem(Object item)
        {
            Product product = item as Product;
            if (product != null)
            {
                return (product.UnitCost > MinimumPrice);
            }
            return false;
        }
    }
}
