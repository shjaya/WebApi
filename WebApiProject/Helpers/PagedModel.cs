﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProject.Models;

namespace WebApiProject.Helpers
{
    public class PagedModel<DisplayItem>
    {
        /// <summary>
        /// The page number this page represents. 
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary> 
        /// The size of this page. 
        /// </summary> 
        public int PageSize { get; set; }

        /// <summary> 
        /// The total number of pages available. 
        /// </summary> 
        public int TotalNumberOfPages { get; set; }

        /// <summary> 
        /// The total number of records available. 
        /// </summary> 
        public int TotalNumberOfRecords { get; set; }        

        /// <summary> 
        /// The records this page represents. 
        /// </summary> 
        public IEnumerable<DisplayItem> Results { get; set; }
    }
}

