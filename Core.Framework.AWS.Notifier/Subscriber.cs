using System;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.SimpleNotificationService.Model;

namespace Core.Framework.AWS.Notifier
{
    public class Subscriber : BaseNotifier
    {
        public Subscriber(AWSCredentials credentials, RegionEndpoint region)
             : base(credentials, region)
        { }

        public Subscriber(string accessKey, string secretKey)
            : base(accessKey, secretKey)
        { }
        /// <summary>
        /// Subscribe to the specified topic.
        /// </summary>
        /// <returns>Subscription Amazon Resource Name.</returns>
        /// <param name="topicArn">Topic Amazon Resource Name.</param>
        /// <param name="protocol">Subscriber Protocol. Must be one of the follow:
        /// - HTTP
        /// - HTTPS
        /// - E-mail
        /// - SQS
        /// - Lambda
        /// - SMS
        /// </param>
        /// <param name="endpoint">Subscriber endpoint or mail address.</param>
        public virtual async Task<string> Subscribe(string topicArn, string protocol, string endpoint)
        {
            try
            {
                SubscribeRequest request = new SubscribeRequest(topicArn, protocol, endpoint);
                SubscribeResponse response = await _snsClient.SubscribeAsync(request);
                return response.SubscriptionArn;
            }
            catch (Exception ex)
            { throw ex; }
        }
        /// <summary>
        /// Confirms the subscription.
        /// </summary>
        /// <returns>Subscription Amazon Resource Name.</returns>
        /// <param name="topicArn">Topic Amazon Resource Name.</param>
        /// <param name="token">Confirmation token.</param>
        public virtual async Task<string> ConfirmSubscription(string topicArn, string token)
        {
            try
            {
                ConfirmSubscriptionRequest request = new ConfirmSubscriptionRequest(topicArn, token);
                ConfirmSubscriptionResponse response = await _snsClient.ConfirmSubscriptionAsync(request);
                return response.SubscriptionArn;
            }
            catch (Exception ex)
            { throw ex; }
        }
        /// <summary>
        /// Unsubscribe the specified subscription Amazon Resource Name.
        /// </summary>
        /// <returns>The request ID.</returns>
        /// <param name="subscriptionArn">Subscription Amazon Resource Name.</param>
        public virtual async Task<string> Unsubscribe(string subscriptionArn)
        {
            try
            {
                UnsubscribeRequest request = new UnsubscribeRequest(subscriptionArn);
                UnsubscribeResponse response = await _snsClient.UnsubscribeAsync(request);
                return response.ResponseMetadata.RequestId;
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
