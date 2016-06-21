using System;
using DoubleKeyCollection.Interfaces;

namespace DoubleKeyCollection.Implementations
{
    public class DoubleKey<TId, TName> : Tuple<TId, TName>, IDoubleKey<TId, TName>
    {
        public DoubleKey(TId id, TName name) :
            base(id, name)
        {

        }

        public TId Id => Item1;

        public TName Name => Item2;

        public static DoubleKey<TId, TName> Create(TId id, TName name)
        {
            return new DoubleKey<TId, TName>(id, name);
        }
    }
}
