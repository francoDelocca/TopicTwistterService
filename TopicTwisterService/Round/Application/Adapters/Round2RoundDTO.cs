using System.Collections.Generic;
using TopicTwisterService.Category.Application.DTO;

public class Round2RoundDTO
{
    public RoundDTO map(Round round)
    {
        RoundDTO roundDto = new RoundDTO();

        roundDto.RoundId = round.RoundId;
        roundDto.RoundLetter = round.RoundLetter;
        roundDto.Close = round.Close;
        roundDto.Winner = round.Winner;
        roundDto.CreatedAt = round.CreatedAt;
        foreach (var category in round.Categories)
        {
            CategoryDTO categoryDto = new CategoryDTO();
            categoryDto.Name = category.Name;
            categoryDto.CategoryId = category.CategoryId;
            roundDto.Categories.Add(categoryDto);
        }

        return roundDto;
    }


    public List<RoundDTO> map(List<Round> roundList)
    {
        List<RoundDTO> roundDTOList = new List<RoundDTO>();
        foreach (var round in roundList)
        {
            roundDTOList.Add(map(round));
        }

        return roundDTOList;
    }
}