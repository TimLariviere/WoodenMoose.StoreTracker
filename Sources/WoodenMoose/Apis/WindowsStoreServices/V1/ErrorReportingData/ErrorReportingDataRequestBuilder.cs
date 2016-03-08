namespace WindowsStoreServices.V1.ErrorReportingData
{
    public class ErrorReportingDataRequestBuilder : GroupableRequestBuilder<ErrorReportingDataRequestBuilder, ErrorReportingDataRequest, ErrorReportingDataOrderBy, ErrorReportingDataGroupBy>
    {
        public ErrorReportingDataRequestBuilder(string applicationId)
            : base(applicationId)
        {
        }
    }
}