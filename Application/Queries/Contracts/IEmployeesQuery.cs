using Core;
namespace Application.Queries.Contracts;

public interface IEmployeesQuery
{
    Task<IEnumerable<Employee>> GetEmployeesAsync(long tenantId);
}
