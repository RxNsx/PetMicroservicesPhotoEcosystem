namespace PhotoEcosystem.UserService.Models
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Login { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }
        public Status Status { get; private set; }
        public DateTime LastTimeOnline { get; private set; }

        public User(string login, string password)
        {
            this.Login = login;
            this.Password = password;
            this.Status = Status.Active;
            this.LastTimeOnline = DateTime.UtcNow;
            this.Email = string.Empty;
        }

        public User(string login, string password, string email) : this(login, password)
        {
            this.Email = email;   
        }

        public void SetLogin(string login)
        {
            Login = login;
        }

        public void SetPassword(string password)
        {
            Password = password;
        }

        public void SetEmail(string email)
        {
            Email = email;
        }
    }
}
