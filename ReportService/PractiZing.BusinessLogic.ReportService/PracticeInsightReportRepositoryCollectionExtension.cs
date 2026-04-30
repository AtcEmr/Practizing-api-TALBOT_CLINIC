using PractiZing.Base.Repositories.ReportService;
using PractiZing.Base.Service.PatientService;
using PractiZing.BusinessLogic.ReportService.Factories;
using PractiZing.BusinessLogic.ReportService.Repositories;
using PractiZing.BusinessLogic.ReportService.Services;
using PractiZing.DataAccess.ReportService;
using PractiZing.DataAccess.ReportService.Tables;


namespace Microsoft.Extensions.DependencyInjection
{
    public static class PractiZingReportRepositoryCollectionExtension
    {
        public static IServiceCollection AddPractiZingReportRepositories(this IServiceCollection services)
        {
            services.AddTransient<IReportRepository, ReportRepository<Report,ReportDataDTO>>();
            services.AddTransient<IReportFormulaFieldRepository, ReportFormulaFieldRepository<ReportFormulaField>>();
            services.AddTransient<IChargeStatRepository, ChargeStatRepository>();
            services.AddTransient<IStatementDTOFactory, StatementDTOFactory>();
            services.AddTransient<ICPAReportMonthYearWiseRepository, CPAReportMonthYearWiseRepository>();
            services.AddTransient<ICPAReportMonthYearWiseChildRepository, CPAReportMonthYearWiseChildRepository>();
            services.AddTransient<IChargeBalanceAR90Repository, ChargeBalanceAR90Repository>();
            services.AddTransient<IReportARChargesMonthWiseRepository, ReportARChargesMonthWiseRepository>();

            return services;
        }

        public static IServiceCollection AddReportServices(this IServiceCollection services)
        {

            services.AddScoped<IStatementFileService, StatementFileService>();
            return services;
        }
    }
}
