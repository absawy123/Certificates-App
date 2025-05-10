using WebApp.Core.Interfaces;
using WebApp.Core.models;
using WebApp.Infrastructure.persistence;

namespace WebApp.Infrastructure.Repositories
{
    internal class CertificateTitleRepo : GenericRepo<Certificate>, ICertificateTitleRepo
    {
        private readonly AppDbContext _context;
        public CertificateTitleRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }

}
