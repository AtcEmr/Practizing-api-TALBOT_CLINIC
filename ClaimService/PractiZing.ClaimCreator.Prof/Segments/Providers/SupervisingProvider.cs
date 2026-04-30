using EdiFabric.Templates.Hipaa5010;
using PractiZing.ClaimCreator.Base;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.ClaimCreator.Prof
{
    internal class SupervisingProviderBuilder: ISegmentBuilder<Loop_2310D_837P>
    {
        public Loop_2310D_837P Build(Claim claim, ClaimOptions claimOptions)
        {
            return new Loop_2310D_837P
            {
                NM1_SupervisingProviderName = new NM1_SupervisingProviderName
                {
                    EntityIdentifierCode_01 = X12_ID_98_12.DQ.X12(),
                    EntityTypeQualifier_02 = X12_ID_1065_3.Item1.X12(),
                    ResponseContactLastorOrganizationName_03 = claim.SupervisionDoctorLastName,
                    ResponseContactFirstName_04 = claim.SupervisionDoctorFirstName,
                    ResponseContactMiddleName_05= !string.IsNullOrWhiteSpace(claim.SupervisionDoctorMiddleName) ? claim.SupervisionDoctorMiddleName : "",
                    NamePrefix_06= !string.IsNullOrWhiteSpace(claim.SupervisionDoctorPrefix) ? claim.SupervisionDoctorPrefix : "",
                    ResponseContactNameSuffix_07= !string.IsNullOrWhiteSpace(claim.SupervisionDoctorSuffix) ? claim.SupervisionDoctorSuffix : "",
                    IdentificationCodeQualifier_08 = "XX",
                    ResponseContactIdentifier_09 = !string.IsNullOrWhiteSpace(claim.SupervisionDoctorNPI) ? claim.SupervisionDoctorNPI : ""
                }
            };
        }
    }
}
