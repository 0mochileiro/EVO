namespace EVO.Repository.Models;

public partial class User
{
    public User()
    {
        Customer = new HashSet<Customer>();
        InvoiceServicesApprovedByUserNavigation = new HashSet<InvoiceServices>();
        InvoiceServicesCreatedByUserNavigation = new HashSet<InvoiceServices>();
        ServiceByInvoice = new HashSet<ServiceByInvoice>();
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int AccessLevelId { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public DateTime RegisterDate { get; set; }
    public DateTime LastUpdate { get; set; }
    public bool CompleteRegistration { get; set; }
    public bool Active { get; set; }

    public virtual UserAccessLevelDomain AccessLevel { get; set; }
    public virtual ICollection<Customer> Customer { get; set; }
    public virtual ICollection<InvoiceServices> InvoiceServicesApprovedByUserNavigation { get; set; }
    public virtual ICollection<InvoiceServices> InvoiceServicesCreatedByUserNavigation { get; set; }
    public virtual ICollection<ServiceByInvoice> ServiceByInvoice { get; set; }
}