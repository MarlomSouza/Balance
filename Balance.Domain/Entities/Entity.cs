using System;

namespace Balance.Domain.Entities
{
    public abstract class Entity<T>
    {
        public string Id { get; protected set; } = Guid.NewGuid().ToString();

    }
}