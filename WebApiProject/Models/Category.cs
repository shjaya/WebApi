using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace WebApiProject.Models
{
    public partial class Category
    {
        public Category()
        {
            SubCategory = new HashSet<SubCategory>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<SubCategory> SubCategory { get; set; }
    }
}
