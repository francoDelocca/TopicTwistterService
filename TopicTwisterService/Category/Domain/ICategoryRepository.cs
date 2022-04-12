using System.Collections.Generic;
using System.Threading.Tasks;
using TopicTwisterService.shared.Domain;

public interface ICategoryRepository : IAsyncRepository<Category>
{
    IEnumerable<Category> GetRandomCategories(int amount);

    Task<Category> GetCategoryWithWords(int categoryId);
}