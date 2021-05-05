using BuscaImei.Entities;
using BuscaImei.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BuscaImei.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Dispositivo> Dispositivos { get; set; }
        public DbSet<DispositivoEncontrado> DispositivoEncontrados { get; set; }
        public DbSet<ApplicationUser> Usuarios { get; set; }
        public DbSet<DispositivoAuxViewModel> DispositivoAuxViewModels { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Estado>(p =>
            {
                p.ToTable("Estado");
                p.HasKey(p => p.IdEstado);
                p.Property(p => p.Nome).HasColumnName("esta_nome").HasColumnType("VARCHAR(25)");
                p.Property(p => p.Uf).HasColumnName("esta_uf").HasColumnType("CHAR(2)");

            });


            modelBuilder.Entity<Cidade>(p =>
            {
                p.ToTable("Cidade");
                p.HasKey(p => p.IdCidade);
                p.Property(p => p.Nome).HasColumnName("cida_nome").HasColumnType("VARCHAR(50)");

                p.HasOne(p => p.Estado)
                .WithMany()
                .HasForeignKey(p => p.EstadoFk).IsRequired();


            });

            modelBuilder.Entity<Dispositivo>(p =>
            {
                p.ToTable("Dispositivo");
                p.HasKey(p => p.IdDispositivo);
                p.Property(p => p.Imei).HasColumnName("dispo_imei").HasColumnType("VARCHAR(50)");
                p.Property(p => p.Modelo).HasColumnName("dispo_modelo").HasColumnType("VARCHAR(50)");
                p.Property(p => p.Marca).HasConversion<string>();
                p.Property(p => p.Status).HasConversion<string>();

                p.HasOne(P => P.Usuario)
                    .WithMany()
                    .HasForeignKey(p => p.UsuarioFk).IsRequired();

            });

            modelBuilder.Entity<DispositivoEncontrado>(p =>
            {
                p.ToTable("DispositivoEncontrado");
                p.HasKey(p => p.IdDispositivoEncontrado);
                p.Property(p => p.Imei).HasColumnName("denc_imei").HasColumnType("VARCHAR(50)");
                p.Property(p => p.Marca).HasConversion<string>();
                p.Property(p => p.Logradouro).HasColumnName("denc_logradouro").HasColumnType("VARCHAR(200)");
                p.Property(p => p.Bairro).HasColumnName("denc_bairro").HasColumnType("VARCHAR(200)");
                p.Property(p => p.Cep).HasColumnName("denc_cep").HasColumnType("VARCHAR(200)");
                p.Property(p => p.Numero).HasColumnName("denc_num").HasColumnType("int");
                p.Property(p => p.Telefone).HasColumnName("denc_telefone").HasColumnType("VARCHAR(200)");
                p.Property(p => p.Complemento).HasColumnName("denc_complemento").HasColumnType("VARCHAR(200)");

                p.HasOne(P => P.Usuario)
                    .WithMany()
                    .HasForeignKey(p => p.UsuarioFk).IsRequired();

                p.HasOne(P => P.Cidade)
                    .WithMany()
                    .HasForeignKey(p => p.CidadeFK).IsRequired();

            });
        }
    }

}
