using System;

namespace Core.Framework.Entities
{
    public interface IEntity : IDbObject
    {
        DateTimeOffset? UpdatedAt { get; set; }
    }
}
