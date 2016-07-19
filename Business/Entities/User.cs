namespace Business.Entities
{
    public class User
    {
        public int ID { get; set; }
        
        //nvarchar(50)
        public string Username { get; set; }

        //nvarchar(50)
        public string Password { get; set; }

        //nvarchar(250)
        public string Email { get; set; }
    }
}
