using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.ERAService;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.BussinessLogic.ERAService.Converter
{
    public interface IERAClaimChargeAdjustmentConverter
    {
        Task<IEnumerable<IDefaultReasonCode>> IniIChargeAdjustment(IEnumerable<IERAClaimChargeAdjustment> eRAClaimChargeAdjustment, decimal payment, IEnumerable<IDefaultReasonCode> defaultReasonCode);
    }

    public class ERAClaimChargeAdjustmentConverter : IERAClaimChargeAdjustmentConverter
    {
        public async Task<IEnumerable<IDefaultReasonCode>> IniIChargeAdjustment(IEnumerable<IERAClaimChargeAdjustment> eRAClaimChargeAdjustments, decimal payment, IEnumerable<IDefaultReasonCode> defaultReasonCode)
        {
            List<DefaultReasonCode> defaultReasonList = new List<DefaultReasonCode>();
            string[] isDenialAdjustmentCodes = { "pr1", "pr2", "pr3", "oa23" };
            //string[] isAccountedAdjustmentCodes = { "pr200", "pi27", "pi227", "pi31" };

            foreach (var item in eRAClaimChargeAdjustments)
            {
                DefaultReasonCode defaultReason = new DefaultReasonCode();
                defaultReason.Id = 0;
                defaultReason.IsAccounted = defaultReasonCode.ToList().Where(i => i.Code.Contains(item.CASCode + item.AdjustmentReasonCode)).Count() > 0 ? defaultReasonCode.Where(i => i.Code == (item.CASCode + item.AdjustmentReasonCode)).FirstOrDefault().IsAccounted : false;
                if ((item.CASCode + item.AdjustmentReasonCode).ToString().ToLower().Contains("pr") == true)
                    defaultReason.IsAccounted = false;
                else
                    defaultReason.IsAccounted = true;
                defaultReason.AdjustmentAmount = item.Amount;
                defaultReason.Code = (item.CASCode + item.AdjustmentReasonCode);
                var isDenialCase = isDenialAdjustmentCodes.Contains((item.CASCode + item.AdjustmentReasonCode).ToLower());
                defaultReason.DisplayName = (item.CASCode + item.AdjustmentReasonCode);
                if (isDenialCase == false && payment == 0)
                {
                    if (eRAClaimChargeAdjustments.Count(i => isDenialAdjustmentCodes.Contains((i.CASCode + i.AdjustmentReasonCode).ToLower())) > 0)
                    {
                        defaultReason.IsAccounted = true;
                        defaultReason.IsDenial = false;
                    }
                    else
                    {
                        defaultReason.IsAccounted = false;
                        defaultReason.IsDenial = true;
                    }
                }
                else
                    defaultReason.IsDenial = false;

                defaultReason.IsFixed = false;
                defaultReason.IsSystem = true;
                defaultReason.PaymentChargeId = 0;

                defaultReasonList.Add(defaultReason);
            }

            return defaultReasonList;
        }
    }
}
