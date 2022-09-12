using FactoryWorkImitation.Interfaces.Entities;
using FactoryWorkImitation.Interfaces.Entities.Manageables.Base;
using FactoryWorkImitation.Interfaces.Entities.Managers;

namespace FactoryWorkImitation.Common.Entities.Manageables
{
    public class Truck : ITruck
    {
        Stack<IProduct> _products = new();
        object _lockObj = new();

        public string Name { get; }
        public int WeightCapacity { get; }
        public int WeightFactLoad { get; private set; }
        public bool IsEmpty => !_products.Any();
        public bool IsFull => WeightFactLoad == WeightCapacity;
        public ITruckManager? Owner { get; set; }

        public Truck(string name, int weightCapacity)
        {
            Name = name;
            WeightCapacity = weightCapacity;
        }

        public bool Load(IProduct product)
        {
            lock (_lockObj)
            {
                if (product is null || IsFull) return false;
                _products.Push(product);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"В {Name} загрузили товар {product.Name}");
                Console.ResetColor();
                WeightFactLoad += product.Weight;
                return true;
            }
        }
        public IProduct Unload()
        {
            lock (_lockObj)
            {
                if (IsEmpty) return null!;
                var product = _products.Pop();
                if (product is null) return null!;

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Из {Name} выгрузили товар {product.Name}");
                Console.ResetColor();
                WeightFactLoad -= product.Weight;
                return product;
            }
        }

        public void Drive(IManageable place)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Name} поехал в {place.Name}");
            Console.ResetColor();
            Thread.Sleep(100);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Name} приехал в {place.Name}");
            Console.ResetColor();
        }

        public void DriveHome()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Name} поехал в гараж");
            Console.ResetColor();
            Thread.Sleep(100);
            Owner?.PutInTheGarage(this);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"{Name} приехал в гараж");
            Console.ResetColor();
        }
    }
}
