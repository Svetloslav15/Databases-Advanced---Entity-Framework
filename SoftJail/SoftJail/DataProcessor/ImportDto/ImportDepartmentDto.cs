using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportDepartmentDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        public List<ImportCellDto> Cells { get; set; }

        public ImportDepartmentDto()
        {
            this.Cells = new List<ImportCellDto>();
        }
    }
}
