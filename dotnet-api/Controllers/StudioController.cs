using dotnet_api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using dotnet_api.Models;
using AutoMapper;
using dotnet_api.Dto;

namespace dotnet_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudioController : Controller
    {
        private readonly IStudioRepository _studioRepository;
        private readonly IMapper _mapper;

        public StudioController(IStudioRepository studioRepository, IMapper mapper)
        {
            _studioRepository = studioRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Studio>))]

        public IActionResult GetStudios()
        {
            var studios = _mapper.Map<List<StudioDto>>(_studioRepository.GetStudios());

            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            return Ok(studios);
        }


        [HttpGet("{studioId}")]
        [ProducesResponseType(200, Type = typeof(Studio))]
        [ProducesResponseType(400)]
        public IActionResult GetStudioById(int studioId)
        {
            if (!_studioRepository.StudioExists(studioId))
                return NotFound();

            var studio = _mapper.Map<StudioDto>(_studioRepository.GetStudioById(studioId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(studio);
        }


        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]

        public IActionResult CreateStudio([FromBody] StudioDto studioCreate)
        {
            if (studioCreate == null)
            {
                return BadRequest(ModelState);
            }

            var studio = _studioRepository.GetStudios().Where(s => s.Name.Trim().ToUpper() == studioCreate.Name.Trim().ToUpper())
            .FirstOrDefault();

            if (studio != null)
            {
                ModelState.AddModelError("", "This studio already exits");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var studioMap = _mapper.Map<Studio>(studioCreate);

            if (!_studioRepository.CreateStudio(studioMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok(studioMap);
            }

    }



}