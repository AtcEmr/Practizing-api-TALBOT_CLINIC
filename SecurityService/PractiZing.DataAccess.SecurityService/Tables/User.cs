using PractiZing.Base.Entities.SecurityService;
using PractiZing.DataAccess.SecurityService.Tables;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.SecurityService
{
    [Alias("PZ_User")]
    public class User : IUser
    {

        public User()
        {
            this.RoleIds = new List<int>();
            this.UserPermissions = new List<UserPermission>();
        }
        [Key]
        [AutoIncrement]
        public Int16 Id { get; set; }
        public Guid UId { get; set; }
        public int PracticeId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(15, ErrorMessage = "UserName - Must not enter more than 15 characters.")]
        public string UserName { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(30, ErrorMessage = "LastName - Must not enter more than 30 characters.")]
        public string LastName { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [MaxLength(30, ErrorMessage = "FirstName - Must not enter more than 30 characters.")]
        public string FirstName { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public Int16 PositionId { get; set; }
        public bool Active { get; set; }

        public byte[] UserPassword { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public bool CanBill { get; set; }
        public bool? IsClinicUser { get; set; }
        public bool? IsHide { get; set; }

        public int? DefaultBillFacilityId { get; set; }
        public int? DefaultPrefFacilityId { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string PIN { get; set; }
        public bool IsAdmin { get; set; }
        [Ignore]
        public string Password { get; set; }

        [Ignore]
        public IEnumerable<int> RoleIds { get; set; }
        [Ignore]
        public IEnumerable<IUserPermission> UserPermissions { get; set; }
        [Ignore]
        public string PositionName { get; set; }

        [Ignore]
        public string BillFacility { get; set; }

        [Ignore]
        public string PerfFacility { get; set; }

        [Ignore]
        public string PracticeName { get; set; }
        [Ignore]
        public Guid? DefaultBillFacilityUId { get; set; }
        [Ignore]
        public Guid? DefaultPrefFacilityUId { get; set; }

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
