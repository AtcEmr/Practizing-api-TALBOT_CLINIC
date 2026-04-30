using PractiZing.Base.Common;
using PractiZing.Base.Entities.PatientService;
using PractiZing.Base.Model;
using PractiZing.Base.Model.Master;
using PractiZing.Base.Model.PatientService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Object.PatientService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PractiZing.Base.Repositories.PatientService
{
    public interface IPatientRepository
    {
        Task<IPatient> Get(Guid UId);
        Task<IPaginationQuery<IPatient>> GetAll(SearchQuery<IBaseSearchModel> entity, string searchKey, string sortOrder);
        Task<IPatient> GetByPatientUId(Guid patientUId);
        Task<IEnumerable<IPatient>> GetAll(string patientName);
        Task<IEnumerable<IPatientChargeDTO>> GetAllPatient(string patientName);
        Task<IStatementDTO> GetStatement(int patientId);
        Task<IEnumerable<IPatient>> GetByIds(IEnumerable<int> ids);
        Task<IEnumerable<IPatientStatementRDLCDTO>> Get();
        //Task<IEnumerable<IPatient>> GetAll(IPatientFilter entity);
        Task<IEnumerable<int>> GetByUId(string uid);
        Task<IPatient> GetByUId(Guid uniqueId);
        Task<IPatient> GetById(int patientId);
        Task<IPatient> AddNew(IPatient entity);
        Task<int> UpdateEntity(IPatient entity);
        Task<IEnumerable<IPatient>> GetByUId(IEnumerable<Guid> patientUId);
        Task<int> Delete(int id);
        Task<IPatient> UpdatePatientFromInsurance(IPatient entity);
        Task<int> Delete(Guid uid);
        Task ThrowError(IPatient patientData);
        Task ValidatePatientAddress(string patientStreet, string patientState, string patientCity, string patientZip);
        Task<IPatientDTO> GetPatientInformation(Guid patientUId, int policyId);
        Task<IEnumerable<IArPatient>> GetArPatientBillingData();
        //Task<bool> SendAcknowledgementToEMR(int billingId, int chargeId, string errorMessage);
        Task<bool> SendAcknowledgementToEMR(int billingId, int chargeId, string errorMessage);
        Task<IEnumerable<IProviderEmrDTO>> GetEMRProviders();
        Task<IEnumerable<IFacilityEMRDto>> GetEMRFacilities();
        Task<bool> SendClaimSentAcknowledgementToEMR(List<IEMRChargeStatus> lst);
        Task<IPatient> Get(int patientId);
        Task<IPatient> GetForDynmo(int patientId, string dob);
        Task<IPatient> GetForDynmoWithEmrPatientId(string patientId, string dob);
        Task<IPatient> PatientByBillingId(string billingId);
        Task<IPatient> GetByCaseId(int patientCaseId);
        Task<IPatient> CheckPatientExist(string billingId);
        Task<object> ImortPatientPoliciesFromEMR();
        Task<object> SyncPoliciesFromEMR(string patientId, string emrToken = "");
        Task<IPatient> PatientByPatientIdWithCaseUid(int patientId);
        Task<object> EMRPolicySyncService(string emrtoken);
        Task<bool> EMRUpdatePolicySync(string emrToken);
        Task<string> GetEMRToken();
        Task<dynamic> RefreshPatientChargesReport_WareHouse(Guid UId);
        Task<bool> EMRUpdatePolicyWithIdsSync(string emrToken, List<int> insuranceIds);
        Task<IEnumerable<IPractitionerModifiersDTO>> GetPractitionerModifierList();
        Task<bool> SendRolledUpChargesToEMR(List<IRolledUpEncounterDTO> lst);
        Task<IEnumerable<ISyncPatientDetailDTO>> GetPatientsForSync();
        Task<IPatient> UpdatePatientByEmrSync(IPatient entity);
        Task<bool> SendPatientSyncAckToEMR(IEnumerable<int> patientIds);
        Task<bool> SendEncounterImportAcknowledgementToEMR(List<IEMRChargeStatus> lst);
    }
}
