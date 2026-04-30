using PractiZing.Base.Object.MasterServcie;
using PractiZing.DataAccess.Common;
using System;

namespace PractiZing.DataAccess.MasterService.Objects
{
    public class CPTCodeFilter : ICPTCodeFilter
    {
        [SearchField(Name = CPTCodeFilterModel.CPT)]
        public string CPT { get; set; }

        [SearchField(Name = CPTCodeFilterModel.Description)]
        public string Description { get; set; }

        [SearchField(Name = CPTCodeFilterModel.DefaultQuantity)]
        public Int16? DefaultQuantity { get; set; }

        [SearchField(Name = CPTCodeFilterModel.ToS)]
        public string ToS { get; set; }

        [SearchField(Name = CPTCodeFilterModel.RevCode)]
        public byte? RevCode { get; set; }

        [SearchField(Name = CPTCodeFilterModel.IsCPTCodeForClaim)]
        public bool? IsCPTCodeForClaim { get; set; }
    }

    public class CPTCodeFilterModel
    {
        public const string TableName = "CPTCode";
        public const string CPT = TableName + "." + "CPTCode";
        public const string Description = TableName + "." + "Description";
        public const string DefaultQuantity = TableName + "." + "DefaultQuantity";
        public const string ToS = TableName + "." + "ToS";
        public const string RevCode = TableName + "." + "RevCode";
        public const string IsCPTCodeForClaim = TableName + "." + "IsCPTCodeForClaim";
    }
}
