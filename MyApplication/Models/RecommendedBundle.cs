using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.Models
{
    public class RecommendedBundle
    {
        public RecommendedBundle(long Id, string Age, string Student, string Income, string BundleName)
        {
            this.Id = Id;
            this.Age = Age;
            this.Student = Student;
            this.Income = Income;
            this.BundleName = BundleName;
        }
        public long Id { get; set; }
        public string Age { get; set; }
        public string Student { get; set; }
        public string Income { get; set; }
        public string BundleName { get; set; }
    }
}
