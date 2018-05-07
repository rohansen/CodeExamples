using System;

namespace Core.Factories
{
    public interface IFactory<T>
    {
        T Create();
        bool AppliesToFactory(Type t);
    }
}