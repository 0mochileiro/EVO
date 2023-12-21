namespace EVO.Repository.Models;

public partial class UserAccessLevelDomain
{
    public UserAccessLevelDomain()
    {
        User = new HashSet<User>();
    }

    public int Id { get; set; }
    public string Function { get; set; }
    public string Department { get; set; }
    public string Description { get; set; }

    public virtual ICollection<User> User { get; set; }
}