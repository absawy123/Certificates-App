using WebApp.Core.Interfaces;
using WebApp.Core.models;
using WebApp.Infrastructure.persistence;

namespace WebApp.Infrastructure.Repositories
{
    internal class InspectedItemRepo : GenericRepo<InspectedItem>, IInspectedItemRepo
    {
        private readonly AppDbContext _context;
        public InspectedItemRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
