using System.Xml.Serialization;

namespace CliniSafePhoneApp.Portable.Models
{
    [XmlRoot("CountriesForProjectForMonitorUser")]
    public interface ICountriesForProjectForMonitorUser
    {
        [XmlElement("ID")]
        int ID { get; set; }

        [XmlElement("TrialCode")]
        string TrialCode { get; set; }

        [XmlElement("DisplayTrialCode")]
        string DisplayTrialCode { get; set; }

        [XmlElement("TrialTitleShort")]
        string TrialTitleShort { get; set; }

        [XmlElement("TrialTitleFull")]
        string TrialTitleFull { get; set; }

        [XmlElement("TrialStatus_ID")]
        int TrialStatus_ID { get; set; }

        [XmlElement("EnglishCountryName")]
        string EnglishCountryName { get; set; }

        [XmlElement("EnglishLanguageName")]
        string EnglishLanguageName { get; set; }

        [XmlElement("Country_ID")]
        int Country_ID { get; set; }

        [XmlElement("Description")]
        string Description { get; set; }

        [XmlElement("TrialDetails")]
        string TrialDetails { get; set; }

    }
}
