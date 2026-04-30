using PractiZing.Base.Repositories.PatientService;
using PractiZing.Base.Service.PatientService;
using PractiZing.BusinessLogic.PatientService.Repositories;
using PractiZing.BusinessLogic.PatientService.Services;
using PractiZing.DataAccess.MasterService.Tables;
using PractiZing.DataAccess.PatientService.Tables;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class PractiZingPatientRepositoryCollectionExtension
    {
        public static IServiceCollection AddPatientServiceRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPatientCaseRepository, PatientCaseRepository>();
            services.AddScoped<ILabVendorInsuranceCodesRepository, LabVendorInsuranceCodesRepository>();
            services.AddScoped<IInsurancePolicyRepository, InsurancePolicyRepository>();
            services.AddScoped<IInsurancePolicyHolderRepository, InsurancePolicyHolderRepository>();
            services.AddScoped<IInsuranceGuarantorRepository, InsuranceGuarantorRepository>();
            services.AddScoped<IPatientAuthorizationNumberRepository, PatientAuthorizationNumberRepository>();
            services.AddScoped<IHL7StatusRepository, HL7StatusRepository>();
            services.AddScoped<IPatientStatementRepository, PatientStatementRepository>();
            services.AddScoped<IPatientNoteRepository, PatientNoteRepository>();
            services.AddScoped<IPatientEligibilityRepository, PatientEligibilityRepository>();
            services.AddScoped<IPatientEligibilityDetailRepository, PatientEligibilityDetailRepository>();
            services.AddScoped<IEDIEligibilityLogRepository, EDIEligibilityLogRepository>();
            services.AddScoped<IDataIntegrationRepository, DataIntegrationRepository>();
            services.AddScoped<IBatchStatementRepository, BatchStatementRepository>();
            services.AddScoped<IPatientAlertRepository, PatientAlertRepository>();
            services.AddScoped<IInsurancePolicyExceptionRepository, InsurancePolicyExceptionRepository>();

            return services;
        }

        public static IServiceCollection AddPatientServices(this IServiceCollection services)
        {
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IDataIntegrationService, DataIntegrationService>();
            services.AddScoped<IInsurancePolicyService, InsurancePolicyService>();
            services.AddScoped<IDashboardQuickStartService, DashboardQuickStartService>();
            return services;
        }
    }
}
