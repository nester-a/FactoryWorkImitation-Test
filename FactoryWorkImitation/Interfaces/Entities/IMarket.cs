namespace FactoryWorkImitation.Interfaces.Entities
{
    public interface IMarket
    {
        List<IProduct> Products { get; }
        void PutOnMarket(IProduct product);
    }
}
