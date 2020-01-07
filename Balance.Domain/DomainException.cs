using System;

namespace Balance.Domain
{
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }
    }
}
