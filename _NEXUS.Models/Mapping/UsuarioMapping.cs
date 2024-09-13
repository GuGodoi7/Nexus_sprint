using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace _NEXUS.Models.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.ToTable("TB_NX_USUARIOS"); 

            builder.HasKey(u => u.IdUsuario);

            builder.Property(u => u.IdUsuario)
                .HasColumnName("ID_USUARIO")
                .IsRequired();

            builder.Property(u => u.NomeUsuario)
                .HasColumnName("NM_USUARIO")
                .HasMaxLength(100);

            builder.Property(u => u.CPF)
                .HasColumnName("NR_CPF");

            builder.Property(u => u.email)
                .HasColumnName("DS_EMAIL")
                .HasMaxLength(100);

            builder.Property(u => u.telefone)
                .HasColumnName("NR_TELEFONE");
        }
    }
}

