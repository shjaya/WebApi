﻿using System;
using System.Collections.Generic;

namespace WebApiProject.Models
{
    public partial class Item
    {
        public long Id { get; set; }
        public long SubCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}
