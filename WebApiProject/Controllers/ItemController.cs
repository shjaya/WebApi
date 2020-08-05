using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiProject.Helpers;
using WebApiProject.Models;
using WebApiProject.Service;

namespace WebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IService _service;
        public ItemController(IService service)
        {
            _service = service;
        }

        /// <summary>
        /// Return the list or single items filtered by the name parameter passed.
        /// </summary>
        /// <param name="name">Item name</param>
        /// <returns></returns>
        // GET: api/Item/Office Chair
        [HttpGet()]
        [Route("ItemsByName")]
        public IActionResult ItemsByName(string name, int page = 1)
        {
            try
            {
                if (!string.IsNullOrEmpty(name) && name.Length < 3)
                    return NotFound(Constant.MinLengthWarning);
                else
                    return Ok(PagedResults.CreatePagedResults<DisplayItem>(_service.GetItemsByName(name), page));
            }
            catch (Exception ex)
            {
                return NotFound(Constant.NotFound + ex.Message);
            }
        }

        /// <summary>
        /// An item is posted and saved in the database.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        //POST: api/Item
        [HttpPost]
        public IActionResult Post([FromBody] PostItem postItem)
        {
            if (postItem is null)
            {
                return BadRequest(Constant.BadRequest);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            try
            {
                var item = new Item();
                item.Name = postItem.Name;
                item.SubCategoryId = postItem.SubCategoryId;
                item.Description = postItem.Description;

                _service.PostItem(item);
            }
            catch (Exception ex)
            {
                return Ok(Constant.InValidData + ex.Message);
            }
            return Ok(Constant.ValidData);
        }

    }
}