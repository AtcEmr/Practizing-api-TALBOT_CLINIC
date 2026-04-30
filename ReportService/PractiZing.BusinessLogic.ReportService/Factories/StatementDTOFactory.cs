using PractiZing.Base.Factory;
using PractiZing.Base.Object.ReportService;
using PractiZing.DataAccess.Common.Helpers;
using PractiZing.DataAccess.ReportService.DTO;
using PractiZing.DataAccess.ReportService.DTO.Statement;
using System.Collections.Generic;
using System.Linq;


namespace PractiZing.BusinessLogic.ReportService.Factories
{
    public interface IStatementDTOFactory : IFactory
    {
        StatementDTO InitStatementDto(IPatientChargeStatementDTO patientChargeStatementDTO);
    }

    public sealed class StatementDTOFactory : IStatementDTOFactory
    {
        public StatementDTO InitStatementDto(IPatientChargeStatementDTO patientChargeStatementDTO)
        {
            var statementDto = new StatementDTO
            {
                Patient = GetPatientDto(patientChargeStatementDTO),
                StatementDate = DateConverter.FormatDate(patientChargeStatementDTO.StatementDate),
                PayByWeb = patientChargeStatementDTO.PayByWeb,
                PayByPhoneNumber = patientChargeStatementDTO.PayByPhoneNumber,
                Transactions = GetTransactionDto(patientChargeStatementDTO),
                AgingBalances = GetAgingBalancesDto(patientChargeStatementDTO),
                RemitMessage = patientChargeStatementDTO.StatementMessage,
                Practice = GetPracticeDto(patientChargeStatementDTO),
                RemitAddress = GetRemitAddressDto(patientChargeStatementDTO),
                Guarantor = GetGuarantorDto(patientChargeStatementDTO),
                DueDate = DateConverter.FormatDateYear(patientChargeStatementDTO.DueDate),
                AmountPatientDue = patientChargeStatementDTO.TotalDueAmount,
                Note = patientChargeStatementDTO.Note
            };
            return statementDto;
        }


        private PatientStatementDTO GetPatientDto(IPatientChargeStatementDTO patientChargeStatementDTO)
        {
            var patientDto = new PatientStatementDTO
            {
                AccountNumber = patientChargeStatementDTO.PatientId.ToString(),
                FirstName = patientChargeStatementDTO.FirstName,
                MiddleName = patientChargeStatementDTO.MiddleName,
                LastName = patientChargeStatementDTO.LastName,
                Address = GetAddressDto(patientChargeStatementDTO),
                
            };
            return patientDto;
        }

        private AddressDTO GetAddressDto(IPatientChargeStatementDTO patientChargeStatementDTO)
        {
            return new AddressDTO
            {
                AddressLine = patientChargeStatementDTO.BillAddress1,                
                City = patientChargeStatementDTO.BillCity,
                State = patientChargeStatementDTO.BillState,
                Zip = patientChargeStatementDTO.BillZip
            };
        }

        private RemitAddressDTO GetRemitAddressDto(IPatientChargeStatementDTO patientChargeStatementDTO)
        {
            return new RemitAddressDTO
            {
                Name = patientChargeStatementDTO.FacilityName,
                Address = new AddressDTO
                {
                    AddressLine = patientChargeStatementDTO.RemitAddress1,
                    AddressLine2 = patientChargeStatementDTO.RemitAddress2,
                    City = patientChargeStatementDTO.RemitCity,
                    State = patientChargeStatementDTO.RemitState,
                    Zip = patientChargeStatementDTO.RemitZipCode
                }
            };
        }        

