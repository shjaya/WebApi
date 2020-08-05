using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiProject.Models
{
    public class PostItem
    {
        public long SubCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
