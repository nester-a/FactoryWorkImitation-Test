using FactoryWorkImitation.Interfaces.Entities;
using FactoryWorkImitation.Interfaces.Entities.Manageables;

namespace FactoryWorkImitation.Common.Entities.Manageables
{
    public class ProductFactory : IManageable
    {
        public bool IsEmpty => false;
        public bool IsFull => false;

        public bool Load(IProduct product)
        {
            //на фабрике не храним товар, поэтому просто его уничтожаем
            product = null!;
            return true;
        }

        public IProduct Unload()
        {
            Console.WriteLine("Делаем новый товар...");
            Thread.Sleep(1000);
            return new Product();
        }
    }
}
