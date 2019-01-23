using System;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.SimpleNotificationService.Model;
using Newtonsoft.Json;

namespace Core.Framework.AWS.Notifier
{
    public class Publihser : BaseNotifier
    {
        public Publihser(AWSCredentials credentials, RegionEndpoint region)
            : base(credentials, region)
        { }

        public Publihser(string accessKey, string secretKey)
            : base(accessKey, secretKey)
        { }
        /// <summary>
        /// Creates the topic.
        /// </summary>
        /// <returns>The topic Amazon Resource Name.</returns>
        /// <param name="topicName">Topic name.</param>
        public virtual async Task<string> CreateTopic(string topicName)
        {
            try
            {
                CreateTopicRequest request = new CreateTopicRequest(topicName);
                CreateTopicResponse response = await _snsClient.CreateTopicAsync(request);
                return response.TopicArn;
            }
            catch (Exception ex)
            { throw ex; }
        }
        /// <summary>
        /// Deletes the topic.
        /// </summary>
        /// <returns>The request ID.</returns>
        /// <param name="topicArn">Topic Amazon Resource Name.</param>
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
        /// <summary>
        /// Publish an message in the specified topic.
        /// </summary>
        /// <returns>The message ID.</returns>
        /// <param name="topicArn">Topic Amazon Resource Name.</param>
        /// <param name="message">The message.</param>
        /// <typeparam name="T">The message type.</typeparam>
        public virtual async Task<string> Publish<T>(string topicArn, T message)
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
    }
}
