﻿using SalaryService.Application.Commands;
using SalaryService.Application.Dtos;
using SalaryService.Application.Queries.Contracts;
using SalaryService.Domain;

namespace SalaryService.Application.Services;

public class CompensationsService
{
    private readonly CompensationCreationCommand _compensationCreationCommand;

    private readonly ICompensationsQuery _compensationsQuery;

    public CompensationsService(CompensationCreationCommand createCompensationCommandHandler, ICompensationsQuery compensationsQuery)
    {
        _compensationCreationCommand = createCompensationCommandHandler;
        _compensationsQuery = compensationsQuery;
    }

    public async Task<List<CompensationType>> GetTypesAsync()
    {
        return CompensationTypes.GetTypeList();
    }

    public async Task<CompensationListDto> GetAllAsync()
    {
        var compensations = await _compensationsQuery.GetCompensationsAsync();

        var compensationList = compensations.Select(x => new CompensationItemDto()
        {
            Id = x.Id,
            Comment = x.Comment,
            Amount = x.Amount,
            IsPaid = x.IsPaid,
            DateCreateCompensation = x.DateCreateCompensation.ToString(),
            DateCompensation = x.DateCompensation.ToString()
        }).ToList();

        var totalUnpaidAmount = compensations.Sum(x => x.Amount);

        var compensationsResponseList = new CompensationListDto()
        {
            List = compensationList,
            TotalUnpaidAmount = totalUnpaidAmount
        };

        return compensationsResponseList;
    }

    public async Task CreateAsync(CompensationCreateDto dto, Employee employee)
    {
        await _compensationCreationCommand.ExecuteAsync(dto, employee);
    }
}