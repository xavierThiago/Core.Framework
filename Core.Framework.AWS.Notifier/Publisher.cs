using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.SimpleNotificationService.Model;
using Newtonsoft.Json;

namespace Core.Framework.AWS.Notifier
{
    public class Publihser<T> : BaseNotifier
        where T : class
    {
        public Model.Topic Topic { get; private set; }

        public Publihser(string topicARN)
        {
            Topic = new Model.Topic
            {
                Arn = topicARN
            };
        }

        public Publihser()
        {
            Topic = new Model.Topic();
        }

        public virtual async Task<List<Model.Subscription>> ListSubscriptions()
        {
            try
            {
                List<Model.Subscription> subscriptions = new List<Model.Subscription>();
                foreach (Model.Subscription subscription in await ListSubscriptions(null)) subscriptions.Add(subscription);
                return subscriptions;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public virtual async Task<List<Model.Subscription>> ListSubscriptionsByTopic(string topicArn)
        {
            try
            {
                List<Model.Subscription> subscriptions = new List<Model.Subscription>();
                foreach (Model.Subscription subscription in await ListSubscriptionsByTopic(topicArn, null)) subscriptions.Add(subscription);
                return subscriptions;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public virtual async Task<List<Model.Subscription>> ListSubscriptionsByTopic()
        {
            try
            {
                return await ListSubscriptionsByTopic(Topic.Arn);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public virtual async Task<string> CreateTopic(string topicName)
        {
            try
            {
                CreateTopicRequest request = new CreateTopicRequest(topicName);
                CreateTopicResponse response = await _snsClient.CreateTopicAsync(request);
                Topic.Arn = response.TopicArn;
                return response.ResponseMetadata.RequestId;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public virtual async Task<string> DeleteTopic(string topicArn)
        {
            try
            {
                DeleteTopicRequest request = new DeleteTopicRequest(topicArn);
                DeleteTopicResponse response = await _snsClient.DeleteTopicAsync(request);
                return response.ResponseMetadata.RequestId;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public virtual async Task<string> DeleteTopic()
        {
            try
            {
                return await DeleteTopic(Topic.Arn);
            }
            catch (Exception ex)
            { throw ex; }
        }

        public virtual async Task<string> Publish(string topicArn, T message)
        {
            try
            {
                PublishRequest request = new PublishRequest(topicArn, JsonConvert.SerializeObject(message));
                PublishResponse response = await _snsClient.PublishAsync(request);
                return response.MessageId;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public virtual async Task<string> Publish(T message)
        {
            try
            {
                return await Publish(Topic.Arn, message);
            }
            catch (Exception ex)
            { throw ex; }
        }

        async Task<List<Model.Subscription>> ListSubscriptions(string nextToken)
        {
            try
            {
                List<Model.Subscription> subscriptions = new List<Model.Subscription>();
                ListSubscriptionsRequest request = new ListSubscriptionsRequest(nextToken);
                ListSubscriptionsResponse response = await _snsClient.ListSubscriptionsAsync(request);
                response.Subscriptions.ForEach(su => subscriptions.Add(new Model.Subscription
                {
                    Arn = su.SubscriptionArn,
                    Endpoint = su.Endpoint,
                    Owner = su.Owner,
                    Protocol = su.Protocol,
                    Topic = new Model.Topic
                    {
                        Arn = su.TopicArn
                    }
                }));
                foreach (Model.Subscription subscription in await ListSubscriptions(response.NextToken)) subscriptions.Add(subscription);
                return subscriptions;
            }
            catch (Exception ex)
            { throw ex; }
        }

        async Task<List<Model.Subscription>> ListSubscriptionsByTopic(string topicArn, string nextToken)
        {
            try
            {
                List<Model.Subscription> subscriptions = new List<Model.Subscription>();
                ListSubscriptionsByTopicRequest request = new ListSubscriptionsByTopicRequest(topicArn, nextToken);
                ListSubscriptionsByTopicResponse response = await _snsClient.ListSubscriptionsByTopicAsync(request);
                response.Subscriptions.ForEach(su => subscriptions.Add(new Model.Subscription
                {
                    Arn = su.SubscriptionArn,
                    Endpoint = su.Endpoint,
                    Owner = su.Owner,
                    Protocol = su.Protocol,
                    Topic = new Model.Topic
                    {
                        Arn = su.TopicArn
                    }
                }));
                foreach (Model.Subscription subscription in await ListSubscriptionsByTopic(topicArn, response.NextToken)) subscriptions.Add(subscription);
                return subscriptions;
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
