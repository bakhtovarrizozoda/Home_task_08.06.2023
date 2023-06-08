using Domain.Dtos;

namespace Infrastructure.Services.CategoryService;

public interface ICategoryService
{
    List<CategoryDto> GetCategories();
    CategoryDto GetCategoryById(int Id);
    CategoryDto AddCategory(CategoryDto category);
    CategoryDto UpdateCategory(CategoryDto category);
    bool DeleteCategory(int Id);
}