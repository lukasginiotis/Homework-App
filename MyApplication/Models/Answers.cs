using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.Models
{
    public class Answers
    {
        public Answers(long Id, string Age, string Student, string Income)
        {
            this.Id = Id;
            this.Age = Age;
            this.Student = Student;
            this.Income = Income;
        }
        public long Id { get; set; }
        public string Age { get; set; }
        public string Student { get; set; }
        public string Income { get; set; }
    }
}
