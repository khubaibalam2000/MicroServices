namespace AdminEventBooking.Database.Entities
{
    public class Event
    {
        public int eventId { get; set; }
        public string eventName { get; set; } = string.Empty;
        public string eventDescription { get; set; } = string.Empty;
        public string venue { get; set; } = string.Empty;
        public string organizationName { get; set; } = string.Empty;
        public string? organzationDescription { get; set; } = string.Empty;
        public string? categoryName { get; set; } = string.Empty;
        public int? price { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public DateTime registrationEndTime { get; set; }

        //public int? ticketCategoryId { get; set; }
        //public TicketCategory? TicketCategory { get; set; }
        // [ForeignKey("ticketCategoryRefId")]


        //public int organizationId { get; set; }
        //public Organization? Organization { get; set; }
        // [ForeignKey("organizationRefId")]

       
    }
}
