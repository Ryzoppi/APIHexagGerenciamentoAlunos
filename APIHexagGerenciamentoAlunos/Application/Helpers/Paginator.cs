namespace APIHexagGerenciamentoAlunos.Application.Helpers
{
    public class Paginator<TEntity>
    {
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public List<TEntity> Data { get; set; }
        public int PageCount { get; set; }

        public Paginator(int totalPages, int totalItems, List<TEntity> data, int pageCount)
        {
            TotalPages = totalPages;
            TotalItems = totalItems;
            Data = data;
            PageCount = pageCount;
        }
    }
}
