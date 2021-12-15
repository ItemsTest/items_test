using Microsoft.EntityFrameworkCore;
using ItemsApi.Models;

namespace ItemsApi.EF{
    public class ItemsDbContext:DbContext
    {
        
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     {
            string con =  "Server=castor.db.elephantsql.com;Port=5432;Database=cjzjqrud;User Id=cjzjqrud;Password=Cw2BpDL9VwNxOPEjuqXNgAOmLdz81Co9;Command Timeout=0";
            optionsBuilder.UseNpgsql(con);
            base.OnConfiguring(optionsBuilder);
     }
    
     public DbSet<Item> items{get;set;}

    }
   
}