        private List<TransactionDTO> GetTransactionDto(IPatientChargeStatementDTO patientChargeStatementDTO)
        {
            var transactions = new List<TransactionDTO>();
            // charges, payments and adjustments
            foreach (var item in patientChargeStatementDTO.ChargePayments.Where(i => i.IsCharge == true))
            {
                // charges
                var charges = new List<ChargeStatementDTO>();
                var charge = new ChargeStatementDTO();
                charge.Amount = item.ChargeAmount;
                charge.Description = item.Description;
                charge.Date = DateConverter.FormatDateYear(item.DOS);
                charge.CPTCode = item.CPTCode;
                charges.Add(charge);

                // payments
                var payments = new List<PaymentStatementDTO>();
                var paymentsResult = patientChargeStatementDTO.ChargePayments.Where(i => i.ChargeId == item.ChargeId && i.IsCharge == false && i.IsPayment == true);
                foreach (var paymentItem in paymentsResult)
                {
                    var payment = new PaymentStatementDTO();
                    payment.Date = DateConverter.FormatDateYear(paymentItem.CreatedDate);
                    payment.PaidAmount = paymentItem.PaidAmount;
                    payments.Add(payment);
                }

                // adjustments
                var adjustments = new List<AdjustmentStatementDTO>();
                var adjustmentsResult = patientChargeStatementDTO.ChargePayments.Where(i => i.ChargeId == item.ChargeId && i.IsCharge == false && i.IsPayment == false);
                foreach (var adjustmentItem in adjustmentsResult)
                {
                    var adjustment = new AdjustmentStatementDTO();
                    adjustment.Date = DateConverter.FormatDateYear(adjustmentItem.CreatedDate);
                    adjustment.AdjustmentAmount = adjustmentItem.AdjustmentAmount;
                    adjustment.Description = adjustmentItem.AdjustmentReasonCode;
                    adjustments.Add(adjustment);
                }

                if (charges.Count > 0)
                {
                    var transaction = new TransactionDTO();
                    transaction.Charges = charges;
                    transaction.Payments = payments;
                    transaction.Adjustments = adjustments;
                    transactions.Add(transaction);
                }
            }
            return transactions;
        }


        private GuarantorDTO GetGuarantorDto(IPatientChargeStatementDTO patientChargeStatementDTO)
        {         
            return new GuarantorDTO
            {
                FirstName = patientChargeStatementDTO.GuarantorFirstName,
                MiddleName = patientChargeStatementDTO.GuarantorMiddleName,
                LastName = patientChargeStatementDTO.GuarantorLastName,
                Address = new AddressDTO
                {
                    AddressLine = patientChargeStatementDTO.GuarantorAddress1,                    
                    City = patientChargeStatementDTO.GuarantorCity,
                    State = patientChargeStatementDTO.GuarantorState,
                    Zip = patientChargeStatementDTO.GuarantorZip
                },                
            };
        }

        private PracticeDTO GetPracticeDto(IPatientChargeStatementDTO patientChargeStatementDTO)
        {           
            return new PracticeDTO
            {
                Name = patientChargeStatementDTO.FacilityName,
                Address = new AddressDTO
                {
                    //AddressLine = patientChargeStatementDTO.FacilityAddress1,
                    //AddressLine2 = patientChargeStatementDTO.FacilityAddress2,
                    //City = patientChargeStatementDTO.FacilityCity,
                    //State = patientChargeStatementDTO.FacilityState,
                    //Zip = patientChargeStatementDTO.FacilityZipCode

                    AddressLine = patientChargeStatementDTO.RemitAddress1,
                    AddressLine2 = patientChargeStatementDTO.RemitAddress2,
                    City = patientChargeStatementDTO.RemitCity,
                    State = patientChargeStatementDTO.RemitState,
                    Zip = patientChargeStatementDTO.RemitZipCode
                },                
                //Phone = patientChargeStatementDTO.FacilityPhone
            };
        }

        private AgingBalancesDTO GetAgingBalancesDto(IPatientChargeStatementDTO patientChargeStatementDTO)
        {
            return new AgingBalancesDTO
            {                
                Current = patientChargeStatementDTO.Current,
                Over30Days = patientChargeStatementDTO.Over30Days,
                Over60Days = patientChargeStatementDTO.Over60Days,
                Over90Days = patientChargeStatementDTO.Over90Days,
                Over120Days = patientChargeStatementDTO.Over120Days,
                DunningMessage = patientChargeStatementDTO.DunningMessage                
            };
        }
    }
}
