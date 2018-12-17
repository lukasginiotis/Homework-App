using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApplication.Models;

namespace MyApplication.Functions
{
    public class Populate
    {
        public static List<Bundle> PopulateBundles()
        {
            List<Bundle> bundles = GetBundles();
            List<Bundle> sortedBundles = bundles.OrderByDescending(b => b.Value).ToList();
            foreach (Bundle bundle in sortedBundles)
            {
                bundle.Rules = GetRules(bundle);
            }
            return sortedBundles;
        }

        public static List<Bundle> GetBundles()
        {
            List<Bundle> bundles = new List<Bundle>();
            List<Rule> rules = new List<Rule>();

            List<string> products = new List<string>{ "Junior Saver Account" };
            bundles.Add(new Bundle("Junior Saver", products, rules, 0));

            products = new List<string> { "Student Account", "Debit Card", "Credit Card" };
            bundles.Add(new Bundle("Student", products, rules, 0));

            products = new List<string> { "Current Account", "Debit Card"};
            bundles.Add(new Bundle("Classic", products, rules, 1));

            products = new List<string> { "Current Account", "Debit Card", "Credit Card"};
            bundles.Add(new Bundle("Classic Plus", products, rules, 2));

            products = new List<string> { "Current Account Plus", "Debit Card", "Gold Credit Card" };
            bundles.Add(new Bundle("Gold", products, rules, 3));

            return bundles;
        }

        public static List<Rule> GetRules(Bundle bundle)
        {
            List<Rule> rules = new List<Rule>();

            switch (bundle.Name)
            {
                case "Junior Saver":
                    rules.Add(new Rule("Age", new List<string> { "0-17" }));
                    break;
                case "Student":
                    rules.Add(new Rule("Age", new List<string> { "18-64", "65+" }));
                    rules.Add(new Rule("Student", new List<string> { "Yes" }));
                    break;
                case "Classic":
                    rules.Add(new Rule("Age", new List<string> { "18-64", "65+" }));
                    rules.Add(new Rule("Income", new List<string> { "1-12000", "12001-40000", "40001+"}));
                    break;
                case "Classic Plus":
                    rules.Add(new Rule("Age", new List<string> { "18-64", "65+" }));
                    rules.Add(new Rule("Income", new List<string> { "12001-40000", "40001+" }));
                    break;
                case "Gold":
                    rules.Add(new Rule("Age", new List<string> { "18-64", "65+" }));
                    rules.Add(new Rule("Income", new List<string> { "40001+" }));
                    break;
                default:
                    break;
            }
            return rules;
        }
    }
}
