namespace AdminEventBooking.Database.Entities
{
    public class TicketCategory
    {
        public int ticketCategoryId { get; set; }
        public string categoryName { get; set; } = string.Empty;
        public int price { get; set; }

        public ICollection<Event>? Events { get; set; }
    }
}
