using WebApp.Core.Interfaces;
using WebApp.Core.models;
using WebApp.Infrastructure.persistence;

namespace WebApp.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;


        public UnitOfWork(AppDbContext context,
            IGenericRepo<Location> locationRepo,
            IGenericRepo<Certificate> certificateRepo,
            IGenericRepo<CertificateTitle> certificateTitleRepo,
            IGenericRepo<CertificateType> certificateTypeRepo,
            IGenericRepo<InspectedItem> inspectedItemRepo,
            IGenericRepo<Job> jobRepo,
            IGenericRepo<ReferenceStandared> referenceRepo
           )
        {
            _context = context;
            CertificateRepo = certificateRepo;
            CertificateTitleRepo = certificateTitleRepo;
            CertificateTypeRepo = certificateTypeRepo;
            InspectedItemRepo = inspectedItemRepo;
            JobRepo = jobRepo;
            ReferenceRepo = referenceRepo;
            LocationRepo = locationRepo;

        }

        public IGenericRepo<Location> LocationRepo { get; private set; } = null!;
        public IGenericRepo<Certificate> CertificateRepo { get; private set; } = null!;
        public IGenericRepo<CertificateTitle> CertificateTitleRepo { get; private set; } = null!;
        public IGenericRepo<CertificateType> CertificateTypeRepo { get; private set; } = null!;
        public IGenericRepo<InspectedItem> InspectedItemRepo { get; private set; } = null!;
        public IGenericRepo<Job> JobRepo { get; private set; } = null!;
        public IGenericRepo<ReferenceStandared> ReferenceRepo { get; private set; } = null!;

        public void Dispose() => _context.Dispose();
        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

    }
}
