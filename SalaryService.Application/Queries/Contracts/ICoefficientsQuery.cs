using Core;

namespace Application.Queries.Contracts;

public interface ICoefficientsQuery
{
    Task<CoefficientOptions> GetCoefficientsAsync();
}
