using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class GetRandomCategories
{
    private readonly ICategoryRepository categoryRepository;

    public GetRandomCategories(ICategoryRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }

    public IEnumerable<Category> GetListOfRandom(int amount)
    {     
        return categoryRepository.GetRandomCategories(amount);
    }
}

