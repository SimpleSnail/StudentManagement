using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var productFactory = new ProductFactory();
            var product=productFactory.MakePizza();
            Box box = new Box();
            box.WrapProduct(product);
            box.WrapProduct(product);
            Console.WriteLine(box.product.Name);
        }
    }
    class Product
    {
        public string Name { get; set; }
    }
    class Box
    {
        public Product product { get; set; }
        public void WrapProduct(Product product)
        {
            this.product = product;
            
        }
    }
    class ProductFactory
    {
        public Product MakePizza()//生产pizza
        {
            var product = new Product();
            product.Name = "Pizza";
            return product;
        }

        public Product MakeToyCar()//生产玩具车
        {
            var product = new Product();
            product.Name = "Toy Car";
            return product;
        }
    }

}
