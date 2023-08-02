using dotnet_api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using dotnet_api.Models;
using AutoMapper;
using dotnet_api.Dto;
using dotnet_api.Repository;

namespace dotnet_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PlatformController : Controller
    {
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;

        public PlatformController(IPlatformRepository platformRepository, IMapper mapper)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Platform>))]

        public IActionResult GetPlatforms()
        {
            var platforms = _mapper.Map<List<PlatformDto>>(_platformRepository.GetPlatforms());

            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            return Ok(platforms);

        }

        [HttpGet("{gameId}")]
        [ProducesResponseType(200, Type = typeof(Platform))]
        [ProducesResponseType(400)]

        public IActionResult GetPlatform(int platformId)
        {
            if (!_platformRepository.PlatformExists(platformId))
                return NotFound();

            var platform = _mapper.Map<PlatformDto>(_platformRepository.GetPlatformById(platformId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(platform);

        }

        [HttpGet("game/{platformId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Game>))]
        [ProducesResponseType(400)]
        public IActionResult GetGamesByPlatform(int platformId) 
        { 
         var games = _mapper.Map<List<GameDto>>(_platformRepository.GetGamesByPlatform(platformId));

        if(!ModelState.IsValid)
        return BadRequest(ModelState);

        return Ok(games);

        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreatePlatform([FromBody] Platform platformCreate)
        {    
            if(platformCreate == null)
            return BadRequest(ModelState);

            var platform = _platformRepository.GetPlatforms().Where(p => p.Name.Trim().ToUpper() == platformCreate.Name.Trim().ToUpper()); 

            if(platform != null)
            {
                ModelState.AddModelError("", "This Platorm already exists");
                return StatusCode(422, ModelState);
            }


            if (!ModelState.IsValid)
                return BadRequest(ModelState);


            var platformMap = _mapper.Map<Platform>(platformCreate);

            if(!_platformRepository.CreatePlatform(platformMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok(platformCreate);
        }

        [HttpPut("{platformId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]

        public IActionResult UpdatePlatform([FromQuery] int gameId,int platformId,[FromBody] PlatformDto platformUpdate)
        {
          if(platformUpdate == null)
            {
             return BadRequest(ModelState);
            }

           if(platformId != platformUpdate.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_platformRepository.PlatformExists(platformId))
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var platformMap = _mapper.Map<Platform>(platformUpdate);

            if (!_platformRepository.UpdatePlatform(gameId,platformMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating the Studio");
                return StatusCode(500, ModelState);
            }

            return Ok(platformMap);
        }

        [HttpDelete("{platformId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]

        public IActionResult DeletePlatform(int platformId)
        {
            if (!_platformRepository.PlatformExists(platformId))
            {
                return NotFound();
            }

            var platformToDelete = _platformRepository.GetPlatformById(platformId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!_platformRepository.DeletePlatform(platformToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting the Platform");

                return StatusCode(500, ModelState);
            }

            return NoContent();

        }

    }
}