using CHK.Common;

namespace CHK.Queries.Devices
{
    public class DevicesListQueryHandler : IQueryHandler<DevicesListQuery, List<DevicesListQueryResultDto>>
    {
        public Task<List<DevicesListQueryResultDto>> Get(DevicesListQuery data)
        {
            throw new NotImplementedException();
        }
    }
    public class DevicesListQuery : IQuery
    {


    }
    public class DevicesListQueryResultDto
    {

    }
}
