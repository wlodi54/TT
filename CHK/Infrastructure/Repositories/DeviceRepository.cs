using CHK.Domain;

namespace CHK.Infrastructure.Repositories
{
    public class DeviceRepository : IDeviceRepostory
    {
        private readonly WriteContext _writeContext;
        public DeviceRepository(WriteContext writeContext)
        {
            _writeContext = writeContext;
        }

        public void Add(AddDeviceDto addDevice)
        {
            _writeContext.Device.Add(new Device { Model = addDevice.Model, Name = addDevice.Name, PhotoLink = addDevice.PhotoLink });
        }
    }

    public class AddDeviceDto
    {
        public string Name { get; set; }
        public string? Model { get; set; }
        public string? PhotoLink { get; set; }
    }
}
