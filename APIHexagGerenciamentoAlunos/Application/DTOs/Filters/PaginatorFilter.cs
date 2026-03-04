namespace APIHexagGerenciamentoAlunos.Application.DTOs.Filters
{
    public class PaginatorFilter
    {
        public int Page { get; set; }
        public int ItensPerPage { get; set; }

        public PaginatorFilter()
        {
            Page = 1;
            ItensPerPage = 10;
        }
    }
}
