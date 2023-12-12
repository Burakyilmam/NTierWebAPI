using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core
{
    public class Base
    {
        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        [JsonIgnore]
        public bool Statu { get; set; }
        [JsonIgnore]
        public DateTime CreateDate { get; set; }
        [JsonIgnore]
        public DateTime? UpdateDate { get; set; }
    }
}
