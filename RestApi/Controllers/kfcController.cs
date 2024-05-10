using DataAccess;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers;

[ApiController]
[Route("v1/api/kfcMenu")]
public class kfcController : ControllerBase
{
    private readonly ICrudOperations _crud;

    public kfcController()
    {
        _crud = new CrudOperations();
    }

    [HttpPost("categories/add/{id}/{name}")]
    public  ActionResult AddCategory(long id, string name)
    {
        _crud.AddCategory(id, name);
        return Ok();
    }

    [HttpPost("items/add/{id}/{name}/{price}/{categoryId}")]
    public ActionResult AddItem(long id, string name, int price, long categoryId)
    {
        _crud.AddItem(id, name, price, categoryId);
        return Ok();
    }

    [HttpGet("categories/get/{id}")]
    public ActionResult<Categories> GetCategory(long id)
    {
        var category = _crud.GetCategory(id);
        if (category is null) return NotFound();
        return Ok(category);
    }

    [HttpGet("items/get/{id}")]
    public ActionResult<Items> GetItem(long id)
    {
        var item = _crud.GetItem(id);
        if (item is null) return NotFound();
        return Ok(item);
    }
    
    [HttpPut("categories/update/{id}/{newName}")]
    public ActionResult<Categories> UpdateCategory(long id, string newName)
    {
        var category = _crud.UpdateCategory(id, newName);
        if (category is null) return NotFound();
        return Ok(category);
    }
    
    [HttpPut("items/update/{id}/{newName}/{newPrice}")]
    public ActionResult<Items> UpdateItem(long id, string newName, int newPrice)
    {
        var item = _crud.UpdateItem(id, newName, newPrice);
        if (item is null) return NotFound();
        return Ok(item);
    }
    
    [HttpPost("categories/delete/{id}")]
    public ActionResult<long> DeleteCategory(long id)
    {
        var categoryId = _crud.DeleteCategory(id);
        if (categoryId is null) return NotFound();
        return Ok(categoryId);
    }

    [HttpPost("items/delete/{id}")]
    public ActionResult DeleteItem(long id)
    {
        var itemId = _crud.DeleteItem(id);
        if (itemId is null) return NotFound();
        return Ok(itemId);
    }
}