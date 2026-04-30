using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.SecurityService
{
    public interface ILoginUser: IUniqueIdentifier, IPracticeDTO, IStamp
    {
        int Id { get; set; }       
        string UserName { get; set; }
        string LastName { get; set; }
        string FirstName { get; set; }
        int PositionId { get; set; }
        bool Active { get; set; }
        string UserPassword { get; set; }
        bool CanBill { get; set; }
        int? DefaultBillFacilityId { get; set; }
        int? DefaultPrefFacilityId { get; set; }
        bool? IsClinicUser { get; set; }
        IEnumerable<int> RoleIds { get; set; }
        IEnumerable<IUserPermission> UserPermissions { get; set; }
        string PracticeName { get; set; }
        string PracticeCode { get; set; }
        string EMRURL { get; set; }
        string EMRChargeGetApi { get; set; }
        string EMRChargeUpdateApi { get; set; }
        string EMRUserName { get; set; }
        string EMRPassword { get; set; }
        string LogoName { get; set; }
        bool IsMentalACT { get; set; }
        string FavIcon { get; set; }
        string OnlinePaymentURL { get; set; }
        bool IsAdmin { get; set; }
        string Position { get; set; }
        bool IsRequiredInsuranceAddEdit { get; set; }
    }
}
