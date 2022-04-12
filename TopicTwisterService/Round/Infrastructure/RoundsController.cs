using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TopicTwisterService.Round.Application;
using TopicTwisterService.Round.Application.DTO;
using TopicTwisterService.shared.Application;

[Route("api/[controller]")]
[ApiController]
public class RoundsController : ControllerBase
{
    private readonly DataContext _context;

    private readonly IMatchRepository _matchRepository;
    private readonly IRoundRepository _roundRepository;

    public RoundsController(DataContext context, IMatchRepository matchRepository, IRoundRepository roundRepository)
    {
        _context = context;
        this._matchRepository = matchRepository;
        this._roundRepository = roundRepository;
    }

    // GET: api/Rounds
    [HttpGet]
    public async Task<ActionResult<Response>> GetRounds()
    {
        Response oResponse = new();

        try
        {
            oResponse.data = JsonConvert.SerializeObject(await _context.Rounds.ToListAsync(),
                new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            oResponse.success = 1;
        }
        catch (Exception ex)
        {
            oResponse.success = 0;
            oResponse.message = ex.Message;
        }

        return oResponse;
    }

    // GET: api/Rounds/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Response>> GetRound(int id)
    {
        Response oResponse = new();

        try
        {
            oResponse.data = JsonConvert.SerializeObject(await _context.Rounds.FindAsync(id),
                new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            oResponse.success = 1;
        }
        catch (Exception ex)
        {
            oResponse.success = 0;
            oResponse.message = ex.Message;
        }

        return oResponse;
    }

    [HttpGet("{roundId}/{playerId}/OpponentPlayed")]
    public async Task<ActionResult<Response>> OpponentAlreadyPlayed(int roundId, int playerId)
    {
        Response oResponse = new();
        int opponentPlayerId = 0;
        try
        {
            var round = await _context.Rounds.Include(w => w.WordEnteredByPlayers)
                .FirstOrDefaultAsync(r => r.RoundId == roundId);
            //  var match = await _context.Matches.FindAsync(round.MatchId);

            var match = await _context.Matches.Include(p => p.PlayerOne).Include(p2 => p2.PlayerTwo)
                .FirstOrDefaultAsync(m => m.MatchId == round.MatchId);

            if (match.PlayerOne.PlayerId == playerId)
            {
                if (match.PlayerTwo != null)
                {
                    opponentPlayerId = match.PlayerTwo.PlayerId;
                }
                else
                {
                    oResponse.data = JsonConvert.SerializeObject(false);
                    oResponse.success = 1;
                    return oResponse;
                }
            }
            else
            {
                opponentPlayerId = match.PlayerOne.PlayerId;
            }


            List<WordsEnteredByPlayer> opponentWords =
                round.WordEnteredByPlayers.Where(word => word.PlayerId == opponentPlayerId).ToList();

            if (opponentWords == null || (opponentWords.Count == 0))
            {
                oResponse.data = JsonConvert.SerializeObject(false);
            }
            else
            {
                oResponse.data = JsonConvert.SerializeObject(true);
            }

            oResponse.success = 1;
        }
        catch (Exception ex)
        {
            oResponse.success = 0;
            oResponse.message = ex.Message;
        }

        return oResponse;
    }


    // PUT: api/Rounds/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<ActionResult<Response>> PutRound(int id, Round round)
    {
        Response oResponse = new();

        try
        {
            if (id != round.RoundId)
            {
                oResponse.success = 0;
                oResponse.message = "Round no existe.";
                return oResponse;
            }

            _context.Entry(round).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            oResponse.success = 1;
        }
        catch (Exception ex)
        {
            oResponse.success = 0;
            oResponse.message = ex.Message;
        }

        return oResponse;
    }

    // POST: api/Rounds
    [HttpPost]
    public async Task<ActionResult<Response>> CreateRound(CreateNewRoundDTO createNewRoundDTO)
    {
        var match = await _matchRepository.GetFullMatch(createNewRoundDTO.MatchId);
        CreateRoundToPlayUseCase createRoundToPlayUseCase = new(_roundRepository);
        var round = createRoundToPlayUseCase.CreateRoundToPlay();
        match.Rounds.Add(round);

        await _matchRepository.Update(match);

        Round2RoundDTO mapper = new Round2RoundDTO();
        
        
        var response = JsonConvert.SerializeObject(mapper.map(round),
            new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });

        return Ok(response);
    }

    // DELETE: api/Rounds/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Response>> DeleteRound(int id)
    {
        Response oResponse = new();

        try
        {
            var round = await _context.Rounds.FindAsync(id);
            if (round == null)
            {
                oResponse.success = 0;
                oResponse.message = "no se encontró el round";
                return oResponse;
            }

            _context.Rounds.Remove(round);
            await _context.SaveChangesAsync();
            oResponse.success = 0;
        }
        catch (Exception ex)
        {
            oResponse.success = 0;
            oResponse.message = ex.Message;
        }

        return oResponse;
    }

    [HttpGet("{roundId}/winner")]
    public async Task<ActionResult<Response>> CalculateRoundWinner(int roundId)
    {
        Response oResponse = new();

        try
        {
            Round round = await _context.Rounds.Where(x => x.RoundId == roundId).Include(r => r.Winner)
                .Include(r => r.Match).ThenInclude(r => r.PlayerOne).Include(r => r.Match).ThenInclude(r => r.PlayerTwo)
                .Include(r => r.WordEnteredByPlayers).ThenInclude(r => r.Category).ThenInclude(r => r.Words)
                .Include(r => r.Categories).FirstOrDefaultAsync();

            var winner = round.CalculateRoundWinner();
            var playerWinner = await _context.Players.FindAsync(winner);

            round.Winner = playerWinner;

            oResponse.data =
                JsonConvert.SerializeObject(playerWinner);
            oResponse.success = 1;

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            oResponse.success = 0;
            oResponse.message = ex.Message;
        }

        return oResponse;
    }

    [HttpPut("close")]
    public async Task<ActionResult<Response>> CloseRound(RoundToCloseDTO round)
    {
        CloseRoundUseCase closeRoundUseCase = new CloseRoundUseCase(_context);
        await closeRoundUseCase.CloseRound(round.RoundId);
        Response oResponse = new();
        try
        {
            oResponse.data = "Se cerró el round correctamente";
            oResponse.success = 1;
        }
        catch (Exception ex)
        {
            oResponse.success = 0;
            oResponse.message = ex.Message;
        }

        return oResponse;
    }

    [HttpGet("{roundId}/player/{playerId}/validatedwords")]
    public async Task<ActionResult<Response>> GetRoundValidatedWords(int roundId, int playerId)
    {
        Response oResponse = new();

        Round round = await _context.Rounds.Include(x => x.WordEnteredByPlayers).SingleAsync(x => x.RoundId == roundId);
        GetValidateWordsForUserUseCase getValidateWordsForUserUseCase = new GetValidateWordsForUserUseCase(_context);
        try
        {
            oResponse.data =
                JsonConvert.SerializeObject(
                    getValidateWordsForUserUseCase.GetValidatedWordsFromPlayer(playerId, roundId));
            oResponse.success = 1;
        }
        catch (Exception ex)
        {
            oResponse.success = 0;
            oResponse.message = ex.Message;
        }

        return oResponse;
    }


    [HttpGet("{roundId}/enteredWords/{playerId}")]
    public async Task<ActionResult<Response>> GetEnteredWords(int roundId, int playerId)
    {
        Response oResponse = new();

        Round round = await _context.Rounds.Include(x => x.WordEnteredByPlayers).SingleAsync(x => x.RoundId == roundId);

        try
        {
            oResponse.data = JsonConvert.SerializeObject(round.GetEnteredWordsFromPlayer(playerId));
            oResponse.success = 1;
        }
        catch (Exception ex)
        {
            oResponse.success = 0;
            oResponse.message = ex.Message;
        }

        return oResponse;
    }

    private bool RoundExists(int id)
    {
        return _context.Rounds.Any(e => e.RoundId == id);
    }
}