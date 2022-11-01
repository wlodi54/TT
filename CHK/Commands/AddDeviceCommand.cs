using CHK.Common;

namespace CHK.Commands
{
    public class AddDeviceCommand : ICommand
    {
        public string Name { get; set; }
        public string? Model { get; set; }
        public string? PhotoLink { get; set; }

        internal static AddDeviceCommand CreateEmpty()
        {
            return new AddDeviceCommand()
            {
                Name = "Name1",
                Model = "Model1",
                PhotoLink = "#url",
            };
        }
    }
}
