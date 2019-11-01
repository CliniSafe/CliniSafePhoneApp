namespace CliniSafePhoneApp.Portable.Models
{
    public interface IProjectUser
    {
        string ProjectCode { get; set; }

        string ProjectTitleShort { get; set; }

        string ProjectTitleShortPhoneDisplay { get; set; }

        string Sponsor { get; set; }

        string ContractResearchOrganisation { get; set; }

        string DropDownDesc { get; set; }

        string IRPUserDashboard { get; set; }

        string StudyDashboard { get; set; }

        string DrugRuleBuilderDashboard { get; set; }

        string ExploreDrugsDashboard { get; set; }

        string TeamDashboard { get; set; }

        string TranslationDashboard { get; set; }

        string ReportsDashboard { get; set; }

        string EndUserDashboard { get; set; }

        string WizardDashboard { get; set; }
        string InvestigatorDashboard { get; set; }
    }
}
