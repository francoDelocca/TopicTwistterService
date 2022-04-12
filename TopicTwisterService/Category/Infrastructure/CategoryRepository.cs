using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class CategoryRepository : EfRepository<Category>, ICategoryRepository
{
    private readonly DataContext _dataContext;

    public CategoryRepository(DataContext dataContext) : base(dataContext)
    {
        _dataContext = dataContext;
    }

    public IEnumerable<Category> GetRandomCategories(int amount)
    {
        Random rnd = new Random();
        var RandomsCategories = _dataContext.Categories.AsEnumerable().OrderBy((x => rnd.Next())).Take(amount).ToList();
        return RandomsCategories;
    }

    public async Task<Category> GetCategoryWithWords(int categoryId)
    {
        return await _dataContext.Categories.Include(c => c.Words).FirstAsync(c => c.CategoryId == categoryId);
    }
}