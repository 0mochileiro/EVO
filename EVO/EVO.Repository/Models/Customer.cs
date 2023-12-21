namespace EVO.Repository.Models;

public partial class Customer
{
    public Customer()
    {
        InvoiceServices = new HashSet<InvoiceServices>();
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public Guid CreatedByUser { get; set; }
    public DateTime RegisterDate { get; set; }
    public DateTime LastUpdate { get; set; }
    public string Comments { get; set; }

    public virtual User CreatedByUserNavigation { get; set; }
    public virtual ICollection<InvoiceServices> InvoiceServices { get; set; }
}
