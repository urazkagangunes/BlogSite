using Core.Entities;

namespace BlogSite.Models.Entities;

public class User : Entity<long>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public List<Post> Posts { get; set; }
    public List<Comment> Comments { get; set; }
}
