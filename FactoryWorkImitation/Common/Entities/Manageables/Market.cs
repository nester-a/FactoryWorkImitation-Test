using FactoryWorkImitation.Interfaces.Entities;
using FactoryWorkImitation.Interfaces.Entities.Manageables;

namespace FactoryWorkImitation.Common.Entities.Manageables
{
    public class Market : IManageable
    {
        List<IProduct> _products = new();
        public bool IsEmpty => false;
        public bool IsFull => false;
        public bool Load(IProduct product)
        {
            if (product is null) return false;
            _products.Add(product);
            return true;
        }
        public IProduct Unload()
        {
            //с рынка нельзя выгружать товар
            return null!;
        }
    }
}
