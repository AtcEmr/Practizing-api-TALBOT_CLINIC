using Newtonsoft.Json;
using PractiZing.Base.Entities.SecurityService;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace PractiZing.Api.Common.Identity
{
    public class PractiZingPrincipal : ClaimsPrincipal
    {
        public PractiZingPrincipal(PractiZingIdentity identity) : base()
        {
            this._identity = identity;
            identity.Principal = this;
            this.AddIdentity(identity);

        }

        private IIdentity _identity;
        public override IIdentity Identity
        {
            get
            {
                return _identity;
            }
        }

    }

    public class PractiZingIdentity : ClaimsIdentity
    {
        public PractiZingIdentity(IIdentity identity,
            IEnumerable<Claim> claims,
            string authenticationType,
            string nameType,
            string roleType,
             ILoginUser user = null) : base(identity, claims, authenticationType, nameType, roleType)
        {
            if (user != null)
            {
                this.User = user;
                this.AddClaim(new Claim("Id", user.Id.ToString()));
                this.AddClaim(new Claim("UserName", user.UserName.ToString()));
                this.AddClaim(new Claim("PracticeId", user.PracticeId.ToString()));
                this.AddClaim(new Claim("FirstName", user.FirstName.ToString()));
                this.AddClaim(new Claim("LastName", user.LastName.ToString()));
                this.AddClaim(new Claim("PositionId", user.PositionId.ToString()));
                this.AddClaim(new Claim("Active", user.Active.ToString()));
                this.AddClaim(new Claim("CanBill", user.CanBill.ToString()));
                this.AddClaim(new Claim("DefaultBillFacilityId", user.DefaultBillFacilityId == null ? "0" : user.DefaultBillFacilityId.ToString()));
                this.AddClaim(new Claim("DefaultPrefFacilityId", user.DefaultPrefFacilityId == null ? "0" : user.DefaultPrefFacilityId.ToString()));
                this.AddClaim(new Claim("IsClinicUser", user.IsClinicUser == null ? "false" : user.IsClinicUser.ToString()));               
                this.AddClaim(new Claim("PracticeName", user.PracticeName.ToString()));
                this.AddClaim(new Claim("UserPermissions", JsonConvert.SerializeObject(user.UserPermissions)));
                this.AddClaim(new Claim("PracticeCode", user.PracticeCode.ToString()));
                this.AddClaim(new Claim("EMRURL", string.IsNullOrWhiteSpace(user.EMRURL)?"":user.EMRURL.ToString()));
                this.AddClaim(new Claim("EMRChargeGetApi", string.IsNullOrWhiteSpace(user.EMRChargeGetApi) ? "" : user.EMRChargeGetApi.ToString()));
                this.AddClaim(new Claim("EMRChargeUpdateApi", string.IsNullOrWhiteSpace(user.EMRChargeUpdateApi) ? "" : user.EMRChargeUpdateApi.ToString()));
                this.AddClaim(new Claim("EMRPassword", string.IsNullOrWhiteSpace(user.EMRPassword) ? "" : user.EMRPassword.ToString()));
                this.AddClaim(new Claim("EMRUserName", string.IsNullOrWhiteSpace(user.EMRUserName) ? "" : user.EMRUserName.ToString()));
                this.AddClaim(new Claim("LogoName", string.IsNullOrWhiteSpace(user.LogoName) ? "" : user.LogoName.ToString()));
                this.AddClaim(new Claim("IsMentalACT",  user.IsMentalACT.ToString()));
                this.AddClaim(new Claim("FavIcon", user.FavIcon.ToString()));
                this.AddClaim(new Claim("OnlinePaymentURL", user.OnlinePaymentURL.ToString()));
                this.AddClaim(new Claim("IsAdmin", user.IsAdmin.ToString()));
                this.AddClaim(new Claim("Position", user.Position.ToString()));
                this.AddClaim(new Claim("IsRequiredInsuranceAddEdit", user.IsRequiredInsuranceAddEdit.ToString()));


            }
        }
        public PractiZingPrincipal Principal { get; set; }


        private ILoginUser _user;

        public ILoginUser User
        {
            get { return _user; }
            set { _user = value; }
        }



        public static PractiZingIdentity ToIdentity(ClaimsIdentity identity)
        {
            PractiZingIdentity myIdentity = new PractiZingIdentity(identity, identity.Claims, identity.AuthenticationType, identity.NameClaimType, identity.RoleClaimType);

            return myIdentity;

        }
    }


}
