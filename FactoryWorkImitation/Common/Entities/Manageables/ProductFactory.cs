using FactoryWorkImitation.Interfaces.Entities;
using FactoryWorkImitation.Interfaces.Entities.Manageables;

namespace FactoryWorkImitation.Common.Entities.Manageables
{
    public class ProductFactory : IProductFactory
    {
        List<IProduct> _products = new();
        object _lockObj = new();
        public bool IsEmpty => false;
        public bool IsFull => false;

        public string Name { get; }

        public int ManufactureSpeed { get; } = 1;

        public IProduct FactoryProduct { get; }

        public ProductFactory(string name, int manufactureSpeed, IProduct factoryProduct)
        {
            Name = name;
            ManufactureSpeed = manufactureSpeed;
            FactoryProduct = factoryProduct;
            Console.WriteLine($"{Name} создана. Скорость работы - {manufactureSpeed} товаров в час");
        }
        public bool Load(IProduct product)
        {
            Console.WriteLine($"На фабриках ничего не храним, поэтому мы просто выкидываем товар {product.Name}");
            //на фабрике не храним товар, поэтому просто его обнуляем
            product = null!;
            return true;
        }
        public IProduct Unload()
        {
            lock (_lockObj)
            {
                Console.WriteLine($"{Name} делает новый {FactoryProduct.Name}...");
                Thread.Sleep(3600000 / ManufactureSpeed);
                Console.WriteLine($"{Name} сделала новый товар {FactoryProduct.Name}");
                var product = new Product(FactoryProduct.Name, FactoryProduct.Weight, FactoryProduct.PackingType);
                _products.Add(product);
                return product;
            }
        }

        public void GetStatistic()
        {
            var statisticList = new List<string>();
            statisticList.Add($"Статистика сущности {Name}");
            if (!_products.Any()) statisticList.Add(@"/*** пусто ***/");
            else
            {
                var productGroups = _products.GroupBy(p => p.Name);
                foreach (var product in productGroups)
                {
                    var tmp = product.Count();
                    statisticList.Add($"Выпущено {product.Key} в количестве {tmp} штук");
                }
            }
            foreach (var str in statisticList)
            {
                Console.WriteLine(str);
            }
        }
    }
}
