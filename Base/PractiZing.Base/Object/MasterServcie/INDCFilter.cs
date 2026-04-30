using System;

namespace PractiZing.Base.Object.MasterServcie
{
    public interface INDCFilter
    {
        Int16? Code { get; set; }
        string NDCCode { get; set; }
        Int16? Format { get; set; }
        Int16? UoM { get; set; }
        decimal? DrugQty { get; set; }
        string Description { get; set; }
    }
}
