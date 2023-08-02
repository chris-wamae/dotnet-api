using dotnet_api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using dotnet_api.Models;
using AutoMapper;
using dotnet_api.Dto;

namespace dotnet_api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class Pro_playerController : Controller
    {
        private readonly IPro_playerRepository _proRepository;
        private readonly IMapper _mapper;
        //private readonly IPlatformRepository _platformRepository;
        private readonly IGameRepository _gameRepository;

        public Pro_playerController(IPro_playerRepository proRepository, IMapper mapper, IGameRepository gameRepository)
        {
            _proRepository = proRepository;
            _mapper = mapper;
            //_platformRepository = platformRepository;
            _gameRepository = gameRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pro_player>))]

        public IActionResult GetPros()
        {
            var pros = _mapper.Map<List<Pro_playerDto>>(_proRepository.GetPro_Players());
            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            return Ok(pros);
        }


        [HttpGet("{proId}")]
        [ProducesResponseType(200, Type = typeof(Pro_player))]
        [ProducesResponseType(400)]

        public IActionResult GetPro_PlayerById(int proId)
        {
            if (!_proRepository.ProExists(proId))
                return NotFound();

            var pro = _mapper.Map<Pro_playerDto>(_proRepository.GetPro_PlayerById(proId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pro);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
         
        public IActionResult CreatePro_player([FromQuery] int gameId,Pro_playerDto pro_playerCreate )
        {
            var pro_player = _proRepository.GetPro_Players().Where(pro => pro.Name.Trim().ToUpper() == pro_playerCreate.Name.Trim().ToUpper()).FirstOrDefault();

            if(pro_player != null)
            {
                ModelState.AddModelError("", "Error, this pro player already exists");
                return StatusCode(422,ModelState);
            }

            if (!ModelState.IsValid)
            {
            return BadRequest(ModelState);
            }

            var proMap = _mapper.Map<Pro_player>(pro_playerCreate);

            proMap.Game = _gameRepository.GetGame(gameId);
           /* proMap.Platform = _platformRepository.GetPlatforms().Where<Platform>(p => p.Id  == platformId)*/

            if (!_proRepository.CreatePro_player(proMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok(proMap);

        }

        //To fix:
        //Not Updating but not thowing an error....
        [HttpPut("{proId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public IActionResult UpdatePro_player(int proId, [FromBody] Pro_playerDto updatePro)
        {
         if(updatePro == null) 
            {
                return BadRequest(ModelState);
            }

         if(proId != updatePro.Id)
            {
                return BadRequest(ModelState);
            }


         if(!_proRepository.ProExists(proId))
            {
                return NotFound();
            }

         if(!ModelState.IsValid) 
            {
                return BadRequest();
            }

            var updatedProMap = _mapper.Map<Pro_player>(updatePro);

        if(!_proRepository.UpdatePro_Player(updatedProMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating the Studio");
                return StatusCode(500, ModelState);
            }

        return Ok(updatedProMap);

        }

        [HttpDelete("{proId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public IActionResult DeleteProPlayer(int proId) 
        { 
         if(!_proRepository.ProExists(proId))
            {
                return NotFound();
            }
         var proToDelete = _proRepository.GetPro_PlayerById(proId);
         
         if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

         if(!_proRepository.DeletePro_Player(proToDelete))
            {

                ModelState.AddModelError("", "Something went wrong while saving");

                return StatusCode(500, ModelState);

            }

         return NoContent();

        }


    }



}