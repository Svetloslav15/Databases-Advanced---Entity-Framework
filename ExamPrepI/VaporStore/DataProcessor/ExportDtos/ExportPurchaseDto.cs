namespace VaporStore.DataProcessor.ExportDtos
{
    using System;
    using System.Xml.Serialization;

    [XmlType("Purchase")]
    public class ExportPurchaseDto
    {
        [XmlElement("Card")]
        public string CardNumber { get; set; }

        [XmlElement("Cvc")]
        public string Cvc { get; set; }

        [XmlElement("Date")]
        public string Date { get; set; }

        [XmlElement("Game")]
        public ExportPurchaseGameDto Game { get; set; }
    }
}