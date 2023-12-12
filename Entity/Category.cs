using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entity
{
    public class Category : Base
    {
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
