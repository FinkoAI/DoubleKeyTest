namespace TestApplication.UI.Model
{
    public class UserIdType
    {
        public UserIdType(long identifier, int size)
        {
            Identifier = identifier;
            Size = size;
        }

        public long Identifier { get; }

        public int Size { get; }

        public override bool Equals(object obj)
        {
            return GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return Identifier.GetHashCode() ^ Size.GetHashCode();
        }
    }
}
