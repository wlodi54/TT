using CHK.Common;
using CHK.Infrastructure.Repositories;

namespace CHK.Commands
{
    public class AddDeviceCommandHandler : ICommandHandler<AddDeviceCommand>
    {
        private readonly DeviceRepository _deviceRepository;
        public AddDeviceCommandHandler(DeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public Task Handle(AddDeviceCommand command)
        {
            _deviceRepository.Add(new AddDeviceDto { Model = command.Model, Name = command.Name, PhotoLink = command.PhotoLink });
            return Task.CompletedTask;
        }
    }
}
