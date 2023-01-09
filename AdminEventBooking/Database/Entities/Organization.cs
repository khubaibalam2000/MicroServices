namespace AdminEventBooking.Database.Entities
{
    public class Organization
    {
        public int organizationId { get; set; }
        public string organizationName { get; set; } = string.Empty;
        public string organzationDescription { get; set; } = string.Empty;

        public ICollection<Event>? Events { get; set; }

    }
}
