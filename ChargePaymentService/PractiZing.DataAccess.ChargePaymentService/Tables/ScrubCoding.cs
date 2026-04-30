using PractiZing.Base.Entities.ChargePaymentService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Tables
{
    public class ScrubCoding : IScrubCoding
    {
        [Key]
        [AutoIncrement]
        public int ScrubResultId { get; set; }

        public short FacilityId { get; set; }
        public string ClinicCode { get; set; }
        public int PatientCaseId { get; set; }
        public int ChargeNumber { get; set; }
        public int ScrubId { get; set; }
        public string Message { get; set; }
        public DateTime ActionDate { get; set; }
        [Ignore]
        public short ScrubStatus { get; set; }
    }
}
