using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.Base.Service.ChargePaymentService
{
    public interface IPortalPaymentService
    {
        Task<int> AddNewPayment(Guid portalPaymentUId);
        Task<IPaymentBatch> IniIPaymentBatch(decimal amount);
        Task<IVoucher> IniIVoucher(IPaymentBatch paymentBatch, int patientId);
        Task<IPayment> InitPayment(IVoucher voucher, int patientId);
        Task<IEnumerable<IPaymentCharge>> InitPaymentCharge(IEnumerable<ICharges> charges, decimal amount, int paymentId);
        Task<IEnumerable<IPortalPayment>> GetPatientPayments(Guid guid);
        Task<IPortalPayment> RefundPortalPayment(IRefundPaymentDTO entity);
        Task<int> GetHelpDeskPayments();
        Task<IEnumerable<IDynmoPayments>> GetDynmoPayments(IDynmoPaymentFilterDTO filter);
        Task<DataTable> GetDynmoPaymentsForCatalystRCM();
        Task<int> UpdateDynmoNotification(List<int> ids);
        Task<int> UpdateBadRecordFromCatalystRCM(List<int> ids);
        Task<int> UpdateDynmoPayment(IDynmoPayments entity);
        Task<bool> MoveInPortalPayment(int id);
        Task<int> SaveDatainPortalPaymentTables(List<IDynmoPayments> list);
        Task<string> RefundChargeByChargeId(string chargeid, string reasons);
        Task<int> AdjustCopayPayment(IPortalPayment entity);
        Task<IVoucher> IniIVoucher(IPaymentBatch paymentBatch, int patientId, decimal amount);
        //Task<IEnumerable<IPaymentCharge>> InitPaymentChargeForCopay(IEnumerable<ICharges> charges, decimal amount, int paymentId);
        Task<IEnumerable<IPaymentCharge>> InitPaymentChargeForCopay(IEnumerable<IPostedCharges> charges, decimal amount, int paymentId);
        Task<IEnumerable<IPortalPayment>> GetPatientPaymentsForEMR(string emrPatientId);
        Task<IEnumerable<IPortalPaymentChargesDTO>> GetChargesForPortalPayment(Guid guid);
        Task<IEnumerable<IPortalPaymentEMRDTO>> GetOnlineUnPostedPayments(string billingId);
        Task<int> SendMoneyToLab(ILabPaymentDTO labPaymentDTO);
        Task<IEnumerable<IPortalPayment>> Get(IPortalPaymentFilterDTO filter);
        Task<bool> AutoMoveInPortalPayment();
    }
}
