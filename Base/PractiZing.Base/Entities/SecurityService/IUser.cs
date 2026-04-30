using System;
using System.Collections.Generic;

namespace PractiZing.Base.Entities.SecurityService
{
    public interface IUser : IUniqueIdentifier, IPracticeDTO, IStamp
    {
        Int16 Id { get; set; }

        string UserName { get; set; }
        string LastName { get; set; }
        string FirstName { get; set; }
        Int16 PositionId { get; set; }
        bool Active { get; set; }
        byte[] UserPassword { get; set; }
        bool CanBill { get; set; }
        int? DefaultBillFacilityId { get; set; }
        int? DefaultPrefFacilityId { get; set; }
        bool? IsClinicUser { get; set; }
        bool? IsHide { get; set; }
        string Password { get; set; }
        IEnumerable<int> RoleIds { get; set; }
        IEnumerable<IUserPermission> UserPermissions { get; set; }
        string PositionName { get; set; }
        string BillFacility { get; set; }
        string PerfFacility { get; set; }
        string PracticeName { get; set; }
        Guid? DefaultBillFacilityUId { get; set; }
        Guid? DefaultPrefFacilityUId { get; set; }


        string PracticeCode { get; set; }
        string EMRURL { get; set; }
        string EMRUserName { get; set; }
        string EMRPassword { get; set; }
        string LogoName { get; set; }
        string EMRChargeGetApi { get; set; }
        string EMRChargeUpdateApi { get; set; }
        bool IsMentalACT { get; set; }
        string FavIcon { get; set; }
        string OnlinePaymentURL { get; set; }
        bool IsAdmin { get; set; }
        string Position { get; set; }
        bool IsRequiredInsuranceAddEdit { get; set; }
        string PIN { get; set; }
    }
}
