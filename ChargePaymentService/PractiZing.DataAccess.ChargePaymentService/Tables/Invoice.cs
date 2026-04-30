using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.DataAccess.Common;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class Invoice : IInvoice
    {
        public Invoice()
        {
            this.ChargeList = new List<Charges>();
            this.InvDiagnosisLst = new List<InvDiagnosis>();
        }

        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public int PracticeId { get; set; }
        public Guid UId { get; set; }

        public int PatientCaseId { get; set; }
        public int? ChargeBatchId { get; set; }

        [MaxLength(50, ErrorMessage = "AccessionNumber - Must not enter more than 50 characters.")]
        public string AccessionNumber { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public DateTime EntryDate { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public DateTime BillFromDate { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public DateTime BillToDate { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public short? BillProviderId { get; set; }
        public short? SupervisingProviderId { get; set; }
        public short? OrderringProviderId { get; set; }
        public short? AuxillaryProviderId { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public short? BillFacilityId { get; set; }
        public short? FacilityId { get; set; }

        public short? PerformingProviderId { get; set; }

        [Ignore]
        public string SupervisingProviderNPI { get; set; }


        public int? ClaimId { get; set; }

        public short? PatientGender { get; set; }

        public short? MartialStatus { get; set; }

        public short? EmployementStatus { get; set; }

        public DateTime? DateOfSign { get; set; }
        public DateTime? IllnessDate { get; set; }
        public DateTime? IllnessSimDate { get; set; }

        public short? RefDoctorId { get; set; }
        public decimal? FeeAmount { get; set; }

        public DateTime? DisabilityFrom { get; set; }
        public DateTime? DisabilityTo { get; set; }
        public DateTime? HospitalizedFrom { get; set; }
        public DateTime? HospitalizedTo { get; set; }

        public int? AuthorizationNumberId { get; set; }
        public int? LabSalesRepID { get; set; }

        public bool AccEmploy { get; set; }
        public bool AccAuto { get; set; }
        public bool AccOther { get; set; }

        public bool? ReviewNeeded { get; set; }
        
        public string ReviewComments { get; set; }
        public string NonBillableComments { get; set; }

        [MaxLength(50, ErrorMessage = "AccState - Must not enter more than 50 characters.")]
        public string AccState { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
        public int? ServiceCircumstanceId { get; set; }
        public bool IsAROldCharges { get; set; }
        public int? InvoiceType { get; set; }
        public bool? IsBillable { get; set; }
        public string BillableCoupon { get; set; }
        public string InternalMessage { get; set; }
        public bool? IsRejected { get; set; }
        public string RejectedPIN { get; set; }
        public bool? IspmgEncounter { get; set; }
        public string OtherPlaceOfService { get; set; }

        [Ignore]
        public IEnumerable<ICharges> ChargeList { get; set; }

        [Ignore]
        public IEnumerable<IInvDiagnosis> InvDiagnosisLst { get; set; }

        [Ignore]
        public decimal? TotalCharges { get; set; }
        [Ignore]
        public decimal? TotalPaid { get; set; }
        [Ignore]
        public decimal? TotalAdjustment { get; set; }
        [Ignore]
        public decimal? TotalDue { get; set; }
        [Ignore]
        public decimal? TotalDiscount { get; set; }

        [Ignore]
        public int InvoiceId
        {
            get { return Id; }
            set { Id = value; }
        }

        [Ignore]
        public Guid InvoiceUId
        {
            get { return UId; }
            set { UId = value; }
        }

        [Ignore]
        public decimal? InsuranceBalance { get; set; }


        [Ignore]
        public decimal? PatientBalance { get; set; }

        [Ignore]
        public string BatchNo { get; set; }

        [Ignore]
        public decimal? TotalPaymentAndAdjustment { get; set; }

        [Ignore]
        public bool IsCombinedGCode { get; set; }
        [Ignore]
        public string PatientName { get; set; }
        [Ignore]
        public string PatientNameBillingHistory { get { return $"{LastName} {FirstName}"; } }
        [Ignore]
        public string FirstName { get; set; }
        [Ignore]
        public string LastName { get; set; }
        [Ignore]
        public int Age { get; set; }
        [Ignore]
        public DateTime? DOB { get; set; }
        [Ignore]
        public string BillingID { get; set; }

        [Ignore]
        public Guid ClaimUId { get; set; }
        [Ignore]
        public Guid? BillProviderUId { get; set; }
        [Ignore]
        public Guid? SupervisingProviderUId { get; set; }
        [Ignore]
        public Guid? OrderringProviderUId { get; set; }
        [Ignore]
        public Guid? AuxillaryProviderUId { get; set; }
        [Ignore]
        public Guid? BillFacilityUId { get; set; }
        [Ignore]
        public Guid? FacilityUId { get; set; }
        [Ignore]
        public Guid? RefDoctorUId { get; set; }
        [Ignore]
        public Guid? AuthorizationNumberUId { get; set; }
        [Ignore]
        public Guid? LabSalesRepUID { get; set; }
        [Ignore]
        public Guid BillingUID { get; set; }
        [Ignore]
        public Guid PatientCaseUId { get; set; }
        [Ignore]
        public DateTime? SentDate { get; set; }
        [Ignore]
        public Guid ChargeBatchUId { get; set; }

        public DateTime? FromTime { get; set; }
        [Ignore]
        public Guid? PerformingProviderUId { get; set; }
        public DateTime? ToTime { get; set; }
        [Ignore]
        public string TimeDiff
        {
            get
            {

                if (ToTime.HasValue)
                    return ToTime.Value.Subtract(FromTime.Value).ToString(@"hh\:mm\:ss");
                else
                    return "";    
                
            }
        }   
        [Ignore]
        public string AuthorizationNumber { get; set; }

        [Ignore]
        public string EncounterTypeCode { get; set; }

        [Ignore]
        public List<string> InvoiceUIds { get; set; }

        [Ignore]
        public bool? IsFromHl7 { get; set; }

        [Ignore]
        public string PatientAccountNumber { get; set; }

        [Ignore]
        public string PrimaryPayerCode { get; set; }
    }
}
