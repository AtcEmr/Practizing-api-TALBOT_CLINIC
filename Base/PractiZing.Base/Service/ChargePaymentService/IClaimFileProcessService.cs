using System;
using System.Threading.Tasks;

namespace PractiZing.Base.Service.ChargePaymentService
{
    public interface IClaimFileProcessService
    {
        Task<string> ExportCms1500Async(Guid uId);
        Task<string> ExportM837File(Guid batchUId);
        Task<string> Read277();
        Task<string> Read824();
        Task<string> Upload270EdiFilesToDeloitte();
        Task<bool> Upload837DeloitteFiles_Bulk();
        Task<bool> Create837PEdiFiles(int clearingHouseId);
    }
}
