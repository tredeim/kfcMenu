using Domain;

namespace DataAccess;

public class CrudOperations : ICrudOperations
{
    
    public void AddCategory(long id, string name)
    {
        using (var dbContext = new StoreContext())
        {
            var category = new Categories()
            {
                Id = id,
                Name = name,
                Items = new List<Items>()
            };
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
        }
    }
    public void AddItem(long id, string name, int price, long categoryId)
    {
        using (var dbContext = new StoreContext())
        {
            var cat = dbContext.Categories.Find(categoryId);
            var item = new Items()
            {
                Id = id,
                Name = name,
                Price = price,
                Categories = cat,
            };

            dbContext.Items.Add(item);
            dbContext.SaveChanges();
        }
    }

    public Categories? GetCategory(long id)
    {
        using (var dbContext = new StoreContext())
        {
            return dbContext.Categories.Find(id);
        }
    }

    public Items? GetItem(long id)
    {
        using (var dbContext = new StoreContext())
        {
            return dbContext.Items.Find(id);
        }
    }
    
    public Categories? UpdateCategory(long id, string newName)
    {
        using (var dbContext = new StoreContext())
        {
            var category = dbContext.Categories.Find(id);
            if (category != null)
            {
                category.Name = newName;
                dbContext.SaveChanges();
            }
            
            return category;
        }
    }
    
    public Items? UpdateItem(long id, string newName, int newPrice)
    {
        using (var dbContext = new StoreContext())
        {
            var item = dbContext.Items.Find(id);
            if (item != null)
            {
                item.Name = newName;
                item.Price = newPrice;
                dbContext.SaveChanges();
            }
            return item;
        }
    }

    public long? DeleteCategory(long id)
    {
        using (var dbContext = new StoreContext())
        {
            var category = GetCategory(id);
            if (category != null)
            {
                dbContext.Categories.Remove(category);
                dbContext.SaveChanges();
                return id;
            }
            
            return null;
        }
    }

    public long? DeleteItem(long id)
    {
        using (var dbContext = new StoreContext())
        {
            var item = GetItem(id);
            if (item != null)
            {
                dbContext.Items.Remove(item);
                dbContext.SaveChanges();
                return id;
            }

            return null;
        }
    }
}