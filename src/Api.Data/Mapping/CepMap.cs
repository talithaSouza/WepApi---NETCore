using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class CepMap : IEntityTypeConfiguration<CEPEntity>
    {
        public void Configure(EntityTypeBuilder<CEPEntity> builder)
        {
            builder.ToTable("Cep");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Cep);

            builder.HasOne(c => c.Municipio)
                   .WithMany(m => m.ListCeps);
        }
    }
}
