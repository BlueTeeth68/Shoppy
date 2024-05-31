namespace Shoppy.Domain.Repositories.Base;

public class PagingResult<T>
{
    public int TotalPages { get; set; }

    public int TotalRecords { get; set; }

    public List<T> Results { get; set; } = new List<T>();
}