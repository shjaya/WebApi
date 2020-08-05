using System;
using System.Collections.Generic;

namespace WebApiProject.Models
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            Item = new HashSet<Item>();
        }

        public long Id { get; set; }
        public long CategoryId { get; set; }
        public string Name { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Item> Item { get; set; }
    }
}
