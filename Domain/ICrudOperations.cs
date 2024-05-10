namespace Domain;

public interface ICrudOperations
{
    void AddCategory(long id, string name);
    void AddItem(long id, string name, int price, long categoryId);
    Categories? GetCategory(long id);
    Items? GetItem(long id);
    Categories? UpdateCategory(long id, string newName);
    Items? UpdateItem(long id, string newName, int newPrice);
    long? DeleteCategory(long id);
    long? DeleteItem(long id);
}