using CHK.Common;

namespace CHK.Queries.Infos
{
    public class InfoListResultDto
    {
        public string Date { get; set; }
        public string DeviceName { get; set; }
    }
    public class InfoListQuery : IQuery
    {
        public DateTimeOffset DateFrom { get; set; }
    }
}
