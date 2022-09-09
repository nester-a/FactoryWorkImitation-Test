using FactoryWorkImitation.Interfaces.Entities;

namespace FactoryWorkImitation.Common.Entities
{
    public class Manager : IManager
    {
        public IStock Stock { get; }
        public Manager(IStock stock)
        {
            Stock = stock;
            Stock.StockLoadPercent95 += Stock_StockLoadPercent95;
        }

        private void Stock_StockLoadPercent95(object? sender, EventArgs e)
        {
            Console.WriteLine($"Менеджер узнал, что склад заполнен на 95%");
        }
    }
}
