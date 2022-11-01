using CHK.Common;
using CHK.Domain;

namespace CHK.Commands
{
    public class AddInfoCommand : ICommand
    {
        public DateTimeOffset OccurredDate { get; set; }
        public Status SecurityStatus { get; set; }
        public Guid DeviceId { get; set; }
        public InfoTemplate Data { get; set; }
        public static AddInfoCommand CreateEmpty() => new AddInfoCommand
        {
            Data = new InfoTemplate
            {
                DumbBool = true,
                DumbDate = DateTimeOffset.Now.AddMinutes(-241),
                DumbText = "DumbText"
            },
            DeviceId = Guid.NewGuid(),
            OccurredDate = DateTime.Now,
            SecurityStatus = Status.Ok
        };
    }

}
