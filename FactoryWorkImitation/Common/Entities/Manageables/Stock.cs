using FactoryWorkImitation.Interfaces.Entities;

namespace FactoryWorkImitation.Common.Entities.Manageables
{
    public class Stock : IStock
    {
        Queue<IProduct> _products = new();
        public int Capacity { get; }
        public int FactLoad => _products.Count;
        public bool IsEmpty => _products.Any();
        public bool IsFull => FactLoad == Capacity;

        public Stock(int capacity)
        {
            Capacity = capacity;
        }

        public bool Load(IProduct product)
        {
            if (product is null || IsFull) return false;
            _products.Enqueue(product);
            return true;
        }

        public IProduct Unload()
        {
            if(IsEmpty) return null!;
            var product = _products.Dequeue();
            if(product is null) return null!;

            return product;
        }
    }
}
