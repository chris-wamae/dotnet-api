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

    public StudioController(IStudioRepository gameRepository, IMapper mapper)
    {
        _studioRepository = gameRepository;
        _mapper = mapper;
    }

   [HttpGet]
   [ProducesResponseType(200, Type = typeof(IEnumerable<Studio>) )]

    public IActionResult GetStudios()
    {
      var studios = _mapper.Map<List <StudioDto>>(_studioRepository.GetStudios());

      if(!ModelState.IsValid)

      return BadRequest(ModelState);

      return Ok(studios);
    }

    
    [HttpGet]
    [ProducesResponseType(200, Type  = typeof(Studio))]
    [ProducesResponseType(400)]
    public IActionResult GetStudioById(int studioId)
    {
        if(!_studioRepository.StudioExists(studioId))
          return NotFound();

        var studio = _mapper.Map<StudioDto>(_studioRepository.GetStudioById(studioId));

        if(!ModelState.IsValid)
           return BadRequest(ModelState);

        return Ok(studio);
    }

  }



}