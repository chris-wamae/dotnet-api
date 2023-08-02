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
        private readonly IPlatformRepository _platformRepository;
        public GameController(IGameRepository gameRepository, IMapper mapper, IPlatformRepository platform)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
            _platformRepository = platform; 
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Game>))]

        public IActionResult GetGames()
        {
            var games = _mapper.Map<List<GameDto>>(_gameRepository.GetGames());

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

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(game);

        }


        [HttpGet("platform/{gameId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Platform>))]

        public IActionResult GetPlatformsByGame(int gameId)
        {
            var platforms = _mapper.Map<List<PlatformDto>>(_gameRepository.GetPlatformsByGame(gameId));

            if (!ModelState.IsValid)
                return BadRequest();
            return Ok(platforms);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateGame([FromQuery] int studioId, [FromQuery] int platformId, GameDto gameCreate)
        {
          if(gameCreate == null)
            return BadRequest(ModelState);

          var game = _gameRepository.GetGames().Where(g => g.Title.Trim().ToUpper() == gameCreate.Title.Trim().ToUpper()).FirstOrDefault();

          if(game != null)
            {
                ModelState.AddModelError("", "Error, this game already exists");
                return StatusCode(422, ModelState);
            }

          if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
        
        var gameMap = _mapper.Map<Game>(gameCreate);

         if(!_gameRepository.CreateGame(studioId,platformId,gameMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

         return Ok(gameMap);
        }

        [HttpPut("gameId")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult UpdateGame(int platformId,int gameId,[FromBody] GameDto updateGame) 
        { 
          if(updateGame  == null) 
          return BadRequest(ModelState);

            if (!_gameRepository.GameExists(gameId))
                return NotFound();

          if(gameId != updateGame.Id)
            return BadRequest(ModelState);

            var updatedGameMap = _mapper.Map<Game>(updateGame);

         if(!_gameRepository.UpdateGame(platformId,gameId, updatedGameMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating the Studio");
                return StatusCode(500, ModelState);
         
            }

            return Ok(updatedGameMap);
        }

        [HttpDelete("{gameId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public IActionResult DeleteGame(int gameId)
        {
            if (!_gameRepository.GameExists(gameId))
            {
                return NotFound();
            }

            var gameToDelete = _gameRepository.GetGame(gameId);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(!_gameRepository.DeleteGame(gameToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while Deleting the Game");
                return StatusCode(500, ModelState);
            }

            return NoContent();
  
        }
    }
}
