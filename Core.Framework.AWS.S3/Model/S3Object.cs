using System;

namespace Core.Framework.AWS.S3.Model
{
    public sealed class S3Object
    {
        public string Key { get; set; }
        public DateTime LastModified { get; set; }
        public long Size { get; set; }
    }
}
