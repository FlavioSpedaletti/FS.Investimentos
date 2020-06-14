using Flunt.Notifications;
using Investimentos.Domain.Entities;
using Investimentos.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Investimentos.Infra.Data.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext(DbContextOptions<EFContext> options) : base(options)
        {
        }

        public DbSet<AtivoRendaVariavel> AtivosRendaVariavel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AtivoRendaVariavelMap());
            modelBuilder.Ignore<Notification>();

            //Seed(modelBuilder);
        }

        //private void Seed(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Cliente>().HasData(
        //        new Cliente
        //        {
        //            ClienteId = 1,
        //            Nome = "Flavio",
        //            Sobrenome = "Spedaletti",
        //            Email = "flavio@email.com",
        //            DataCadastro = DateTime.Now,
        //            Ativo = true
        //        });

        //    modelBuilder.Entity<Reclamacao>().HasData(
        //        new Reclamacao { ClienteId = 1, ReclamacaoId = 1, Descricao = "Internet lenta", Resolvida = false },
        //        new Reclamacao { ClienteId = 1, ReclamacaoId = 2, Descricao = "Sinal da TV caiu", Resolvida = true }
        //    );
        //}
    }
}
