using System;

namespace Core.Framework.API.Messages
{
    public sealed class ResponseMessage
    {
        public string Code
        { get; set; }

        public string Source
        { get; set; }

        public string Message
        { get; set; }

        public string InnerException
        { get; set; }

        public string StackTrace
        { get; set; }

        ResponseMessage()
        { }

        public static ResponseMessage Create(Exception ex, string code)
        {
            return new ResponseMessage
            {
                Code = code,
                InnerException =
                    ex.InnerException != null ? ex.InnerException.Message : String.Empty,
                Message = ex.Message,
                Source = ex.Source,
                StackTrace = ex.StackTrace
            };
        }

        public static ResponseMessage Create(string code, string message)
        {
            return new ResponseMessage
            {
                Code = code,
                Message = message
            };
        }
    }
}
