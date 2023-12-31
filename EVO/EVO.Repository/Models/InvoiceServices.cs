﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace EVO.Repository.Models;

public partial class InvoiceServices
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }

    public Guid CreatedByUser { get; set; }

    public decimal? Montante { get; set; }

    public DateTime OpenDate { get; set; }

    public DateTime? CloseDate { get; set; }

    public bool Approved { get; set; }

    public DateTime? ApprovedDate { get; set; }

    public Guid? ApprovedByUser { get; set; }

    public virtual User ApprovedByUserNavigation { get; set; }

    public virtual User CreatedByUserNavigation { get; set; }

    public virtual Customer Customer { get; set; }

    public virtual ICollection<ServiceByInvoice> ServiceByInvoice { get; set; } = new List<ServiceByInvoice>();
}