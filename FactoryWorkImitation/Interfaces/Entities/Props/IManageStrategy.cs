﻿namespace FactoryWorkImitation.Interfaces.Entities.Props
{
    public interface IManageStrategy
    {
        void Do(IManageable unloadingObject, IManageable loadingObject);
    }
}
