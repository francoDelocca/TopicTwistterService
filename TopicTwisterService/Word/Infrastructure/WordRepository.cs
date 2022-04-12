public class WordRepository : EfRepository<Word>, IWordRepository
{
    private readonly DataContext dataContext;

    public WordRepository(DataContext dataContext) : base(dataContext)
    {
        this.dataContext = dataContext;
    }
}