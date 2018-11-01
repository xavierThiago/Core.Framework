using System;

namespace Core.Framework.Entities
{
    public interface IEntity
    {
        int ID { get; set; }
        DateTime? CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }
}
