using Core;

namespace Api.Models;

public class EmployeesByIdsDto
{
    public List<EmployeeById> Employees { get; set; }
}

public class EmployeeById
{
    public long EmployeeId { get; }

    public string FullName { get; }

    public EmployeeById(Employee employee)
    {
        EmployeeId = employee.Id;
        FullName = employee.GetFullName();
    }
}