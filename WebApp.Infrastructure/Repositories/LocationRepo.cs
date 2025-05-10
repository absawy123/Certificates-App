using WebApp.Core.Interfaces;
using WebApp.Core.models;
using WebApp.Infrastructure.persistence;

namespace WebApp.Infrastructure.Repositories
{
    public class LocationRepo :GenericRepo<Location> , ILocationRepo
    {
        private readonly AppDbContext _context;
        public LocationRepo(AppDbContext context):base(context) 
        {
            _context = context;
        }


    }
}
