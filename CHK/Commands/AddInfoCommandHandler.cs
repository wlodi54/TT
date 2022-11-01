using CHK.Common;
using CHK.Infrastructure.Repositories;

namespace CHK.Commands
{
    public class AddInfoCommandHandler : ICommandHandler<AddInfoCommand>
    {
        private readonly InfoRepository infoRepository;
        public AddInfoCommandHandler(InfoRepository infoRepository)
        {
            this.infoRepository = infoRepository;
        }
        public Task Handle(AddInfoCommand command)
        {
            infoRepository.Add(new AddInfoDto
            {
                Data = command.Data,
                DeviceId = command.DeviceId,
                OccurredDate = command.OccurredDate,
                SecurityStatus = command.SecurityStatus
            });
            return Task.CompletedTask;
        }

    }
}
