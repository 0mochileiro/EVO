using EVO.Repository.Data;
using EVO.Repository.Models;
using EVO.Repository.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EVO.Repository.Repositories;

public class InvoiceServiceRepository : AbstractRepository<InvoiceServices>
{
    public InvoiceServiceRepository(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions)
    {
    }
}
