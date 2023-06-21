using AutoMapper;
using core7_postgre_angular14.Entities;
using core7_postgre_angular14.Helpers;
using core7_postgre_angular14.Models;
using core7_postgre_angular14.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace core7_postgre_angular14.Controllers.Users
{
    [ApiExplorerSettings(GroupName = "Update User")]
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class UpdateUser : ControllerBase {
    private IUserService _userService;

    private IMapper _mapper;
    private readonly IConfiguration _configuration;  

    private readonly IWebHostEnvironment _env;

    private readonly ILogger<UpdateUser> _logger;

    public UpdateUser(
        IConfiguration configuration,
        IWebHostEnvironment env,
        IUserService userService,
        IMapper mapper,
        ILogger<UpdateUser> logger
        )
    {
        _configuration = configuration;  
        _userService = userService;
        _mapper = mapper;
        _logger = logger;
        _env = env;        
    }  


        [HttpPost("/api/updateprofile/{id}")]
        public IActionResult updateUser(int id, [FromBody]UserUpdate model) {
            var user = _mapper.Map<User>(model);
            user.Id = id;
            user.FirstName = model.Firstname;
            user.LastName = model.Lastname;
            user.Mobile = model.Mobile;
            try
            {
                _userService.Update(user, model.Password);
                return Ok(new {statuscode=200, message="Your profile has been updated.",user = model});
            }
            catch (AppException ex)
            {
                return BadRequest(new { statuscode = 404, message = ex.Message });
            }
        }
    }
    
}