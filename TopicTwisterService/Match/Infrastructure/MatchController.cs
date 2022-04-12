using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TopicTwisterService.Match.Application.DTO;
using TopicTwisterService.Player.Domain;
using TopicTwisterService.shared.Application;

[Route("api/[controller]")]
[ApiController]
public class MatchController : ControllerBase
{
    private readonly IMatchRepository _matchRepository;
    private readonly IPlayerRepository _playerRepository;
    private readonly IRoundRepository _roundRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IWordsEnteredByPlayerRepository _wordsEnteredByPlayerRepository;
    private readonly INotificationRepository _notificationRepository;

    public MatchController(IMatchRepository matchRepository, IPlayerRepository playerRepository,
        IRoundRepository roundRepository,
        ICategoryRepository categoryRepository, IWordsEnteredByPlayerRepository wordsEnteredByPlayerRepository, INotificationRepository notificationRepository)
    {
        _matchRepository = matchRepository;
        _playerRepository = playerRepository;
        _roundRepository = roundRepository;
        _categoryRepository = categoryRepository;
        _wordsEnteredByPlayerRepository = wordsEnteredByPlayerRepository;
        _notificationRepository = notificationRepository;
    }

    [HttpPut]
    public async Task<ActionResult<Response>> CreateNewMatch(Player Player)
    {
        FindOrCreateNewMatchUseCase findBrandNewPlayableMatchUseCase =
            new FindOrCreateNewMatchUseCase(_matchRepository, _playerRepository, _roundRepository);
        Response oResponse = new();
        Match match = new Match();
        try
        {
            match = await findBrandNewPlayableMatchUseCase.FindOrCreateNewMatch(Player.PlayerId);
            oResponse.data =
                oResponse.data = JsonConvert.SerializeObject(match,
                    new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            oResponse.success = 1;
        }
        catch (Exception ex)
        {
            oResponse.message = ex.ToString();
            oResponse.success = 0;
        }

        return oResponse;
    }


    [HttpPut("updateMatch")]
    public async Task<ActionResult<Response>> UpdateMatch(MatchUpdateDTO matchDTO)
    {
        Response oResponse = new();
        try
        {
            UpdateMatchUseCases updateMatchUseCase =
                new UpdateMatchUseCases(_matchRepository, _categoryRepository, _wordsEnteredByPlayerRepository);
            await updateMatchUseCase.UpdateMatch(matchDTO);

            CreateNotificationUserCase createNotificationUserCase = new
                CreateNotificationUserCase(_notificationRepository, _matchRepository);

            await createNotificationUserCase.CreateNotificatioIfDontExists(matchDTO.MatchId);
            oResponse.success = 1;
            oResponse.message = "Se guardo la partida éxitosamente";
        }
        catch (Exception ex)
        {
            oResponse.success = 0;
            oResponse.message = ex.Message;
        }

        return oResponse;
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Response>> DeleteMatch(int id)
    {
        Response oResponse = new();
        try
        {
            UpdateMatchUseCases modifyMatchUseCases =
                new UpdateMatchUseCases(_matchRepository, _categoryRepository, _wordsEnteredByPlayerRepository);
            await modifyMatchUseCases.DeleteMatch(id);
            oResponse.success = 1;
        }
        catch (Exception ex)
        {
            oResponse.message = ex.Message;
            oResponse.success = 0;
        }

        return oResponse;
    }

    [HttpGet("ListOfPendingMatches/{playerId}")]
    public async Task<ActionResult<Response>> ListOfPendingMatches(int playerId)
    {
        Response response = new();

        try
        {
            GetListOfFinishedAndPendingMatchesUseCases getListOfFinishedAndPendingMatchesUseCases =
                new GetListOfFinishedAndPendingMatchesUseCases(_matchRepository);


            var matches = await getListOfFinishedAndPendingMatchesUseCases.GetListOfPendingMatches(playerId);

            response.success = 1;

            var settings = new JsonSerializerSettings();
            settings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            response.data = JsonConvert.SerializeObject(matches);
        }
        catch (Exception ex)
        {
            response.message = ex.Message;
            response.success = 0;
        }

        return response;
    }

    [HttpGet("ListOfFinishedMatches/{playerId}")]
    public async Task<ActionResult<Response>> ListOfFinishedMatches(int playerId)

    {
        Response response = new();

        try
        {
            GetListOfFinishedAndPendingMatchesUseCases getListOfFinishedAndPendingMatchesUseCases =
                new GetListOfFinishedAndPendingMatchesUseCases(_matchRepository);

            var matches = await getListOfFinishedAndPendingMatchesUseCases.GetListOfFinishedMatches(playerId);

            response.success = 1;
            response.data = JsonConvert.SerializeObject(matches);
        }
        catch (Exception ex)
        {
            response.message = ex.Message;
            response.success = 0;
        }

        return response;
    }


    [HttpGet("{matchId}/winner")]
    public async Task<ActionResult<Response>> CalculateMatchWinner(int matchId)
    {
        Response oResponse = new();

        try
        {
            CalculateMatchWinnerUseCase calculateMatchWinnerUserCase =
                new CalculateMatchWinnerUseCase(_matchRepository);

            oResponse.data = JsonConvert.SerializeObject(
                await calculateMatchWinnerUserCase.CalculateMatchWinner(matchId),
                new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

            oResponse.success = 1;
        }
        catch (Exception ex)
        {
            oResponse.message = ex.Message;
        }

        return oResponse;
    }

    [HttpGet("{matchId}")]
    public async Task<ActionResult<Response>> GetMatch(int matchId)
    {
        Response oResponse = new();

        try
        {
            ContinueMatchUseCase continueMatchUseCase = new ContinueMatchUseCase(_matchRepository);
            var match = await continueMatchUseCase.GetMatch(matchId);

            oResponse.data = JsonConvert.SerializeObject(match);
            oResponse.success = 1;
        }
        catch (Exception ex)
        {
            oResponse.message = ex.Message;
        }

        return oResponse;
    }

    [HttpPut("tryclose")]
    public async Task<IActionResult> CloseMatchIfRequired(CloseMatchDTO closeMatchDTO)
    {        
        Response oResponse = new();
        CloseMatchUseCase closeMatchUseCase = new CloseMatchUseCase(_matchRepository);
        var closeMatchResponseDTO = new CloseMatchDTO();

        closeMatchResponseDTO.MatchId = closeMatchDTO.MatchId;
        closeMatchResponseDTO.Closed = await closeMatchUseCase.Close(closeMatchDTO.MatchId);

        oResponse.data = JsonConvert.SerializeObject(closeMatchResponseDTO);
        oResponse.success = 1;

        return Ok(oResponse);
    }
}