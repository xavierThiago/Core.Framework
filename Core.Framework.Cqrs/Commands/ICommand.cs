using System.ComponentModel.DataAnnotations;

namespace Core.Framework.Cqrs.Commands
{
    public interface ICommand : IValidatableObject
    { }
}
