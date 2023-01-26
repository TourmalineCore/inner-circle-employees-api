﻿using SalaryService.Domain;

namespace SalaryService.Application.Dtos
{
    public class GetPreviewParameters
    {
        public double RatePerHour { get; set; }

        public double Pay { get; set; }

        public double EmploymentType { get; set; }

        public double ParkingCostPerMonth { get; set; }
    }
}
