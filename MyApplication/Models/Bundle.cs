using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.Models
{
    public class Bundle
    {
        public Bundle(string Name, List<string> Products, List<Rule> Rules, long Value)
        {
            this.Name = Name;
            this.Products = Products;
            this.Rules = Rules;
            this.Value = Value;
        }
        public string Name { get; set; }
        public List<string> Products { get; set; }
        public List<Rule> Rules { get; set; }
        public long Value { get; set; }
    }
}
