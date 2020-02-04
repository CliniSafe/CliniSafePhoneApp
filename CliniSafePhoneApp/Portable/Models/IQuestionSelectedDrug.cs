namespace CliniSafePhoneApp.Portable.Models
{
    public interface IQuestionSelectedDrug
    {
        int Question_ID { get; set; }
        string Question { get; set; }
        bool Answer { get; set; }
    }
}
