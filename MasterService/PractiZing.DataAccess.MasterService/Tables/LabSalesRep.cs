using PractiZing.Base.Entities.MasterService;
using System;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class LabSalesRep : ILabSalesRep
    {
        public int Id { get; set; }
        public Guid UId { get; set; }
        public int PracticeId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
