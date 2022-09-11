using FactoryWorkImitation.Common.Entities.Props;
using FactoryWorkImitation.Interfaces.Entities.Props;

namespace FactoryWorkImitation.Interfaces.Entities
{
    public abstract class Truck : ITruck
    {
        Stack<IProduct> _products = new();
        int _speed;
        int _loadSpeed;

        public IWorkStatus WorkStatus { get; set; }
        public int WeightCapacity { get; }
        public int FactWeightLoad { get; private set; }
        public int FactWeightLoadPercent { get => FactWeightLoad * 100 / WeightCapacity; }
        public bool IsFull { get => FactWeightLoad == WeightCapacity; }
        public bool IsEmpty { get => FactWeightLoad == 0; }
        public int FreeSpace { get => WeightCapacity - FactWeightLoad; }
        public string Name { get; }
        public IShipCompany Home { get; set; }

        public Truck(string name, int weightCapacity, int speed)
        {
            Name = name;
            WeightCapacity = weightCapacity;
            _speed = speed;
            _loadSpeed = _speed - (_speed * 20 / 100);
        }

        private bool LoadOnTruck(IProduct product)
        {
            if (product is null) return false;
            if (IsFull || FreeSpace < product.Weight) 
            {
                Console.WriteLine($"{Name} заполнен");
                return false;
            }
            Console.WriteLine($"{product.Name} разместили в {Name}");
            _products.Push(product);
            FactWeightLoad += product.Weight;
            Console.WriteLine($"Общий вес товаров в {Name} - {FactWeightLoad} товаров. Заполненность - {FactWeightLoadPercent}%. Свободного веса - {FreeSpace}.");
            return true;
        }

        private IProduct UnloadFromTruck()
        {
            if(!_products.Any()) return null!;
            var product = _products.Pop();
            FactWeightLoad -= product.Weight;
            return product;
        }

        public void StartWork(ITruckOrder order)
        {
            WorkStatus = new OnWorkStatus();
            var stock = order.Stock;
            var market = order.Market;

            MoveTo(stock);
            MoveTo(market);
            MoveHome();
        }

        private void MoveTo(IStock stock)
        {
            Console.WriteLine($"{Name} поехал на склад. Скорость движения - {_speed}");
            Thread.Sleep(10000 / _speed);
            Console.WriteLine($"{Name} прибыл на рынок");
            do
            {
                var product = stock.RemoveFromStock();
                if (product is null) break;
                var loadResult = LoadOnTruck(product);
                if (!loadResult) 
                {
                    stock.PutOnStock(product);
                    break; 
                }
            } while (!IsFull);
        }

        private void MoveTo(IMarket market)
        {
            Console.WriteLine($"{Name} поехал на рынок. Скорость движения - {_loadSpeed}");
            Thread.Sleep(10000 / _loadSpeed);
            Console.WriteLine($"{Name} прибыл на рынок");
            do
            {
                var product = UnloadFromTruck();
                if (product is null) break;
                market.PutOnMarket(product);
            } while (!IsEmpty);
        }

        private void MoveHome()
        {
            Console.WriteLine($"{Name} поехал в гараж. Скорость движения - {_speed}");
            Thread.Sleep(10000 / _speed);
            Console.WriteLine($"{Name} приехал в гараж");
            Home.ParkTheTruck(this);
        }
    }
}
