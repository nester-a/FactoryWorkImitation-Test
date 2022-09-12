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

        public ProductFactory(string name)
        {
            Name = name;
        }
        public bool Load(IProduct product)
        {
            //на фабрике не храним товар, поэтому просто его обнуляем
            product = null!;
            return true;
        }
        public IProduct Unload()
        {
            lock (_lockObj)
            {
                Console.WriteLine($"{Name} делает новый товар...");
                Thread.Sleep(10);
                Console.WriteLine($"{Name} сделала новый товар");
                return new Product();
            }
        }
    }
}
