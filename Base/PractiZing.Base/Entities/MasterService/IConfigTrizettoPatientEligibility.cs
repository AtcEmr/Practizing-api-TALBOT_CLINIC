using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Entities.MasterService
{
    public interface IConfigTrizettoPatientEligibility
    {
        int Id { get; set; }
        Guid UId { get; set; }
        string ISA01AuthQual { get; set; }
        string ISA02AuthInfo { get; set; }
        string ISA03SecQual { get; set; }
        string ISA04SecInfo { get; set; }
        string ISA06SenderId { get; set; }
        string ISA08ReceiverId { get; set; }
        string ISA15UsageIndi { get; set; }
        string GS02SenderId { get; set; }
        string GS03ReceiverId { get; set; }
        string SubmitterEntity { get; set; }
        string SubmitterOrgName { get; set; }
        string SubmitterQual { get; set; }
        string SubmitterNM141Id { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        long ISA13CntrlNumber { get; set; }
        long TRN01 { get; set; }
        string CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        string ModifiedBy { get; set; }
        DateTime? ModifiedDate { get; set; }
    }
}
