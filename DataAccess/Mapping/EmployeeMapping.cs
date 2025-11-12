using Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Mapping;

public class EmployeeMapping : IEntityTypeConfiguration<Employee>
{
  public void Configure(EntityTypeBuilder<Employee> builder)
  {
    var ceoHiringAtUtc = DateTime.SpecifyKind(new DateTime(2020, 01, 01, 0, 0, 0), DateTimeKind.Utc);

    builder.Property(x => x.CorporateEmail).IsRequired();
    builder.Property(x => x.FirstName).IsRequired();
    builder.Property(x => x.LastName).IsRequired();

    builder.Property(x => x.MiddleName).IsRequired(false);
    builder.Property(x => x.PersonalEmail).IsRequired(false);
    builder.Property(x => x.Phone).IsRequired(false);
    builder.Property(x => x.GitHub).IsRequired(false);
    builder.Property(x => x.GitLab).IsRequired(false);

    builder.Property(x => x.IsBlankEmployee).IsRequired().HasDefaultValue(true);
    builder.Property(x => x.IsCurrentEmployee).IsRequired().HasDefaultValue(false);

    builder.HasIndex(x => x.CorporateEmail).IsUnique();

    builder.HasData(
      new
      {
        Id = 1L,
        FirstName = "Ceo",
        LastName = "Ceo",
        MiddleName = "Ceo",
        CorporateEmail = "ceo@tourmalinecore.com",
        PersonalEmail = "ceo@gmail.com",
        Phone = "88006663636",
        GitHub = "@ceo.github",
        GitLab = "@ceo.gitlab",
        IsBlankEmployee = true,
        IsCurrentEmployee = true,
        IsSpecial = false,
        TenantId = 1L
      },
      new
      {
        Id = 2L,
        FirstName = "Admin",
        LastName = "Admin",
        MiddleName = "Admin",
        CorporateEmail = "inner-circle-admin@tourmalinecore.com",
        PersonalEmail = "inner-circle-admin@gmail.com",
        IsBlankEmployee = true,
        IsCurrentEmployee = true,
        IsSpecial = true,
        TenantId = 1L
      },
      new
      {
        Id = 3L,
        FirstName = "Trial",
        LastName = "Trial",
        MiddleName = "Trial",
        CorporateEmail = "trial@tourmalinecore.com",
        PersonalEmail = "trial@gmail.com",
        IsBlankEmployee = true,
        IsCurrentEmployee = true,
        IsSpecial = false,
        TenantId = 1L
      }
    );
  }
}
