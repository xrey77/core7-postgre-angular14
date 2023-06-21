using AutoMapper;
using core7_postgre_angular14.Entities;
using core7_postgre_angular14.Helpers;
using core7_postgre_angular14.Models;
using core7_postgre_angular14.Services;
using Microsoft.AspNetCore.Mvc;

namespace core7_postgre_angular14.Controllers.Products
{
    [ApiExplorerSettings(GroupName = "List All Products")]
    [ApiController]
    [Route("[controller]")]
    public class ListProducts : ControllerBase {

        private IProductService _productService;

        private IMapper _mapper;
        private readonly IConfiguration _configuration;  

        private readonly IWebHostEnvironment _env;

        private readonly ILogger<ListProducts> _logger;

        public ListProducts(
            IConfiguration configuration,
            IWebHostEnvironment env,
            IProductService productService,
            IMapper mapper,
            ILogger<ListProducts> logger
            )
        {
            _configuration = configuration;  
            _productService = productService;
            _mapper = mapper;
            _logger = logger;
            _env = env;        
        }  

        [HttpGet("/listproducts/{page}")]
        public IActionResult listProducts(int page) {
            try {                
                int totalpage = _productService.TotPage();
                var prods = _productService.ListAll(page);
                if (prods != null) {
                    var prod = _mapper.Map<IList<ProductModel>>(prods);
                    return Ok(new {totpage = totalpage, page = page, products = prod});
                } else {
                    return Ok(new {statuscode=404, message="No Data found."});
                }
            } catch(AppException ex) {
               return Ok(new {statuscode = 404, Message = ex.Message});
            }
        }
    }
    
}