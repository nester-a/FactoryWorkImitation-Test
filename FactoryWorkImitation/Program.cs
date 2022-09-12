﻿using FactoryWorkImitation.Common.Entities.Manageables;
using FactoryWorkImitation.Common.Entities.Managers;
using FactoryWorkImitation.Common.Entities.Props.Strategies;

var truck = new Truck("Грузовик", 100);
var market = new Market();
var productFactory = new ProductFactory("Фабрика");
var stock = new Stock("Склад", 100);

var managerStrat = new ConcurrencyManageStrategy();
var logistStrat = new ConcurrencyTruckStrategy();

var manager = new StockManager();
var logist = new TruckManager();
logist.PutInTheGarage(truck);
manager.Factories.Add(productFactory);
manager.Stock = stock;
manager.Market = market;
manager.LogisticSpecialist = logist;

manager.ManageStrategy = managerStrat;
logist.ManageStrategy = logistStrat;

truck.Owner = logist;

manager.Manage();

Task.WaitAll();
Console.ReadKey();
