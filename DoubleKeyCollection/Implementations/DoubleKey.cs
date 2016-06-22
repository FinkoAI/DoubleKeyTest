using System;
using DoubleKeyCollection.Interfaces;

namespace DoubleKeyCollection.Implementations
{
    /// <summary>
    /// Тип объект типа двойного ключа
    /// </summary>
    /// <typeparam name="TId">Тип части ключа Id</typeparam>
    /// <typeparam name="TName">Тип части ключа Name</typeparam>
    public class DoubleKey<TId, TName> : Tuple<TId, TName>, IDoubleKey<TId, TName>
    {
        #region Constructors
        private DoubleKey(TId id, TName name) :
            base(id, name)
        {
        }
        #endregion

        #region Properties
        public TId Id => Item1;

        public TName Name => Item2;

        #endregion

        #region Public methods

        /// <summary>
        /// Создаёт новый объект ключа
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static DoubleKey<TId, TName> Create(TId id, TName name)
        {
            return new DoubleKey<TId, TName>(id, name);
        }

        #endregion
    }
}
