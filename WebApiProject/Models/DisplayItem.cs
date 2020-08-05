using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiProject.Models
{
    /// <summary>
    /// Display the list or single item details
    /// </summary>
    public partial class DisplayItem
    {
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }    
           
    }
}
