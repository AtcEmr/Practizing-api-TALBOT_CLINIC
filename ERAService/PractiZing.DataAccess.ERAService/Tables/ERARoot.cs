using PractiZing.Base.Entities.ERAService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.ERAService.Tables
{
    public class ERARoot : IERARoot
    {
        public ERARoot()
        {
            this.Claims = new List<ERAClaim>();
        }

        [Key]
        [AutoIncrement]
        public long Id { get; set; }

        public string FileName { get; set; }

        public string InsuranceCompanyName { get; set; }

        public string InsuranceCompanyAddress1 { get; set; }

        public string InsuranceCompanyAddress2 { get; set; }

        public string InsuranceCompanyCity { get; set; }

        public string InsuranceCompanyState { get; set; }

        public string InsuranceCompanyZip { get; set; }

        public string FacililityName { get; set; }

        public string FacililityAddress1 { get; set; }

        public string FacililityAddress2 { get; set; }

        public string FacililityCity { get; set; }

        public string FacililityState { get; set; }

        public string FacililityZip { get; set; }

        public decimal EraPayment { get; set; }

        public string PaymentCreditDebitFlag { get; set; }

        public string PaymentMethod { get; set; }

        public string PaymentFormat { get; set; }

        public string CheckNumber { get; set; }

        public string PaymentEffectiveDate { get; set; }

        public int PracticeId { get; set; }

        public string ProiderName { get; set; }

        public string ProiderNPI { get; set; }

        public string ErrorLog { get; set; }
        
        public DateTime? CreateDate { get; set; }
        [Ignore]
        public IEnumerable<IERAClaim> Claims { get; set; }
        [Ignore]
        public int StatusId { get; set; }
        [Ignore]
        public string CreatedDate { get; set; }
    }
}
