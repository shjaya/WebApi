using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiProject.Models
{
    public partial class Item
    {
        [Key]
        public long Id { get; set; }
        public long? SubCategoryId { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey("SubCategoryId")]
        [JsonIgnore]
        public virtual SubCategory SubCategory { get; set; }
    }
}
