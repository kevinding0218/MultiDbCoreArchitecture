using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entities.ArchitectMain;

namespace EFCore.ArchitectMain.Configurations
{
    internal class DrugPropertiesMappingConfig : IEntityTypeConfiguration<DrugProperties>
    {
        public void Configure(EntityTypeBuilder<DrugProperties> builder)
        {
            // Mapping for table
            builder.ToTable("DrugProperties");
            // builder.ToTable("DrugProperties", "DrugProperties");

            // Set key for entity
            builder.HasKey(dp => dp.NDC);

            // Set identity for entity (auto increment)
            builder.Property(dp => dp.NDCID).UseSqlServerIdentityColumn();

            // Set mapping for columns 

        }
    }
}
