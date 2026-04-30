using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    [Alias("CPTCode")]
    public class CPTCodes : ICPTCode
    {       

        [Key]
        [AutoIncrement]
        public int ID { get; set; }
        public byte VisitType { get; set; }

        public Guid UId { get; set; }
        public int PracticeId { get; set; }

        [MaxLength(10, ErrorMessage = "CPTCode - Must not enter more than 10 characters.")]
        public string CPTCode { get; set; }

        [MaxLength(255, ErrorMessage = "Description - Must not enter more than 255 characters.")]
        public string Description { get; set; }

        public short? CPTCategoryId { get; set; }
        public int? DrugClassId { get; set; }

        public bool IsCommon { get; set; }
        public bool Ultrasound { get; set; }
        public short? DefaultQuantity { get; set; }

        [MaxLength(20, ErrorMessage = "DefaultPOSId - Must not enter more than 20 characters.")]
        public string SNOMEDCT { get; set; }

        [MaxLength(2, ErrorMessage = "SNOMEDCT - Must not enter more than 2 characters.")]
        public string DefaultPOSId { get; set; }

        [MaxLength(2, ErrorMessage = "DefaultTOSId - Must not enter more than 2 characters.")]
        public string DefaultTOSId { get; set; }

        public bool IsTaxable { get; set; }
        public bool BillToInsurance { get; set; }
        public bool IsQtyUnits { get; set; }
        public bool IsCostOfGoods { get; set; }

        [MaxLength(8, ErrorMessage = "OffCode - Must not enter more than 8 characters.")]
        public string OffCode { get; set; }

        [MaxLength(50, ErrorMessage = "Color - Must not enter more than 50 characters.")]
        public string Color { get; set; }

        public DateTime? InactiveDate { get; set; }

        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsSameAsDefault { get; set; }
        public string DefaultModifier { get; set; }
        public string GTModPOS { get; set; }
        public bool? IsForMentalAct { get; set; }
        public decimal? COGs { get; set; }

        [Ignore]
        public List<string> GTModPOSList { get; set; }

        [Ignore]
        public bool IsCPTAddToFavourite { get; set; }

        [Ignore]
        public string DrugCode { get; set; }

        [Ignore]
        public string NDCCode { get; set; }

        [Ignore]
        public string CategoryName { get; set; }

        [Ignore]
        public Guid CPTCategoryUId { get; set; }
    }
}
