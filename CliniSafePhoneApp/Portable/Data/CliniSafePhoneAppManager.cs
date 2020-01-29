using CliniSafePhoneApp.Portable.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CliniSafePhoneApp.Portable.Data
{
    public class CliniSafePhoneAppManager
    {
        ISoapService soapService;

        public CliniSafePhoneAppManager(ISoapService service)
        {
            soapService = service;
        }

        public Task<string> HelloWorldAsync()
        {
            return soapService.HelloWorldAsync();
        }

        public Task<string> HandShakeAysnc(HandshakeHeader handShakeHeader)
        {
            return soapService.HandShakeAsync(handShakeHeader);
        }

        public Task<string> AuthenticationAsync(AuthHeader authHeader)
        {
            return soapService.AuthenticateAsync(authHeader);
        }
        public Task<List<ProjectUser>> GetProjectsForUserAsync(AuthHeader authHeader)
        {
            return soapService.GetProjectsForUserListAysnc(authHeader);
        }

        public Task<List<CountriesForProjectForMonitorUser>> GetCountriesForProjectForMonitorUserListAsync(ProjectUser projectUser)
        {
            return soapService.GetCountriesForProjectForMonitorUserListAsync(projectUser);
        }

        public Task<List<ResearchSitesForProjectForInvestigatorUser>> FindGenericDrugNameAsync(ProjectUser projectUser)
        {
            return soapService.GetResearchSitesForProjectForInvestigtorUserListAsync(projectUser);
        }

        public Task<List<GenericDrugsFound>> FindGenericDrugNameListAsync(int trialID, string genericDrugNameToFind)
        {
            return soapService.FindGenericDrugNameListAsync(trialID, genericDrugNameToFind);
        }

        public Task<List<QuestionSelectedDrug>> GetQuestionSelectedDrugsListAsync(int trialID)
        {
            return soapService.GetQuestionSelectedDrugsListAsync(trialID);
        }
    }
}
