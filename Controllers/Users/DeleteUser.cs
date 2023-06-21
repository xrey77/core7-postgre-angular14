using AutoMapper;
using core7_postgre_angular14.Helpers;
using core7_postgre_angular14.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace core7_postgre_angular14.Controllers.Users
{
    [ApiExplorerSettings(GroupName = "Delete User")]
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class DeleteUser : ControllerBase {

    private IUserService _userService;

    private IMapper _mapper;
    private readonly IConfiguration _configuration;  

    private readonly IWebHostEnvironment _env;

    private readonly ILogger<DeleteUser> _logger;

    public DeleteUser(
        IConfiguration configuration,
        IWebHostEnvironment env,
        IUserService userService,
        IMapper mapper,
        ILogger<DeleteUser> logger
        )
    {
        _configuration = configuration;  
        _userService = userService;
        _mapper = mapper;
        _logger = logger;
        _env = env;        
    }  

        [HttpDelete("/api/deleteuser/{id}")]
        public IActionResult deleteUser(int id) {
            try
            {
               _userService.Delete(id);
            return Ok();
           }
            catch (AppException ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }
    }
    
}