using FactoryWorkImitation.Common.Entities.Manageables;
using FactoryWorkImitation.Interfaces.Creators;
using FactoryWorkImitation.Interfaces.Entities;

namespace FactoryWorkImitation.Common.Creators
{
    public class TruckCreator : ITruckCreator
    {
        int TrucksCount { get; set; }

        int _speed;
        int _weightCapacity;
        public int SetSpeed
        {
            get { return _speed; }
            set
            {
                if (value < 50) _speed = 50;
                else _speed = value;
            }
        }
        public int SetWeightCapacity
        {
            get { return _weightCapacity; }
            set
            {
                if (value < 80) _weightCapacity = 80;
                else _weightCapacity = value;
            }
        }

        public ITruck CreateTruck()
        {
            TrucksCount++;
            return new Truck($"Грузовик-{TrucksCount}", _weightCapacity, _speed);
        }
    }
}
