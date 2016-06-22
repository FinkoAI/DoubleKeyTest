using System.Collections.Generic;

namespace DoubleKeyCollection.Interfaces
{
    public interface IDoubleKeyDictionary<TId, TName, TValue> : IDictionary<IDoubleKey<TId, TName>, TValue>
    {
        TValue this[TId id, TName name] { get; set; }
        void Add(TId id, TName name, TValue value);
        bool TryGetValue(TId id, TName name, out TValue value);
        bool ContainsKey(TId id, TName name);
        bool Remove(TId id, TName name);
        IEnumerable<TValue> GetById(TId id);
        IEnumerable<TValue> GetByName(TName name);
        new void Clear();
    }
}
