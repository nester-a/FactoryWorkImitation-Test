using FactoryWorkImitation.Interfaces.Entities;

namespace FactoryWorkImitation.Common.Entities.Manageables
{
    public class Stock : IStock
    {
        List<IProduct> _loadList = new();
        List<IProduct> _unloadList = new();
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
            SendMessage($"{Name} создан. Вместимость - {Capacity} товаров");
        }

        public bool Load(IProduct product)
        {
            lock (_lockObj)
            {
                if (product is null || IsFull)
                {
                    if (IsFull)
                    {
                        SendMessage("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!Склад заполнен!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                    return false;
                }
                _products.Enqueue(product);
                _loadList.Add(product);
                SendMessage($"На {Name} попал товар {product.Name}. Общее кол-во товаров - {FactLoad} штук, процент загрузки - {FactLoadPercent}%");
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
                _unloadList.Add(product);
                SendMessage($"Со {Name} забрали товар {product.Name}. Товаров осталось - {FactLoad} штук, процент загрузки - {FactLoadPercent}%");
                return product;
            }
        }

        void SendMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void GetStatistic()
        {
            var statisticList = new List<string>();
            statisticList.Add($"Статистика сущности {Name}");

            StatisticsHelper(statisticList, _loadList, "Загрузка товаров");
            StatisticsHelper(statisticList, _unloadList, "Выгрузка товаров");
            //statisticList.Add("Загрузка товаров");
            //if(!_loadList.Any()) statisticList.Add(@"/*** пусто ***/");
            //else
            //{
            //    var loadGroups = _loadList.GroupBy(p => p.Name);
            //    foreach (var product in loadGroups)
            //    {
            //        var tmp = product.Count();
            //        statisticList.Add($"{product.Key} был загружен в количестве {tmp} штук");
            //    }
            //}
            //statisticList.Add("Выгрузка товаров");
            //if (!_unloadList.Any()) statisticList.Add(@"/*** пусто ***/");
            //else
            //{
            //    var unloadGroups = _unloadList.GroupBy(p => p.Name);
            //    foreach (var product in unloadGroups)
            //    {
            //        var tmp = product.Count();
            //        statisticList.Add($"{product.Key} был выгружен в количестве {tmp} штук");
            //    }
            //}
            foreach (var str in statisticList)
            {
                SendMessage(str);
            }
        }
        private void StatisticsHelper(List<string> statisticList, List<IProduct> productsList, string title)
        {
            statisticList.Add(title);
            if (!productsList.Any()) statisticList.Add(@"/*** пусто ***/");
            else
            {
                var loadGroups = productsList.GroupBy(p => p.Name);
                foreach (var product in loadGroups)
                {
                    var tmp = product.Count();
                    statisticList.Add($"{product.Key} в количестве {tmp} штук");
                }
            }

        }
    }
}
