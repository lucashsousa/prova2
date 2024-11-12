public class Aluno {
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Matricula { get; set; } = string.Empty;
    public int Idade { get; set; }

    public List <Disciplina> Disciplinas { get; set; } = new List<Disciplina>();
}