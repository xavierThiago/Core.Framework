using System;

namespace Core.Framework.Entities
{
    public interface IDbObject
    {
        int ID { get; set; }
        DateTimeOffset CreatedAt { get; set; }
    }
}
