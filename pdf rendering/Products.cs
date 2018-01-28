using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf_rendering
{
    public class Product
    {
        public string name { get; set; }

        public string description { get; set; }
    }

    public class Products
    {
        public List<Product> GetProducts()
        {
            List<Product> productList = new List<Product>();
            productList.Add(new Product() { name = "Colgate", description = "Ships in stacks of 4." });
            productList.Add(new Product() { name = "Aquafresh", description = "The packaging looks flimsy." });
            productList.Add(new Product() { name = "Blend-a-med", description = "A lot of commercials." });
            return productList;
        }
    }
}
