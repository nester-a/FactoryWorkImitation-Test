﻿using FactoryWorkImitation.Interfaces.Entities;

namespace FactoryWorkImitation.Common.Entities
{
    public class Stock : IStock
    {
        object _obj = new();
        Queue<IProduct> _products;
        public int Capacity { get; }
        public int FactLoad { get => _products.Count; }
        public int FactLoadPercent { get => FactLoad * 100 / Capacity; }
        public bool IsFull { get => FactLoad == Capacity; }


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
                return true;
            }
        }

        public IProduct RemoveFromStock()
        {
            throw new NotImplementedException();
        }
    }
}
