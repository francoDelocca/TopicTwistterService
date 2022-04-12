using System;

public class CreateRoundToPlayUseCase
{
    private readonly IRoundRepository _roundRepository;

    public CreateRoundToPlayUseCase(IRoundRepository roundRepository)
    {
        _roundRepository = roundRepository;
    }

    public Round CreateRoundToPlay()
    {
        return new()
        {
            Categories = _roundRepository.GetRandomCategoriesToPlay(),
            RoundLetter = GenerateRandomLetter()
        };
    }

    public char GenerateRandomLetter()
    {
        char[] charList = new[] { 'A', 'E', 'I', 'O', 'U' };
        Random rnd = new Random();
        return charList[rnd.Next(1, 5)];
    }
}