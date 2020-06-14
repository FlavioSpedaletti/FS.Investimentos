using Investimentos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Investimentos.Infra.Data.Mappings
{
    public class AtivoRendaVariavelMap : MapBase<AtivoRendaVariavel>
    {
        public override void Configure(EntityTypeBuilder<AtivoRendaVariavel> builder)
        {
            base.Configure(builder);
            builder.ToTable("AtivosRendaVariavel");
            builder.Property(a => a.TipoRendaVariavel).IsRequired().HasColumnName("TipoRendaVariavel");
            builder.Property(a => a.NomePregao).IsRequired().HasColumnName("NomePregao").HasMaxLength(100);
            builder.Property(a => a.CodigoNegociacao).IsRequired().HasColumnName("CodigoNegociacao").HasMaxLength(100);
            builder.Property(a => a.CNPJ).IsRowVersion().HasMaxLength(14).HasColumnName("CNPJ");
            builder.Property(a => a.Site).IsRowVersion().HasMaxLength(50).HasColumnName("Site");
        }
    }
}
