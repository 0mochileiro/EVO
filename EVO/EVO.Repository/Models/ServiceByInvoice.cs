namespace EVO.Repository.Models;

public partial class ServiceByInvoice
{
    public Guid Id { get; set; }
    public Guid InvoiceServicesId { get; set; }
    public Guid CreatedByUser { get; set; }
    public decimal Amount { get; set; }
    public string Details { get; set; }
    public DateTime RegisterDate { get; set; }

    public virtual User CreatedByUserNavigation { get; set; }
    public virtual InvoiceServices InvoiceServices { get; set; }
}