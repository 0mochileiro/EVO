using EVO.Repository.Data;
using EVO.Repository.Models;
using EVO.Repository.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace EVO.Repository.Repositories;

public class ApplicationVersionRepository : AbstractRepository<ApplicationVersion>
{
    public ApplicationVersionRepository(DbContextOptions<Context> dbContextOptions) : base(dbContextOptions)
    {
    }

    public string GetVersion()
    {
        return context.ApplicationVersion?
            .First()?.Version;
    }

    public ApplicationVersion GetApplicationVersionWithComponent()
    {
        return context.ApplicationVersion?
            .Include(ap => ap.ApplicationVersionLabel)
                .Include(ap => ap.ApplicationVersionComponent)
                    .Include(ap => ap.ApplicationVersionScript)
            .First();
    }

}
