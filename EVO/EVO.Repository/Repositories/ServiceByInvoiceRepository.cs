using EVO.Repository.Data;
using EVO.Repository.Models;
using EVO.Repository.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EVO.Repository.Repositories;

public class ServiceByInvoiceRepository : AbstractRepository<ServiceByInvoice>
{
    public ServiceByInvoiceRepository(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions)
    {
    }
}
