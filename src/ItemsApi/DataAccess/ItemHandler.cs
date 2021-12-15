using ItemsApi.Models;
using ItemsApi.EF;
using System.Linq;
using System.Collections.Generic;
using System;

namespace ItemsApi.DataAccess
{
    public static class ItemHadler
    {
        public static List<Item> GetItems(int page,out decimal totalPages)
        {
            var items = new List<Item>();
            int endItem = page*10; 
            int startItem = endItem - 9;
            using(var db = new ItemsDbContext())
            {
                // refractored change by casting items count as decimal
                decimal tp = (decimal)db.items.Count()/10;
                items = db.items.Where(r=>r.id>= startItem && r.id <= endItem).ToList();
                // refractored ceiling , was round initially
                totalPages =  Math.Ceiling(tp);

            }
            return items;
    
        }
    }

}