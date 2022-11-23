﻿using SalaryService.Application.Dtos;
using SalaryService.DataAccess.Repositories;

namespace SalaryService.Application.Commands
{
    public partial class UpdateEmployeeCommand
    {
        
    }
    public class UpdateEmployeeCommandHandler
    {
        private readonly EmployeeRepository _employeeRepository;

        public UpdateEmployeeCommandHandler(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task Handle(EmployeeUpdatingParameters request)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.EmployeeId);

            employee.Update(request.Name, request.Surname, request.MiddleName, request.WorkEmail, request.PersonalEmail, request.Phone, request.GitHub, request.GitLab);

            await _employeeRepository.UpdateAsync(employee);
        }
    }
}