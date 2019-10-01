namespace CliniSafePhoneApp.Portable.Models
{
    public interface IHandshakeHeader
    {
        string CPAVersion { get; set; }

        bool HasIssues { get; set; }

        bool MaintenanceMode { get; set; }

        bool CPAVersionExact { get; set; }

        bool CPANeedsUpdating { get; set; }

        int MessageCode { get; set; }

        string Message { get; set; }
    }
}
