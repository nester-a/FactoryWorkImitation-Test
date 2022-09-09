using FactoryWorkImitation.Interfaces.Entities;

namespace FactoryWorkImitation.Common.Entities
{
    public class Factory : IFactory
    {
        public string Name { get; set; }

        public int ProducedProductCount { get; private set; }

        public IStock Stock { get; set; }

        public int ManufactureSpeed { get; set; }

        public IProduct FactoryProduct { get; set; }

        public Factory() { }
        public Factory(string name, IProduct factoryProduct, int manufactureSpeed, IStock stock)
        {
            Name = name;
            FactoryProduct = factoryProduct;
            ManufactureSpeed = manufactureSpeed;
            Stock = stock;
        }
        public void CreateProduct()
        {
            Console.WriteLine($"{Name} начала производить свой товар...");
            Thread.Sleep(3600000 / ManufactureSpeed);
            var product = new Product(FactoryProduct.Name, FactoryProduct.Weight, FactoryProduct.PackingType);
            ProducedProductCount++;
            Console.WriteLine($"{Name} произвела {product.Name}");
            Console.WriteLine($"{Name} пробует разместить {product.Name} на складе...");
            var res = Stock.PutOnStock(product);
            if (res) Console.WriteLine($"{Name} разместила {product.Name} на складе");
            else Console.WriteLine($"{Name} не смогла разместить {product.Name} на складе. И просто выкинула его");
        }
    }
}
