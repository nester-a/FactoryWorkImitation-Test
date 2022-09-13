using FactoryWorkImitation.Common.Creators;
using FactoryWorkImitation.Common.Entities.Managers;
using FactoryWorkImitation.Common.Entities.Props.Strategies;


//определяем стратегии (синхронные или конкурентные) 
var managerStrat = new ConcurrencyManageStrategy();
var logistStrat = new ConcurrencyTruckStrategy();

//создаем фабрики
var factoryCreator = new FactoryCreator();

factoryCreator.ManufactureSpeed = 5000;
var productFactory = factoryCreator.CreateFactory();
var productFactory2 = factoryCreator.CreateFactory();

//создаем грузовики
var truckCreator = new TruckCreator();

truckCreator.SetSpeed = 12000;
truckCreator.SetWeightCapacity = 100;
var truck = truckCreator.CreateTruck();

truckCreator.SetSpeed = 10000;
truckCreator.SetWeightCapacity = 150;
var truck2 = truckCreator.CreateTruck();

//создаем рынок
var marketCreator = new MarketCreator();
var market = marketCreator.CreateMarket();

//создаём склад
var stockCreator = new StockCreator();
stockCreator.SetCapacity = 200;
var stock = stockCreator.CreateStock();



var manager = new StockManager();
var logist = new TruckManager();
logist.PutInTheGarage(truck);
logist.PutInTheGarage(truck2);
manager.Factories.Add(productFactory);
manager.Factories.Add(productFactory2);
manager.Stock = stock;
manager.Market = market;
manager.LogisticSpecialist = logist;

manager.ManageStrategy = managerStrat;
logist.ManageStrategy = logistStrat;

manager.Manage();

Task.Factory.StartNew(() => Console.ReadKey());

Task.WaitAny();


Console.ReadKey();
