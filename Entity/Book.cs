using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Book : Base
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int WriterId { get; set; }
        public Writer writer { get; set; }
        public int CategoryId { get; set; }
        public Category category { get; set; }
    }
}
