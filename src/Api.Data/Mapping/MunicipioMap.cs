using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class MunicipioMap : IEntityTypeConfiguration<MunicipioEntity>
    {
        public void Configure(EntityTypeBuilder<MunicipioEntity> builder)
        {
            builder.ToTable("Municipio");

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.CodIBGE);

            builder.HasOne(x => x.Uf)
                   .WithMany(m => m.ListMunicipios);
        }
    }
}
