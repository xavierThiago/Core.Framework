using System;
using System.Threading.Tasks;
using Amazon.SimpleNotificationService.Model;

namespace Core.Framework.AWS.Notifier
{
    public class Subscriber : BaseNotifier
    {
        public Model.Subscription Subscription { get; private set; }

        public Subscriber(string topicArn, string subscriptionArn)
        {
            Subscription = new Model.Subscription
            {
                Arn = subscriptionArn,
                Topic = new Model.Topic
                {
                    Arn = topicArn
                }
            };
        }

        public Subscriber(string topicArn)
        {
            Subscription = new Model.Subscription
            {
                Topic = new Model.Topic
                {
                    Arn = topicArn
                }
            };
        }

        public virtual async Task<string> Subscribe(string protocol, string endpoint)
        {
            try
            {
                SubscribeRequest request = new SubscribeRequest(Subscription.Topic.Arn, protocol, endpoint);
                SubscribeResponse response = await _snsClient.SubscribeAsync(request);
                Subscription = new Model.Subscription
                {
                    Arn = response.SubscriptionArn
                };
                return response.ResponseMetadata.RequestId;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public virtual async Task<string> ConfirmSubscription(string token)
        {
            try
            {
                ConfirmSubscriptionRequest request = new ConfirmSubscriptionRequest(Subscription.Topic.Arn, token);
                ConfirmSubscriptionResponse response = await _snsClient.ConfirmSubscriptionAsync(request);
                Subscription = new Model.Subscription
                {
                    Arn = response.SubscriptionArn
                };
                return response.ResponseMetadata.RequestId;
            }
            catch (Exception ex)
            { throw ex; }
        }

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

        public virtual async Task<string> Unsubscribe()
        {
            try
            {
                return await Unsubscribe(Subscription.Arn);
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
