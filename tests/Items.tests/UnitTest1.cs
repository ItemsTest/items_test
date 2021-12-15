using System;
using Xunit;
using ItemsApi.Controllers;
using System.Linq;
using ItemsApi.DataAccess;
using ItemsApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Items.tests
{
    public class Tests
    {
        ItemsController _controller;
        public Tests()
        {
          _controller = new ItemsController();
        }
        [Theory]
        [InlineData(1)]
        public void OnlyTen(int page)
        {
            var items = _controller.Get(page);
            //var items = ItemHandler.GetItems(1,out int totalPages);
            Assert.IsType<OkObjectResult>(items.Result);
            
            var item  =  items.Result as OkObjectResult;
            Assert.IsType<ItemsModel>(item.Value);
            var itemValues = item.Value as ItemsModel;
            int count = itemValues.count;
            Console.WriteLine(count);
            Assert.True(count <= 10);
        }
        [Theory]
        [InlineData(1)]
        public void NextVsBefore(int page)
        {
            var items = _controller.Get(page);
            int nextPage = page+1;
            var nextitems = _controller.Get(nextPage);
            //var items = ItemHandler.GetItems(1,out int totalPages);
            Assert.IsType<OkObjectResult>(items.Result);
            Assert.IsType<OkObjectResult>(nextitems.Result);
            var item  =  items.Result as OkObjectResult;
            var nextItem = nextitems.Result as OkObjectResult;
            Assert.IsType<ItemsModel>(item.Value);
            Assert.IsType<ItemsModel>(nextItem.Value);
            var beforeValues = item.Value as ItemsModel;
            var nextValues = nextItem.Value as ItemsModel;
            List<Item> beforeItems = beforeValues.items;
            List<Item> next = nextValues.items;
            var secondNotFirst = beforeItems.Except(next).ToList();
            var FirsNotSecond = next.Except(beforeItems).ToList();            
            Assert.True(secondNotFirst.Count() == beforeItems.Count() );
            Assert.True(FirsNotSecond.Count() ==  next.Count());
        }
    }
}
