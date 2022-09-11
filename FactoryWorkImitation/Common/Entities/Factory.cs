using FactoryWorkImitation.Interfaces.Entities;

namespace FactoryWorkImitation.Common.Entities
{
    public class Factory : IFactory
    {
        public string Name { get; set; }

        public int ProducedProductCount { get; private set; }

        public int ManufactureSpeed { get; set; }

        public IProduct FactoryProduct { get; set; }

        public Factory() { }
        public Factory(string name, IProduct factoryProduct, int manufactureSpeed)
        {
            Name = name;
            FactoryProduct = factoryProduct;
            ManufactureSpeed = manufactureSpeed;
        }
        public IProduct CreateProduct()
        {
            Console.WriteLine($"{Name} начала производить свой товар...");
            Thread.Sleep(3600000 / ManufactureSpeed);
            var product = new Product(FactoryProduct.Name, FactoryProduct.Weight, FactoryProduct.PackingType);
            ProducedProductCount++;
            Console.WriteLine($"{Name} произвела {product.Name}");
            return product;
        }

        public void CreateProductAndPlaceOnStock(IStock stock)
        {
            var product = CreateProduct();
            var res = stock.PutOnStock(product);
            if (!res) Console.WriteLine($"{product.Name} выкинули!!");
        }
    }
}
