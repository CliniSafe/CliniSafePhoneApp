using CliniSafePhoneApp.Portable.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CliniSafePhoneApp.Portable.Data
{
    public interface ISoapService
    {
        Task<string> HelloWorldAsync();

        Task<string> HandShakeAsync(HandshakeHeader handShakeHeader);

        Task<string> AuthenticateAsync(AuthHeader authHeader);


        Task HelloErrorAsync();

        Task<string> EchoAsync(string inputValue);

        Models.AuthHeader GetAuthHeader();

        Models.HandshakeHeader GetHandshakeHeader();

        Task<List<ProjectUser>> GetProjectsForUserListAysnc(AuthHeader authHeader);

        Task<List<CountriesForProjectForMonitorUser>> GetCountriesForProjectForMonitorUserListAsync(ProjectUser projectUser);

        Task<List<ResearchSitesForProjectForInvestigatorUser>> GetResearchSitesForProjectForInvestigtorUserListAsync(ProjectUser projectUser);

        Task<List<GenericDrugsFound>> FindGenericDrugNameListAsync(int trialID, string genericDrugNameToFind);

        Task<List<QuestionSelectedDrug>> GetQuestionSelectedDrugsListAsync(int trialID);

        Task<ValidateDrugsOutput> ValidateDrugsListAsync(ValidateDrugsInput validateDrugsInput);

    }
}
