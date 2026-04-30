using PractiZing.Base.Object.MasterServcie;
using PractiZing.Base.Object.ReportService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.Base.Repositories.SecurityService;
using PractiZing.DataAccess.MasterServcie.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Services
{
    public interface IReportParameterService
    {
        Task<IReportParameterDTO> ConvertGUIDToId(IReportParameterDTO reportParameterDTO);
        Task<IPatientStatementParameterDTO> ConvertGUIDToId(IPatientStatementParameterDTO patientUIDs);
        Task<IPatientStatementParameterDTO> ConvertGUIDToIdForEMR(IPatientStatementParameterDTO patientUIDs);
    }


    public class ReportParameterService: IReportParameterService
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IInsuranceCompanyRepository _insuranceCompanyRepository;
        private readonly IDepositTypeRepository _depositTypeRepository;
        private readonly IARSCategoryReasonCodeRepository _aRSCategoryReasonCodeRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICPTCodeRepository _cptCodeRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IFacilityRepository _facilityRepository;
        private readonly IReferringDoctorRepository _referringDoctorRepository;

        public ReportParameterService(IProviderRepository providerRepository, 
                                      IInsuranceCompanyRepository insuranceCompanyRepository,
                                      IDepositTypeRepository depositTypeRepository,
                                      IARSCategoryReasonCodeRepository aRSCategoryReasonCodeRepository,
                                      IUserRepository userRepository,
                                      ICPTCodeRepository cPTCodeRepository,
                                      IPatientRepository patientRepository, 
                                      IFacilityRepository facilityRepository,
                                      IReferringDoctorRepository referringDoctorRepository)
        {
            _aRSCategoryReasonCodeRepository = aRSCategoryReasonCodeRepository;
            _cptCodeRepository = cPTCodeRepository;
            _depositTypeRepository = depositTypeRepository;
            _insuranceCompanyRepository = insuranceCompanyRepository;
            _providerRepository = providerRepository;
            _userRepository = userRepository;
            _patientRepository = patientRepository;
            _facilityRepository = facilityRepository;
            this._referringDoctorRepository = referringDoctorRepository;
        }

        public async Task<IReportParameterDTO> ConvertGUIDToId (IReportParameterDTO reportParameterDTO)
        {
            ReportParameterDTO reportParameter = reportParameterDTO as ReportParameterDTO;
            List<Guid> guidIds = new List<Guid>();

            if(reportParameter.InsuranceCompanyId != null && reportParameter.InsuranceCompanyId != "")
            {
                var getCompanyIds = reportParameter.InsuranceCompanyId.Split(',');
                getCompanyIds.ToList().ForEach((res) =>
                {
                    guidIds.Add(new Guid(res));
                });

                var companyData = await this._insuranceCompanyRepository.GetByUId(guidIds);
                reportParameter.InsuranceCompanyId = string.Join(",", companyData.Select(i => i.Id));
                reportParameter.CompanyName = companyData.Where(i => i.Id == companyData.FirstOrDefault().Id).FirstOrDefault().CompanyName;
            }

            if (reportParameter.FacilityUId != null && reportParameter.FacilityUId != "")
            {
                var getFacilityIds = reportParameter.FacilityUId.Split(',');
                getFacilityIds.ToList().ForEach((res) =>
                {
                    guidIds.Add(new Guid(res));
                });

                var facilityData = await this._facilityRepository.GetByUId(guidIds);
                reportParameter.FacilityId = facilityData.FirstOrDefault().Id; //string.Join(",", companyData.Select(i => i.Id));
                //reportParameter.CompanyName = companyData.Where(i => i.Id == companyData.FirstOrDefault().Id).FirstOrDefault().CompanyName;
            }

            if (reportParameter.ReasonCodes != null && reportParameter.ReasonCodes != "")
            {
                List<long> Ids = new List<long>();

                var getReasonCodeIds = reportParameter.ReasonCodes.Split(',');
                getReasonCodeIds.ToList().ForEach((res) =>
                {
                    Ids.Add(long.Parse(res));
                });


                var reasonCodeData = await this._aRSCategoryReasonCodeRepository.GetByUId(Ids);
                reportParameter.ReasonCodes = string.Join(",", reasonCodeData.Select(i => i.ReasonCode));
            }

            //if (reportParameter.DepositID != null && reportParameter.DepositID != "")
            //{
            //    guidIds = new List<Guid>();

            //    var getDepositIds = reportParameter.DepositID.Split(',');
            //    getDepositIds.ToList().ForEach((res) =>
            //    {
            //        guidIds.Add(new Guid(res));
            //    });


            //    var depositTypeData = await this._depositTypeRepository.GetByUId(guidIds);
            //    reportParameter.DepositID = string.Join(",", depositTypeData.Select(i => i.DepositPlace));
            //}

            if (reportParameter.DepositUID != null && reportParameter.DepositUID.ToString().Contains("00000") == false)
            {
                guidIds.Add(reportParameter.DepositUID);
                var depositTypeData = await this._depositTypeRepository.GetByUId(guidIds);
                reportParameter.DepositID = depositTypeData.Count() <= 0 ? 0 : depositTypeData.FirstOrDefault().Id;
            }

            //if (reportParameter.CptCode != null && reportParameter.CptCode != "")
            //{
            //    guidIds = new List<Guid>();

            //    var getCptCodeIds = reportParameter.CptCode.Split(',');
            //    getCptCodeIds.ToList().ForEach((res) =>
            //    {
            //        guidIds.Add(new Guid(res));
            //    });


            //    var cptCodeData = await this._cptCodeRepository.GetByUId(guidIds);
            //    reportParameter.CptCode = string.Join(",", cptCodeData.Select(i => i.CPTCode));
            //}

            if (reportParameter.ProviderID != null && reportParameter.ProviderID != "")
            {
                guidIds = new List<Guid>();

                var getProviderIDs = reportParameter.ProviderID.Split(',');
                getProviderIDs.ToList().ForEach((res) =>
                {
                    guidIds.Add(new Guid(res));
                });

                var getProviderData = await this._providerRepository.GetByUId(guidIds);
                reportParameter.ProviderID = string.Join(",", getProviderData.Select(i => i.Id));
            }

            if (reportParameter.AuxillaryProviderUId != null && reportParameter.AuxillaryProviderUId != "")
            {
                guidIds = new List<Guid>();

                var getAuxillaryProviderIDs = reportParameter.AuxillaryProviderUId.Split(',');
                getAuxillaryProviderIDs.ToList().ForEach((res) =>
                {
                    guidIds.Add(new Guid(res));
                });

                var getProviderData = await this._providerRepository.GetByUId(guidIds);
                reportParameter.AuxillaryProviderId = string.Join(",", getProviderData.Select(i => i.Id));
            }

            if (reportParameter.RefferingProviderUId != null && reportParameter.RefferingProviderUId != "")
            {
                guidIds = new List<Guid>();

                var getRefferingProviderUIds = reportParameter.RefferingProviderUId.Split(',');
                getRefferingProviderUIds.ToList().ForEach((res) =>
                {
                    guidIds.Add(new Guid(res));
                });

                var getProviderData = await this._referringDoctorRepository.GetByUId(guidIds);
                reportParameter.RefferingProviderId = string.Join(",", getProviderData.Select(i => i.Id));
            }

            if (reportParameter.UserID != null && reportParameter.UserID != "")
            {
                guidIds = new List<Guid>();

                var getUserIDs = reportParameter.UserID.Split(',');
                getUserIDs.ToList().ForEach((res) =>
                {
                    guidIds.Add(new Guid(res));
                });


                var getUserData = await this._userRepository.GetByUId(guidIds);
                reportParameter.UserID = string.Join(",", getUserData.Select(i => i.Id));
            }

            return reportParameter;
        }

        public async Task<IPatientStatementParameterDTO> ConvertGUIDToId(IPatientStatementParameterDTO patientUIDs)
        {
            List<Guid> guidIds = new List<Guid>();
            
            if (patientUIDs.PatientId != null && patientUIDs.PatientId != "")
            {
                guidIds = new List<Guid>();

                var getPatientIDs = patientUIDs.PatientId.Split(',');
                getPatientIDs.ToList().ForEach((res) =>
                {
                    guidIds.Add(new Guid(res));
                });


                var getPatientData = await this._patientRepository.GetByUId(guidIds);
                patientUIDs.PatientId = string.Join(",", getPatientData.Select(i => i.Id));
            }

            return patientUIDs;
        }

        public async Task<IPatientStatementParameterDTO> ConvertGUIDToIdForEMR(IPatientStatementParameterDTO patientUIDs)
        {
            List<Guid> guidIds = new List<Guid>();

            if (patientUIDs.PatientId != null && patientUIDs.PatientId != "")
            {
                var getPatientData = await this._patientRepository.PatientByBillingId(patientUIDs.PatientId);
                if(getPatientData!=null)
                {
                    patientUIDs.PatientId = getPatientData.Id.ToString();
                }
                
            }

            return patientUIDs;
        }
    }
}
