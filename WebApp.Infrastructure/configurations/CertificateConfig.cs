using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Core.models;

namespace WebApp.Infrastructure.configurations
{
    public class CertificateConfig : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            builder.HasKey(c => c.Id);
           // builder.Property(c => c.NextExaminationDate).HasComputedColumnSql("DATEADD(YEAR, 1, ExaminationDate)",stored:true);  // Remove this 

            //builder.Property(c => c.Length).HasConversion<string>();
            //builder.Property(c => c.Load).HasConversion<string>();
            //builder.Property(c => c.Status).HasConversion<string>();


            builder.HasOne(c => c.CertificateTitle).WithMany(cTitle => cTitle.Certificates)
                    .HasForeignKey(c => c.CertificateTitleId);

            builder.HasOne(c => c.CertificateType).WithMany(cType => cType.Certificates)
                   .HasForeignKey(c => c.CertificateTypeId);

            builder.HasOne(c => c.InspectedItem).WithMany(i => i.Certificates)
                   .HasForeignKey(c => c.InspectedItemId);

            builder.HasOne(c => c.Job).WithMany(j => j.Certificates)
                   .HasForeignKey(c => c.JobId);

            builder.HasOne(c => c.ReferenceStandared).WithMany(r => r.Certificates)
                   .HasForeignKey(c => c.ReferenceId);






            builder.HasOne(c => c.Inspector).WithMany(a => a.Certificates)
                .HasForeignKey(c => c.CertificateIssuerId).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(c => c.Admin).WithMany()
                .HasForeignKey(c => c.CertificateAuthenticatorId).OnDelete(DeleteBehavior.NoAction);

        }

    }


}
