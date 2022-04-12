using System.Collections.Generic;
using System.Linq;

public class RoundRepository : EfRepository<Round>, IRoundRepository
{
    private readonly DataContext dataContext;

    public RoundRepository(DataContext dataContext) : base(dataContext)
    {
        this.dataContext = dataContext;
    }

    public List<Category> GetRandomCategoriesToPlay()
    {
        return dataContext.Categories.Take(5).ToList();
    }
}