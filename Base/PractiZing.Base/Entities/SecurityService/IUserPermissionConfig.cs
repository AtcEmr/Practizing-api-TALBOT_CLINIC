using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.SecurityService
{
    public interface IUserPermissionConfig
    {
        string RoleOrUser { get; set; }
        bool IsRole { get; set; }
        string ModifiedBy { get; set; }
        DateTime ModifiedDate { get; set; }
        bool? SendCharges { get; set; }
        bool? PostPayment { get; set; }
        bool? ModifyPayment { get; set; }
        bool? DeletePayment { get; set; }
        bool? PostAdjustment { get; set; }
        bool? ModifyAdjustment { get; set; }
        bool? DeleteAdjustment { get; set; }
        bool? AddTemplate { get; set; }
        bool? ModifyTemplate { get; set; }
        bool? DeleteTemplate { get; set; }
        bool? AddContract { get; set; }
        bool? ModifyContract { get; set; }
        bool? DeleteContract { get; set; }
        bool? AddContractPayment { get; set; }
        bool? ModifyContractPayment { get; set; }
        bool? DeleteContractPayment { get; set; }
        bool? MarkContractPaidInFull { get; set; }
        bool? ModifyUnsignedPlanOfCare { get; set; }
        bool? ModifyBlockSchedulingAppointments { get; set; }
        bool? PostCharge { get; set; }
    }
}
