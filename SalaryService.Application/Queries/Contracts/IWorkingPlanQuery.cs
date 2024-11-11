using Core;

namespace Application.Queries.Contracts;

public interface IWorkingPlanQuery
{
    Task<WorkingPlan> GetWorkingPlanAsync();
}
