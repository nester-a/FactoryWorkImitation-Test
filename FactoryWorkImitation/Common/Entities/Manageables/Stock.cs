﻿using FactoryWorkImitation.Interfaces.Entities;

namespace FactoryWorkImitation.Common.Entities.Manageables
{
    public class Stock : IStock
    {
        object _lockObj = new();
        Queue<IProduct> _products = new();
        public event EventHandler? StockIsAlmostFull;

        public string Name { get; }
        public int Capacity { get; }
        public int FactLoad => _products.Count;
        public bool IsEmpty => !_products.Any();
        public bool IsFull => FactLoad == Capacity;
        int FactLoadPercent => FactLoad * 100 / Capacity;

        public Stock(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }

        public bool Load(IProduct product)
        {
            lock (_lockObj)
            {
                if (product is null || IsFull) return false;
                _products.Enqueue(product);
                Console.WriteLine($"На склад попал товар {product.Name}");
                if (FactLoadPercent >= 95) StockIsAlmostFull?.Invoke(this, EventArgs.Empty);
                return true;
            }
        }

        public IProduct Unload()
        {
            lock (_lockObj)
            {
                if (IsEmpty) return null!;
                var product = _products.Dequeue();
                if (product is null) return null!;
                Console.WriteLine($"Со склада забрали товар {product.Name}");
                return product;
            }
        }
    }
}
