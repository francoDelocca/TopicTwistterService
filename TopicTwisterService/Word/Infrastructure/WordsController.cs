using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TopicTwisterService.shared.Application;

[Route("api/[controller]")]
[ApiController]
public class WordsController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IWordRepository wordRepository;

    public WordsController(IWordRepository wordRepository)
    {
        this.wordRepository = wordRepository;
    }

    // GET: api/Words
    [HttpGet]
    public async Task<ActionResult<Response>> GetWords()
    {
        Response oResponse = new();

        try
        {
            var words = await wordRepository.GetAll();
            oResponse.data = JsonConvert.SerializeObject(words);
            oResponse.success = 1;
        }
        catch (Exception ex)
        {
            oResponse.success = 0;
            oResponse.message = ex.Message;
        }

        return oResponse;
    }

    // GET: api/Words/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Response>> GetWord(int id)
    {
        Response oResponse = new();

        try
        {
            var word = await wordRepository.GetById(id);

            if (word == null)
            {
                oResponse.message = "no se encontró la palabra";
                oResponse.success = 0;
            }

            oResponse.data = JsonConvert.SerializeObject(word);
            oResponse.success = 1;
        }
        catch (Exception ex)
        {
            oResponse.success = 0;
            oResponse.message = ex.Message;
        }

        return oResponse;

    }


    //DEPRECATED
    //
    //
    //
    //// GET: api/Words/5/20
    //[HttpGet("wordforcategory/{categoryId}")]
    //public async Task<ActionResult<Response>> GetWordsForCategory(int categoryId)
    //{
    //    Response oResponse = new();

    //    try
    //    {
    //        Word word = await _context.Words
    //            .FirstOrDefaultAsync(w => w.Categories.Any(c => c.CategoryId == categoryId));

    //        oResponse.data = JsonConvert.SerializeObject(word);
    //        oResponse.success = 1;
    //    }
    //    catch (Exception ex)
    //    {
    //        oResponse.success = 0;
    //        oResponse.message = ex.Message;
    //    }
    //    return oResponse;
    //}

    // PUT: api/Words/5
    [HttpPut("{id}")]
    public async Task<ActionResult<Response>> PutWord(int id, Word word)
    {
        Response oResponse = new();

        try
        {
            if (id != word.WordId)
            {
                oResponse.success = 0;
                oResponse.message = "bad request";
                return oResponse;
            }

            await wordRepository.Update(word);

            oResponse.success = 1;


        }
        catch (Exception ex)
        {
            oResponse.success = 0;
            oResponse.message = ex.Message;
        }

        return oResponse;
    }

    // POST: api/Words
    [HttpPost]
    public async Task<ActionResult<Response>> PostWord(Word word)
    {
        Response oResponse = new();

        try
        {
            await wordRepository.Add(word);
            oResponse.success = 1;
        }
        catch (Exception ex)
        {
            oResponse.success = 0;
            oResponse.message = ex.Message;
        }


        return oResponse;
    }

    // DELETE: api/Words/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Response>> DeleteWord(int id)
    {
        Response oResponse = new();

        try
        {
            var word = await wordRepository.GetById(id);
            if (word == null)
            {
                oResponse.success = 0;
                oResponse.message = "No se encontró la palabra";
                return oResponse;
            }

            await wordRepository.Remove(word);
            oResponse.success = 1;
        }
        catch (Exception ex)
        {
            oResponse.success = 0;
            oResponse.message = ex.Message;
        }

        return oResponse;
    }

    private async Task<bool> WordExists(int id)
    {
        return await wordRepository.Any(x => x.WordId == id);
    }
}

