namespace UserEventBooking.Database.Entities
{
    public class Review
    {
        public int reviewId { get; set; }
        public string review { get; set; } = string.Empty;
        public DateTime createdTime { get; set; }
        public string personName { get; set; } = string.Empty;
        public string eventName { get; set; } = string.Empty;
    }
}
