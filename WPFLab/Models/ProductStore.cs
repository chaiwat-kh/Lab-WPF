using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;

namespace WPFLab.Models
{
    public class ProductStore
    {
        public IList<Category> GetCategoriesList()
        {
            return new List<Category>
            {
                new Category{CategoryType="1",Description="Mobile"},
                new Category{CategoryType="2",Description="Car"},
                new Category{CategoryType="3",Description="Computer"}
            };
        }
        public IList<Product> GetAll()
        {
            return new List<Product>
            {
                new Product{ModelNumber = "PD1", ModelName= "Apple", 
                    Description = "iPhone5", UnitCost = 25000, 
                    CategoryType="1", ProductImage = "iphone5.jpg",
                    DateAdded = DateTime.Now},
                new Product{ModelNumber = "PD2", ModelName= "BMW", 
                    Description = "BMW3", UnitCost = 5000000, 
                    CategoryType="2", ProductImage = "bmw.jpg",
                    DateAdded = DateTime.Now},
                new Product{ModelNumber = "PD3", ModelName= "iMac", 
                    Description = "Mac2.4", UnitCost = 70000, 
                    CategoryType="3", ProductImage = "iMac.jpg",
                    DateAdded = DateTime.Now},
                new Product{ModelNumber = "PD4", ModelName= "Toyota", 
                    Description = "Camry", UnitCost = 1000000, 
                    CategoryType="2", ProductImage = "camry.jpg",
                    DateAdded = DateTime.Now},
                new Product{ModelNumber = "PD5", ModelName= "Sony", 
                    Description = "Vaio", UnitCost = 50000, 
                    CategoryType="3", ProductImage = "vaio.jpg",
                    DateAdded = DateTime.Now},
                new Product{ModelNumber = "PD6", ModelName= "Samsung", 
                    Description = "Galaxy Note 10.1", UnitCost = 23000, 
                    CategoryType="1", ProductImage = "galaxy.jpg",
                    DateAdded = DateTime.Now},
            };
        }

        public IList<Product> GetByNumber(string number)
        {
            var product = GetAll();
            var findProd = from p in product where p.ModelNumber.Contains(number) select p;
            return findProd.ToList();
        }

        public DataTable GetCategories()
        {
            DataTable cate = new DataTable("Categories");
            cate.Columns.Add("CategoryType");
            
            DataRow row = cate.NewRow();
            row[0] = "Mobile";
            cate.Rows.Add(row);

            row = cate.NewRow();
            row[0] = "Car";
            cate.Rows.Add(row);

            row = cate.NewRow();
            row[0] = "Computer";
            cate.Rows.Add(row);

            return cate;
        }

        
    }
}
