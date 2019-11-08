namespace CliniSafePhoneApp.Portable.Models
{
    public interface ICountry
    {
        int ID { get; set; }
        string TrialCode { get; set; }
        string DisplayTrialCode { get; set; }
        string TrialTitleShort { get; set; }
        string TrialTitleFull { get; set; }
        int TrialStatus_ID { get; set; }
        string EnglishCountryName { get; set; }
        string EnglishLanguageName { get; set; }

        int Country_ID { get; set; }

        string Description { get; set; }
        string TrialDetails { get; set; }

    }
}
