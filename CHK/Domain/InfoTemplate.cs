namespace CHK.Domain
{
    public class InfoTemplate : BaseEntity
    {
        public string DumbText { get; set; }
        public bool DumbBool { get; set; }
        public DateTimeOffset DumbDate { get; set; }
    }
}
