
public class User 
{
    public string Name;
    public string Email;
    public string Password;
    public int Record;

    public User(string name, string email, string password, int record)
    {
        this.Name = name;
        this.Email = email;
        this.Password = password;
        this.Record = record;
    }
}
