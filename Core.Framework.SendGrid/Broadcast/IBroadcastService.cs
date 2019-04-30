using System.Threading;
using System.Threading.Tasks;
using Core.Framework.SendGrid.Broadcast.Domain;

namespace Core.Framework.SendGrid.Broadcast
{
    public interface IBroadcastService
    {
        Task<string> CreateAsync(BroadcastList broadcastList, CancellationToken cancellationToken = default);
    }
}
