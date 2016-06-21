namespace DoubleKeyCollection.Interfaces
{
    public interface IDoubleKey<out TId, out TName>
    {
        TId Id { get; }
        TName Name { get; }
    }
}
