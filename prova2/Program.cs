using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace aula13_MTM
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                // Adicionando Pessoas e Habilidades (Relacionamento N:N)
                var aluno1 = new Aluno { Nome = "Lucas" };
                var aluno2 = new Aluno { Nome = "Victor" };

                var disciplina1 = new Disciplina { NomeDisciplina = "Programação" };
                var disciplina2 = new Disciplina { NomeDisciplina = "Design" };

                aluno1.Disciplinas.Add(disciplina1);
                aluno1.Disciplinas.Add(disciplina2);

                aluno2.Disciplinas.Add(disciplina1);

                context.Alunos.AddRange(aluno1, aluno2);

                context.Disciplinas.AddRange(disciplina1, disciplina2);
               
                context.SaveChanges();

                var pessoas = context.Alunos.Include(p => p.Disciplinas).ToList();
                foreach (var pessoa in pessoas)
                {
                    Console.WriteLine($"Pessoa: {pessoa.Nome}");
                    foreach (var habilidade in pessoa.Disciplinas)
                    {
                        Console.WriteLine($"Habilidade: {habilidade.NomeDisciplina}");
                    }
                }
            }
        }
    }
}
