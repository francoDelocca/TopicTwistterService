using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TopicTwisterService.Category.Infrastructure.DTO;
using TopicTwisterService.shared.Application;
using TopicTwistter.Core.DTO;

[Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        //GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<Response>> GetCategories()
        {
            Response oResponse = new();

            try
            {
                var categories = await categoryRepository.GetAll(); 
                oResponse.data =  JsonConvert.SerializeObject(categories,
                    new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
                oResponse.success = 1;
            }
            catch (Exception ex)
            {
                oResponse.data = ex.Message;
                oResponse.success = 0;
            }

            return oResponse;
        }

    // GET: api/RandomCategoriesForMatch
    [Route("GetRandomCategoriesForMatch")]
    [HttpGet]
    public ActionResult<Response> GetRandomCategoriesForMatch()
    {
        Response oResponse = new();

        try
        {
            GetRandomCategories RandomCategories = new GetRandomCategories(categoryRepository);
            var categories = RandomCategories.GetListOfRandom(5);
            oResponse.data = JsonConvert.SerializeObject(categories,
              new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            oResponse.success = 1;
        }
        catch (Exception ex)
        {
            oResponse.data = ex.Message;
            oResponse.success = 0;
        }

        return oResponse;

    }

    // GET: api/Categories/5
    [HttpGet("{id}")]
        public async Task<ActionResult<Response>> GetCategory(int id)
        {
            Response oResponse = new();

            try
            {
            
                var category = await categoryRepository.GetById(id);
                oResponse.data = JsonConvert.SerializeObject(category,
                    new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
                oResponse.success = 1;
                if (category == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {  oResponse.data = ex.Message;
                oResponse.success = 0;
                
            }

            return oResponse;
        }

        // PUT: api/Categories/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Response>> PutCategory(int id, Category category)
        {
            Response oResponse = new();
        
          
            if (id != category.CategoryId)
            {
                return BadRequest();
            }


            try
            {
                await categoryRepository.Update(category);               
                oResponse.success = 1;
                
            }
            catch (Exception ex)
            {        
                    oResponse.message = ex.Message;
                    oResponse.success = 0;
                    return oResponse;
            }

            return oResponse;
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<Response>> PostCategory(Category category)
        { 
            Response oResponse = new();

            try
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                oResponse.success = 1;
            }
            catch (Exception ex)
            {
                oResponse.message = ex.Message;
                oResponse.success = 0;
            }

            return oResponse;
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Response>> DeleteCategory(int id)
        {
            Response oResponse = new();

            try
            {
                var category = await _context.Categories.FindAsync(id);
                if (
                 category == null)
                {
                    oResponse.message = "no se encontró la categoría";
                    oResponse.success = 0;
                    return oResponse;

                }

                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                oResponse.success = 1;
                

            }
            catch (Exception ex)
            {
                oResponse.message = ex.Message;
                oResponse.success = 0;

            }

            return oResponse;
        }

    }

