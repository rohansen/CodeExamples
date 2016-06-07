using System;
using SimpleObjectMapper;
namespace SimpleObjectMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Product p = new Product { Id = 1, Name = "Icecream", Price = 10.0, Review = "Tastes Nice" };
            var mappedObject = SimpleObjectMapperExtensions.MapObject<Product, ProductDTO>(p);
            Console.WriteLine(mappedObject.Name + " - " + mappedObject.Price + "$, review: " + mappedObject.Review);
            Console.ReadKey();
        }
    }
}
