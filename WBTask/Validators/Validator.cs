using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using WBTask.Models;

namespace WBTask.Validator;

public class Validator
{
    public Validator(WBTaskContext _context)
    {
        this.context = _context;
    }
    public WBTaskContext context;
    public bool isValidUser(string userId, string roleName, string CountryCode)
    {
        if (userId!=null) {

            User? u = context.Users.Find(Int64.Parse(userId));
            if (u!=null)
            {
                foreach(UserRole ur in context.UserRoles)
                {
                    if (ur.user == u && ur.Role == roleName && ur.CountryCode==CountryCode)
                    {
                        return true;
                    }
                }
            }
        }
        return false;

    }
}