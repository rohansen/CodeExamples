using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SecureService.Clients.WebMVCClientWithCookie.Models.Authorization
{
/// <summary>
/// This is the datastructure that is used to serialize and deserialize the data contained in the authorization cookie
/// </summary>
public class CustomPrincipalSerializeModel
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
}