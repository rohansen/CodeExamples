using Core.Factories;
using System;
using System.Collections.Generic;

namespace Core.Strategies
{
    public interface IStrategy<T>
    {
        IEnumerable<IFactory<T>> Factories { get; set; }
        T Create(Type type);
    }
}