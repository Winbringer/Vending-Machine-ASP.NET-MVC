using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace VM_ASP_MVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public static implicit operator string(Product p)
        {
            return string.Format("{0} = {1} руб, {2} штук", p.ProductName, p.Price, p.Count);
        }
        public override string ToString()
        {
            return string.Format("{0} = {1} руб, {2} штук", ProductName, Price, Count);
        }


        public override bool Equals(object obj)
        {
            Product product = obj as Product;

            if (ReferenceEquals(product, null))
                return false;

            return ProductName.Equals(product.ProductName, StringComparison.CurrentCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
