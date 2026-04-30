using System;

namespace PractiZing.Base.Entities.MasterService
{
    public interface INDC : IUniqueIdentifier, IPracticeDTO, IStamp, IActive
    {
        Int16 Code { get; set; }
        string NDCCode { get; set; }
        Int16? Format { get; set; }
        Int16? UoM { get; set; }
        decimal? DrugQty { get; set; }
        string Description { get; set; }
        string UoMDesc { get; set; }        
        string FormatDesc { get; set; }
        Guid CPTCodeUId { get; set; }
        string CptCode { get; set; }
    }
}
