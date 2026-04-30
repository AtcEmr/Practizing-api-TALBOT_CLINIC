using System;
using System.Collections.Generic;

namespace PractiZing.Base.Entities.MasterService
{
    public interface ICPTCode : IUniqueIdentifier, IPracticeDTO, IStamp, IActive
    {
        int ID { get; set; }
        byte VisitType { get; set; }
        string CPTCode { get; set; }
        string Description { get; set; }
        bool IsCommon { get; set; }
        bool Ultrasound { get; set; }
        Int16? DefaultQuantity { get; set; }
        string SNOMEDCT { get; set; }
        Int16? CPTCategoryId { get; set; }
        string DefaultPOSId { get; set; }
        string DefaultTOSId { get; set; }
        bool IsTaxable { get; set; }
        bool BillToInsurance { get; set; }
        bool IsQtyUnits { get; set; }
        string OffCode { get; set; }
        DateTime? InactiveDate { get; set; }
        bool IsCostOfGoods { get; set; }
        string Color { get; set; }
        int? DrugClassId { get; set; }
        bool IsCPTAddToFavourite { get; set; }
        string DrugCode { get; set; }
        string CategoryName { get; set; }
        string NDCCode { get; set; }
        Guid CPTCategoryUId { get; set; }
        bool IsSameAsDefault { get; set; }
        string DefaultModifier { get; set; }
        string GTModPOS { get; set; }
        List<string>GTModPOSList { get; set; }
        bool? IsForMentalAct { get; set; }
        decimal? COGs { get; set; }

    }
}
