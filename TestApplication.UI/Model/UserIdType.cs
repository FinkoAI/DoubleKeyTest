namespace TestApplication.UI.Model
{
    /// <summary>
    /// Пользовательский ключ
    /// </summary>
    public class UserIdType
    {
        #region Constructors

        public UserIdType(long identifier, int size)
        {
            Identifier = identifier;
            Size = size;
        }

        #endregion

        #region Properties

        public long Identifier { get; private set; }

        public int Size { get; private set; }

        #endregion

        #region Base override members

        public override bool Equals(object obj)
        {
            return GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            return Identifier.GetHashCode() ^ Size.GetHashCode();
        }

        #endregion
    }
}
