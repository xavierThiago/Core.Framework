using System.Collections.Generic;

namespace Core.Framework.API.Messages
{
    public abstract class BaseResponse<T>
        where T : class
    {
        public string StatusCode
        { get; set; }
        public int ResponseTime
        { get; set; }
        public List<ResponseMessage> Messages
        { get; set; }
        public List<T> Data
        { get; set; }

        protected BaseResponse()
        {
            Messages = new List<ResponseMessage>();
            Data = new List<T>();
        }
    }
}
