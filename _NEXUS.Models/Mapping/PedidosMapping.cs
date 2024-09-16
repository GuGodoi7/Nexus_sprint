using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using _NEXUS.Models;

public class PedidosMapping : IEntityTypeConfiguration<PedidosModel>
{
    public void Configure(EntityTypeBuilder<PedidosModel> builder)
    {
        builder.ToTable("TB_NX_PEDIDOS");

        builder.HasKey(p => p.IdPedido);

        builder.Property(p => p.IdPedido)
            .HasColumnName("ID_PEDIDO")
            .IsRequired();

        builder.Property(p => p.CodigoPedido)
            .HasColumnName("NR_PEDIDO")
            .IsRequired();

        builder.Property(p => p.Quantidade)
            .HasColumnName("VL_QUANTIDADE");

        builder.Property(p => p.ValorPedido)
            .HasColumnName("VL_PEDIDO");

    }
}
