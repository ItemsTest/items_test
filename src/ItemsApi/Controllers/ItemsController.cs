using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ItemsApi.DataAccess;
using ItemsApi.Models;

namespace ItemsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        public ItemsController(){

        }

        [HttpGet("{page}")]
        public ActionResult<ItemsModel>  Get(int page=1)
        {
            var items = ItemHadler.GetItems(page,out decimal totalPages);
            return Ok(new ItemsModel{page = page,totalPages = totalPages,items = items,count = items.Count()});
            
        }
    }
}
