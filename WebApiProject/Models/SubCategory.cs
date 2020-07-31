using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiProject.Models
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            Item = new HashSet<Item>();
        }
        [Key]
        public long Id { get; set; }
        public long? CategoryId { get; set; }
        public string Name { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [JsonIgnore]
        public virtual ICollection<Item> Item { get; set; }
    }
}
