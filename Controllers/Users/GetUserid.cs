using AutoMapper;
using core7_postgre_angular14.Helpers;
using core7_postgre_angular14.Models;
using core7_postgre_angular14.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace core7_postgre_angular14.Controllers.Users
{
    [ApiExplorerSettings(GroupName = "Retrieve User ID")]
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class GetUserid : ControllerBase {
    private IUserService _userService;

    private IMapper _mapper;
    private readonly IConfiguration _configuration;  

    private readonly IWebHostEnvironment _env;

    private readonly ILogger<GetUserid> _logger;

    public GetUserid(
        IConfiguration configuration,
        IWebHostEnvironment env,
        IUserService userService,
        IMapper mapper,
        ILogger<GetUserid> logger
        )
    {
        _configuration = configuration;  
        _userService = userService;
        _mapper = mapper;
        _logger = logger;
        _env = env;        
    }  

        [HttpGet("/api/getuserbyid/{id}")]
        public IActionResult getByid(int id) {
            try {
                var user = _userService.GetById(id);
                var model = _mapper.Map<UserModel>(user);

                return Ok(new {
                    statuscode = 200,
                    message = "User found, please wait.",
                    user = model
                });

            } catch(AppException ex) {
                return NotFound(new {
                    statuscode = 404,
                    message = ex.Message
                });

            }
        }
    }
    
}