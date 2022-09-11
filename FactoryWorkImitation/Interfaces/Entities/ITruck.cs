using FactoryWorkImitation.Interfaces.Entities.Props;

namespace FactoryWorkImitation.Interfaces.Entities
{
    public interface ITruck
    {
        string Name { get; }
        IShipCompany Home { get; set; }
        IWorkStatus WorkStatus { get; set; }
        int WeightCapacity { get; }
        int FactWeightLoad { get; }
        int FactWeightLoadPercent { get; }
        bool IsFull { get; }
        bool IsEmpty { get; }
        int FreeSpace { get; }
        void StartWork(ITruckOrder order);
    }
}
