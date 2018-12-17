using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApplication.Models;

namespace MyApplication.Data
{
    public class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (context.RecommendedBundles.Any())
            {
                return;
            }

            RecommendedBundle bundle = new RecommendedBundle(0, "18-64", "Yes", "0", "Junior Saver"); 

            context.RecommendedBundles.Add(bundle);

            context.SaveChanges();
        }
    }
}
