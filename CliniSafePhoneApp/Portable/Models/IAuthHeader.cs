namespace CliniSafePhoneApp.Portable.Models
{
    public interface IAuthHeader
    {
        string Username { get; set; }

        string Password { get; set; }

        string CPAVersion { get; set; }

        bool HasIssues { get; set; }

        bool MaintenanceMode { get; set; }

        bool CPAVersionExact { get; set; }

        bool CPANeedsUpdating { get; set; }

        bool Authenticated { get; set; }

        bool UsernamePasswordValid { get; set; }

        bool UserTypeValid { get; set; }

        bool UserMobileTrained { get; set; }

        bool TrialActive { get; set; }

        int MessageCode { get; set; }

        string Message { get; set; }
    }
}
