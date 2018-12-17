using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApplication.Models;

namespace MyApplication.Functions
{
    public class GetBundle
    {
        public static Bundle ReturnBundle(Answers item)
        {
            List<Bundle> bundles = new List<Bundle>();
            bundles = Populate.PopulateBundles();
            return BestBundle(item, bundles);
        }

        public static Bundle BestBundle(Answers item, List<Bundle> bundles)
        {
            foreach (Bundle bundle in bundles)
            {
                if (BundleIsEligible(item, bundle))
                {
                    return bundle;
                }
            }
            return null;
        }

        public static bool BundleIsEligible(Answers item, Bundle bundle)
        {
            foreach (Rule rule in bundle.Rules)
            {
                if (!PassesRule(item, rule))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool PassesRule(Answers item, Rule rule)
        {
            switch (rule.Field)
            {
                case "Age":
                    return (rule.AcceptedValues.Where(v => v == item.Age).Any()) ? true : false;
                case "Student":
                    return (rule.AcceptedValues.Where(v => v == item.Student).Any()) ? true : false;
                case "Income":
                    return (rule.AcceptedValues.Where(v => v == item.Income).Any()) ? true : false;
                default:
                    return false;
            }
        }
    }
}
