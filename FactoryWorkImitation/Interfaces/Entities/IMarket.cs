namespace FactoryWorkImitation.Interfaces.Entities
{
    public interface IMarket
    {
        List<IProduct> Products { get; }
        ITruck? Truck { get; set; }
        void PutProductsOnMarket();
    }
}
