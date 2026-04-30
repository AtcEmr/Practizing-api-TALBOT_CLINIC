using PractiZing.Base.Repositories.BatchPaymentService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.BusinessLogic.BatchPaymentService.Repositories;
using PractiZing.BusinessLogic.ChargePaymentService.Repositories;
using PractiZing.BusinessLogic.ChargePaymentService.Services;
using PractiZing.ClaimCreator.Form;


namespace Microsoft.Extensions.DependencyInjection
{
    public static class PractiZingChargePaymentRepositoryCollectionExtension
    {
        public static IServiceCollection AddChargePaymentServiceRepositories(this IServiceCollection services)
        {
            services.AddScoped<IChargesRepository, ChargesRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IInvDiagnosisRepository, InvDiagnosisRepository>();
            services.AddScoped<IFeeScheduleRepository, FeeScheduleRepository>();
            services.AddScoped<IFSChargeRepository, FSChargeRepository>();
            services.AddScoped<IFSDiscountRepository, FSDiscountRepository>();
            services.AddScoped<IFSLocalityCarrierRepository, FSLocalityCarrierRepository>();
            services.AddScoped<IConfigMessageCodeRepository, ConfigMessageCodeRepository>();
            services.AddScoped<ICPTModifierRepository, CPTModifierRepository>();

            services.AddScoped<IPaymentBatchRepository, PaymentBatchRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IPaymentChargeRepository, PaymentChargeRepository>();
            services.AddScoped<IPaymentAdjustmentRepository, PaymentAdjustmentRepository>();
            services.AddScoped<IVoucherRepository, VoucherRepository>();
            services.AddScoped<IDefaultReasonCodeRepository, DefaultReasonCodeRepository>();
            services.AddScoped<IChargeBatchRepository, ChargeBatchRepository>();
            services.AddScoped<IDrugChargeRepository, DrugChargeRepository>();
            services.AddScoped<IConfigHCFAFormFieldRepository, ConfigHCFAFormFieldRepository>();
            services.AddScoped<IClaimRepository, ClaimRepository>();
            services.AddScoped<IPaymentRemarkCodeRepository, PaymentRemarkCodeRepository>();

            services.AddScoped<IClaimBatchRepository, ClaimBatchRepository>();
            services.AddScoped<IClaimTotalRepository, ClaimTotalRepository>();
            services.AddScoped<IClaimChargeRepository, ClaimChargeRepository>();
            //services.AddScoped<IFillFormService, FillFormService>();
            //services.AddScoped<IFillUB04FormService, PractiZing.ClaimService.UB04.FillFormService>();
            services.AddScoped<ClaimFileCreator, ClaimFileCreator>();
            services.AddScoped<IScrubCodingRepository, ScrubCodingRepository>();
            services.AddScoped<IScrubRepository, ScrubRepository>();
            services.AddScoped<IScrubErrorRepository, ScrubErrorRepository>();
            services.AddScoped<IChargeScrubRepository, ChargeScrubRepository>();
            services.AddScoped<IHL7RuleStatementsRepository, HL7RulesScriptsRepository>();
            services.AddScoped<IPortalPaymentRepository, PortalPaymentRepository>();

            services.AddScoped<IDynmoPaymentsRepository, DynmoPaymentsRepository>();
            services.AddScoped<IChargesReportDataRepository, ChargesReportDataRepository>();
            services.AddScoped<IPaymentReportDataRepository, PaymentReportDataRepository>();

            services.AddScoped<IHistoryPaymentRepository, HistoryPaymentRepository>();
            services.AddScoped<IPlaidPaymentRepository, PlaidPaymentRepository>();
            services.AddScoped<IChargeInWriteOffRepository, ChargeInWriteOffRepository>();
            

            services.AddScoped<IPaymentAdjustmentNotesRepository, PaymentAdjustmentNotesRepository>();

            services.AddScoped<IChargesReportDataConsolidateRepository, ChargesReportDataConsolidateRepository>();

            services.AddScoped<IClaimStatusInquiryRepository, ClaimStatusInquiryRepository>();
            services.AddScoped<IClaimStatusInquiryChildRepository, ClaimStatusInquiryChildRepository>();
            services.AddScoped<IClaim824StatusRepository, Claim824StatusRepository>();
            services.AddScoped<IMethaSoftInvoiceRepository, MethaSoftInvoiceRepository>();
            services.AddScoped<IBankReconciliationRepository, BankReconciliationRepository>();
            services.AddScoped<IChasePaymentsRepository, ChasePaymentsRepository>();
            services.AddScoped<IChasePaymentChildRepository, ChasePaymentChildRepository>();
            services.AddScoped<IPortalPaymentChildRepository, PortalPaymentChildRepository>();
            services.AddScoped<IChargeStatementCountRepository, ChargeStatementCountRepository>();
            services.AddScoped<IWriteOffTHCodeRepository, WriteOffTHCodeRepository>();
            


            return services;

        }

        public static IServiceCollection AddChargePaymentService(this IServiceCollection services)
        {
            services.AddScoped<IChargeInvoiceService, ChargeInvoiceService>();
            services.AddScoped<IFeeScheduleService, FeeScheduleService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IClaimService, ClaimService>();
            services.AddScoped<IClaimFileProcessService, ClaimFileProcessService>();
            services.AddScoped<IClaimStatusEnquiryService, ClaimStatusEnquiryService>();
            
            services.AddScoped<IPortalPaymentService, PortalPaymentService>();

            return services;
        }
    }
}
