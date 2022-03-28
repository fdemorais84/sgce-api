using System;
using FluentValidator;

namespace SGCE.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Entity(Guid id)
        {
            this.Id = id;
        }

        public Guid Id { get; private set; }
    }
}