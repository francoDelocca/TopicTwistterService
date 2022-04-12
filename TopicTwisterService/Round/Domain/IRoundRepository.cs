using System.Collections.Generic;
using TopicTwisterService.shared.Domain;

public interface IRoundRepository : IAsyncRepository<Round>
{
    List<Category> GetRandomCategoriesToPlay();
}