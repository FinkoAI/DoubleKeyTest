using System;
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
    public class DoubleKeyDictionary<TId, TName, TValue> : Dictionary<IDoubleKey<TId, TName>, TValue>,
        IDoubleKeyDictionary<TId, TName, TValue>
    {
        #region Private fields

        private readonly Dictionary<TId, List<IDoubleKey<TId, TName>>> _idIndexDictionary;
        private readonly Dictionary<TName, List<IDoubleKey<TId, TName>>> _nameIndexDictionary;

        #endregion

        #region Constructors

        public DoubleKeyDictionary()
        {
            _idIndexDictionary = new Dictionary<TId, List<IDoubleKey<TId, TName>>>();
            _nameIndexDictionary = new Dictionary<TName, List<IDoubleKey<TId, TName>>>();
        }

        #endregion

        #region Public properties

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

        #endregion

        #region Public members

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
                var newKey = DoubleKey<TId, TName>.Create(id, name);

                Add(newKey, value);
                List<IDoubleKey<TId, TName>> keyHashForId;
                List<IDoubleKey<TId, TName>> keyHashForName;

                if (_idIndexDictionary.TryGetValue(id, out keyHashForId))
                {
                    keyHashForId.Add(newKey);
                }
                else
                {
                    _idIndexDictionary.Add(id, new List<IDoubleKey<TId, TName>> {newKey});
                }

                if (_nameIndexDictionary.TryGetValue(name, out keyHashForName))
                {
                    keyHashForName.Add(newKey);
                }
                else
                {
                    _nameIndexDictionary.Add(name, new List<IDoubleKey<TId, TName>> {newKey});
                }

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
                var keyForRemove = DoubleKey<TId, TName>.Create(id, name);

                if (!Remove(keyForRemove))
                    return false;

                _idIndexDictionary[id].Remove(keyForRemove);
                _nameIndexDictionary[name].Remove(keyForRemove);

                return true;
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
                List<IDoubleKey<TId, TName>> filteredKeys;

                return _idIndexDictionary.TryGetValue(id, out filteredKeys)
                    ? filteredKeys.Select(key => this[key.Id, key.Name])
                    : new List<TValue>();
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
                List<IDoubleKey<TId, TName>> filteredKeys;
                return _nameIndexDictionary.TryGetValue(name, out filteredKeys)
                    ? filteredKeys.Select(key => this[key.Id, key.Name])
                    : new List<TValue>();
            }
        }

        /// <summary>
        /// Очищает коллекцию
        /// </summary>
        public new void Clear()
        {
            lock (this)
            {
                base.Clear();
                _idIndexDictionary.Clear();
                _nameIndexDictionary.Clear();
            }
        }
        #endregion
        
    }
}
