using FactoryWorkImitation.Common.Creators;
using FactoryWorkImitation.Common.Entities.Manageables;
using FactoryWorkImitation.Common.Entities.Managers;
using FactoryWorkImitation.Common.Entities.Props.Strategies;


var factoryCreator = new FactoryCreator();
var productFactory = factoryCreator.CreateFactory();
var productFactory2 = factoryCreator.CreateFactory();
var truck = new Truck("Грузовик", 100);
var truck2 = new Truck("Большой грузовик", 200);
var market = new Market();
var stock = new Stock("Склад", 100);

var managerStrat = new ConcurrencyManageStrategy();
var logistStrat = new ConcurrencyTruckStrategy();

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

truck.Owner = logist;

manager.Manage();

Task.WaitAll();
Console.ReadKey();
