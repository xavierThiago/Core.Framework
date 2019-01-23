using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;

namespace Core.Framework.AWS.Notifier
{
    public abstract class BaseNotifier
    {
        protected AmazonSimpleNotificationServiceClient _snsClient;

        protected BaseNotifier(AWSCredentials credentials, RegionEndpoint region)
        {
            _snsClient = new AmazonSimpleNotificationServiceClient(credentials, region);
        }

        protected BaseNotifier(string accessKey, string secretKey)
        {
            AWSCredentials credentials = new BasicAWSCredentials(accessKey, secretKey);
            _snsClient = new AmazonSimpleNotificationServiceClient(credentials, RegionEndpoint.USEast1);
        }
        /// <summary>
        /// Lists the topics.
        /// </summary>
        /// <returns>The first 100 topics Amazon Resource Name.</returns>
        public virtual async Task<List<string>> ListTopics()
        {
            try
            {
                List<string> topics = new List<string>();
                ListTopicsRequest request = new ListTopicsRequest();
                ListTopicsResponse response = await _snsClient.ListTopicsAsync(request);
                response.Topics.ForEach(topic => topics.Add(topic.TopicArn));
                return topics;
            }
            catch (Exception ex)
            { throw ex; }
        }
        /// <summary>
        /// Gets the specified topic.
        /// </summary>
        /// <returns>The topic Amazon Resource Name.</returns>
        /// <param name="topicName">Topic name.</param>
        public virtual async Task<string> GetTopic(string topicName)
        {
            try
            {
                var topic = await _snsClient.FindTopicAsync(topicName);
                return topic?.TopicArn;
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
