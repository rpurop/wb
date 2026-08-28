namespace WBTask.Models;

public class UserRole
{
    public long Id {get; set;}
    public User user { get; set; }
    public string Role { get; set; }
    public string CountryCode { get; set; }
}