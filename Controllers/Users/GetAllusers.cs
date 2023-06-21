using AutoMapper;
using core7_postgre_angular14.Helpers;
using core7_postgre_angular14.Models;
using core7_postgre_angular14.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace core7_postgre_angular14.Controllers.Users
{
    [ApiExplorerSettings(GroupName = "List All Users")]
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class GetallUsers : ControllerBase {
    private IUserService _userService;

    private IMapper _mapper;
    private readonly IConfiguration _configuration;  

    private readonly IWebHostEnvironment _env;

    private readonly ILogger<GetallUsers> _logger;

    public GetallUsers(
        IConfiguration configuration,
        IWebHostEnvironment env,
        IUserService userService,
        IMapper mapper,
        ILogger<GetallUsers> logger
        )
    {
        _configuration = configuration;  
        _userService = userService;
        _mapper = mapper;
        _logger = logger;
        _env = env;        
    }  

        [HttpGet("/api/getallusers")]
        public IActionResult getAllusers() {
            try {
                
                var user = _userService.GetAll();
                var model = _mapper.Map<IList<UserModel>>(user);
                return Ok(model);
            } catch(AppException ex) {
               return Ok(new {statuscode = 404, Message = ex.Message});
            }
        }
    }

}