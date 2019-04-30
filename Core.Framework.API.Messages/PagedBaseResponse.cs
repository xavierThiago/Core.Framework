using System;
using System.Collections.Generic;

namespace Core.Framework.API.Messages
{
    public abstract class PagedBaseResponse<T> : BaseResponse<T>
        where T : class
    {
        public int Page
        { get; set; } = 0;

        public int PageSize
        { get; set; } = 1;

        public int TotalCount
        {
            get
            {
                if (Data is IList<T>)
                    return ((IList<T>)Data).Count;

                return 1;
            }
        }

        public int TotalPages
        {
            get
            { return (int)Math.Round((decimal)TotalCount / PageSize); }
        }
    }
}
