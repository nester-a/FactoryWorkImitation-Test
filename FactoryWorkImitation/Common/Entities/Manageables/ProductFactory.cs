using FactoryWorkImitation.Interfaces.Entities;
using FactoryWorkImitation.Interfaces.Entities.Manageables;

namespace FactoryWorkImitation.Common.Entities.Manageables
{
    public class ProductFactory : IProductFactory
    {
        object _lockObj = new();
        public bool IsEmpty => false;
        public bool IsFull => false;

        public string Name { get; }

        public int ManufactureSpeed { get; } = 1;

        public IProduct FactoryProduct { get; }

        public ProductFactory(string name, int manufactureSpeed, IProduct factoryProduct)
        {
            Name = name;
            ManufactureSpeed = manufactureSpeed;
            FactoryProduct = factoryProduct;
        }
        public bool Load(IProduct product)
        {
            Console.WriteLine($"На фабриках ничего не храним, поэтому мы просто выкидываем товар {product.Name}");
            //на фабрике не храним товар, поэтому просто его обнуляем
            product = null!;
            return true;
        }
        public IProduct Unload()
        {
            lock (_lockObj)
            {
                Console.WriteLine($"{Name} делает новый {FactoryProduct.Name}...");
                Thread.Sleep(10000/ ManufactureSpeed);
                Console.WriteLine($"{Name} сделала новый товар {FactoryProduct.Name}");
                return new Product(FactoryProduct.Name, FactoryProduct.Weight, FactoryProduct.PackingType);
            }
        }
    }
}
