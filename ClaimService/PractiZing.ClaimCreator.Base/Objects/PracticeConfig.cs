using PractiZing.Base.Entities.MasterService;
using PractiZing.DataAccess.MasterService.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.ClaimCreator.Base
{
    public class ClaimOptions
    {
        public PracticeConfig PracticeConfig { get; set; }
        public IClearingHouse ClearingHouse { get; set; }
        public DateTime TransactionDate { get; set; }
        public List<string> CptCodes { get; set; }
        public string ClaimBatchNumber { get; set; }
    }

    public class PracticeConfig
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public PracticeContact Contact { get; set; }

    }
}
