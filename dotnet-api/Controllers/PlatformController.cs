using dotnet_api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using dotnet_api.Models;
using AutoMapper;
using dotnet_api.Dto;

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



    }
}