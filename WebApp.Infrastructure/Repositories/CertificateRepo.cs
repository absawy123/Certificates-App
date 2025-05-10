using WebApp.Core.Interfaces;
using WebApp.Core.models;
using WebApp.Infrastructure.persistence;

namespace WebApp.Infrastructure.Repositories
{
    public class CertificateRepo : GenericRepo<Certificate>, ICertificateRepo
    {
        private readonly AppDbContext _context;
        public CertificateRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
