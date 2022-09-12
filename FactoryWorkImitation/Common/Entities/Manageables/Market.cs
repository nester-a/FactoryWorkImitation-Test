using FactoryWorkImitation.Interfaces.Entities;
using FactoryWorkImitation.Interfaces.Entities.Manageables;

namespace FactoryWorkImitation.Common.Entities.Manageables
{
    public class Market : IMarket
    {
        object _lockObj = new();
        List<IProduct> _products = new();

        public string Name => "Рынок";
        public bool IsEmpty => false;
        public bool IsFull => false;
        public bool Load(IProduct product)
        {
            lock (_lockObj)
            {
                if (product is null) return false;
                _products.Add(product);
                Console.WriteLine($"Товар {product.Name} попал на рынок");
                return true;
            }
        }
        public IProduct Unload()
        {
            //с рынка нельзя выгружать товар
            return null!;
        }
    }
}
