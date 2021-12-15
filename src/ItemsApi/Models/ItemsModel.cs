using System.Collections.Generic;
namespace ItemsApi.Models

{
    public class ItemsModel
    {
        public List<Item> items{get;set;}
        public decimal totalPages{get;set;}
        public int page{get;set;}
        public int count {get;set;}

    }

}