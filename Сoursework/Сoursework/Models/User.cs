using System.Security.Policy;
using BCrypt.Net;

namespace Сoursework.Models;

public class User
{
    private String userName;
    private String passwordHash;
    private Role userRole;

    public User(String userName, String password, String userRole)
    {
        this.userName = userName;
        this.passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
        try
        {
            this.userRole = Enum.Parse<Role>(userRole);
        }
        catch (ArgumentException e)
        {
            this.userRole = Role.Guest;
        }
    }
}