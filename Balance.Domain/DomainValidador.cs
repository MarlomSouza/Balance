namespace Balance.Domain
{
    public class DomainValidator
    {
        public static DomainValidator New() => new DomainValidator();
        public DomainValidator When(bool condition, string message)
        {
            if (condition)
                throw new DomainException(message);

            return this;
        }
    }
}