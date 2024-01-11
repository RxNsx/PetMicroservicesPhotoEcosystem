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
        }

        public User(string login, string password, string email) : this(login, password)
        {
            this.Email = email;   
        }

        public void ChangeLogin(string oldLogin, string newLogin)
        {
            throw new NotImplementedException();
        }

        public void ChangePassword(string oldPassword, string passwordConfirm)
        {
            throw new NotImplementedException();
        }

        public void ChangeEmail(string oldEmail, string newEmail)
        {
            throw new NotImplementedException();
        }
    }
}
