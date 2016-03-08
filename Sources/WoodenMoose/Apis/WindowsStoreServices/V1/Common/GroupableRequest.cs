using System.Collections.Generic;

namespace WindowsStoreServices.V1.Common
{
    public class GroupableRequest<TOrderByFields, TGroupByFields> : Request<TOrderByFields>
    {
        public List<TGroupByFields> GroupBy { get; set; }
    }
}
