using EVO.Repository;
using EVO.Repository.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EVO.ApiService.Controllers.Abstractions
{
    public abstract class AbstractController : Controller
    {
        protected readonly Entities _Entities;

        public AbstractController(DbContextOptions<Context> dbContextOptions)
        {
            _Entities = new Entities(dbContextOptions);
        }
    }
}
