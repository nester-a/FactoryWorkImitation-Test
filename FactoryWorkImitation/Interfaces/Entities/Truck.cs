using FactoryWorkImitation.Interfaces.Entities.Props;

namespace FactoryWorkImitation.Interfaces.Entities
{
    public abstract class Truck : ITruck
    {
        Stack<IProduct> _products = new();
        public IWorkStatus WorkStatus { get; set; }
        public int WeightCapacity { get; }
        public int FactWeightLoad { get; private set; }
        public int FactWeightLoadPercent { get => FactWeightLoad * 100 / WeightCapacity; }
        public bool IsFull { get => FactWeightLoad == WeightCapacity; }
        public int FreeSpace { get => WeightCapacity - FactWeightLoad; }
        public string Name { get; }

        public Truck(string name, int weightCapacity)
        {
            Name = name;
            WeightCapacity = weightCapacity;
        }

        public bool LoadOnTruck(IProduct product)
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

        public IProduct UnloadFromTruck()
        {
            if(!_products.Any()) return null!;
            var product = _products.Pop();
            FactWeightLoad -= product.Weight;
            return product;
        }
    }
}
