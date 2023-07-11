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

        public Pro_playerController(IPro_playerRepository proRepository, IMapper mapper)
        {
            _proRepository = proRepository;
            _mapper = mapper;
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

            var pro = _mapper.Map<GameDto>(_proRepository.GetPro_PlayerById(proId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pro);
        }


    }

}