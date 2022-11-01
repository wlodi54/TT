namespace CHK.Domain
{

    public class Info : BaseEntity
    {
        public DateTimeOffset OccurredDate { get; set; }
        public Status SecurityStatus { get; set; }
        public Guid DeviceId { get; set; }
        public Guid DataId { get; set; }
        public Device Device { get; set; }
        public InfoTemplate Data { get; set; }
    }
}
