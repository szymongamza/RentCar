

namespace RentCar.Domain.Common.Query;
public class QueryResult<T>
{
    public List<T> Items { get; set; } = new List<T>();
    public int TotalItems { get; set; } = 0;
}
