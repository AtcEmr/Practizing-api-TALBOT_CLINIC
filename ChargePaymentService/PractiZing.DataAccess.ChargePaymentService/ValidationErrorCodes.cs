using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService
{
    public enum EnumErrorCode : Int32
    {
        ChargeDoesNotExists = 1004,
        DuplicateCPTCode = 1005,
        BillDocRequired = 1006,
        EntryDateValidation = 1007,
        DuplicateFeeSchedule = 1008,
        DuplicateFSCharge = 1009,
        DuplicateFSDiscount = 1010,

        CodeAlreadyExists = 1011,
        CodeCannotBeNullOrEmpty = 1013,
        DescriptionCannotBeNullOrEmpty = 1014,
        DescriptionAlreadyExists = 1015,

        PatientIdMandatory = 1016,
        InsuranceComapnyIdMandatory = 1017,
        PaymentBatchIdMandatory = 1018,
        PatientDoesNotHaveInsurance = 1019,

        DiagnosisCodeAlreadyUsedForThisCPT = 1020,
        PrimaryDiagnosisCodeIsMandatory = 1021,
        ModifierShouldBeUniqueForSameCPTCodes = 1022,
        ModifierAlreadyExistForThisCPT = 1023,
        AccessionNumberUnique = 1024,
        NoDeletionOfPaymentBatch = 1025,
        NoDeletionOfChargeBatch = 1026,

        ClaimAlreadyExist = 1027,
        ClaimCannotBeDeleted = 1028,
        ClaimCreatedforCharge = 1029,
        FeeScheduleNotExist = 1030,
        FeeDiscountEffectiveDate = 1031,
        EffectiveAndExpiryDate = 1032,
        ExpiryDateLessThanEffectiveDate = 1033,
        FeeDiscountAmountValidation = 1034,
        HoldCommentRequired = 1035,
        ChargeIsInUse = 1036,
        PatientCannotBeDeleted = 1037,
        ChargeNoNotExists = 1038,
        VoucherNotExists = 1039,
        PaymentBatchNotExists = 1040,
        DiagnosisCodeDuplicate = 1050,
        ChargeExist = 1041,
        VoucherExist = 1042,
        PaymentExist = 1043,
        FsDisocuntExists = 1044,
        VoucherExists = 1045,
        VoucherExistsCheckNo =1046,
        PaymentExistsWithThisCharge = 1047,
        ClaimforCharge = 1048,
        ClaimforChargeDelete = 1049,
        CPT90834Validation = 1060,
        ChargeRejectionPIN = 1065,
        JCodeError=1066,
        CardPayemntValidation = 1067,
        CardPayemntValidationForSingleSelection = 1068,
       OnlinePayemntCanNotEceedAcutal= 1070,
        AvoidPostedZeroPayment= 1071,
        RecurringError=1072,
        PostPaymentGreaterValidation = 1075,
    }

    public class ValidationErrorCodes : BaseValidationErrorCodes
    {
        public ValidationErrorCodes()
        {
            this.InitializeErrorCodes();
        }

        protected override void InitializeErrorCodes()
        {
            base.InitializeErrorCodes();
            this.AddErrorCode(EnumErrorCode.RecurringError, "Cannot update because there is a Recurring cpt code= H0048");
            this.AddErrorCode(EnumErrorCode.AvoidPostedZeroPayment, "Please enter posted amount.");
            this.AddErrorCode(EnumErrorCode.OnlinePayemntCanNotEceedAcutal, "Posted Payment cannot greater than Paid Amount");
            this.AddErrorCode(EnumErrorCode.CardPayemntValidationForSingleSelection, "Payment and Charge due amount is mismatched. Pls select Single charge for adjust the amount.");
            this.AddErrorCode(EnumErrorCode.CardPayemntValidation, "Posted Payment and online payment is mismatched.");
            this.AddErrorCode(EnumErrorCode.PostPaymentGreaterValidation, "Posted Payment cannot greater than Paid Amount");
            this.AddErrorCode(EnumErrorCode.JCodeError, "Ndc value is not there for J Code");
            this.AddErrorCode(EnumErrorCode.CPT90834Validation, "90834 only allows 1 Unit per day.");
            this.AddErrorCode(EnumErrorCode.ChargeDoesNotExists, "Charge not found with this charge id.");
            this.AddErrorCode(EnumErrorCode.DuplicateCPTCode, "Duplicate CPT Code and modifier not allowed!");
            this.AddErrorCode(EnumErrorCode.BillDocRequired, "Please select bill doctor");
            this.AddErrorCode(EnumErrorCode.EntryDateValidation, "Entry date(Post date) can not be less than bill from date or bill to date");
            this.AddErrorCode(EnumErrorCode.DuplicateFeeSchedule, "FeeSchedule for this  name already exist!");
            this.AddErrorCode(EnumErrorCode.DuplicateFSDiscount, "InsuranceCompany, Provider and Effective Date should be unique!");
            this.AddErrorCode(EnumErrorCode.DuplicateFSCharge, "Modifier and CPTCode should be unique!");
            this.AddErrorCode(EnumErrorCode.ChargeRejectionPIN, "Please enter correct PIN");

            this.AddErrorCode(EnumErrorCode.CodeAlreadyExists, "Code already exists.");
            this.AddErrorCode(EnumErrorCode.CodeCannotBeNullOrEmpty, "Code cannot be null or empty");
            this.AddErrorCode(EnumErrorCode.DescriptionCannotBeNullOrEmpty, "Description cannot be null or empty");
            this.AddErrorCode(EnumErrorCode.DescriptionAlreadyExists, "Description already exists");

            this.AddErrorCode(EnumErrorCode.InsuranceComapnyIdMandatory, "Please select insurance company.");
            this.AddErrorCode(EnumErrorCode.PatientIdMandatory, "Please select patient or insurance company.");
            this.AddErrorCode(EnumErrorCode.PaymentBatchIdMandatory, "Please select  payment batch Id company.");
            this.AddErrorCode(EnumErrorCode.PatientDoesNotHaveInsurance, "Patient does not have insurance policy");

            this.AddErrorCode(EnumErrorCode.DiagnosisCodeAlreadyUsedForThisCPT, "Diagnosis Code Already Used for this  CPT");
            this.AddErrorCode(EnumErrorCode.PrimaryDiagnosisCodeIsMandatory, "Primary Diagnosis Code Is Mandatory");
            this.AddErrorCode(EnumErrorCode.ModifierShouldBeUniqueForSameCPTCodes, "Modifier should be unique for same CPT Codes");
            this.AddErrorCode(EnumErrorCode.ModifierAlreadyExistForThisCPT, "Modifier already exist for this  CPT");
            this.AddErrorCode(EnumErrorCode.AccessionNumberUnique, "Accession Number already exist");
            this.AddErrorCode(EnumErrorCode.NoDeletionOfPaymentBatch, "You cannot delete this  payment batch because it contains multiple deposit's data.");
            this.AddErrorCode(EnumErrorCode.NoDeletionOfChargeBatch, "You cannot delete this  charge batch because it contains multiple invoices data.");

            this.AddErrorCode(EnumErrorCode.ClaimAlreadyExist, "Claim already exists.");
            this.AddErrorCode(EnumErrorCode.ClaimCannotBeDeleted, "Claim can not be deleted as the claim has been sent.");

            this.AddErrorCode(EnumErrorCode.ClaimCreatedforCharge, "This charge already included in claim. And has already been sent to clearing house with batch = {0}. so, if you want to save this then first delete claim and then try.");
            this.AddErrorCode(EnumErrorCode.ClaimforCharge, "This charge already included in claim. so, if you want to save this then first delete claim and then try.");
            this.AddErrorCode(EnumErrorCode.ClaimforChargeDelete, "This charge already included in claim. so, if you want to delete this then first delete claim and then try.");
            this.AddErrorCode(EnumErrorCode.FeeScheduleNotExist, "FeeSchedule does not exist!");
            this.AddErrorCode(EnumErrorCode.FeeDiscountEffectiveDate, "Fee Discount should be in the Date range of Fee Schedule. ");
            this.AddErrorCode(EnumErrorCode.EffectiveAndExpiryDate, $"FeeSchedule exist in this  Effective and Expiry Date Range. Active FeeSchedule is -");
            this.AddErrorCode(EnumErrorCode.ExpiryDateLessThanEffectiveDate, "Expiry Date can not be less than Effective Date. ");
            this.AddErrorCode(EnumErrorCode.FeeDiscountAmountValidation, "Discount on any CPT cannot be more than it's charge. ");
            this.AddErrorCode(EnumErrorCode.HoldCommentRequired, "Hold comment is required. ");
            this.AddErrorCode(EnumErrorCode.ChargeIsInUse, "This Charge is used for payment, So can't delete");
            this.AddErrorCode(EnumErrorCode.PatientCannotBeDeleted, "Patient can not be deleted");
            this.AddErrorCode(EnumErrorCode.ChargeNoNotExists, "Charge with charge number - {0} doesn't exists.");
            this.AddErrorCode(EnumErrorCode.VoucherNotExists, "Voucher with Unique Id - {0} doesn't exists.");
            this.AddErrorCode(EnumErrorCode.PaymentBatchNotExists, "PaymentBatch doesn't exists. please make a payment batch.");
            this.AddErrorCode(EnumErrorCode.DiagnosisCodeDuplicate, "Duplicate Diagnosis code not allowed!");
            this.AddErrorCode(EnumErrorCode.ChargeExist, "Patient can not be deleted as charge exists on the patient");
            this.AddErrorCode(EnumErrorCode.VoucherExist, "Patient can not be deleted as voucher exists on the patient");
            this.AddErrorCode(EnumErrorCode.PaymentExist, "Patient can not be deleted as payment exists on the patient");
            this.AddErrorCode(EnumErrorCode.FsDisocuntExists, "Insurance Company can not be deleted as Fee schedule disocunt exists on it.");
            this.AddErrorCode(EnumErrorCode.VoucherExists, "Insurance Company can not be deleted as voucher exists on it.");
            this.AddErrorCode(EnumErrorCode.VoucherExistsCheckNo, "deposit already exists with check number {0}.");
            this.AddErrorCode(EnumErrorCode.PaymentExistsWithThisCharge, "payment exists with this charge. if you want to make gcode then first delete payment then try.");
            

        }

        public void AddErrorCode(EnumErrorCode errorCode, string message)
        {
            base.AddErrorCode((int)errorCode, message);
        }

        public KeyValuePair<int, string> this[EnumErrorCode errorCode, params object[] formatter]
        {
            get
            {
                return base[(int)errorCode, formatter];
            }
        }
    }
}
