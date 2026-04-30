using Microsoft.Extensions.Logging;
using PractiZing.Base.Entities.ERAService;
using PractiZing.Base.Enums.ERAService;
using PractiZing.Base.Repositories.ERAService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Repositories.PatientService;
using PractiZing.Base.Service.ERAService;
using PractiZing.DataAccess.ERAService.Tables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BussinessLogic.ERAService.Service
{
    public class ERARootService : IERARootService
    {
        private readonly IERARootRepository _iERARootRepository;
        private readonly IERAClaimRepository _iERAClaimRepository;
        private readonly IERAClaimChargeRemarkRepository _iERAClaimChargeRemarkRepository;
        private readonly IERAClaimChargePaymentRepository _iERAClaimChargePaymentRepository;
        private readonly IERAClaimChargeAdjustmentRepository _iERAClaimChargeAdjustmentRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IPracticeRepository _practiceRepository;
        private readonly ILogger _logger;

        public ERARootService(IERARootRepository iERARootRepository,
            IERAClaimRepository iERAClaimRepository,
            IERAClaimChargeRemarkRepository iERAClaimChargeRemarkRepository,
            IERAClaimChargePaymentRepository iERAClaimChargePaymentRepository,
            IERAClaimChargeAdjustmentRepository iERAClaimChargeAdjustmentRepository,
            IPatientRepository patientRepository,
            IPracticeRepository practiceRepository,
            ILogger<ERARootService> logger)
        {
            this._iERARootRepository = iERARootRepository;
            this._iERAClaimRepository = iERAClaimRepository;
            this._iERAClaimChargePaymentRepository = iERAClaimChargePaymentRepository;
            this._iERAClaimChargeAdjustmentRepository = iERAClaimChargeAdjustmentRepository;
            this._iERAClaimChargeRemarkRepository = iERAClaimChargeRemarkRepository;
            this._patientRepository = patientRepository;
            this._practiceRepository = practiceRepository;
            this._logger = logger;
        }

        public async Task<IERARoot> Get(long id, bool isErrorRecords = false)
        {
            try
            {
                var result = await this._iERARootRepository.GetbyId(id);
                if (result != null)
                {
                    if (!isErrorRecords)
                        result.Claims = (await this._iERAClaimRepository.GetbyERARootId(id)).ToList();
                    else
                        result.Claims = (await this._iERAClaimRepository.GetbyERARootId_ErroClaims(id)).ToList();
                    var claimId = result.Claims.Select(i => i.Id);
                    var eraClaimPaymentsData = await this._iERAClaimChargePaymentRepository.GetByClaimId(claimId.ToArray());
                    var practice = await this._practiceRepository.Get();

                    _logger.LogInformation("getting patient control number");
                    string[] patientIds = result.Claims.Select(i => i.PatientControlNumber).ToArray();
                    _logger.LogInformation("getting patient control number- " + string.Join(',', patientIds));
                    List<int> patientId = new List<int>();

                    patientIds.ToList().ForEach((res) =>
                    {
                        if (res.Contains(practice.PracticeCodeCLM) == true)
                        {
                            res = res.Split("-")[0].Substring(3).ToString();
                            int ids = Convert.ToInt32(res);
                            patientId.Add(ids);
                        }
                    });

                    patientId = patientId.Distinct().ToList();
                    _logger.LogInformation("getting patient Id - " + string.Join(',', patientId));

                    var patients = await this._patientRepository.GetByIds(patientId);

                    var paymentIds = eraClaimPaymentsData.Select(i => i.Id);
                    var chargeRemark = await this._iERAClaimChargeRemarkRepository.Get(paymentIds.ToArray());
                    var chargeAdjustments = await this._iERAClaimChargeAdjustmentRepository.Get(paymentIds.ToArray());
                    _logger.LogInformation("getting patients - " + patients.Count());

                    foreach (var item in result.Claims)
                    {
                        item.Payments = eraClaimPaymentsData.Where(i => i.ERAClaimID == item.Id);
                        _logger.LogInformation("getting PatientControlNumber - " + item.PatientControlNumber);
                        string newPatientId = item.PatientControlNumber.Contains(practice.PracticeCodeCLM) ? item.PatientControlNumber.Split("-")[0].Substring(3).ToString() : null;
                        _logger.LogInformation("getting newPatientId - " + newPatientId);

                        if (newPatientId != null)
                        {
                            long Id = Convert.ToInt64(newPatientId);
                            _logger.LogInformation("getting PatientId - " + Id);

                            item.PatientUId = patients.FirstOrDefault(i => i.Id == Id) == null ? Guid.Empty : patients.FirstOrDefault(i => i.Id == Id).UId;
                            _logger.LogInformation("getting PatientUId - " + item.PatientUId);
                        }

                        foreach (var claimCharge in item.Payments)
                        {
                            claimCharge.RemarkCodes = string.Join(",", chargeRemark.Where(i => i.ERAClaimChargePaymentId == claimCharge.Id).Select(i => i.RemarkCode));
                            claimCharge.AdjustmentCodes = string.Join(",", chargeAdjustments.Where(i => i.ERAClaimChargePaymentId == claimCharge.Id).Select(i => i.CASCode + '-' + i.AdjustmentReasonCode));
                            claimCharge.AdjustmentAmount = chargeAdjustments.Where(i => i.ERAClaimChargePaymentId == claimCharge.Id).Sum(i => i.Amount);

                            claimCharge.Adjustments = chargeAdjustments.Where(i => i.ERAClaimChargePaymentId == claimCharge.Id);
                            claimCharge.Remarks = chargeRemark.Where(i => i.ERAClaimChargePaymentId == claimCharge.Id);
                            claimCharge.CoIns = chargeAdjustments.Where(i => i.ERAClaimChargePaymentId == claimCharge.Id && i.CASCode == "CO" && i.AdjustmentReasonCode == "Ins").Sum(i => i.Amount);
                            claimCharge.CoPay = chargeAdjustments.Where(i => i.ERAClaimChargePaymentId == claimCharge.Id && i.CASCode == "CO" && i.AdjustmentReasonCode == "Pay").Sum(i => i.Amount);
                            claimCharge.AllowedDed = claimCharge.Amount == null ? 0 : claimCharge.Amount;
                            claimCharge.Deductible = chargeAdjustments.Where(i => i.ERAClaimChargePaymentId == claimCharge.Id && i.CASCode == "Ded").Sum(i => i.Amount); ;
                            claimCharge.LastFilled = 0;
                        }

                        item.ClaimChargeTotalDTO.TotalAdjustments = item.Payments.Sum(i => i.AdjustmentAmount);
                        item.ClaimChargeTotalDTO.TotalAllowedDed = item.Payments.Sum(i => i.AllowedDed);
                        item.ClaimChargeTotalDTO.TotalBilledAmount = item.Payments.Sum(i => i.ChargeAmount);
                        item.ClaimChargeTotalDTO.TotalCoIns = item.Payments.Sum(i => i.CoIns);
                        item.ClaimChargeTotalDTO.TotalCoPay = item.Payments.Sum(i => i.CoPay);
                        item.ClaimChargeTotalDTO.TotalLastFilled = item.Payments.Sum(i => i.LastFilled);
                        item.ClaimChargeTotalDTO.TotalPrevPaid = item.Payments.Sum(i => i.Amount);
                        item.ClaimChargeTotalDTO.TotalDed = item.Payments.Sum(i => i.Deductible);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("error - " + ex.Message);
                _logger.LogInformation("error stack trace- " + ex.StackTrace);
                throw;
            }
        }

        public async Task<IEnumerable<IERARoot>> Get()
        {
            List<ERARoot> eRARoots = new List<ERARoot>();
            var result = await this._iERARootRepository.Get("");

            foreach (var item in result)
            {
                var getIdData = await this.Get(item.Id) as ERARoot;
                eRARoots.Add(getIdData);
            }

            return eRARoots;
        }

        public async Task<IEnumerable<IERARoot>> GetStatus(string checkNo)
        {
            var eraRootData = await this._iERARootRepository.Get(checkNo);

            long[] ids = eraRootData.OrderByDescending(i=>i.CreateDate).Take(2000).Select(i => i.Id).ToArray();
            var eraClaimData = await this._iERAClaimRepository.GetbyERARootId(ids);

            eraRootData.ToList().ForEach((res) =>
            {
                res.CreatedDate = res.CreateDate.HasValue ? res.CreateDate.Value.Date.ToString("MM/dd/yyyy") : string.Empty;
                res.StatusId = (eraClaimData.Where(i => i.ERARootID == res.Id && i.StatusId == (int)StatusEnum.Failed)).Count() > 0 ? (int)StatusEnum.Failed : (int)StatusEnum.Processed;
            });

            eraRootData = eraRootData.OrderByDescending(i => i.CreateDate);
            return eraRootData;
        }

        public async Task<IEnumerable<IERARoot>> GetErrorStatus()
        {
            //checkNo = "602000455452";

            var eraClaimData = await this._iERAClaimRepository.GetAllErrorRecords();

            long[] errorids = eraClaimData.Select(i => i.ERARootID).ToArray();

            var eraRootData = await this._iERARootRepository.GetbyERARootId(errorids);

            //long[] ids = eraRootData.Select(i => i.Id).ToArray();

            //var eraClaimData = await this._iERAClaimRepository.GetbyERARootId(ids);

            eraRootData.ToList().ForEach((res) =>
            {
                res.CreatedDate = res.CreateDate.HasValue ? res.CreateDate.Value.Date.ToString("MM/dd/yyyy") : string.Empty;
                res.StatusId = (eraClaimData.Where(i => i.ERARootID == res.Id && i.StatusId == (int)StatusEnum.Failed)).Count() > 0 ? (int)StatusEnum.Failed : (int)StatusEnum.Processed;
            });

            eraRootData = eraRootData.OrderByDescending(i => i.CreateDate);
            return eraRootData;
        }
    }
}
