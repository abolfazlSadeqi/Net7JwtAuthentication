


using Microsoft.AspNetCore.Identity;

namespace Entities;

public class ApplicationRole : IdentityRole<long>
{
    public ApplicationRole() { }
    public ApplicationRole(string name) { Name = name; }
}
