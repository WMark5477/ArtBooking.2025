namespace Xtech.Common.Pagination;

public static class PagedListExtensions
{
    /// <summary>
    /// Converts an IEnumerable to a paged list with optional pagination.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    /// <param name="query">The source collection to paginate.</param>
    /// <param name="pageNumber">The current page number (1-based). Defaults to 1 if not specified.</param>
    /// <param name="pageSize">The number of items per page. If null, all items will be returned without pagination.</param>
    /// <param name="totalCount">The optional pre-calculated total count. If null, count will be calculated from the query.</param>
    /// <returns>A PagedList containing the requested page of data along with pagination metadata.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the requested page number exceeds the available data range.</exception>
    public static PagedList<T> AsPagedList<T>(
        this IEnumerable<T> query,
        int? pageNumber = 1,
        int? pageSize = null,
        int? totalCount = null) where T : class
    {
        // Get the total count of items
        int _totalCount = totalCount ?? query.Count();
        int actualPageNumber = pageNumber ?? 1;

        // If pageSize is null, return all items (no pagination)
        if (pageSize == null)
        {
            // When no pagination is used, there's only one page
            if (actualPageNumber > 1 && _totalCount > 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageNumber),
                    "The requested page number exceeds the available data range. When pageSize is null, only page 1 is valid.");
            }

            List<T> allItems = query.ToList();
            return new PagedList<T>(allItems, _totalCount, actualPageNumber, _totalCount);
        }

        // Calculate total pages
        int totalPages = (_totalCount + pageSize.Value - 1) / pageSize.Value;

        // Check if page number is valid
        if (actualPageNumber > totalPages && _totalCount > 0)
        {
            throw new ArgumentOutOfRangeException(nameof(pageNumber),
                $"The requested page number {actualPageNumber} exceeds the available data range. Total pages: {totalPages}.");
        }

        // Calculate the skip amount
        int skip = (actualPageNumber - 1) * pageSize.Value;

        // Get the paged data
        List<T> items = query
            .Skip(skip)
            .Take(pageSize.Value)
            .ToList();

        // Return the paged result
        return new PagedList<T>(items, _totalCount, actualPageNumber, pageSize.Value);
    }


}