using Microsoft.AspNetCore.Http;
using PractiZing.Base.Entities.SecurityService;
using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace PractiZing.Api.Common.Identity
{
    public partial class IdentityUser : ILoginUser
    {
        private static IHttpContextAccessor _httpContextAccessor;
        public IdentityUser(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor != null
                && httpContextAccessor.HttpContext != null
                && httpContextAccessor.HttpContext.User != null
                && httpContextAccessor.HttpContext.User.Identity != null
                )
            {
                var identity = (httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity);
                var idClaim = identity.Claims.FirstOrDefault(i => i.Type == "Id");
                if (identity != null && idClaim != null)
                {
                    this.SetIdentiyFromClaims(identity);
                }
                _httpContextAccessor = httpContextAccessor;
            }
        }
        public string EMRURL { get; set; }
        public string EMRPassword { get; set; }
        public string EMRUserName { get; set; }
        public string EMRChargeGetApi { get; set; }
        public bool IsMentalACT { get; set; }
        public string FavIcon { get; set; }
        public string EMRChargeUpdateApi { get; set; }
        public int Id { get; set; }
        public Guid UId { get; set; }
        public int PracticeId { get; set; }
        public string UserName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int PositionId { get; set; }
        public bool Active { get; set; }
        public string UserPassword { get; set; }
        public bool CanBill { get; set; }
        public int? DefaultBillFacilityId { get; set; }
        public int? DefaultPrefFacilityId { get; set; }
        public bool? IsClinicUser { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsRequiredInsuranceAddEdit { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsAdmin { get; set; }
        [Ignore]
        public string PracticeName { get; set; }
        [Ignore]
        public IEnumerable<int> RoleIds { get; set; }
        [Ignore]
        public IEnumerable<IUserPermission> UserPermissions { get; set; }
        [Ignore]
        public string LogoName { get; set; }
        [Ignore]
        public string OnlinePaymentURL { get; set; }
        [Ignore]
        public string Position { get; set; }
        
        public Claim GetUserPermissionClaim()
        {
            var identity = (_httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity);
            var permissionClaim = identity.Claims.FirstOrDefault(i => i.Type == "UserPermissions");
            return permissionClaim;
        }

        [Ignore]
        public string PracticeCode { get; set; }

        public void SetIdentiyFromClaims(ClaimsIdentity identity)
        {
            this.Id = Int32.Parse(identity.Claims.FirstOrDefault(i => i.Type == "Id").Value);
            this.FirstName = identity.Claims.FirstOrDefault(i => i.Type == "FirstName").Value;
            this.UserName = identity.Claims.FirstOrDefault(i => i.Type == "UserName").Value;
            this.LastName = identity.Claims.FirstOrDefault(i => i.Type == "LastName").Value;
            this.PracticeId = Int32.Parse(identity.Claims.FirstOrDefault(i => i.Type == "PracticeId").Value);
            this.PositionId = Char.Parse(identity.Claims.FirstOrDefault(i => i.Type == "PositionId").Value);
            this.Active = Boolean.Parse(identity.Claims.FirstOrDefault(i => i.Type == "Active").Value);
            this.DefaultBillFacilityId = Int32.Parse(identity.Claims.FirstOrDefault(i => i.Type == "DefaultBillFacilityId").Value);
            this.DefaultPrefFacilityId = Int32.Parse(identity.Claims.FirstOrDefault(i => i.Type == "DefaultPrefFacilityId").Value);
            this.CanBill = Boolean.Parse(identity.Claims.FirstOrDefault(i => i.Type == "CanBill").Value);
            this.IsClinicUser = Boolean.Parse(identity.Claims.FirstOrDefault(i => i.Type == "IsClinicUser").Value);
            this.PracticeName = identity.Claims.FirstOrDefault(i => i.Type == "PracticeName").Value;
            //var permissions = identity.Claims.FirstOrDefault(i => i.Type == "UserPermissions").Value;
            //this.UserPermissions = JsonConvert.DeserializeObject<dynamic[]>(permissions);
            this.PracticeCode = identity.Claims.FirstOrDefault(i => i.Type == "PracticeCode").Value;
            var roles = identity.Claims.Where(i => i.Type == ClaimTypes.Role).ToList().Select(i => i.Value);
            this.EMRURL = identity.Claims.FirstOrDefault(i => i.Type == "EMRURL").Value;
            this.EMRChargeGetApi = identity.Claims.FirstOrDefault(i => i.Type == "EMRChargeGetApi").Value;
            this.EMRChargeUpdateApi = identity.Claims.FirstOrDefault(i => i.Type == "EMRChargeUpdateApi").Value;
            this.EMRUserName = identity.Claims.FirstOrDefault(i => i.Type == "EMRUserName").Value;
            this.EMRPassword = identity.Claims.FirstOrDefault(i => i.Type == "EMRPassword").Value;
            this.LogoName = identity.Claims.FirstOrDefault(i => i.Type == "LogoName").Value;
            this.IsMentalACT = Boolean.Parse(identity.Claims.FirstOrDefault(i => i.Type == "IsMentalACT").Value);
            this.FavIcon = identity.Claims.FirstOrDefault(i => i.Type == "FavIcon").Value;
            this.OnlinePaymentURL = identity.Claims.FirstOrDefault(i => i.Type == "OnlinePaymentURL").Value;
            this.Position = identity.Claims.FirstOrDefault(i => i.Type == "Position").Value;
            this.IsAdmin = Boolean.Parse(identity.Claims.FirstOrDefault(i => i.Type == "IsAdmin").Value);
            this.IsRequiredInsuranceAddEdit = Boolean.Parse(identity.Claims.FirstOrDefault(i => i.Type == "IsRequiredInsuranceAddEdit").Value);

            //this.UserRoleId = roles.Select(int.Parse).ToList();
        }
    }
}
