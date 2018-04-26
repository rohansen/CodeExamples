using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace SecureService.Clients.WebMVCClientWithCookie.Models.Authorization
{
public class CustomPrincipal : IPrincipal
{
    public IIdentity Identity { get; private set; }
    public bool IsInRole(string role) { return Role.Contains(role); }

    public CustomPrincipal(string email)
    {
        this.Identity = new GenericIdentity(email);
    }

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string[] Role { get; set; }
}
}