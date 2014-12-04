using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewyorkTimes_BestSellers.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public Double Price { get; set; }
    }
}
