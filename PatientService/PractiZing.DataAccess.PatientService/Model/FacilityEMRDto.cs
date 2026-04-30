using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Model.Master;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.PatientService.Model
{
    
    public class FacilityEMRDto: IFacilityEMRDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipCode { get; set; }
        public string phone { get; set; }
        public int? locationId { get; set; }
        public string facilityCode { get; set; }
        public string facilityDescription { get; set; }
        public string fax { get; set; }
        public string posCode { get; set; }
        public string locationCode { get; set; }
        public string npi { get; set; }
        public string sudnpi { get; set; }
        public string tin { get; set; }
        public string timeZone { get; set; }
        public string serviceTypeCode { get; set; }
        public int? pmFacilityId { get; set; }
        public string locality { get; set; }
        public int? feeScheduleCarrierNumber { get; set; }
        public int? feeLocalCarrNumId { get; set; }
        public bool isDefaultLocation { get; set; }
        public int? defaultProviderId { get; set; }
        public string limsCode { get; set; }
        public IFacilityidentity[] facilityIdentities { get; set; }        
    }

    public class Facilityidentity
    {
        public int id { get; set; }
        public int facilityId { get; set; }
        public int identityId { get; set; }
        public string value { get; set; }
        public DateTime activeDate { get; set; }
        public DateTime? inactiveDate { get; set; }
        public Identity identity { get; set; }
    }

    //public class PractitionerModifierDTO: IPractitionerModifierDTO
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public short CPTModifierId { get; set; }
    //    public string Description { get; set; }
    //    public bool? IsSupervisionRequired { get; set; }
    //    public bool? CanSuperviseOther { get; set; }
    //    public bool? CanAdminSuperviseOther { get; set; }
    //    public ICPTModifiersDTO CPTModifier { get; set; }
    //    public ICPTModifiersDTO SUDCPTModifier { get; set; }
    //}

    //public class CPTModifiersDTO: ICPTModifiersDTO
    //{
    //    public short Id { get; set; }
    //    public string Code { get; set; }
    //    public string Description { get; set; }
    //}
}
