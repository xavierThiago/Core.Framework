using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Core.Framework.SendGrid.Recipients.Domain;

namespace Core.Framework.SendGrid.Recipients
{
    public interface IRecipientService
    {
        Task<string> CreateAsync(Recipient recipient, CancellationToken cancellationToken = default);
        Task<string> CreateAsync(List<Recipient> recipients, CancellationToken cancellationToken = default);
    }
}
