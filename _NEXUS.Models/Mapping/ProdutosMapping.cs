using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace _NEXUS.Models.Mapping
{
    public class ProdutosMapping : IEntityTypeConfiguration<ProdutosModel>
    {
        public void Configure(EntityTypeBuilder<ProdutosModel> builder)
        {
            builder.ToTable("TB_NX_PRODUTOS"); 

            builder.HasKey(p => p.IdProduto);

            builder.Property(p => p.IdProduto)
                .HasColumnName("ID_PRODUTO")
                .IsRequired();

            builder.Property(p => p.NomeProduto)
                .HasColumnName("NM_PRODUTO")
                .HasMaxLength(100);

            builder.Property(p => p.TipoProduto)
                .HasColumnName("TP_PRODUTO")
                .HasMaxLength(50);

            builder.Property(p => p.Marca)
                .HasColumnName("NM_MARCA")
                .HasMaxLength(50);

            builder.Property(p => p.Modelo)
                .HasColumnName("NM_MODELO")
                .HasMaxLength(50);

            builder.Property(p => p.Quantidade)
                .HasColumnName("VL_QUANTIDADE");

            builder.Property(p => p.ValorProduto)
                .HasColumnName("VL_PRODUTO");

            builder.Property(p => p.DescricaoProduto)
                .HasColumnName("DS_PRODUTO")
                .HasMaxLength(255);
        }
    }
}
