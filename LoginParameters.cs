public class LoginParameters{
    public string Password { get; set; }
    public string Login { get; set; }
    
    public LoginParameters()
    {
        this.Password = string.Empty;
        this.Login = string.Empty;
    }

    public LoginParameters(string login, string password)
    {
        this.Login = login;
        this.Password  = password;
    }
}