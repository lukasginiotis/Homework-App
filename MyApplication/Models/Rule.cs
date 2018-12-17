using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplication.Models
{
    public class Rule
    {
        public Rule(string Field, List<string> AcceptedValues)
        {
            this.Field = Field;
            this.AcceptedValues = AcceptedValues;
        }
        public string Field { get; set; }
        public List<string> AcceptedValues { get; set; }
    }
}
