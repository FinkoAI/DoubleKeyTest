namespace DoubleKeyCollection.Interfaces
{
    public interface IDoubleKey<TId, TName>
    {
        TId Id { get; }
        TName Name { get; }
    }
}
