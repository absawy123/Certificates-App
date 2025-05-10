using WebApp.Core.Interfaces;
using WebApp.Core.models;
using WebApp.Infrastructure.persistence;

namespace WebApp.Infrastructure.Repositories
{
    public class CertificateTypeRepo : GenericRepo<CertificateType>, ICertificateTypeRepo
    {
        private readonly AppDbContext _context;
        public CertificateTypeRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }


    }


}
