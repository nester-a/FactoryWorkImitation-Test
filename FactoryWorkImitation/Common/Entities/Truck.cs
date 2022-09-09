using FactoryWorkImitation.Interfaces.Entities;

namespace FactoryWorkImitation.Common.Entities
{
    public class Truck : ITruck
    {
        public Stack<IProduct> Products { get; } = new();
        public event EventHandler? TruckOnStock;
        public event EventHandler? TruckOnMarket;
        public int Capacity { get; }
        public int FactLoad { get; private set; }
        public bool IsFull { get => FactLoad == Capacity; }
        public int FreeSpace { get => Capacity - FactLoad; }
        public int FactLoadPercent { get => FactLoad * 100 / Capacity; }

        public IShipCompany Home { get; set; }

        public Truck(int capacity)
        {
            Capacity = capacity;
        }
        public void MoveTo(IStock stock)
        {
            Console.WriteLine("Грузовик поехал на склад...");
            Thread.Sleep(1);
            stock.Truck = this;
            Console.WriteLine("Грузовик на складе");
            TruckOnStock?.Invoke(this, new EventArgs());
        }

        public void MoveTo(IMarket market)
        {
            Console.WriteLine("Грузовик поехал на рынок...");
            Thread.Sleep(1);
            market.Truck = this;
            Console.WriteLine("Грузовик на рынке");
            TruckOnMarket?.Invoke(this, new EventArgs());
        }
        public void MoveHome()
        {
            Console.WriteLine("Грузовик поехал домой...");
            Thread.Sleep(1);
            Home.Truck = this;
            Console.WriteLine("Грузовик дома");
        }
        public bool PickUp(IProduct product)
        {
            if (IsFull || FactLoad + product.Weight > Capacity)
            {
                Console.WriteLine($"Грузовик полный");
                return false;
            }
            Products.Push(product);
            FactLoad += product.Weight;
            Console.WriteLine($"В грузовике - {Products.Count} товаров. Вес - {FactLoad}. Заполненность - {FactLoadPercent}%");

            return true;
        }
        public IProduct UnloadProduct()
        {
            if (!Products.Any()) return null!;
            var product = Products.Pop();
            if(product is not null)
                FactLoad -= product.Weight;
            return product;
        }
    }
}
