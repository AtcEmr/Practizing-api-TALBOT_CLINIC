using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Model
{
    public class HCFA
    {
        public enum Box11Values
        {
            GroupID,
            None ,
            OtherGroupID,
            OtherInsuranceID
        }

        public enum Box9aValues
        {
            GroupNumber = 0,
            InsuredID = 1,
            PrimaryInsured = 2,
            Medigap = 3
        }

        public enum Box4And7Values
        {
            FullNameAndAddress,
            SameForName,
            SameForNameAndAddress,
            Blank
        }

        public enum Box17OverValues
        {
            None =0,
            CaseDoctor =1 ,
            BillingDoctor =2,
            PerformingDoctor=3
        }


        public enum Box33Values
        {
            Clinic,
            Doctor,
            Both
        }

        public enum Box29AmtPaidValues
        {
            Blank,
            Zero,
            PriorInsurancePayments,
            InsurancePayments,
            PriorInsurPtPayments,
            InsurPtPayments,
            PatientPayments
        }

        public enum SplitClaimsBy
        {
            None,
            CptKind,
            Coverage
        }



        public int CarrierNumber { get; set; }

        public int CarrierTypeID { get; set; }

        public int CurrentHCFA_1FormType { get; set; }

        public string Reserved10 { get; set; }

        public int FacilityNum { get; set; }

        public string FacilityIDTypeName { get; set; }

        public string Place { get; set; }

        public string Type { get; set; }

        public short ClaimType { get; set; }

        public string FilingCode { get; set; }

        public string InsuranceType { get; set; }

        public string Medicare2 { get; set; }

        public bool USECSDOC { get; set; }

        public bool IsSsn { get; set; }

        public short PIN { get; set; }

        public short GRP { get; set; }

        public int FedTaxID { get; set; }

        public int PlanNumber { get; set; }

        public bool Box1ABlank { get; set; }

        public bool MedicareSecondaryPayer { get; set; }

        public Box11Values Box11 { get; set; }

        public bool Blank11abc { get; set; }

        public bool Blank9abcd { get; set; }

        public bool Box11cPayerID { get; set; }

        public Box9aValues Box9a { get; set; }

        public string Box9aPrefix { get; set; }

        public Box4And7Values Box4And7 { get; set; }

        public bool IndividualID { get; set; }

        public bool NumberOnly { get; set; }

        public short Box24 { get; set; }

        public bool NoRend { get; set; }

        public bool Box31Clinic { get; set; }

        public bool HipaaRendering { get; set; }

        public bool TransmitSecondary { get; set; }

        public bool Box14 { get; set; }

        public bool NpiAlways { get; set; }

        public bool NoRefId { get; set; }

        public bool GroupNPI { get; set; }

        public bool Box33bSpace { get; set; }

        public bool Auth { get; set; }

        public int Box17Over { get; set; }

        /// <summary>
        ///     ''' Use case provider
        ///     ''' </summary>
        public bool OverrideBox17 { get; set; }

        public string EraPayment { get; set; }

        public DateTime ModifiedDate { get; set; }

        public bool XRays { get; set; }

        public string Modifier { get; set; }

        public bool BlankBalance { get; set; }

        public bool NA15_20 { get; set; }

        public bool NASecondary { get; set; }

        public bool Year2Digit { get; set; }

        public short Box23 { get; set; }

        public bool AcceptAssignment { get; set; }

        public bool SignatureOnFile { get; set; }

        public short Res10Provider { get; set; }

        public bool Box9Same { get; set; }

        public bool MedigapOnly { get; set; }

        public bool Box11dBlank { get; set; }

        public int AmountPaid { get; set; }

        public bool Box9cAddress { get; set; }

        public bool Box9dPayorID { get; set; }

        public bool ExcludeAdjustments { get; set; }

        public bool LabOnly { get; set; }

        public bool CombineDiagnoses { get; set; }

        public int RenderingProvider { get; set; }

        public int BillingProvider { get; set; }

        public string TypeBill { get; set; }

        public int ProvRep { get; set; }

        public int AttendingPhys { get; set; }

        public int PhysID { get; set; }

        public int AdmitDate { get; set; }

        public int PayerName { get; set; }

        public bool Medicaid { get; set; }

        public int SplitBy { get; set; }

        public bool ShowCptDescription { get; set; }

        public bool HideDecimalPoint { get; set; }

        public bool EoB { get; set; }

        public int Box33 { get; set; }



        //internal HCFA_1(int carrierNumber, int carrierTypeId)
        //{
        //    this.CarrierNumber = carrierNumber;
        //    this.CarrierTypeID = carrierTypeId;
        //}

    }
}
