using AutoMapper;
using core7_postgre_angular14.Helpers;
using core7_postgre_angular14.Models;
using core7_postgre_angular14.Services;
using Microsoft.AspNetCore.Mvc;

namespace core7_postgre_angular14.Controllers.Products
{
     [ApiExplorerSettings(GroupName = "Search Product Description")]
   [ApiController]
    [Route("[controller]")]
    public class SearchProduct : ControllerBase {
        private IProductService _productService;

        private IMapper _mapper;
        private readonly IConfiguration _configuration;  

        private readonly IWebHostEnvironment _env;

        private readonly ILogger<SearchProduct> _logger;

        public SearchProduct(
            IConfiguration configuration,
            IWebHostEnvironment env,
            IProductService productService,
            IMapper mapper,
            ILogger<SearchProduct> logger
            )
        {
            _configuration = configuration;  
            _productService = productService;
            _mapper = mapper;
            _logger = logger;
            _env = env;        
        }  

        [HttpPost("/searchproducts")]
        public IActionResult SearchProducts([FromBody]ProductSearch prod) {
            try {                
                var products = _productService.SearchAll(prod.Search);
                if (products != null) {
                    var model = _mapper.Map<IList<ProductModel>>(products);
                    return Ok(new {products=model});
                } else {
                    return Ok(new {statuscode=404, message="No Data found."});
                }
            } catch(AppException ex) {
               return Ok(new {statuscode = 404, Message = ex.Message});
            }
        }
    }

}