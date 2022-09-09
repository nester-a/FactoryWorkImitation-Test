﻿using FactoryWorkImitation.Interfaces.Entities;

namespace FactoryWorkImitation.Common.Entities
{
    public class Stock : IStock
    {
        public event EventHandler StockLoadPercent95;

        public ITruck? Truck { get; set; }
        object _obj = new();
        Queue<IProduct> _products;
        public int Capacity { get; }
        public int FactLoad { get => _products.Count; }
        public int FactLoadPercent { get => FactLoad * 100 / Capacity; }
        public bool IsFull { get => FactLoad == Capacity; }

        public IManager Manager { get; set; }


        public Stock(int capacity)
        {
            _products = new();
            Capacity = capacity;
        }

        public bool PutOnStock(IProduct product)
        {
            lock (_obj)
            {
                if (IsFull)
                {
                    Console.WriteLine("Склад заполнен");
                    return false;
                }
                _products.Enqueue(product);
                Console.WriteLine($"На складе - {FactLoad} товаров. Заполненность - {FactLoadPercent}%");
                if (FactLoadPercent >= 25) StockLoadPercent95?.Invoke(this, new EventArgs());
                return true;
            }
        }

        public IProduct RemoveFromStock()
        {
            lock (_obj)
            {
                if (!_products.Any())
                {
                    Console.WriteLine("Склад пуст");
                    return null!;
                }
                return _products.Dequeue();
            }
        }
    }
}
