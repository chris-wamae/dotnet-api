using dotnet_api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using dotnet_api.Models;

namespace dotnet_api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GameController : Controller
    {    
        private readonly IGameRepository _gameRepository;

        public GameController(IGameRepository gameRepository) 
        {
            _gameRepository = gameRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Game>))]

        public IActionResult GetGames()
        {
            var games = _gameRepository.GetGames();

            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            return Ok(games);
                     
        }


    }
}
