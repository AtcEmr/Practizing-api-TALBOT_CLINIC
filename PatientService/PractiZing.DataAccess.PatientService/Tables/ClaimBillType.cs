using PractiZing.Base.Entities;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.PatientService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.DataAccess.PatientService.Tables
{
    public class ClaimBillType : IClaimBillType, IEntity
    {
        [Key]
        [AutoIncrement]
        public int ID { get; set; }

        public string Code { get; set; }
        public string Description { get; set; }

       public bool IsActive { get; set; }

        [Ignore]
        public string KeyID { get; set; }
    }
}
