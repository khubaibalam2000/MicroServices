namespace AuthService.Database.Entities
{
    public class User
    {
        public int userId { get; set; }
        public string userName { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }
}
