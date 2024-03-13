using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopMyNghe.Models
{
    public class Cart_Session
    {
        DB_MyNgheDataContext data = new DB_MyNgheDataContext();

        public string sproduct_id { get; set; }
        public string sproduct_name { get; set; }
        public string sproduct_image { get; set; }
        public Decimal dproduct_price { get; set; }
        public int isoLuong { get; set; }
        public Decimal dtTien
        {
            get { return isoLuong * dproduct_price; }
        }

        public Cart_Session(string id)
        {
            //Chổ cần hỏi
            sproduct_id = id;
            Product product = data.Products.SingleOrDefault(s => s.product_id == id);
            sproduct_name = product.name;
            dproduct_price = Decimal.Parse(product.price.ToString());
            sproduct_image = product.Images;
            isoLuong = 1;
        }
    }
}