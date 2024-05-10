using DataAccess;

var crud = new CrudOperations();
var cats = crud.CategoriesList();

foreach (var cat in cats)
{
    Console.WriteLine(cat.Name);
}