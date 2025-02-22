namespace Ledger.Entities.Exceptions
{
    public class MissingRequiredPropertyException : Exception
    {
        public string PropertyName { get; set; }
        public string OwnerName { get; set; }

        public MissingRequiredPropertyException(string propertyName, string ownerName)
            : base($"The required property {ownerName}.{propertyName} is default when it should not be.")
        {
            PropertyName = propertyName;
            OwnerName = ownerName;
        }
    }
}
