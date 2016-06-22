namespace DoubleKeyCollection.Interfaces
{
    /// <summary>
    /// Интерфейс парного ключа
    /// </summary>
    /// <typeparam name="TId"></typeparam>
    /// <typeparam name="TName"></typeparam>
    public interface IDoubleKey<TId, TName>
    {
        TId Id { get; }
        TName Name { get; }        
    }
}
