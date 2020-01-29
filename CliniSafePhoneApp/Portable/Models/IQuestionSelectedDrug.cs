namespace CliniSafePhoneApp.Portable.Models
{
    public interface IQuestionSelectedDrug
    {
        int Question_ID { get; set; }
        string Question { get; set; }
        bool Yes { get; set; }
        bool No { get; set; }
    }
}
