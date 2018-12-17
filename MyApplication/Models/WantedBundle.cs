using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.Models
{
    public class WantedBundle
    {
        public WantedBundle(long Id, string Age, string Student, string Income, List<Products> Products)
        {
            this.Id = Id;
            this.Age = Age;
            this.Student = Student;
            this.Income = Income;
            this.Products = Products;
        }
        public long Id { get; set; }
        public string Age { get; set; }
        public string Student { get; set; }
        public string Income { get; set; }
        public List<Products> Products { get; set; }
    }

    public class Products
    {
        public Products(int Id, string ProductName)
        {
            this.Id = Id;
            this.ProductName = ProductName;
        }
        public int Id { get; set; }
        public string ProductName { get; set; }
    }
}
