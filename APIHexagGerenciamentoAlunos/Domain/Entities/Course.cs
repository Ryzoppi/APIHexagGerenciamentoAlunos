using APIHexagGerenciamentoAlunos.Domain.Entities;

public class Course : EntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }

    public List<Student> Students { get; set; } = new List<Student>();
}
