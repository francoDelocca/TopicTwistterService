public class WordsEnteredByPlayerRepository : EfRepository<WordsEnteredByPlayer>, IWordsEnteredByPlayerRepository
{
    readonly DataContext dataContext;


    public WordsEnteredByPlayerRepository(DataContext dataContext) : base(dataContext)
    {
        this.dataContext = dataContext;
    }
}