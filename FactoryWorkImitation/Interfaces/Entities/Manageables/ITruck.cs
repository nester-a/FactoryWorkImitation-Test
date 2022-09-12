using FactoryWorkImitation.Interfaces.Entities.Manageables.Base;
using FactoryWorkImitation.Interfaces.Entities.Managers;

namespace FactoryWorkImitation.Interfaces.Entities
{
    public interface ITruck : IManageable
    {
        ITruckManager Owner { get; set; }
        int WeightCapacity { get; }
        int WeightFactLoad { get; }

        void Drive(IManageable place);
        void DriveHome();
    }
}
