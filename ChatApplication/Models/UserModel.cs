namespace ChatApplication.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        public UserModel()
        {
            Id = Guid.NewGuid().ToString();
            UserName = $"User {Guid.NewGuid().ToString()}";
        }
    }
}
