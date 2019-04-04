using System;
using System.Collections.Generic;
using System.Text;
using VaporStore.Data.Models;

namespace VaporStore.DataProcessor.ImportDtos
{
    public class ImportCardDto
    {
        public string Number { get; set; }

        public string CVC { get; set; }

        public CardType Type { get; set; }
    }
}
