
namespace FactoryWorkImitation.Interfaces.Entities
{
    public interface IManager
    {
        List<IFactory> Factories { get; }
        IStock Stock { get; }
        void ManageWork();
    }
}
