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

        public long Identifier { get; }

        public int Size { get; }

        #endregion

        #region Base override members

        public override bool Equals(object obj)
        {
            return GetHashCode() == obj.GetHashCode();
        }

        public override int GetHashCode()
        {
            var hash = 17;
            hash = hash*31 + Identifier.GetHashCode();
            hash = hash*31 + Size.GetHashCode();

            return hash;
        }

        #endregion
    }
}
