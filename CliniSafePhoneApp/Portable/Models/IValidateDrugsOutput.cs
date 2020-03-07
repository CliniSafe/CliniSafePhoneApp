namespace CliniSafePhoneApp.Portable.Models
{
    public interface IValidateDrugsOutput
    {
        string HTMLResult { get; set; }

        string XMLResult { get; set; }

        string XMLDrugRuleMessage { get; set; }
    }
}
