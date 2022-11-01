namespace CHK.Domain
{
    public class Device : BaseEntity
    {
        public string Name { get; set; }
        public string? Model { get; set; }
        public string? PhotoLink { get; set; }
    }
}
