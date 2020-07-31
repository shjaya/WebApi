using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.Models;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemsStoreContext _itemStoreContext;      
        
        public ItemsController(ItemsStoreContext storeContext)
        {
            _itemStoreContext = storeContext;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok(_itemStoreContext.Item.ToList());
        }

        // GET: api/Items/Office Chair
        [HttpGet("{name}")]
        public IActionResult ItemsByName(string name)
        {
            try
            {
                if(name == null)
                {
                    return Ok(_itemStoreContext.Item.ToList());
                }
                if (name.Length < 3)
                {
                    return NotFound(Constant.MinLengthWarning);
                }
                else
                {
                    var item = _itemStoreContext.Item
                        .SingleOrDefault(b => b.Name == name);

                    var subCategory = _itemStoreContext.SubCategory.SingleOrDefault(b => b.Id == item.SubCategoryId);
                    var category = _itemStoreContext.Category.SingleOrDefault(b => b.Id == subCategory.CategoryId);

                    var displayItem = new DisplayItem
                    {
                        CategoryName = category.Name,
                        SubCategoryName = subCategory.Name,
                        ItemDescription = item.Description,
                        ItemName = item.Name
                    };

                    if (displayItem == null)
                    {
                        return NotFound(Constant.NotFound);
                    }

                    return Ok(displayItem);
                }
            }
            catch(Exception ex)
            {
                return NotFound(Constant.NotFound);
            }
        }

        //POST: api/Items
       [HttpPost]
        public IActionResult Post([FromBody] Item item)
        {
            if (item is null)
            {
                return BadRequest("Item is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                _itemStoreContext.Item.Add(item);
                _itemStoreContext.SaveChanges();
            }
            catch(Exception ex)
            {
                return Ok(Constant.InValidData+ex.Message);
            }

            return Ok(Constant.ValidData);
        }
    }
}