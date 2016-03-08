using System;
using System.Collections.Generic;
using WindowsStoreServices.V1.Common;

namespace WindowsStoreServices.V1
{
    public class RequestBuilder
    {
    }

    public class RequestBuilder<TRequestBuilder, TRequest, TOrderByFields> : RequestBuilder
        where TRequestBuilder : RequestBuilder
        where TRequest : Request<TOrderByFields>, new()
    {
        protected TRequest Request { get; set; } = new TRequest();

        public RequestBuilder(string applicationId)
        {
            Request.ApplicationId = applicationId;
        }

        #region Methods

        public TRequestBuilder AggregateBy(AggregationLevels? value)
        {
            Request.AggregationLevel = value;
            return this as TRequestBuilder;
        }

        public TRequestBuilder Between(DateTime? startDate, DateTime? endDateTime)
        {
            Request.StartDate = startDate;
            Request.EndDate = endDateTime;
            return this as TRequestBuilder;
        }

        public TRequestBuilder Skip(int? value)
        {
            Request.Skip = value;
            return this as TRequestBuilder;
        }

        public TRequestBuilder Take(int? value)
        {
            Request.Top = value;
            return this as TRequestBuilder;
        }

        public TRequestBuilder OrderBy(TOrderByFields orderByValue, OrderByDirections orderByDirection = OrderByDirections.Ascending)
        {
            Request.OrderBy = new List<Tuple<TOrderByFields, OrderByDirections>>()
            {
                Tuple.Create(orderByValue, orderByDirection)
            };
            return this as TRequestBuilder;
        }

        public TRequestBuilder ThenOrderBy(TOrderByFields orderByValue, OrderByDirections orderByDirection = OrderByDirections.Ascending)
        {
            Request.OrderBy.Add(Tuple.Create(orderByValue, orderByDirection));
            return this as TRequestBuilder;
        }

        public TRequest GetResult()
        {
            return Request;
        }

        #endregion
    }
}
