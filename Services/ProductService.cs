using core7_postgre_angular14.Entities;
using core7_postgre_angular14.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace core7_postgre_angular14.Services
{

    public interface IProductService {
        IEnumerable<Product> ListAll(int page);
        IEnumerable<Product> SearchAll(string key);
        IEnumerable<Product> Dataset();
        Boolean Add_Product(Product product);
        int TotPage();
    }

    public class ProductService : IProductService
    {

    private DataDbContext _context;
        private readonly AppSettings _appSettings;


        public ProductService(DataDbContext context,IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }        
        public int TotPage() {
            var perpage = 5;
            var totrecs = _context.Products.Count();
            Console.WriteLine(totrecs);
            int totpage = (int)Math.Ceiling((float)(totrecs) / perpage);
            Console.WriteLine(totpage);
            return totpage;
        }
        public IEnumerable<Product> ListAll(int page)
        {
            var perpage = 5;
            var offset = (page -1) * perpage;

            var products = _context.Products                                
                .OrderBy(b => b.Id)
                .Skip(offset)
                .Take(perpage)
                .ToList();

            return products;
        }

        public IEnumerable<Product> SearchAll(string key)
        {
            var products = _context.Products.FromSqlRaw("SELECT * FROM products WHERE lower(descriptions) LIKE '%" + key + "%'").ToList();
            return products;
        }

        public IEnumerable<Product> Dataset()
        {
            var products = _context.Products.ToList();
            return products;
        }

        public bool Add_Product(Product product)
        {
            Product prodDesc = _context.Products.Where(c => c.Descriptions == product.Descriptions).FirstOrDefault();
            if (prodDesc is not null) {
                throw new AppException("Product Description is already taken...");
            }
            product.Created_at = DateTime.Now;
            product.Updated_at = DateTime.Now;
            _context.Products.Add(product);
            _context.SaveChanges();
            return true;
        }
    }
}