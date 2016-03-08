namespace WindowsStoreServices.V1.AppAcquisitions
{
    public class AppAcquisitionsRequestBuilder : RequestBuilder<AppAcquisitionsRequestBuilder, AppAcquisitionsRequest, AppAcquisitionsOrderBy>
    {
        public AppAcquisitionsRequestBuilder(string applicationId)
            : base(applicationId)
        {
        }
    }
}