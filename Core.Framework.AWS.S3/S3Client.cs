using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Core.Framework.AWS.S3.Model;

namespace Core.Framework.AWS.S3
{
    public class S3Client
    {
        readonly AmazonS3Client _client;

        public S3Client(string awsAccessKeyID, string awsSecretAccessKey)
        {
            _client = new AmazonS3Client(awsAccessKeyID, awsSecretAccessKey);
        }

        public S3Client()
        {
            _client = new AmazonS3Client();
        }

        ~S3Client()
        {
            _client.Dispose();
        }

        public async Task<List<Bucket>> ListBuckets()
        {
            List<Bucket> buckets = new List<Bucket>();

            try
            {
                ListBucketsRequest request = new ListBucketsRequest();
                ListBucketsResponse response = await _client.ListBucketsAsync(request);
                response.Buckets.ForEach(bucket => buckets.Add(new Bucket
                {
                    CreationDate = bucket.CreationDate,
                    Name = bucket.BucketName
                }));
                return buckets;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public async Task<string> CreateBucket(string bucketName)
        {
            try
            {
                PutBucketRequest request = new PutBucketRequest
                {
                    BucketName = bucketName,
                    UseClientRegion = true
                };
                PutBucketResponse response = await _client.PutBucketAsync(request);
                return response.ResponseMetadata.RequestId;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public async Task<string> DeleteBucket(string bucketName)
        {
            try
            {
                DeleteBucketRequest request = new DeleteBucketRequest
                {
                    BucketName = bucketName,
                    UseClientRegion = true
                };
                DeleteBucketResponse response = await _client.DeleteBucketAsync(request);
                return response.ResponseMetadata.RequestId;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public async Task<List<Model.S3Object>> ListObjects(string bucketName, string delimiter = null, string marker = null, int maxKeys = 0, string prefix = null)
        {
            List<Model.S3Object> objects = new List<Model.S3Object>();

            try
            {
                ListObjectsRequest request = new ListObjectsRequest
                {
                    BucketName = bucketName,
                    Delimiter = delimiter,
                    Marker = marker,
                    MaxKeys = maxKeys,
                    Prefix = prefix
                };
                ListObjectsResponse response = await _client.ListObjectsAsync(request);
                response.S3Objects.ForEach(obj => new Model.S3Object
                {
                    Key = obj.Key,
                    LastModified = obj.LastModified,
                    Size = obj.Size
                });
                return objects;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public async Task<string> PutObject(string bucketName, string key, string contentType, string contentBody)
        {
            try
            {
                PutObjectRequest request = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = key,
                    ContentType = contentType,
                    ContentBody = contentBody
                };
                PutObjectResponse response = await _client.PutObjectAsync(request);
                return response.ResponseMetadata.RequestId;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public async Task<string> PutObject(string bucketName, string key, string filePath)
        {
            try
            {
                PutObjectRequest request = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = key,
                    FilePath = filePath
                };
                PutObjectResponse response = await _client.PutObjectAsync(request);
                return response.ResponseMetadata.RequestId;
            }
            catch (Exception ex)
            { throw ex; }
        }

        public async Task<string> DeleteObject(string bucketName, string key)
        {
            try
            {
                DeleteObjectRequest request = new DeleteObjectRequest
                {
                    BucketName = bucketName,
                    Key = key
                };
                DeleteObjectResponse response = await _client.DeleteObjectAsync(request);
                return response.ResponseMetadata.RequestId;
            }
            catch (Exception ex)
            { throw ex; }
        }
    }
}
