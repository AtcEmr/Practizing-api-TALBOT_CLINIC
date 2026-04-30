using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.QuickSight;
using Amazon.QuickSight.Model;
using Amazon.Runtime;
using Amazon.SecurityToken;
using Amazon.SecurityToken.Model;
using Microsoft.Extensions.Configuration;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Service.PatientService;

namespace PractiZing.BusinessLogic.PatientService.Services
{
    public class DashboardQuickStartService: IDashboardQuickStartService
    {
        IPracticeRepository _practiceRepository;
        public DashboardQuickStartService(IPracticeRepository practiceRepository)
        {
            this._practiceRepository = practiceRepository;
        }

        public async Task<string> GetUrl()
        {

            var practice = await this._practiceRepository.Get();

            string accessKey = practice.QuickSiteAccessKey;
            string secretKey = practice.QuickSiteSecretKey;
            string AwsAccountId = practice.QuickSiteAWSAccointId;

            string rolename = practice.QuickSiteRoleName;


            RegionEndpoint regionEndpoint=null;
            if (practice.QuickSiteRegionEndpoint == "USEast2")
                regionEndpoint = RegionEndpoint.USEast2;
            else if (practice.QuickSiteRegionEndpoint == "USEast1")
            {
                regionEndpoint = RegionEndpoint.USEast1;
            }


                var roleArnToAssume = $"arn:aws:iam::{AwsAccountId}:role/"+ rolename + "";
            var securityClient = new AmazonSecurityTokenServiceClient(accessKey, secretKey, regionEndpoint);
            var getCallerIdReq = new GetCallerIdentityRequest();
            var caller = await GetCallerIdentityResponseAsync(client: securityClient, request: getCallerIdReq);
            try
            {

                string roleSessionName = practice.QuickSiteRoleSessionName; //nikunj;


                var assumeRoleReq = new AssumeRoleRequest
                {
                    RoleArn = roleArnToAssume,
                    RoleSessionName = roleSessionName//"nikunj"
                };

                var assumeRoleRes = await
                    GetAssumeRoleResponseAsync(client: securityClient,
                    request: assumeRoleReq);

                string AccessKey = assumeRoleRes.Credentials.AccessKeyId;
                string SecretAccessKey = assumeRoleRes.Credentials.SecretAccessKey;
                string sessionToken = assumeRoleRes.Credentials.SessionToken;

                var client = new AmazonQuickSightClient(
                    AccessKey,
                    SecretAccessKey,
                    sessionToken,
                    regionEndpoint);
              

                var urlReponse = await client.GetDashboardEmbedUrlAsync(new GetDashboardEmbedUrlRequest
                {
                    AwsAccountId = AwsAccountId,
                    DashboardId = practice.QuickSiteDashboardId,
                    IdentityType = IdentityType.IAM,
                    ResetDisabled = true,
                    SessionLifetimeInMinutes = Convert.ToInt64( practice.QuickSiteSessionLifetimeInMinutes), //600
                    UndoRedoDisabled = false
                });

                return urlReponse.EmbedUrl;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        static async Task<GetCallerIdentityResponse> GetCallerIdentityResponseAsync(AmazonSecurityTokenServiceClient client, GetCallerIdentityRequest request)
        {
            try
            {
                var caller = await client.GetCallerIdentityAsync(request);
                return caller;

            }
            catch (Exception ex)
            {

            }
            return null;
        }
        static async Task<AssumeRoleResponse> GetAssumeRoleResponseAsync(AmazonSecurityTokenServiceClient client, AssumeRoleRequest request)
        {
            var response = await client.AssumeRoleAsync(request);
            return response;
        }
    }
}
