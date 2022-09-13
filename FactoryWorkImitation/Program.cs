using FactoryWorkImitation.Common.Creators;
using FactoryWorkImitation.Common.Entities.Props.Strategies;
using FactoryWorkImitation.Interfaces;
using FactoryWorkImitation.Interfaces.Entities;
using FactoryWorkImitation.Interfaces.Entities.Manageables;


Console.WriteLine("Для начала работы программы нажмите любую клавишу.");
Console.WriteLine("Для вывода статистики и завершения работы также нажмите любую клавишу");
Console.ReadKey();

//держатели статистики
List<IStatisticsHandler> statList = new();

//определяем стратегии (синхронные или конкурентные) 
var managerStrat = new ConcurrencyManageStrategy();
var logistStrat = new ConcurrencyTruckStrategy();

//создаем фабрики
int factoriesCount = 3;
int n = 50;

var factoryCreator = new FactoryCreator();
factoryCreator.ManufactureSpeed = n;
List<IProductFactory> factories = new List<IProductFactory>();
for (int i = 0; i < factoriesCount; i++)
{
    factories.Add(factoryCreator.CreateFactory());
}
foreach (var factory in factories)
{
    statList.Add(factory);
}

//создаем грузовики
var truckCreator = new TruckCreator();

truckCreator.SetSpeed = 120;
truckCreator.SetWeightCapacity = 100;
var truck1 = truckCreator.CreateTruck();

truckCreator.SetSpeed = 100;
truckCreator.SetWeightCapacity = 150;
var truck2 = truckCreator.CreateTruck();

List<ITruck> trucks = new List<ITruck>();
trucks.Add(truck1);
trucks.Add(truck2);

//создаем рынок
var marketCreator = new MarketCreator();
var market = marketCreator.CreateMarket();
statList.Add(market);

//создаём склад
var stockCreator = new StockCreator();
int M = 100;
int factoriesSpeedSum = 0;
foreach (var factory in factories)
{
    factoriesSpeedSum += factory.ManufactureSpeed;
}
stockCreator.SetCapacity = M * factoriesSpeedSum;
var stock = stockCreator.CreateStock();
statList.Add(stock);


//создаём менеджера склада
var managerCreator = new StockManagerCreator();
var manager = managerCreator.CreateStockManager();
manager.ManageStrategy = managerStrat;
manager.Stock = stock;
manager.Market = market;
foreach (var factory in factories)
{
    manager.Factories.Add(factory);
}

//создаём менеджера логистической компании
var logistCreator = new TruckManagerCreator();
var logist = logistCreator.CreateTruckManager();
logist.ManageStrategy = logistStrat;

//паркуем грузовики в гараж логистической компании
foreach (var truck in trucks)
{
    logist.PutInTheGarage(truck);
    statList.Add(truck);
}


//даём менеджеру склада контакты логиста
manager.LogisticSpecialist = logist;


//просим менеджера склада начать работу
manager.Manage();

Task.Factory.StartNew(() => Console.ReadKey());

Task.WaitAny();


Console.ReadKey();

//вывод статистики
for (int i = 0; i < 2; i++)
{
    Console.WriteLine();
}
Console.WriteLine("***ВЫВОД СТАТИСТИКИ***");
foreach (var item in statList)
{
    Console.WriteLine();
    item.GetStatistic();
}
