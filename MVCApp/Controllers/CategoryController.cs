using Domain.Dtos;
using Infrastructure.Services.CategoryService;
using Microsoft.AspNetCore.Mvc;

namespace MVCApp.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var result = _categoryService.GetCategories();
        return View(result);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        return View(new CategoryDto());
    }

    [HttpPost]
    public IActionResult Create(CategoryDto category)
    {
        if (ModelState.IsValid)
        {
            _categoryService.AddCategory(category);
            return RedirectToAction("Index");
        }
        else
        {
            return View(category);
        }
    }
    
    [HttpGet]
    public IActionResult Update(int id)
    {
        var updat = _categoryService.GetCategoryById(id);
        var result = (new CategoryDto()
        {
            Id = updat.Id,
            CategoryName = updat.CategoryName
        });
        return View(result);
    }

    [HttpPost]
    public IActionResult Update(CategoryDto category)
    {
        if (ModelState.IsValid)
        {
            _categoryService.UpdateCategory(category);
            return RedirectToAction("Index");
        }
        else
        {
            return View(category);
        }
    }
    
    public  IActionResult Delete(int id)  
    {
        _categoryService.DeleteCategory(id);
        return RedirectToAction("Index");  
    }
}