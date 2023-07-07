using dotnet_api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using dotnet_api.Models;
using AutoMapper;
using dotnet_api.Dto;

namespace dotnet_api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GameController : Controller
    {    
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GameController(IGameRepository gameRepository, IMapper mapper) 
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Game>))]

        public IActionResult GetGames()
        {
            var games = _mapper.Map <List <GameDto>>( _gameRepository.GetGames()); 

            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            return Ok(games);
                     
        }

        [HttpGet("{gameId}")]
        [ProducesResponseType(200, Type = typeof(Game))]
        [ProducesResponseType(400)]

        public IActionResult GetGame(int gameId) 
        {
            if (!_gameRepository.GameExists(gameId)) 
                return NotFound();

            var game = _mapper.Map<GameDto>(_gameRepository.GetGame(gameId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(game);

        }

        //[HttpGet("{}")]

    }
}
