using FactoryWorkImitation.Common.Creators;
using FactoryWorkImitation.Common.Entities.Props.Strategies;
using FactoryWorkImitation.Interfaces.Entities;
using FactoryWorkImitation.Interfaces.Entities.Manageables;


//определяем стратегии (синхронные или конкурентные) 
var managerStrat = new ConcurrencyManageStrategy();
var logistStrat = new ConcurrencyTruckStrategy();

//создаем фабрики
var factoryCreator = new FactoryCreator();

factoryCreator.ManufactureSpeed = 500;
List<IProductFactory> factories = new List<IProductFactory>();
for (int i = 0; i < 2; i++)
{
    factories.Add(factoryCreator.CreateFactory());
}

//создаем грузовики
var truckCreator = new TruckCreator();

truckCreator.SetSpeed = 1200;
truckCreator.SetWeightCapacity = 100;
var truck1 = truckCreator.CreateTruck();

truckCreator.SetSpeed = 1000;
truckCreator.SetWeightCapacity = 150;
var truck2 = truckCreator.CreateTruck();

List<ITruck> trucks = new List<ITruck>();
trucks.Add(truck1);
trucks.Add(truck2);

//создаем рынок
var marketCreator = new MarketCreator();
var market = marketCreator.CreateMarket();

//создаём склад
var stockCreator = new StockCreator();
stockCreator.SetCapacity = 200;
var stock = stockCreator.CreateStock();


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
}


//даём менеджеру склада контакты логиста
manager.LogisticSpecialist = logist;


//просим менеджера склада начать работу
manager.Manage();

Task.Factory.StartNew(() => Console.ReadKey());

Task.WaitAny();


Console.ReadKey();
