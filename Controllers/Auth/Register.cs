using AutoMapper;
using core7_postgre_angular14.Entities;
using core7_postgre_angular14.Helpers;
using core7_postgre_angular14.Models;
using core7_postgre_angular14.Services;
using Microsoft.AspNetCore.Mvc;

namespace core7_postgre_angular14.Controllers.Auth
{
    [ApiExplorerSettings(GroupName = "Sign-up or Account Registration")]
    [ApiController]
    [Route("[controller]")]
    public class Register : ControllerBase {

    private IAuthService _authService;
    private IMapper _mapper;

    private readonly IWebHostEnvironment _env;

    private readonly ILogger<Register> _logger;

    public Register(
        IWebHostEnvironment env,
        IAuthService userService,
        IMapper mapper,
        ILogger<Register> logger
        )
    {   
        _authService = userService;
        _mapper = mapper;
        _logger = logger;
        _env = env;
    }  

    [HttpPost("/signup")]
    public IActionResult signup(UserRegister model) {
        var user = _mapper.Map<User>(model);

            try
            {
                user.LastName = model.Lastname;
                user.FirstName = model.Firstname;
                user.Email = model.Email;
                user.Mobile = model.Mobile;
                user.UserName = model.Username;
                _authService.SignupUser(user, model.Password);
                return Ok(new {statuscode = 200, message = "You have registered successfully."});
            }
            catch (AppException ex)
            {
                return Ok(new { statuscode = 404, message = ex.Message });
            }
    }

    }
    
}