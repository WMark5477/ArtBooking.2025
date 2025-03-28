using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Xtech.Common.Pagination;

/// <summary>
/// Defines list parameters in terms of list paging and filtering.
/// </summary>
/// <typeparam name="F"></typeparam>
public class PagedListParams<F> where F : class, new()
{
    /// <summary>
    /// Gets or sets expected page list number
    /// </summary>
    [Required]
    public int PageNumber { get; set; } = 0;

    /// <summary>
    /// Gets or sets expected page size (number of items that list contains).
    /// </summary>
    [Required]
    public int PageSize { get; set; } = 20;

    /// <summary>
    /// Contains list specific filters
    /// </summary>
    public F? Filters { get; set; } = new F();

    /// <summary>
    /// Gets or sets sort by property name. Use simple name like "SomeProperty" for ascending order or "-SomeProperty" for descending order.
    /// </summary>
    public string? SortBy { get; set; } = null;

    /// <summary>
    /// Gets lowercase name of sort by field.
    /// </summary>
    public string? SortByField()
    {
        if (string.IsNullOrEmpty(this.SortBy))
            return null;

        return this.IsSortByAsc()
            ? this.SortBy.ToLower()
            : this.SortBy.Substring(1).ToLower();
    }

    /// <summary>
    /// Gets sort direction. True for ASC, false for DESC
    /// </summary>
    public bool IsSortByAsc()
    {
        return !this.SortBy?.StartsWith("-") ?? true;
    }

    /// <summary>
    /// Determines whether sortBy has been defined.
    /// </summary>
    public bool HasSort() => !string.IsNullOrEmpty(SortBy);

    /// <summary>
    /// Checks whether specied sort field name equals specified value (CASE INSENSITIVE: lower case values are compared)
    /// </summary>
    /// <param name="fieldName"></param>
    /// <returns></returns>
    public bool SortByFieldIs(string fieldName)
    {
        return this.SortByField() == fieldName.ToLowerInvariant();
    }
}

public class NoFilters
{

}