using System.ComponentModel.DataAnnotations;
using System.Collections.Specialized;

namespace Xtech.Common.Pagination;

public class PagedList<T>
{
    [Required]
    public List<T> Items { get; set; } = [];
    [Required]
    public int TotalCount { get; set; } = 0;
    [Required]
    public int PageNumber { get; set; } = 1;
    [Required]
    public int PageSize { get; set; } = 25;
    [Required]
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

    public PagedList(List<T> items, int totalCount, int pageNumber, int pageSize)
    {
        Items = items ?? new List<T>();
        TotalCount = totalCount;
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}