using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiProject.Models
{
    public partial class DisplayItem
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }   
        
    }
}
