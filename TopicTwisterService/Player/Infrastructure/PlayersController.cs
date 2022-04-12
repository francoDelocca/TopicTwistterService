using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TopicTwisterService.shared.Application;

namespace TopicTwisterService.Player.Infrastructure
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly Domain.IPlayerRepository playerRepository;

        public PlayersController(Domain.IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        // GET: api/Players
        [HttpGet]
        private async Task<ActionResult<Response>> GetPlayers()
        {  Response oResponse = new Response();
            try
            {
                var players = await playerRepository.GetAll();
                oResponse.success = 1;
                oResponse.data = JsonConvert.SerializeObject(players);
            }
            catch (Exception ex)
            {
                oResponse.success = 0;
                oResponse.message = ex.Message;

            }

            return oResponse;
        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        private async Task<ActionResult<Response>> GetPlayer(int id)
        {
            Response oResponse = new Response();
            try
            {
                var player = await playerRepository.GetById(id);
             
                if (player == null)
                {
                    oResponse.success = 0;
                    oResponse.message = "no se encontró el player";
                    return oResponse;
                }
                else
                {
                    oResponse.success = 1;
                    oResponse.data = JsonConvert.SerializeObject(player);
                }
            }
            catch (Exception ex)
            {
                oResponse.success = 0;
                oResponse.message = ex.Message;
            }

            return oResponse;
        }

        
        [HttpGet("GetPlayerWins/{id}")]
        public async Task<ActionResult<Response>> GetPlayerWins(int id)
        {
            Response oResponse = new Response();
            try
            {
                var player = await playerRepository.GetById(id);

                if (player == null)
                {
                    oResponse.success = 0;
                    oResponse.message = "no se encontró el player";
                    return oResponse;
                }
                else
                {
                    oResponse.success = 1;
                    oResponse.data = JsonConvert.SerializeObject(player.Wins);
                }
            }
            catch (Exception ex)
            {
                oResponse.success = 0;
                oResponse.message = ex.Message;
            }

            return oResponse;
        }

        // POST: api/Players
        [HttpPut]
        public async Task<ActionResult<Response>> CreateUser(Domain.Player player)
        {
            Response oResponse = new Response();

            try
            {
                if (!PlayerAlreadyExists(player.email))
                {
                    player.Name = player.email.Split("@")[0];
                    player.password = "123";

                    CreateUserUseCase createUser = new(playerRepository);
                    await createUser.CreateUser(player);

                    oResponse.success = 1;
                    var data = new { PlayerId = player.PlayerId, Name = player.Name, Email = player.email, Password = player.password };

                    oResponse.data = JsonConvert.SerializeObject(data);
                }
                else
                {
                    oResponse.success = 0;
                    oResponse.message = "Ya hay un usuario creado con ese email";
                }
            }
            catch (Exception ex)
            {
                oResponse.message = "Error: " + ex.Message;
            }
            
            return Ok(oResponse);
        }

        
        [HttpPost("login")]
        public async Task<ActionResult<Response>> LogInUser(Application.DTO.PlayerDTO player)
        {
            Response oResponse = new Response();

            try
            {
                var playerResponse = await new ValidateUserUseCase(playerRepository).ValidateUser(player.Email, player.Password);

                if (playerResponse == null)
                {
                    return NotFound();
                }

                oResponse.success = 1;
                var data = new { PlayerId = playerResponse.PlayerId, Name = playerResponse.Name, Email = playerResponse.email, Password = playerResponse.password };

                oResponse.data = JsonConvert.SerializeObject(data);
            }
            catch (Exception ex)
            {
                oResponse.success = 0;
                oResponse.message = "Error" + ex.Message;
            }

            return Ok(oResponse);
        }


        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        private async Task<ActionResult<Response>> DeletePlayer(int id)
        {
            
            Response oResponse = new Response();

            try
            {
                var player = await playerRepository.GetById(id);

                if (player == null)
                {
                    oResponse.success = 0;
                    oResponse.message = "no se encontró el player";
                    return oResponse;
                }

                await playerRepository.Remove(player);

                oResponse.success = 1;

                return Ok();

            }
            catch (Exception ex)
            {
                oResponse.success = 0;
                oResponse.message = ex.Message;

                return NoContent();

            }

            
        }

        private bool PlayerAlreadyExists(string email)
        {
            return playerRepository.PlayerWithEmailExists(email);
        }
    }
}
