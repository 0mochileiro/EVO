using EVO.Repository.Data;
using EVO.Repository.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EVO.Repository;

public class Entities : IDisposable
{
    public Entities(DbContextOptions<Context> dbContextOptions)
    {
        _CustomerRepository = new Lazy<CustomerRepository>(() => new CustomerRepository(dbContextOptions));

        _InvoiceServiceRepository = new Lazy<InvoiceServiceRepository>(() => new InvoiceServiceRepository(dbContextOptions));

        _ServiceByInvoiceRepository = new Lazy<ServiceByInvoiceRepository>(() => new ServiceByInvoiceRepository(dbContextOptions));

        _UserAccessLevelDomainRepository = new Lazy<UserAccessLevelDomainRepository>(() => new UserAccessLevelDomainRepository(dbContextOptions));

        _UserRepository = new Lazy<UserRepository>(() => new UserRepository(dbContextOptions));
    }

    private Lazy<CustomerRepository> _CustomerRepository { get; set; }
    public CustomerRepository CustomerRepository => _CustomerRepository.Value;

    private Lazy<InvoiceServiceRepository> _InvoiceServiceRepository { get; set; }
    public InvoiceServiceRepository InvoiceServiceRepository => _InvoiceServiceRepository.Value;

    private Lazy<ServiceByInvoiceRepository> _ServiceByInvoiceRepository { get; set; }
    public ServiceByInvoiceRepository ServiceByInvoiceRepository => _ServiceByInvoiceRepository.Value;

    private Lazy<UserAccessLevelDomainRepository> _UserAccessLevelDomainRepository { get; set; }
    public UserAccessLevelDomainRepository UserAccessLevelDomain => _UserAccessLevelDomainRepository.Value;

    private Lazy<UserRepository> _UserRepository { get; set; }
    public UserRepository User => _UserRepository.Value;

    public void Dispose()
    {
        if (_CustomerRepository.IsValueCreated)
            _UserRepository.Value.Dispose();

        if (_InvoiceServiceRepository.IsValueCreated)
            _InvoiceServiceRepository.Value.Dispose();

        if (_ServiceByInvoiceRepository.IsValueCreated)
            _ServiceByInvoiceRepository.Value.Dispose();

        if (_UserAccessLevelDomainRepository.IsValueCreated)
            _UserAccessLevelDomainRepository.Value.Dispose();

        if (_UserRepository.IsValueCreated)
            _UserRepository.Value.Dispose();
    }
}
