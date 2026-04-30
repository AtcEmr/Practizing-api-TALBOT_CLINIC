using System;
using System.Collections.Generic;

namespace PractiZing.Base.Entities.ERAService
{
    public interface IERARoot
    {

        long Id { get; set; }

        string FileName { get; set; }

        string InsuranceCompanyName { get; set; }

        string InsuranceCompanyAddress1 { get; set; }

        string InsuranceCompanyAddress2 { get; set; }

        string InsuranceCompanyCity { get; set; }

        string InsuranceCompanyState { get; set; }

        string InsuranceCompanyZip { get; set; }

        string FacililityName { get; set; }

        string FacililityAddress1 { get; set; }

        string FacililityAddress2 { get; set; }

        string FacililityCity { get; set; }

        string FacililityState { get; set; }

        string FacililityZip { get; set; }

        decimal EraPayment { get; set; }

        string PaymentCreditDebitFlag { get; set; }

        string PaymentMethod { get; set; }

        string PaymentFormat { get; set; }

        string CheckNumber { get; set; }

        string PaymentEffectiveDate { get; set; }

        int PracticeId { get; set; }

        string ProiderName { get; set; }

        string ProiderNPI { get; set; }

        string ErrorLog { get; set; }

        DateTime? CreateDate { get; set; }

        IEnumerable<IERAClaim> Claims { get; set; }

        int StatusId { get; set; }

        string CreatedDate { get; set; }
    }
}
