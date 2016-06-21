using System.Collections.Generic;
using System.Linq;
using DoubleKeyCollection.Interfaces;

namespace DoubleKeyCollection.Implementations
{
    /// <summary>
    /// Реализация коллекции с двойным ключом
    /// </summary>
    /// <typeparam name="TId">Тип части ключа ID</typeparam>
    /// <typeparam name="TName">Тип части ключа Name</typeparam>
    /// <typeparam name="TValue">Тип значения</typeparam>
    public class DoubleKeyDictionary<TId, TName, TValue> : Dictionary<DoubleKey<TId, TName>, TValue>,
        IDoubleKeyDictionary<TId, TName, TValue>
    {

        /// <summary>
        /// Получет/записывает значение с заданными ключами
        /// В плане эффективности скорости поиска решил оставить стандартный поиск словаря, так как он имеет постоянную производительность O(1)
        /// </summary>
        /// <param name="id">Ключ ID</param>
        /// <param name="name">Ключ Name</param>
        /// <returns></returns>
        public TValue this[TId id, TName name]
        {
            get
            {
                lock (this)
                {
                    return base[DoubleKey<TId, TName>.Create(id, name)];
                }
            }
            set
            {
                lock (this)
                {
                    base[DoubleKey<TId, TName>.Create(id, name)] = value;
                }
            }
        }

        /// <summary>
        /// Добавляет значение с заданными ключами
        /// </summary>
        /// <param name="id">Ключ ID</param>
        /// <param name="name">Ключ Name</param>
        /// <param name="value">Значение</param>
        public void Add(TId id, TName name, TValue value)
        {
            lock (this)
            {
                Add(DoubleKey<TId, TName>.Create(id, name), value);
            }
        }

        /// <summary>
        /// Если переданные ключи найдены, то возвращает true и изменяет параметр value, в противном случае false
        /// В плане эффективности скорости поиска решил оставить стандартный поиск словаря, так как он имеет постоянную производительность O(1)
        /// </summary>
        /// <param name="id">Ключ ID</param>
        /// <param name="name">Ключ Name</param>
        /// <param name="value">Значение (выходной параметр)</param>
        /// <returns></returns>
        public bool TryGetValue(TId id, TName name, out TValue value)
        {
            lock (this)
            {
                return TryGetValue(DoubleKey<TId, TName>.Create(id, name), out value);
            }
        }

        /// <summary>
        /// Если переданные ключи найдены, то возвращает true, в противном случае false
        /// </summary>
        /// <param name="id">Ключ ID</param>
        /// <param name="name">Ключ Name</param>
        /// <returns></returns>
        public bool ContainsKey(TId id, TName name)
        {
            lock (this)
            {
                return ContainsKey(DoubleKey<TId, TName>.Create(id, name));
            }
        }

        /// <summary>
        /// Удаляет запись соответствующую переданным ключам
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool Remove(TId id, TName name)
        {
            lock (this)
            {
                return Remove(DoubleKey<TId, TName>.Create(id, name));
            }
        }

        /// <summary>
        /// Получить список элементов соответствующих Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<TValue> GetById(TId id)
        {
            lock (this)
            {
                var filteredKeys = Keys.ToList().FindAll(x => x.Item1.Equals(id));
                return filteredKeys.Select(key => this[key.Item1, key.Item2]);
            }
        }

        /// <summary>
        /// Получить список элементов соответствующих Name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IEnumerable<TValue> GetByName(TName name)
        {
            lock (this)
            {
                var filterdKeys = Keys.ToList().FindAll(x => x.Item2.Equals(name));
                return filterdKeys.Select(key => this[key.Item1, key.Item2]);
            }
        }
    }
}
