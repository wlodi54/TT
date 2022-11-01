using CHK.Domain;

namespace CHK.Infrastructure.Repositories
{
    public class InfoRepository
    {
        private readonly WriteContext _writeContext;
        public InfoRepository(WriteContext writeContext)
        {
            _writeContext = writeContext;
        }

        public void Add(AddInfoDto addDevice)
        {
            _writeContext.Info.Add(new Info
            {
                Data = addDevice.Data,
                SecurityStatus = addDevice.SecurityStatus,
                DeviceId = addDevice.DeviceId,
                OccurredDate = addDevice.OccurredDate
            });
        }
    }

    public class AddInfoDto
    {
        public DateTimeOffset OccurredDate { get; set; }
        public Status SecurityStatus { get; set; }
        public Guid DeviceId { get; set; }
        public InfoTemplate Data { get; set; }
    }
}
