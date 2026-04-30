using PractiZing.Base.Common;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Model;
using PractiZing.Base.Model.Master;
using PractiZing.Base.Object.PatientService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Service.PatientService
{
    public interface IDataIntegrationService
    {
        Task<IEnumerable<IArPatient>> GetArPatientBillingData();
        Task<IEnumerable<IProviderEmrDTO>> GetEMRProviders();
        Task<IEnumerable<IFacilityEMRDto>> GetEMRFacilities();
        Task<bool> GetAllPolicies();
        Task<bool> SyncPoliciesFromEMR(int patientId, string emrToken = "");
        Task<bool> SyncPoliciesFromEMRBulk();
        Task<IEnumerable<IPractitionerModifiersDTO>> GetPractitionerModifierList();
        Task<bool> SyncEmrPatients();
    }
}
