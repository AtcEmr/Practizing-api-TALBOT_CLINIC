using PractiZing.Base.Entities.SecurityService;
using PractiZing.DataAccess.SecurityService.Tables;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.SecurityService.View
{
    [Alias("PZ_User")]
    public class LoginView : ILoginUser
    {

        public LoginView()
        {
            this.RoleIds = new List<int>();
            this.UserPermissions = new List<UserPermission>();
        }

        public int Id { get; set; }
        public Guid UId { get; set; }
        public int PracticeId { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int PositionId { get; set; }
        public bool Active { get; set; }
        public string UserPassword { get; set; }
        public bool CanBill { get; set; }
        public int? DefaultBillFacilityId { get; set; }
        public int? DefaultPrefFacilityId { get; set; }
        public bool? IsClinicUser { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsAdmin { get; set; }
        [Ignore]
        public IEnumerable<int> RoleIds { get; set; }
        [Ignore]
        public IEnumerable<IUserPermission> UserPermissions { get; set; }
        [Ignore]
        public string PracticeName { get; set; }

        [Ignore]
        public string PracticeCode { get; set; }
        [Ignore]
        public string EMRURL { get; set; }

        [Ignore]
        public string EMRPassword { get; set; }

        [Ignore]
        public string EMRUserName { get; set; }

        [Ignore]
        public string LogoName { get; set; }
        [Ignore]
        public string EMRChargeGetApi { get; set; }
        [Ignore]
        public string EMRChargeUpdateApi { get; set; }

        [Ignore]
        public bool IsMentalACT { get; set; }

        [Ignore]
        public string FavIcon { get; set; }

        [Ignore]
       public string OnlinePaymentURL { get; set; }

        [Ignore]
        public string Position { get; set; }
        [Ignore]
        public bool IsRequiredInsuranceAddEdit { get; set; }
    }
}
