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

        int LoadPercent => WeightFactLoad * 100 / WeightCapacity;
        public int EmptyDriveSpeed { get; }
        int FullDriveSpeed => (int)(EmptyDriveSpeed * 0.6);
        int CurrentSpeed
        {
            get
            {
                if (LoadPercent == 0) return EmptyDriveSpeed;
                return EmptyDriveSpeed - ((EmptyDriveSpeed - FullDriveSpeed) * 100 / LoadPercent);
            }
        }

        public Truck(string name, int weightCapacity, int emptyDriveSpeed)
        {
            Name = name;
            WeightCapacity = weightCapacity;
            EmptyDriveSpeed = emptyDriveSpeed;
            SendMessage($"{Name} создан. Вместимость - {WeightCapacity} кг. Скорость порожнем - {EmptyDriveSpeed} км/ч");
        }

        public bool Load(IProduct product)
        {
            lock (_lockObj)
            {
                if (product is null || IsFull) return false;
                _products.Push(product);
                SendMessage($"В {Name} загрузили товар {product.Name}");
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

                SendMessage($"Из {Name} выгрузили товар {product.Name}");
                WeightFactLoad -= product.Weight;
                return product;
            }
        }

        public void Drive(IManageable place)
        {
            SendMessage($"{Name} поехал в {place.Name} со скоростью {CurrentSpeed} км/ч. Процент загрузки - {LoadPercent}%");
            Thread.Sleep(3600000 / CurrentSpeed);
            SendMessage($"{Name} приехал в {place.Name}");
        }

        public void DriveHome()
        {
            SendMessage($"{Name} поехал в гараж со скоростью {CurrentSpeed} км/ч");
            Thread.Sleep(3600000 / CurrentSpeed);
            Owner?.PutInTheGarage(this);
            SendMessage($"{Name} приехал в гараж");
        }

        void SendMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
