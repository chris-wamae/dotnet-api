using AutoMapper;
using dotnet_api.Data;
using dotnet_api.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApiUser> _userManager;
        private readonly SignInManager<ApiUser> _signInManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IMapper _mapper;

        public AccountController(UserManager<ApiUser> userManager, SignInManager<ApiUser> signInManager, ILogger<AccountController> logger, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
     public async Task<IActionResult> Register([FromBody] UserDto userDto)
        {
            _logger.LogInformation($"Registration attempt for {userDto.Email}");

            if(!ModelState.IsValid) 
            { 
              return BadRequest(ModelState);
            }

            try
            {
                var  user = _mapper.Map<ApiUser>(userDto);
                var result = await _userManager.CreateAsync(user);
                if(!result.Succeeded)
                {
                    return BadRequest("User registation attempt failed");
                }
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something went wrong in the {nameof(Register)}");
                
                return Problem($"Something went wrong in the {nameof(Register)}", statusCode: 500);
            }



        }
    }
}
