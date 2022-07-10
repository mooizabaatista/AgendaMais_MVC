using AgendaMais.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgendaMais.Infra.EntitiesConfiguration
{
    public class ProfissionalConfiguration : IEntityTypeConfiguration<Profissional>
    {
        public void Configure(EntityTypeBuilder<Profissional> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired();

            builder.HasMany(x => x.Consultas).WithOne(x => x.Profissional).HasForeignKey(x => x.ProfissionalId);
        }
    }
}
