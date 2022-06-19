using GestaoMaquiesse.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoMaquiesse.Infra.Mapeamentos
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(x=>x.Id);

            builder.Property(x=>x.Id)
                    .HasColumnType("BIGINT")
                    .ValueGeneratedOnAdd();
            builder.Property(x=>x.Nome)
                    .IsRequired()
                    .HasMaxLength(80)
                    .HasColumnName("nome")
                    .HasColumnType("VARCHAR(80)");

            builder.Property(x=>x.Email)
                    .IsRequired()
                    .HasMaxLength(180)
                    .HasColumnName("email")
                    .HasColumnType("VARCHAR(180)");
            
            builder.Property(x=>x.PalavraPasse)
                    .IsRequired()
                    .HasMaxLength(180)
                    .HasColumnName("palavrapasse")
                    .HasColumnType("VARCHAR(180)");
        }
    }
}