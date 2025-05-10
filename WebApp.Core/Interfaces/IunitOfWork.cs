using WebApp.Core.models;

namespace WebApp.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenericRepo<Location> LocationRepo { get; }
        public IGenericRepo<Certificate> CertificateRepo { get; }
        public IGenericRepo<InspectedItem> InspectedItemRepo { get; }
        public IGenericRepo<CertificateTitle> CertificateTitleRepo { get; }
        public IGenericRepo<CertificateType> CertificateTypeRepo { get; }
        public IGenericRepo<Job> JobRepo { get; }
        public IGenericRepo<ReferenceStandared> ReferenceRepo { get; }
     
        Task<int> SaveChangesAsync();


    }
}
