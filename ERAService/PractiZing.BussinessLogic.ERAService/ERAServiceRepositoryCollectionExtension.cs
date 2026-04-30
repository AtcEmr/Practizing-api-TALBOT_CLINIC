using PractiZing.Base.Repositories.ERAService;
using PractiZing.Base.Service.ChargePaymentService;
using PractiZing.Base.Service.ERAService;
using PractiZing.BusinessLogic.ChargePaymentService.Services;
using PractiZing.BussinessLogic.ERAService.Converter;
using PractiZing.BussinessLogic.ERAService.Repositiories;
using PractiZing.BussinessLogic.ERAService.Service;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ERAServiceRepositoryCollectionExtension
    {
        public static IServiceCollection AddERAServiceRepositories(this IServiceCollection services)
        {
            services.AddScoped<IERAClaimChargeAdjustmentRepository, ERAClaimChargeAdjustmentRepository>();
            services.AddScoped<IERAClaimChargePaymentRepository, ERAClaimChargePaymentRepository>();
            services.AddScoped<IERAClaimChargeRemarkRepository, ERAClaimChargeRemarkRepository>();
            services.AddScoped<IERAClaimRepository, ERAClaimRepository>();
            services.AddScoped<IERARootRepository, ERARootRepository>();

            return services;
        }

        public static IServiceCollection AddERAServices(this IServiceCollection services)
        {
            services.AddScoped<IPaymentBatchConverter, PaymentBatchConverter>();
            services.AddScoped<IERARootService, ERARootService>();
            services.AddScoped<IERAPaymentService, ERAPaymentService>();
            services.AddScoped<IERARequestService, ERARequestService>();
            services.AddScoped<IPaymentObjectConverterService, PaymentObjectConverterService>();
            services.AddScoped<IVoucherConverter, VoucherConverter>();
            services.AddScoped<IERAClaimChargeAdjustmentConverter, ERAClaimChargeAdjustmentConverter>();

            return services;
        }
    }
}
