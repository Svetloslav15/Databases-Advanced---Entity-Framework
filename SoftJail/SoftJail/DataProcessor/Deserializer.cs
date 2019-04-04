namespace SoftJail.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using SoftJail.Data.Models;
    using System.Text;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            ImportDepartmentDto[] departmentDtos = JsonConvert.DeserializeObject<ImportDepartmentDto[]>(jsonString);
            StringBuilder sb = new StringBuilder();

            foreach (ImportDepartmentDto dto in departmentDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                bool isValidCells = true;
                foreach (ImportCellDto dtoCell in dto.Cells)
                {
                    if (!IsValid(dtoCell))
                    {
                        isValidCells = false;
                        break;
                    }
                }

                if (!isValidCells)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Department department = new Department()
                {
                    Name = dto.Name
                };

                context.Departments.Add(department);
                context.SaveChanges();

                List<Cell> cells = new List<Cell>();
                foreach (ImportCellDto dtoCell in dto.Cells)
                {
                    Cell cell = new Cell()
                    {
                        CellNumber = dtoCell.CellNumber,
                        HasWindow = dtoCell.HasWindow,
                        DepartmentId = department.Id
                    };

                    cells.Add(cell);
                }

                context.Cells.AddRange(cells);
                context.SaveChanges();

                sb.AppendLine($"Imported {dto.Name} with {dto.Cells.Count} cells");
            }

            return sb.ToString().Trim();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            ImportPrisonerDto[] prisonerDtos = JsonConvert.DeserializeObject<ImportPrisonerDto[]>(jsonString);
            StringBuilder sb = new StringBuilder();
            List<Prisoner> prisoners = new List<Prisoner>();

            foreach (ImportPrisonerDto prisonerDto in prisonerDtos)
            {
                if (!IsValid(prisonerDto))
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }
                DateTime releaseDate = DateTime.ParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime incarcerationDate = DateTime.ParseExact(prisonerDto.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                bool isValidMail = true;
                foreach (var mailDto in prisonerDto.Mails)
                {
                    if (!IsValid(mailDto))
                    {
                        isValidMail = false;
                        break;
                    }
                }

                if (!isValidMail)
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                Prisoner prisoner = new Prisoner()
                {
                    FullName = prisonerDto.FullName,
                    Nickname = prisonerDto.Nickname,
                    Age = prisonerDto.Age,
                    IncarcerationDate = incarcerationDate,
                    ReleaseDate = prisonerDto.ReleaseDate == null ? (DateTime?)null : DateTime.ParseExact(prisonerDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None),
                    Bail = prisonerDto.Bail,
                    CellId = prisonerDto.CellId
                };

                context.Prisoners.Add(prisoner);
                context.SaveChanges();
                List<Mail> mails = new List<Mail>();
                foreach (var dtoMail in prisonerDto.Mails)
                {
                    Mail mail = new Mail()
                    {
                        Description = dtoMail.Description,
                        Sender = dtoMail.Sender,
                        Address = dtoMail.Address,
                        PrisonerId = prisoner.Id
                    };

                    mails.Add(mail);
                }
                context.Mails.AddRange(mails);
                context.SaveChanges();

                sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
            }
            return sb.ToString().Trim();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResults = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(entity, validationContext, validationResults, true);

            return isValid;
        }

    }
}