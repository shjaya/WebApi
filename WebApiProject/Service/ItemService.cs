using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiProject.Models;
using WebApiProject.Repository;

namespace WebApiProject.Service
{
    /// <summary>
    /// Service class to call IRepository classes 
    /// </summary>
    public class ItemService : IService
    {
        private readonly IRepository<Item> itemRepo;
        private readonly IRepository<Category> categoryRepo;
        private readonly IRepository<SubCategory> subCategoryRepo;

        public ItemService(IRepository<Category> _categoryRepo, IRepository<SubCategory> _subCategoryRepo, IRepository<Item> _itemRepo)
        {
            categoryRepo = _categoryRepo;
            subCategoryRepo = _subCategoryRepo;
            itemRepo = _itemRepo;
        }

        public IEnumerable<DisplayItem> GetItemsByName(string name)
        {
            var displayItem = new List<DisplayItem>();
            if (!string.IsNullOrEmpty(name))
            {
                int subCategoryId = Convert.ToInt32(itemRepo.GetByName(name).SubCategoryId);
                int categoryId = Convert.ToInt32(subCategoryRepo.GetById(subCategoryId).CategoryId);

                var item = new DisplayItem
                {
                    CategoryName = categoryRepo.GetById(categoryId).Name,
                    SubCategoryName = subCategoryRepo.GetById(subCategoryId).Name,
                    ItemDescription = itemRepo.GetByName(name).Description,
                    ItemName = name
                };
                displayItem.Add(item);
            }
            else
            {
                var items = itemRepo.GetAll();
                foreach (var item in items)
                {
                    int subCategoryId = Convert.ToInt32(itemRepo.GetById(Convert.ToInt32(item.Id)).SubCategoryId);
                    int categoryId = Convert.ToInt32(subCategoryRepo.GetById(subCategoryId).CategoryId);

                    var newItem = new DisplayItem
                    {
                        CategoryName = categoryRepo.GetById(categoryId).Name,
                        SubCategoryName = subCategoryRepo.GetById(subCategoryId).Name,
                        ItemDescription = itemRepo.GetById(Convert.ToInt32(item.Id)).Description,
                        ItemName = itemRepo.GetById(Convert.ToInt32(item.Id)).Name
                    };
                    displayItem.Add(newItem);
                }
            }
            return displayItem;
        }

        public void PostItem(Item item)
        {
            itemRepo.Add(item);
            itemRepo.Save();
        }
    }
}
