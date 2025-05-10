using WebApp.Core.Interfaces;
using WebApp.Core.models;
using WebApp.Infrastructure.persistence;

namespace WebApp.Infrastructure.Repositories
{
    internal class JobRepo : GenericRepo<Job>, IJobRepo
    {
        private readonly AppDbContext _context;
        public JobRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
