﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

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