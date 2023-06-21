using AutoMapper;
using core7_postgre_angular14.Entities;
using core7_postgre_angular14.Helpers;
using core7_postgre_angular14.Models;
using core7_postgre_angular14.Services;
using Microsoft.AspNetCore.Mvc;

namespace core7_postgre_angular14.Controllers.Products
{
    [ApiExplorerSettings(GroupName = "Add Product")]
    [ApiController]
    [Route("[controller]")]
    public class AddProduct : ControllerBase {
        private IProductService _productService;

        private IMapper _mapper;
        private readonly IConfiguration _configuration;  

        private readonly IWebHostEnvironment _env;

        private readonly ILogger<AddProduct> _logger;

        public AddProduct(
            IConfiguration configuration,
            IWebHostEnvironment env,
            IProductService productService,
            IMapper mapper,
            ILogger<AddProduct> logger
            )
        {
            _configuration = configuration;  
            _productService = productService;
            _mapper = mapper;
            _logger = logger;
            _env = env;        
        }  
        [HttpPost("/api/addproduct")]
        public IActionResult addProduct([FromBody]AddproductModel model) {
            try {
                var prod = _mapper.Map<Product>(model);
                _productService.Add_Product(prod);
            } catch(AppException ex) {
                return NotFound(new {statuscode = 404, ex.Message});
            }
            return Ok(new {statuscode=200, message="New product has been added."});
        }


    }
    
}