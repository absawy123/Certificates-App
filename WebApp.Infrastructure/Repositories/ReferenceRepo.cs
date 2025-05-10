using WebApp.Core.Interfaces;
using WebApp.Core.models;
using WebApp.Infrastructure.persistence;

namespace WebApp.Infrastructure.Repositories
{
    internal class ReferenceRepo : GenericRepo<ReferenceStandared>, IReferenceRepo
    {
        private readonly AppDbContext _context;
        public ReferenceRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
