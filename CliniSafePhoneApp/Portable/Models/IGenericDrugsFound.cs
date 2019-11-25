using System.Xml.Serialization;

namespace CliniSafePhoneApp.Portable.Models
{
    [XmlRoot("GenericDrugsFound")]
    public interface IGenericDrugsFound
    {
        int Drug_ID { get; set; }

        string DrugName { get; set; }
    }
}
