namespace APIHexagGerenciamentoAlunos.Domain.Entities
{
    public class Student : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        private string Password { get; set; }
        private string Cpf { get; set; }
        private string Rg { get; set; }
        public Guid? CourseId { get; set; }  // chave estrangeira
        public Course Course { get; set; }

        public string UpdatePassword(string newPassword) 
        {
            this.Password = newPassword;
            return this.Password;
        }
    }
}
