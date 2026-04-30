using PractiZing.Base.Entities.SecurityService;
using ServiceStack.DataAnnotations;
using System;
using System.Net.Mime;

namespace PractiZing.DataAccess.SecurityService
{
    [Alias("BL_UserPermissions_Config")]
    public class UserPermissionConfig : IUserPermissionConfig
    {
        public string RoleOrUser { get; set; }
        public bool IsRole { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? SendCharges { get; set; }
        public bool? PostPayment { get; set; }
        public bool? ModifyPayment { get; set; }
        public bool? DeletePayment { get; set; }
        public bool? PostAdjustment { get; set; }
        public bool? ModifyAdjustment { get; set; }
        public bool? DeleteAdjustment { get; set; }
        public bool? AddTemplate { get; set; }
        public bool? ModifyTemplate { get; set; }
        public bool? DeleteTemplate { get; set; }
        public bool? AddContract { get; set; }
        public bool? ModifyContract { get; set; }
        public bool? DeleteContract { get; set; }
        public bool? AddContractPayment { get; set; }
        public bool? ModifyContractPayment { get; set; }
        public bool? DeleteContractPayment { get; set; }
        public bool? MarkContractPaidInFull { get; set; }
        public bool? ModifyUnsignedPlanOfCare { get; set; }
        public bool? ModifyBlockSchedulingAppointments { get; set; }
        public bool? PostCharge { get; set; }
    }
}
