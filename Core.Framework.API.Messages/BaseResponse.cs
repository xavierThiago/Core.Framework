using System.Collections.Generic;

namespace Core.Framework.API.Messages
{
    public abstract class BaseResponse<T>
        where T : class
    {
        public int StatusCode
        { get; set; }
        public List<ResponseMessage> Messages
        { get; set; }
        public T Data
        { get; set; }

        protected BaseResponse()
        {
            Messages = new List<ResponseMessage>();
        }
    }
}
