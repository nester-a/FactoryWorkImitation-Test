using FactoryWorkImitation.Interfaces.Entities;

namespace FactoryWorkImitation.Common.Entities.Manageables
{
    public class Truck : ITruck
    {
        Stack<IProduct> _products = new();

        public int WeightCapacity { get; }
        public int WeightFactLoad { get; private set; }
        public bool IsEmpty => _products.Any();
        public bool IsFull => WeightFactLoad == WeightCapacity;

        public Truck(int weightCapacity)
        {
            WeightCapacity = weightCapacity;
        }

        public bool Load(IProduct product)
        {
            if (product is null || IsFull) return false;
            _products.Push(product);
            WeightFactLoad += product.Weight;
            return true;
        }
        public IProduct Unload()
        {
            if (IsEmpty) return null!;
            var product = _products.Pop();
            if (product is null) return null!;

            WeightFactLoad -= product.Weight;
            return product;
        }

        public void Drive()
        {
            Thread.Sleep(100);
        }
    }
}
