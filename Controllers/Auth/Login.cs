using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using core7_postgre_angular14.Entities;
using core7_postgre_angular14.Helpers;
using core7_postgre_angular14.Models;
using core7_postgre_angular14.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace core7_postgre_angular14.Controllers.Auth
{
    [ApiExplorerSettings(GroupName = "Sign-in to User Account")]
    [ApiController]
    [Route("[controller]")]
    public class Login : ControllerBase {

    private IAuthService _authService;
    private IMapper _mapper;
    private readonly IConfiguration _configuration;  

    private readonly IWebHostEnvironment _env;

    private readonly ILogger<Login> _logger;

    public Login(
        // IJWTTokenServices jWTTokenServices,
        IConfiguration configuration,
        IWebHostEnvironment env,
        IAuthService authService,
        IMapper mapper,
        ILogger<Login> logger
        )
    {
        // _jwttokenservice = jWTTokenServices;        
        _configuration = configuration;  
        _authService = authService;
        _mapper = mapper;
        _logger = logger;
        _env = env;        
    }  

    [HttpPost("/signin")]
    public IActionResult signin(UserLogin model) {
            try {
                 User xuser = _authService.SignUser(model.Username, model.Password);
                 if (xuser != null) {
                    // var token = _jwttokenservice.Authenticate(xuser).Token;
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var xkey = _configuration["AppSettings:Secret"];
                    var key = Encoding.ASCII.GetBytes(xkey);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                            new Claim(ClaimTypes.Name, xuser.Id.ToString())
                        }),
                        Expires = DateTime.UtcNow.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var tokenString = tokenHandler.WriteToken(token);

                    return Ok(new { 
                        statuscode = 200,
                        message = "Login Successfull, please wait..",
                        id = xuser.Id,
                        lastname = xuser.LastName,
                        firstname = xuser.FirstName,
                        username = xuser.UserName,
                        roles = xuser.Roles,
                        isactivated = xuser.Isactivated,
                        isblocked = xuser.Isblocked,
                        profilepic = xuser.Profilepic,
                        qrcodeurl = xuser.Qrcodeurl,
                        token = tokenString
                        });
                 } else {
                    return NotFound(new { statuscode = 404, message = "Username not found.."});
                 }
            }
            catch (AppException ex)
            {
                return Ok(new {Message = ex.Message});
            }

    }
    }
    
}