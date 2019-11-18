using System.Xml.Serialization;

namespace CliniSafePhoneApp.Portable.Models
{
    [XmlRoot("ResearchSitesForProjectForInvestigatorUser")]
    public interface IResearchSitesForProjectForInvestigatorUser
    {
        int ID { get; set; }

        int Trial_ID { get; set; }

        string SiteCode { get; set; }

        string SiteTitle { get; set; }

        string Address1 { get; set; }

        int ResearchSiteStatus_ID { get; set; }

        string EnglishCountryName { get; set; }

        int Country_ID { get; set; }

        string LocalCountryName { get; set; }

        string SiteStatus { get; set; }
    }
}
