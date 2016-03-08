using System.Collections.Generic;
using WindowsStoreServices.V1.Common;

namespace WindowsStoreServices.V1
{
    public class GroupableRequestBuilder<TRequestBuilder, TRequest, TOrderByFields, TGroupByFields>
        : RequestBuilder<TRequestBuilder, TRequest, TOrderByFields>
        where TRequestBuilder : GroupableRequestBuilder<TRequestBuilder, TRequest, TOrderByFields, TGroupByFields>
        where TRequest : GroupableRequest<TOrderByFields, TGroupByFields>, new()
    {
        public GroupableRequestBuilder(string applicationId)
            : base(applicationId)
        {
            Request.GroupBy = new List<TGroupByFields>();
        }

        public TRequestBuilder GroupBy(TGroupByFields groupByValue)
        {
            Request.GroupBy = new List<TGroupByFields>()
            {
                groupByValue
            };
            return this as TRequestBuilder;
        }

        public TRequestBuilder ThenGroupBy(TGroupByFields groupByValue)
        {
            Request.GroupBy.Add(groupByValue);
            return this as TRequestBuilder;
        }
    }
}
