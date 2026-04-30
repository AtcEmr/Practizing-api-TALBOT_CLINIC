using PractiZing.Base.Entities.MasterService;
using System;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class CategoryDDO : ICategoryDDO
    {
        public short Id { get; set; }
        public string CategoryName { get; set; }
        public Guid UId { get; set; }
    }
}
