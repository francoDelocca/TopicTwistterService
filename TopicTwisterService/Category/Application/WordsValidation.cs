using System.Threading.Tasks;

public class WordsValidation
{
    private readonly ICategoryRepository _categoryRepository;

    public WordsValidation(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public  bool IsValidWord(int categoryId, string word, string letter)
    {
        var category =  _categoryRepository.GetCategoryWithWords(categoryId).Result;
        
        return category.IsValidWord(word, letter);
    }
}