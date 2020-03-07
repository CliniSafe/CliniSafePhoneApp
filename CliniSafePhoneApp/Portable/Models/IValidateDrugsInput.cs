namespace CliniSafePhoneApp.Portable.Models
{
    public interface IValidateDrugsInput
    {
        int Project_ID { get; set; }

        int Trial_ID { get; set; }
        int ResearchSite_ID { get; set; }

        int Patient_ID { get; set; }

        string DrugName { get; set; }

        string QuestionsAndAnswers { get; set; }
    }
}
