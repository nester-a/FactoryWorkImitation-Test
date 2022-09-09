// See https://aka.ms/new-console-template for more information
using FactoryWorkImitation.Common.Creators;
using FactoryWorkImitation.Common.Entities;

Console.WriteLine("Hello, World!");
var factory_creator = new FactoryCreator(500);
while(factory_creator.FactorysCount != 3)
{
    factory_creator.CreateFactory();
}
int wholeSpeed = 0;
foreach (var item in factory_creator.Factories)
{
    wholeSpeed += item.ManufactureSpeed;
}
var stock = new Stock(100);
Console.WriteLine($"Вместимость склада - {100}");

foreach (var factory in factory_creator.Factories)
{
    factory.Stock = stock;
    Task.Factory.StartNew(() =>
    {
        do
        {
            factory.CreateProduct();
        } while (!stock.IsFull);
    });
})
Task.WaitAny();
Console.Read();
