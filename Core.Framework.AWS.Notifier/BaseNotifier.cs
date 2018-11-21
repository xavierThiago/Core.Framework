using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace Core.Framework.AWS.Notifier
{
    public abstract class BaseNotifier
    {
        protected AmazonSimpleNotificationServiceClient _snsClient;

        protected BaseNotifier()
        {
            _snsClient = new AmazonSimpleNotificationServiceClient();
        }

        public virtual async Task<List<Model.Topic>> ListTopics()
        {
            try
            {
                List<Model.Topic> topics = new List<Model.Topic>();
                foreach (Model.Topic topic in await ListTopics(null)) topics.Add(topic);
                return topics;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public virtual async Task<Model.Topic> FindTopic(string topicName)
        {
            try
            {
                Topic topic = await _snsClient.FindTopicAsync(topicName);
                return topic != null
                    ? new Model.Topic
                    {
                        Arn = topic.TopicArn
                    }
                    : null;
            }
            catch (Exception ex)
            { throw ex; }
        }

        async Task<List<Model.Topic>> ListTopics(string nextToken)
        {
            try
            {
                List<Model.Topic> topics = new List<Model.Topic>();
                ListTopicsRequest request = new ListTopicsRequest(nextToken);
                ListTopicsResponse response = await _snsClient.ListTopicsAsync(request);
                response.Topics.ForEach(to => topics.Add(new Model.Topic
                {
                    Arn = to.TopicArn
                }));
                foreach (Model.Topic topic in await ListTopics(response.NextToken)) topics.Add(topic);
                return topics;
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
