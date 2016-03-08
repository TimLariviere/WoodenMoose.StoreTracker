using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsStoreServices.V1.Common
{
    public class Request<TOrderByFields>
    {
        public string ApplicationId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Top { get; set; }
        public int? Skip { get; set; }
        public string Filter { get; set; }
        public AggregationLevels? AggregationLevel { get; set; }
        public List<Tuple<TOrderByFields, OrderByDirections>> OrderBy { get; set; }

        public virtual string GetUriParameters()
        {
            var sb = new StringBuilder();

            sb.Append($"applicationId={ApplicationId}");

            if (StartDate.HasValue)
                sb.Append($"&startDate={StartDate.Value.ToString("MM/dd/yyyy")}");

            if (EndDate.HasValue)
                sb.Append($"&endDate={EndDate.Value.ToString("MM/dd/yyyy")}");

            if (Top.HasValue)
                sb.Append($"&top={Top.Value}");

            if (Skip.HasValue)
                sb.Append($"&skip={Skip.Value}");

            if (!string.IsNullOrEmpty(Filter))
                sb.Append($"&filter={Filter}");

            if (AggregationLevel.HasValue)
                sb.Append($"&aggregationLevel={AggregationLevel.Value}");

            if (OrderBy != null && OrderBy.Any())
            {
                var value = string.Join(",", OrderBy.Select(o => $"{o.Item1} {o.Item2}"));
                sb.Append($"orderBy={value}");
            }

            return sb.ToString();
        }
    }
}
