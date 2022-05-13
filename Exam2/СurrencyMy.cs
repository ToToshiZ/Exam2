using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2
{
    internal class СurrencyMy
    {
        public string title { get; set; }
        public double description { get; set; }

       public СurrencyMy(string title, double description)
        {
            this.title = title;
            this.description = description; 
        }
    }
}
