using PractiZing.Base.Model.Master;
using System;

namespace PractiZing.DataAccess.MasterService.Models
{
    public class InsuranceCompaniesDTO : IInsuranceCompaniesDTO
    {
        public int Id { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress1 { get; set; }
        public string CompanyAddress2 { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyType { get; set; }
        public string CompanyState { get; set; }
        public string CompanyZip { get; set; }
        public string PhoneNumber { get; set; }
        public int InsuranceCompanyID { get; set; }
        public int? PMS_ID { get; set; }
        public string EXTERNAL_ID { get; set; }
        public bool Medigap { get; set; }
        // private Int16 _companyTypeId;
        //public Int16? CompanyTypeId
        //{
        //    get
        //    {
        //        return _companyTypeId;
        //    }
        //    set
        //    {
        //        _companyTypeId = (Int16)(value == null ? -1 : this.CompanyTypeId.Value);
        //    }
        //}
        public Int16? CompanyTypeId { get; set; }
        //private Int16 _formTypeId;
        public Int16? FormTypeId { get; set; }
        //{
        //    get
        //    {
        //        return _formTypeId;
        //    }
        //    set
        //    {
        //        _formTypeId = (Int16)(value == null ? -1 : this.FormTypeId.Value);
        //    }
        //}
        //  private Int16 _clearinghouseId;
        public Int16? ClearingHouseId { get; set; }
        //{
        //    get
        //    {
        //        return _clearinghouseId;
        //    }
        //    set
        //    {
        //        _clearinghouseId = (Int16)(value == null ? -1 : this.ClearingHouseId.Value);
        //    }
        //}
        //private bool _transmitClaims;
        public bool? TransmitClaims { get; set; }
        //{
        //    get
        //    {
        //        return _transmitClaims;
        //    }
        //    set
        //    {
        //        _transmitClaims = value == null ? false : this.TransmitClaims.Value;
        //    }
        //}
        public string InsuranceCompanyTypeName { get; set; }


        public int PracticeId { get; set; }
        public Guid UId { get; set; }
    }
}
