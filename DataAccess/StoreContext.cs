using Domain;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DataAccess;


public class StoreContext : DbContext
{
    public DbSet<Categories> Categories { get; set; }
    public DbSet<Items> Items { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=1321;Database=KFCstore;Username=postgres;Password=lg100hav2");
    }

    public void InitialDataFilling()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
        using (var dbContext = new StoreContext())
        {
            var storeRepository = new StoreRepository();
            var categories = storeRepository.GetStore().PayLoad.Categories;
    
            foreach (var category in categories)
            {
                dbContext.Categories.Add(category);
                foreach (var item in category.Items)
                {
                    dbContext.Items.Add(item);
                }
            }
            dbContext.SaveChanges();
        }
    }
}