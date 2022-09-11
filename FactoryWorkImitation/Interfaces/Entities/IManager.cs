using FactoryWorkImitation.Interfaces.Entities.Props;

namespace FactoryWorkImitation.Interfaces.Entities
{
    public interface IManager
    {
        IWorkStatus WorkStatus { get; }
        List<IFactory> Factories { get; }
        IStock Stock { get; }
        void ManageWork();
    }
}
