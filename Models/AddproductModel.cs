namespace core7_postgre_angular14.Models
{
    public class AddproductModel {
        public string descriptions { get; set; }
        public int qty { get; set; }
        public string unit { get; set; }
        public decimal cost_price { get; set; }
        public decimal sell_price { get; set; }
        public string category { get; set; }
        public decimal sale_price { get; set; }
        public int alert_level { get; set; }
        public int critical_level { get; set; }
        public DateTime Created_at { get; set; }        
    }
}