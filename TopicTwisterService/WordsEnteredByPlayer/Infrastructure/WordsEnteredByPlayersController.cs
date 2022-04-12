using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TopicTwisterService.shared.Application;

[Route("api/[controller]")]
[ApiController]
public class WordsEnteredByPlayersController : ControllerBase
{
    private readonly DataContext _context;

    private readonly IWordsEnteredByPlayerRepository wordsEnteredByPlayerRepository;

    public WordsEnteredByPlayersController(IWordsEnteredByPlayerRepository wordsEnteredByPlayerRepository)
    {
        this.wordsEnteredByPlayerRepository = wordsEnteredByPlayerRepository;
    }

    // GET: api/WordsEnteredByPlayers
    [HttpGet]
    public async Task<ActionResult<Response>> GetWordsEnteredByPlayer()
    {
        Response oResponse = new();

        try
        {
            var wordsEntered = await wordsEnteredByPlayerRepository.GetAll();
            oResponse.success = 1;
            oResponse.data = JsonConvert.SerializeObject(wordsEntered);
        }
        catch (Exception ex)
        {
            oResponse.success = 0;
            oResponse.message = ex.Message;
        }

        return oResponse;
    }

    // GET: api/WordsEnteredByPlayers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Response>> GetWordsEnteredByPlayer(int id)
    {
        Response oResponse = new();

        try
        {
            var wordsEnteredByPlayer = await wordsEnteredByPlayerRepository.GetById(id);
            oResponse.success = 1;
            oResponse.data = JsonConvert.SerializeObject(wordsEnteredByPlayer);
        }
        catch (Exception ex)
        {
            oResponse.success = 0;
            oResponse.message = ex.Message;
        }
        return oResponse;
    }

    // PUT: api/WordsEnteredByPlayers/5
    [HttpPut("{id}")]
    public async Task<ActionResult<Response>> PutWordsEnteredByPlayer(int id, WordsEnteredByPlayer wordsEnteredByPlayer)
    {
        Response oResponse = new();

        try
        {
            if (id != wordsEnteredByPlayer.WordsEnteredByPlayerId)
            {
                oResponse.success = 0;
                oResponse.data = "Bad request";
                return oResponse;
            }

            await wordsEnteredByPlayerRepository.Update(wordsEnteredByPlayer);

            oResponse.success = 1;
        }
        catch (Exception ex)
        {
            oResponse.success = 0;
            oResponse.message = ex.Message;
        }


        return oResponse;
    }

    // POST: api/WordsEnteredByPlayers
    [HttpPost]
    public async Task<ActionResult<Response>> PostWordsEnteredByPlayer(WordsEnteredByPlayer wordsEnteredByPlayer)
    {

        await wordsEnteredByPlayerRepository.Add(wordsEnteredByPlayer);

        return CreatedAtAction("GetWordsEnteredByPlayer", new { id = wordsEnteredByPlayer.WordsEnteredByPlayerId }, wordsEnteredByPlayer);
    }

    // DELETE: api/WordsEnteredByPlayers/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Response>> DeleteWordsEnteredByPlayer(int id)
    {
        Response oResponse = new();

        try
        {
            var wordsEnteredByPlayer = await wordsEnteredByPlayerRepository.GetById(id);
            if (wordsEnteredByPlayer == null)
            {
                oResponse.data = "bad request";
                oResponse.success = 0;
                return oResponse;
            }

            await wordsEnteredByPlayerRepository.Remove(wordsEnteredByPlayer);

            oResponse.success = 1;


        }
        catch (Exception ex)
        {
            oResponse.success = 0;
            oResponse.message = ex.Message;
        }
        return NoContent();
    }

    private async Task<bool> WordsEnteredByPlayerExists(int id)
    {
        return await wordsEnteredByPlayerRepository.Any(x => x.WordsEnteredByPlayerId == id);
    }
}

