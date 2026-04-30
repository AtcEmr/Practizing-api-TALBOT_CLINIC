using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Service.MasterService;
using PractiZing.BusinessLogic.MasterService.Repositories;
using PractiZing.BusinessLogic.MasterService.Services;
using PractiZing.DataAccess.MasterService.Tables;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class PractiZingPatientRepositoryCollectionExtension
    {
        public static IServiceCollection AddMasterServiceRepositories(this IServiceCollection services)
        {
            services.AddScoped<IInsuranceCompanyRepository, InsuranceCompanyRepository>();
            services.AddScoped<IConfigBillTypeRepository, ConfigBillTypeRepository>();
            services.AddScoped<IConfigPatientRaceRepository, ConfigPatientRaceRepository>();
            services.AddScoped<IConfigCaseTypeRepository, ConfigCaseTypeRepository>();
            services.AddScoped<IConfigFacilitySubTypeRepository, ConfigFacilitySubTypeRepository>();
            services.AddScoped<IConfigFacilityTypeRepository, ConfigFacilityTypeRepository>();
            services.AddScoped<IConfigInsuranceCompanyTypeRepository, ConfigInsuranceCompanyTypeRepository>();
            services.AddScoped<IConfigInsuranceFormTypeRepository, ConfigInsuranceFormTypeRepository>();
            services.AddScoped<IConfigInsuranceMedicareSecondaryRepository, ConfigInsuranceMedicareSecondaryRepository>();
            services.AddScoped<IConfigMaritalStatusRepository, ConfigMaritalStatusRepository>();
            services.AddScoped<IConfigPositionRepository, ConfigPositionRepository>();
            services.AddScoped<IConfigPOSRepository, ConfigPOSRepository>();
            services.AddScoped<IConfigProviderPositionRepository, ConfigProviderPositionRepository>();
            services.AddScoped<IConfigProviderSpecialtyRepository, ConfigProviderSpecialtyRepository>();
            services.AddScoped<IConfigTOSRepository, ConfigTOSRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<ICPTCodeRepository, CPTCodeRepository>();
            services.AddScoped<IICDCodeRepository, ICDCodeRepository>();
            services.AddScoped<IZipCodeLookUpRepository, ZipCodeLookUpRepository>();
            services.AddScoped<INDCRepository, NDCRepository>();
            services.AddScoped<IReferringDoctorRepository, ReferringDoctorRepository>();
            services.AddScoped<IClearingHouseRepository, ClearingHouseRepository>();
            services.AddScoped<ILabSalesRepRepository, LabSalesRepRepository>();
            services.AddScoped<IMasterICD10Repository, MasterICD10Repository>();
            services.AddScoped<IMasterCPTRepository, MasterCPTRepository>();
            services.AddScoped<IConfigReferralSourceRepository, ConfigReferralSourceRepository>();
            services.AddScoped<IConfigRelationshipRepository, ConfigRelationshipRepository>();
            services.AddScoped<IDrugClassRepository, DrugClassRepository>();
            services.AddScoped<IEncounterRulesAllowedPOSRepository, EncounterRulesAllowedPOSRepository>();
            services.AddScoped<IEncounterRulesRepository, EncounterRulesRepository>();
            services.AddScoped<IFacilityRepository, FacilityRepository>();
            services.AddScoped<INotesCategoryRepository, NotesCategoryRepository>();
            services.AddScoped<IConfigSettingGroupRepository, ConfigSettingGroupRepository>();
            services.AddScoped<IConfigSettingRepository, ConfigSettingRepository<ConfigSetting, AppSetting>>();
            services.AddScoped<IAppSettingRepository, AppSettingRepository>();
            services.AddScoped<IConfigFollowUpPeriodRepository, ConfigFollowUpPeriodRepository>();
            services.AddScoped<IARSCategoryReasonCodeRepository, ARSCategoryReasonCodeRepository>();
            services.AddScoped<IConfigAdjustmentReasonCodeRepository, ConfigAdjustmentReasonCodeRepository>();
            services.AddScoped<IConfigNDCUOMRepository, ConfigNDCUOMRepository>();
            services.AddScoped<IDepositTypeRepository, DepositTypeRepository>();
            services.AddScoped<IConfigSystemCDRepository, ConfigSystemCDRepository>();

            services.AddScoped<IDemographicNoteRepository, DemographicNoteRepository>();
            services.AddScoped<IConfigERARemarkCodesRepository, ConfigERARemarkCodesRepository>();
            services.AddScoped<IAttFileRepository, AttFileRepository>();
            services.AddScoped<IAttFileTableRepository, AttFileTableRepository>();
            services.AddScoped<IMonthEndCloseRepository, MonthEndCloseRepository>();
            services.AddScoped<IProviderIdentityRepository, ProviderIdentityRepository>();
            services.AddScoped<IConfigDrugClassRepository, ConfigDrugClassRepository>();
            services.AddScoped<IClaimConfigRepository, ClaimConfigRepository>();
            services.AddScoped<IConfigIdTypeRepository, ConfigIdTypeRepository>();
            services.AddScoped<IFacilityIdentityRepository, FacilityIdentityRepository>();
            services.AddScoped<ICPTCategoryRepository, CPTCategoryRepository>();
            services.AddScoped<IPracticeRepository, PracticeRepository>();
            services.AddScoped<IDenialCategoryReasonCodeRepository, DenialCategoryReasonCodeRepository>();
            services.AddScoped<IDenialCategoryRepository, DenialCategoryRepository>();
            services.AddScoped<IAdjustmentReasonCodeRepository, AdjustmentReasonCodeRepository>();
            services.AddScoped<IConfigServiceTypeRepository, ConfigServiceTypeRepository>();
            services.AddScoped<IConfigTrizettoPatientEligibilityRepository, ConfigTrizettoPatientEligibilityRepository>();
            services.AddScoped<IConfigSupervisionTypeRepository, ConfigSupervisionTypeRepository>();
            services.AddScoped<IConfigPractitionerServiceRepository, ConfigPractitionerServiceRepository>();
            services.AddScoped<IConfigServiceCircumstanceRepository, ConfigServiceCircumstanceRepository>();
            services.AddScoped<IBillingUnitConversionChartRepository, BillingUnitConversionChartRepository>();
            services.AddScoped<IEncounterRulesAllowedCPTRepository, EncounterRulesAllowedCPTRepository>();
            services.AddScoped<IConfigPlaidRepository, ConfigPlaidRepository>();
            services.AddScoped<IProviderFacilityValidtionRepository, ProviderFacilityValidtionRepository>();
            services.AddScoped<IRemarkCodeSolutionRepository, RemarkCodeSolutionRepository>();


            return services;
        }

        public static IServiceCollection AddMasterServices(this IServiceCollection services)
        {
            services.AddScoped<IInsuranceCompanyService, InsuranceCompanyService>();
            services.AddScoped<IAppSettingService, AppSettingService>();
            services.AddScoped<IProviderService, ProviderService>();
            services.AddScoped<INotesCategoryService, NotesCategoryService>();
            services.AddScoped<IFullFrameworkRequestService, FullFrameworkRequestService>();
            services.AddScoped<IReportService, ReportService>();
            services.AddScoped<IReportParameterService, ReportParameterService>();
            services.AddScoped<IMergePdfFiles, MergePdfFiles>();
            services.AddScoped<IAttService, AttService>();
            services.AddScoped<IFacilityService, FacilityService>();

            return services;
        }
    }
}
