using Microsoft.EntityFrameworkCore;

namespace prova2{

    public class AppDbContext : DbContext{
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.UseSqlite("Data Source=pessoas.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Aluno>().ToTable("Alunos");
            modelBuilder.Entity<Disciplina>().ToTable("Professores");
        }
    }
}




namespace aula13_MTM
{
    public class AppDbContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; } = null!;
        public DbSet<Disciplina> Disciplinas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=relacionamento.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>()
                .HasMany(a => a.Disciplinas)
                .WithMany(d => d.Alunos)
                .UsingEntity(j => j.ToTable("AlunoDisciplina")); // Tabela de junção N:N
        }
    }
}
