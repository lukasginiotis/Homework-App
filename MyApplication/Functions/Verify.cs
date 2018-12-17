using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApplication.Models;

namespace MyApplication.Functions
{
    public class Verify
    {
        public static string CheckValidity(WantedBundle item)
        {
            List<Rule> rules = new List<Rule>();
            bool account = false;
            foreach (Products product in item.Products)
            {
                if (product.ProductName.Contains("Account"))
                {
                    if (account) return "Bundle cannot contain more than one account";
                    else account = true;
                }
                string reasonCode = IsAvailable(product.ProductName, item.Products, item);
                if (reasonCode != "No reason") return reasonCode;  
            }
            return "No reason";
        }

        public static string IsAvailable(string product, List<Products> productList, WantedBundle item)
        {
            switch (product)
            {
                case "Current Account":
                    if ((item.Income != "1-12000") & (item.Income != "12001-40000") & (item.Income != "40001+")) return "Income is required for Current Account";
                    if ((item.Age != "18-64") & (item.Age != "65+")) return "You have to be at least 18 years old to qualify for Current Account";
                    break;
                case "Current Account Plus":
                    if (item.Income != "40001+") return "Income of at least 40001 is required for Current Account Plus";
                    if ((item.Age != "18-64") & (item.Age != "65+")) return "You have to be at least 18 years old to qualify for Current Account Plus";
                    break;
                case "Junior Saver Account":
                    if (item.Age != "0-17") return "Only people younger than 18 years old are eligible for Junior Saver Account";
                    break;
                case "Student Account":
                    if (item.Student != "Yes") return "Only students are eligible for Student Account";
                    if ((item.Age != "18-64") & (item.Age != "65+")) return "You have to be at least 18 years old to qualify for Student Account";
                    break;
                case "Debit Card":
                    if (!productList.Where(p => p.ProductName.Contains("Account")).Any()) return "An account is needed for debit card";
                    break;
                case "Credit Card":
                    if ((item.Income != "12001-40000") & (item.Income != "40001+")) return "Income of at least 12001 is required for Credit Card";
                    if ((item.Age != "18-64") & (item.Age != "65+")) return "You have to be at least 18 years old to qualify for Credit Card";
                    break;
                case "Gold Credit Card":
                    if (item.Income != "40001+") return "Income of at least 40001 is required for Gold Credit Card";
                    if ((item.Age != "18-64") & (item.Age != "65+")) return "You have to be at least 18 years old to qualify for Gold Credit Card";
                    break;
                default:
                    return "Wrong Product";
            }
            return "No reason";
        }
    }
}
