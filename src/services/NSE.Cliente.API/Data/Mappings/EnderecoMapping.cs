using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NSE.Clientes.API.Models;

namespace NSE.Clientes.API.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Logradouro)
                .IsRequired()
                .HasColumnName("varchahr(200)");

            builder.Property(p => p.Numero)
                .IsRequired()
                .HasColumnName("varchahr(50)");

            builder.Property(p => p.Complemento)
              .IsRequired()
              .HasColumnName("varchahr(250)");
            
            builder.Property(p => p.Bairro)
             .IsRequired()
             .HasColumnName("varchahr(100)");

            builder.Property(p => p.Cep)
             .IsRequired()
             .HasColumnName("varchahr(20)");

            builder.Property(p => p.Cidade)
              .IsRequired()
              .HasColumnName("varchahr(100)");

            builder.Property(p => p.Estado)
              .IsRequired()
              .HasColumnName("varchahr(50)");

            builder.ToTable("Enderecos");
        }
    }
}
