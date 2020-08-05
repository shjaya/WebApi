using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProject.Models;

namespace WebApiProject.Service
{
    public interface IService
    {
        IEnumerable<DisplayItem> GetItemsByName(string name);
        void PostItem(Item item);                
    }
}
