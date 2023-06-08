using Dapper;
using Domain.Dtos;
using Infrastructure.Cantext;
using Infrastructure.Services.CategoryService;

namespace Infrastructure.Services.CategoryService;

public class CategoryService : ICategoryService
{
    private readonly DapperContext _context;

    public CategoryService(DapperContext context)
    {
        _context = context;
    }
    public List<CategoryDto> GetCategories()
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select id as Id, category_name as CategoryName from categories order by id";
            var result = conn.Query<CategoryDto>(sql);
            return result.ToList();
        }
    }

    public CategoryDto GetCategoryById(int Id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"select id as Id, category_name as CategoryName from categories where id = @Id";
            var result = conn.QuerySingleOrDefault<CategoryDto>(sql, new {Id});
            return result;
        }
    }

    public CategoryDto AddCategory(CategoryDto category)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"insert into categories(category_name) values (@CategoryName) returning id";
            var result = conn.ExecuteScalar<int>(sql, category);
            category.Id = result;
            return category;
        }
    }

    public CategoryDto UpdateCategory(CategoryDto category)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"update categories set category_name = @CategoryName where id = @Id";
            var result = conn.Execute(sql, category);
            return category;
        }
    }

    public bool DeleteCategory(int Id)
    {
        using (var conn = _context.CreateConnection())
        {
            var sql = $"delete from categories where id = @Id";
            var result = conn.Execute(sql, new {Id});
            if (result > 0) return true;
            else return false;
        }
    }
}