using FactoryWorkImitation.Interfaces.Entities;
using FactoryWorkImitation.Interfaces.Entities.Manageables;

namespace FactoryWorkImitation.Common.Entities.Manageables
{
    public class Market : IMarket
    {
        object _lockObj = new();
        List<IProduct> _products = new();

        public Market()
        {
            SendMessage($"{Name} создан");
        }

        public string Name => "Рынок";
        public bool IsEmpty => false;
        public bool IsFull => false;

        public void GetStatistic()
        {
            var statisticList = new List<string>();
            statisticList.Add($"Статистика сущности {Name}");
            var productGroups = _products.GroupBy(p => p.Name);
            foreach (var product in productGroups)
            {
                var tmp = product.Count();
                statisticList.Add($"{product.Key} в количестве {tmp} штук");
            }
            foreach (var str in statisticList)
            {
                SendMessage(str);
            }
        }

        public bool Load(IProduct product)
        {
            lock (_lockObj)
            {
                if (product is null) return false;
                _products.Add(product);
                SendMessage($"Товар {product.Name} попал на рынок");
                return true;
            }
        }
        public IProduct Unload()
        {
            //с рынка нельзя выгружать товар
            return null!;
        }
        void SendMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
