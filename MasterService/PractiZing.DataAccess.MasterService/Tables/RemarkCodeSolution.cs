using PractiZing.Base.Entities.MasterService;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class RemarkCodeSolution : IRemarkCodeSolution
    {
        [Key]
        public int Id { get; set; }
        public string RemarkCode { get; set; }
        public short StepNumber { get; set; }
        public string Solution { get; set; }        
    }
}
