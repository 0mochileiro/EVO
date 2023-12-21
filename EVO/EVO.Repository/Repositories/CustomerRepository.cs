using EVO.Repository.Data;
using EVO.Repository.Models;
using EVO.Repository.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EVO.Repository.Repositories;

public class CustomerRepository : AbstractRepository<Customer>
{
    public CustomerRepository(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions)
    {
    }
}
