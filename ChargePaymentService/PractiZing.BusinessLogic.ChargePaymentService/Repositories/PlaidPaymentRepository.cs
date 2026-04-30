using AutoMapper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using OfficeOpenXml;
using PractiZing.Api.Common;
using PractiZing.Base.Entities.ChargePaymentService;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Model.ChargePaymentService;
using PractiZing.Base.Object.ChargePaymentService;
using PractiZing.Base.Repositories.ChargePaymentService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.View.ChargePaymentService;
using PractiZing.BusinessLogic.Common;
using PractiZing.DataAccess.ChargePaymentService;
using PractiZing.DataAccess.ChargePaymentService.Model;
using PractiZing.DataAccess.ChargePaymentService.Tables;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.PatientService.Tables;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.ChargePaymentService.Repositories
{
    public class PlaidPaymentRepository : ModuleBaseRepository<PlaidPayment>, IPlaidPaymentRepository
    {
        private readonly IMapper _mapper;
        private readonly IConfigPlaidRepository _configPlaidRepository;
        private readonly IChasePaymentsRepository _chasePaymentsRepository;
        public PlaidPaymentRepository(ValidationErrorCodes errorCodes,
                                      DataBaseContext dbContext,
                                      ILoginUser loggedUser,
                                      IMapper mapper,
                                      IConfigPlaidRepository configPlaidRepository,
                                      IChasePaymentsRepository chasePaymentsRepository)
                                      : base(errorCodes, dbContext, loggedUser)
        {

            this._mapper = mapper;
            this._configPlaidRepository = configPlaidRepository;
            this._chasePaymentsRepository = chasePaymentsRepository;
        }


        public async Task<bool> AddNew(List<IPlaidPayment> entities)
        {
            try
            {
                List<PlaidPayment> lst = new List<PlaidPayment>();
                foreach (var item in entities)
                {
                    var record = await this.Connection.SingleAsync<PlaidPayment>(i => i.TransactionId == item.TransactionId && i.Amount == item.Amount);
                    if (record == null)
                    {
                        PlaidPayment payment = item as PlaidPayment;
                        lst.Add(payment);
                    }
                }

                return await base.AddAllAsync(lst);
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> GetBankTransactionSync(IPlaidPaymentSearch plaidPaymentSearch)
        {
            try
            {
                //this.Connection.DropTable<PlaidPayment>();
                //this.Connection.CreateTableIfNotExists<PlaidPayment>();

                var configPlaid = await this._configPlaidRepository.Get();
                if (configPlaid != null)
                {
                    HttpResponseMessage response;
                    string url = configPlaid.PlaidURL;
                    using (var client = new HttpClient { BaseAddress = new Uri(url) })
                    {
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        using (var request = new HttpRequestMessage(HttpMethod.Post, @"/transactions/sync"))
                        {
                            PliadTransactionSyncRequest dto = new PliadTransactionSyncRequest();
                            dto.client_id = configPlaid.ClientId;
                            dto.secret = configPlaid.SecretKey;
                            dto.access_token = configPlaid.AccessToken;
                            dto.cursor = null;
                            dto.count = 500;
                            dto.options = new optionsSync();
                            dto.options.include_original_description = true;
                            dto.options.include_personal_finance_category = true;
                            string jsondata = JsonConvert.SerializeObject(dto);
                            //jsonValues.Add("public_token", "access-sandbox-4fb23bca-3ff9-49a0-86aa-81be915aec75");
                            request.Content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");

                            response = await client.SendAsync(request);

                            if (response.IsSuccessStatusCode)
                            {

                                string result = await response.Content.ReadAsStringAsync();
                                RootobjectTransactionSync pliadPublicToken = JsonConvert.DeserializeObject<RootobjectTransactionSync>(result);
                                await Test1Sybc(pliadPublicToken);
                                if (!string.IsNullOrWhiteSpace(pliadPublicToken.next_cursor))
                                {
                                    if (pliadPublicToken.added.Count() == 500)
                                        await CallTransactionsSyncPaging(plaidPaymentSearch, pliadPublicToken, configPlaid);
                                }

                            }
                            else
                            {
                                string result = await response.Content.ReadAsStringAsync();
                                PlaidExceptionModel pliadPublicToken = JsonConvert.DeserializeObject<PlaidExceptionModel>(result);
                                return pliadPublicToken.error_code + " : " + pliadPublicToken.error_message;
                            }
                        }
                    }
                }
                else
                {
                    return "There is no configuration for Plaid Payments";
                }
                return "";

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task CallTransactionsSyncPaging(IPlaidPaymentSearch plaidPaymentSearch, RootobjectTransactionSync rootobject, IConfigPlaid configPlaid)
        {
            try
            {
                //var transactions = rootobject.transactions.Count();
                //var total_transactions = rootobject.total_transactions;

                //int offset = transactions;
                //int count = total_transactions - transactions;

                //if (count > 500)
                //    count = 500;
                string cursor = rootobject.next_cursor;

                while (cursor.Length > 0)
                {
                    HttpResponseMessage response;
                    string url = configPlaid.PlaidURL;
                    using (var client = new HttpClient { BaseAddress = new Uri(url) })
                    {
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        using (var request = new HttpRequestMessage(HttpMethod.Post, @"/transactions/sync"))
                        {
                            PliadTransactionSyncRequest dto = new PliadTransactionSyncRequest();
                            dto.client_id = configPlaid.ClientId;
                            dto.secret = configPlaid.SecretKey;
                            dto.access_token = configPlaid.AccessToken;
                            dto.cursor = cursor;
                            dto.count = 500;
                            dto.options = new optionsSync();
                            dto.options.include_original_description = true;
                            dto.options.include_personal_finance_category = true;
                            //dto.offset = offset;
                            string jsondata = JsonConvert.SerializeObject(dto);
                            //jsonValues.Add("public_token", "access-sandbox-4fb23bca-3ff9-49a0-86aa-81be915aec75");
                            request.Content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");

                            response = await client.SendAsync(request);

                            if (response.IsSuccessStatusCode)
                            {
                                string result = await response.Content.ReadAsStringAsync();
                                RootobjectTransactionSync pliadPublicToken = JsonConvert.DeserializeObject<RootobjectTransactionSync>(result);
                                await Test1Sybc(pliadPublicToken);
                                if (!string.IsNullOrWhiteSpace(pliadPublicToken.next_cursor))
                                {
                                    if (pliadPublicToken.added.Count() > 0)
                                    {
                                        cursor = pliadPublicToken.next_cursor;
                                    }
                                    else
                                    {
                                        cursor = "";
                                    }
                                }
                                else
                                {
                                    cursor = "";
                                }
                                if (pliadPublicToken.added.Count() == 0)
                                {
                                    cursor = "";
                                }
                                //return result;
                            }
                            else
                            {
                                string result = await response.Content.ReadAsStringAsync();
                                //return "";
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task GetBankTransaction(IPlaidPaymentSearch plaidPaymentSearch)
        {
            try
            {
                //this.Connection.DropTable<PlaidPayment>();
                //this.Connection.CreateTableIfNotExists<PlaidPayment>();

                var configPlaid = await this._configPlaidRepository.Get();

                HttpResponseMessage response;
                string url = configPlaid.PlaidURL;
                using (var client = new HttpClient { BaseAddress = new Uri(url) })
                {
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    using (var request = new HttpRequestMessage(HttpMethod.Post, @"/transactions/get"))
                    {
                        PliadTransactionRequest dto = new PliadTransactionRequest();
                        dto.client_id = configPlaid.ClientId;
                        dto.secret = configPlaid.SecretKey;
                        dto.access_token = configPlaid.AccessToken;
                        dto.start_date = Convert.ToDateTime(plaidPaymentSearch.StartDate).ToString("yyyy-MM-dd");// "2022-05-01";
                        dto.end_date = Convert.ToDateTime(plaidPaymentSearch.EndDate).ToString("yyyy-MM-dd");//"2022-05-19";
                        dto.options = new options();
                        dto.options.count = 500;
                        string jsondata = JsonConvert.SerializeObject(dto);
                        //jsonValues.Add("public_token", "access-sandbox-4fb23bca-3ff9-49a0-86aa-81be915aec75");
                        request.Content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");

                        response = await client.SendAsync(request);

                        if (response.IsSuccessStatusCode)
                        {

                            string result = await response.Content.ReadAsStringAsync();
                            Rootobject pliadPublicToken = JsonConvert.DeserializeObject<Rootobject>(result);
                            await Test1(pliadPublicToken);
                            if (pliadPublicToken.total_transactions > 500)
                            {
                                await CallTransactionsPaging(plaidPaymentSearch, pliadPublicToken, configPlaid);
                            }
                            //return result;
                        }
                        else
                        {
                            string result = await response.Content.ReadAsStringAsync();
                            //return "";
                        }
                    }
                }
                //return response;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task CallTransactionsPaging(IPlaidPaymentSearch plaidPaymentSearch, Rootobject rootobject, IConfigPlaid configPlaid)
        {
            try
            {
                var transactions = rootobject.transactions.Count();
                var total_transactions = rootobject.total_transactions;

                int offset = transactions;
                int count = total_transactions - transactions;

                if (count > 500)
                    count = 500;


                while (transactions < total_transactions)
                {
                    HttpResponseMessage response;
                    string url = configPlaid.PlaidURL;
                    using (var client = new HttpClient { BaseAddress = new Uri(url) })
                    {
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        using (var request = new HttpRequestMessage(HttpMethod.Post, @"/transactions/get"))
                        {
                            PliadTransactionRequest dto = new PliadTransactionRequest();
                            dto.client_id = configPlaid.ClientId;
                            dto.secret = configPlaid.SecretKey;
                            dto.access_token = configPlaid.AccessToken;
                            dto.start_date = Convert.ToDateTime(plaidPaymentSearch.StartDate).ToString("yyyy-MM-dd");// "2022-05-01";
                            dto.end_date = Convert.ToDateTime(plaidPaymentSearch.EndDate).ToString("yyyy-MM-dd");//"2022-05-19";
                            dto.options = new options();
                            dto.options.count = 500;
                            dto.options.offset = offset;
                            //dto.offset = offset;
                            string jsondata = JsonConvert.SerializeObject(dto);
                            //jsonValues.Add("public_token", "access-sandbox-4fb23bca-3ff9-49a0-86aa-81be915aec75");
                            request.Content = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");

                            response = await client.SendAsync(request);

                            if (response.IsSuccessStatusCode)
                            {

                                string result = await response.Content.ReadAsStringAsync();
                                Rootobject pliadPublicToken = JsonConvert.DeserializeObject<Rootobject>(result);
                                await Test1(pliadPublicToken);
                                //return result;
                            }
                            else
                            {
                                string result = await response.Content.ReadAsStringAsync();
                                //return "";
                            }
                        }
                    }
                    transactions += count;
                    //count = total_transactions - transactions;
                    offset = transactions;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task Test1(Rootobject pliadPublicToken)
        {
            try
            {
                //string result = File.ReadAllText(@"C:\DSIG\RND\PLAID\plaid-postman-master\transaction.txt");
                //Rootobject pliadPublicToken = JsonConvert.DeserializeObject<Rootobject>(result);
                List<IPlaidPayment> lst = new List<IPlaidPayment>();

                foreach (var item in pliadPublicToken.transactions.Where(i => i.pending == false))
                {
                    PlaidPayment plaidPayment = new PlaidPayment();
                    plaidPayment.AccountId = item.account_id;
                    plaidPayment.AccountOwner = item.account_owner != null ? item.account_owner.ToString() : "";
                    plaidPayment.Amount = (decimal)item.amount;
                    plaidPayment.AuthorizedDate = item.authorized_date;
                    plaidPayment.AuthorizedDatetime = item.authorized_datetime != null ? item.authorized_datetime.ToString() : "";
                    if (item.category != null)
                    {
                        string category = string.Join(",", item.category.ToList());
                        plaidPayment.Category = category;
                    }

                    plaidPayment.CheckNumber = item.check_number != null ? item.check_number.ToString() : "";
                    plaidPayment.IsoCurrencyCode = item.iso_currency_code;
                    plaidPayment.LocationAddress = item.location.address != null ? item.location.address : "";
                    plaidPayment.LocationCity = item.location.city != null ? item.location.city : "";
                    plaidPayment.LocationCountry = item.location.country != null ? item.location.country.ToString() : "";
                    plaidPayment.LocationLat = item.location.lat != null ? item.location.lat.ToString() : "";
                    plaidPayment.LocationLon = item.location.lon != null ? item.location.lon.ToString() : "";
                    plaidPayment.LocationPostalCode = item.location.postal_code != null ? item.location.postal_code.ToString() : "";
                    plaidPayment.LocationRegion = item.location.region != null ? item.location.region : "";
                    plaidPayment.LocationStoreNumber = item.location.store_number != null ? item.location.store_number : "";
                    plaidPayment.MerchantName = item.merchant_name;
                    plaidPayment.Name = item.name != null ? item.name.ToString() : "";

                    plaidPayment.PaymentDate = item.date;
                    plaidPayment.PaymentDatetime = item.datetime != null ? item.datetime.ToString() : "";
                    plaidPayment.PaymentMetabyOrderOf = item.payment_meta.by_order_of != null ? item.payment_meta.by_order_of.ToString() : "";
                    plaidPayment.PaymentMetaPayee = item.payment_meta.payee != null ? item.payment_meta.payee.ToString() : "";
                    plaidPayment.PaymentMetaPayer = item.payment_meta.payer != null ? item.payment_meta.payer.ToString() : "";
                    plaidPayment.PaymentMetaPaymentMethod = item.payment_meta.payment_method != null ? item.payment_meta.payment_method.ToString() : "";
                    plaidPayment.PaymentMetaPaymentProcessor = item.payment_meta.payment_processor != null ? item.payment_meta.payment_processor.ToString() : "";
                    plaidPayment.PaymentMetaPpdId = item.payment_meta.ppd_id != null ? item.payment_meta.ppd_id.ToString() : "";
                    plaidPayment.PaymentMetaReason = item.payment_meta.reason != null ? item.payment_meta.reason.ToString() : "";
                    plaidPayment.PaymentMetaReferenceNumber = item.payment_meta.reference_number != null ? item.payment_meta.reference_number.ToString() : "";
                    plaidPayment.Pending = item.pending;
                    plaidPayment.PendingTransactionId = item.pending_transaction_id != null ? item.pending_transaction_id.ToString() : "";
                    plaidPayment.PersonalFinanceCategory = item.personal_finance_category != null ? item.personal_finance_category.ToString() : "";
                    plaidPayment.TransactionCode = item.transaction_code != null ? item.transaction_code.ToString() : "";
                    plaidPayment.TransactionId = item.transaction_id;
                    plaidPayment.TransactionType = item.transaction_type;
                    plaidPayment.UnofficialCurrencyCode = item.unofficial_currency_code != null ? item.unofficial_currency_code.ToString() : "";

                    lst.Add(plaidPayment);
                }

                await this.AddNew(lst);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task Test1Sybc(RootobjectTransactionSync pliadPublicToken)
        {
            try
            {
                //string result = File.ReadAllText(@"C:\DSIG\RND\PLAID\plaid-postman-master\transaction.txt");
                //Rootobject pliadPublicToken = JsonConvert.DeserializeObject<Rootobject>(result);
                List<IPlaidPayment> lst = new List<IPlaidPayment>();

                foreach (var item in pliadPublicToken.added.Where(i => i.pending == false))
                {
                    PlaidPayment plaidPayment = new PlaidPayment();
                    plaidPayment.AccountId = item.account_id;
                    plaidPayment.AccountOwner = item.account_owner != null ? item.account_owner.ToString() : "";
                    plaidPayment.Amount = (decimal)item.amount;
                    plaidPayment.AuthorizedDate = item.authorized_date;
                    plaidPayment.AuthorizedDatetime = item.authorized_datetime != null ? item.authorized_datetime.ToString() : "";
                    if (item.category != null)
                    {
                        string category = string.Join(",", item.category.ToList());
                        plaidPayment.Category = category;
                    }

                    plaidPayment.CheckNumber = item.check_number != null ? item.check_number.ToString() : "";
                    plaidPayment.IsoCurrencyCode = item.iso_currency_code;
                    plaidPayment.LocationAddress = item.location.address != null ? item.location.address : "";
                    plaidPayment.LocationCity = item.location.city != null ? item.location.city : "";
                    plaidPayment.LocationCountry = item.location.country != null ? item.location.country.ToString() : "";
                    plaidPayment.LocationLat = item.location.lat != null ? item.location.lat.ToString() : "";
                    plaidPayment.LocationLon = item.location.lon != null ? item.location.lon.ToString() : "";
                    plaidPayment.LocationPostalCode = item.location.postal_code != null ? item.location.postal_code.ToString() : "";
                    plaidPayment.LocationRegion = item.location.region != null ? item.location.region : "";
                    plaidPayment.LocationStoreNumber = item.location.store_number != null ? item.location.store_number : "";
                    plaidPayment.MerchantName = item.merchant_name;
                    plaidPayment.Name = item.name != null ? item.name.ToString() : "";

                    plaidPayment.PaymentDate = item.date;
                    plaidPayment.PaymentDatetime = item.datetime != null ? item.datetime.ToString() : "";
                    plaidPayment.PaymentMetabyOrderOf = item.payment_meta.by_order_of != null ? item.payment_meta.by_order_of.ToString() : "";
                    plaidPayment.PaymentMetaPayee = item.payment_meta.payee != null ? item.payment_meta.payee.ToString() : "";
                    plaidPayment.PaymentMetaPayer = item.payment_meta.payer != null ? item.payment_meta.payer.ToString() : "";
                    plaidPayment.PaymentMetaPaymentMethod = item.payment_meta.payment_method != null ? item.payment_meta.payment_method.ToString() : "";
                    plaidPayment.PaymentMetaPaymentProcessor = item.payment_meta.payment_processor != null ? item.payment_meta.payment_processor.ToString() : "";
                    plaidPayment.PaymentMetaPpdId = item.payment_meta.ppd_id != null ? item.payment_meta.ppd_id.ToString() : "";
                    plaidPayment.PaymentMetaReason = item.payment_meta.reason != null ? item.payment_meta.reason.ToString() : "";
                    plaidPayment.PaymentMetaReferenceNumber = item.payment_meta.reference_number != null ? item.payment_meta.reference_number.ToString() : "";
                    plaidPayment.Pending = item.pending;
                    plaidPayment.PendingTransactionId = item.pending_transaction_id != null ? item.pending_transaction_id.ToString() : "";
                    plaidPayment.PersonalFinanceCategoryDetailed = item.personal_finance_category != null ? item.personal_finance_category.detailed.ToString() : "";
                    plaidPayment.PersonalFinanceCategoryPrimary = item.personal_finance_category != null ? item.personal_finance_category.primary.ToString() : "";
                    plaidPayment.TransactionCode = item.transaction_code != null ? item.transaction_code.ToString() : "";
                    plaidPayment.TransactionId = item.transaction_id;
                    plaidPayment.TransactionType = item.transaction_type;
                    plaidPayment.UnofficialCurrencyCode = item.unofficial_currency_code != null ? item.unofficial_currency_code.ToString() : "";

                    lst.Add(plaidPayment);
                }

                await this.AddNew(lst);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task Test()
        {
            try
            {
                string result = File.ReadAllText(@"C:\DSIG\RND\PLAID\plaid-postman-master\transaction.txt");
                Rootobject pliadPublicToken = JsonConvert.DeserializeObject<Rootobject>(result);
                List<IPlaidPayment> lst = new List<IPlaidPayment>();

                foreach (var item in pliadPublicToken.transactions)
                {
                    PlaidPayment plaidPayment = new PlaidPayment();
                    plaidPayment.AccountId = item.account_id;
                    plaidPayment.AccountOwner = item.account_owner != null ? item.account_owner.ToString() : "";
                    plaidPayment.Amount = (decimal)item.amount;
                    plaidPayment.AuthorizedDate = item.authorized_date;
                    plaidPayment.AuthorizedDatetime = item.authorized_datetime != null ? item.authorized_datetime.ToString() : "";
                    if (item.category != null)
                    {
                        string category = string.Join(",", item.category.ToList());
                        plaidPayment.Category = category;
                    }

                    plaidPayment.CheckNumber = item.check_number != null ? item.check_number.ToString() : "";
                    plaidPayment.IsoCurrencyCode = item.iso_currency_code;
                    plaidPayment.LocationAddress = item.location.address != null ? item.location.address : "";
                    plaidPayment.LocationCity = item.location.city != null ? item.location.city : "";
                    plaidPayment.LocationCountry = item.location.country != null ? item.location.country.ToString() : "";
                    plaidPayment.LocationLat = item.location.lat != null ? item.location.lat.ToString() : "";
                    plaidPayment.LocationLon = item.location.lon != null ? item.location.lon.ToString() : "";
                    plaidPayment.LocationPostalCode = item.location.postal_code != null ? item.location.postal_code.ToString() : "";
                    plaidPayment.LocationRegion = item.location.region != null ? item.location.region : "";
                    plaidPayment.LocationStoreNumber = item.location.store_number != null ? item.location.store_number : "";
                    plaidPayment.MerchantName = item.merchant_name;
                    plaidPayment.Name = item.name != null ? item.name.ToString() : "";

                    plaidPayment.PaymentDate = item.date;
                    plaidPayment.PaymentDatetime = item.datetime != null ? item.datetime.ToString() : "";
                    plaidPayment.PaymentMetabyOrderOf = item.payment_meta.by_order_of != null ? item.payment_meta.by_order_of.ToString() : "";
                    plaidPayment.PaymentMetaPayee = item.payment_meta.payee != null ? item.payment_meta.payee.ToString() : "";
                    plaidPayment.PaymentMetaPayer = item.payment_meta.payer != null ? item.payment_meta.payer.ToString() : "";
                    plaidPayment.PaymentMetaPaymentMethod = item.payment_meta.payment_method != null ? item.payment_meta.payment_method.ToString() : "";
                    plaidPayment.PaymentMetaPaymentProcessor = item.payment_meta.payment_processor != null ? item.payment_meta.payment_processor.ToString() : "";
                    plaidPayment.PaymentMetaPpdId = item.payment_meta.ppd_id != null ? item.payment_meta.ppd_id.ToString() : "";
                    plaidPayment.PaymentMetaReason = item.payment_meta.reason != null ? item.payment_meta.reason.ToString() : "";
                    plaidPayment.PaymentMetaReferenceNumber = item.payment_meta.reference_number != null ? item.payment_meta.reference_number.ToString() : "";
                    plaidPayment.Pending = item.pending;
                    plaidPayment.PendingTransactionId = item.pending_transaction_id != null ? item.pending_transaction_id.ToString() : "";
                    plaidPayment.PersonalFinanceCategory = item.personal_finance_category != null ? item.personal_finance_category.ToString() : "";
                    plaidPayment.TransactionCode = item.transaction_code != null ? item.transaction_code.ToString() : "";
                    plaidPayment.TransactionId = item.transaction_id;
                    plaidPayment.TransactionType = item.transaction_type;
                    plaidPayment.UnofficialCurrencyCode = item.unofficial_currency_code != null ? item.unofficial_currency_code.ToString() : "";

                    lst.Add(plaidPayment);
                }

                await this.AddNew(lst);
            }
            catch (Exception ex)
            {

                throw;
            }

        }


        public async Task<IEnumerable<IPlaidPayment>> GetAllPlaidPayments()
        {
            return await this.Connection.SelectAsync<PlaidPayment>(i => i.VoucherId == null && i.MatchedSource == null);
        }

        public async Task<decimal> GetDepositsAmount(DateTime fromDate, DateTime toDate)
        {
            var list = await this.Connection.SelectAsync<PlaidPayment>(i => i.PersonalFinanceCategoryPrimary == "TRANSFER_IN" && i.PersonalFinanceCategoryDetailed == "TRANSFER_IN_ACCOUNT_TRANSFER");
            if (list.Count() > 0)
            {
                return list.Where(i => Convert.ToDateTime(i.PaymentDate) >= fromDate && Convert.ToDateTime(i.PaymentDate) <= toDate).Sum(i => Math.Abs(i.Amount));
            }

            return 0;
        }

        public async Task<IEnumerable<IPlaidPayment>> GetPaymentsOnFilterDates(IPlaidPaymentSearch voucherViewFilter)
        {
            var list = await this.Connection.SelectAsync<PlaidPayment>(i => i.PersonalFinanceCategoryPrimary == "TRANSFER_IN" && i.PersonalFinanceCategoryDetailed == "TRANSFER_IN_ACCOUNT_TRANSFER");
            list = list.Where(i => Convert.ToDateTime(i.PaymentDate) >= Convert.ToDateTime(voucherViewFilter.StartDate) && Convert.ToDateTime(i.PaymentDate) <= Convert.ToDateTime(voucherViewFilter.EndDate)).ToList();
            //&& Convert.ToDateTime(i.PaymentDate) <= Convert.ToDateTime(voucherViewFilter.ToDate
            foreach (var item in list)
            {
                item.Amount = Math.Abs(item.Amount);
            }
            return list;
        }

        public async Task<int> UpdatePlaidMatched(List<int> ids)
        {
            try
            {

                foreach (var item in ids)
                {
                    PlaidPayment tEntity = await this.Connection.SingleAsync<PlaidPayment>(i => i.Id == item);
                    tEntity.MatchedSource = this.LoggedUser.PracticeCode;

                    var updateOnlyFields = this.Connection
                                          .From<PlaidPayment>()
                                          .Update(x => new
                                          {
                                              x.MatchedSource
                                          })
                                          .Where(i => i.Id == item);

                    var value = await base.UpdateOnlyAsync(tEntity, updateOnlyFields);
                }

                return 1;
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> GeneratePlaidPaymentsFromExcelImport(int monthId,int yearId,IFormFile file)
        {
            bool recordExists= await this._chasePaymentsRepository.CheckRecordExists(monthId,yearId);
            if(recordExists)
            {
                throw new Exception("Chase Transactions already exists for selected year and month.");
            }

            var filesToDelete = new List<string>();
            var name = Path.GetFileName(file.FileName);
            var extension = Path.GetExtension(name);
            var tempFilePath = Path.GetTempFileName();
            filesToDelete.Add(tempFilePath);
            // full path to file in temp location
            var filePath = tempFilePath + "_" + DateTime.Now.ToString("yyyyMMdd_HH_mm_ss") + "_" + name;
            filesToDelete.Add(filePath);
            try
            {
                if (extension.ToLower() != ".csv")
                {
                    throw new Exception("Please upload CSV file only.");
                }

                await FileOperations.CreateFileUsingIFromFile(file, filePath);
                if (extension.ToLower() == ".csv")
                {
                    string csvFileName = filePath;
                    string excelFileName = filePath + ".xlsx";
                    FileOperations.ConvertCsvToXlsx(excelFileName, csvFileName);
                    filePath = excelFileName;
                }

                List<string> typeList = new List<string>() { "ACCT_XFER", "ACH_CREDIT", "DEPOSIT" };

                List<ChasePayments> lstChasePayment = new List<ChasePayments>();

                FileInfo fileInfo = new FileInfo(Path.Combine(filePath));
                using (ExcelPackage package = new ExcelPackage(fileInfo))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;
                    int ColCount = worksheet.Dimension.Columns;
                    if ((ColCount >= 1) && rowCount > 0)
                    {
                        for (int row = 2; row <= rowCount; row++)
                        {
                            try
                            {
                                string chaseType = Convert.ToString(worksheet.Cells[row, 5].Value);
                                var existsType = typeList.FirstOrDefault(i => i.ToString() == chaseType);
                                if(existsType==null)
                                {
                                    continue;
                                }

                                ChasePayments chasePayments = new ChasePayments();
                                chasePayments.Details = Convert.ToString(worksheet.Cells[row, 1].Value);
                                chasePayments.PostingDate = FromExcelSerialDate(Convert.ToInt32(Convert.ToString(worksheet.Cells[row, 2].Value)));
                                chasePayments.Description = Convert.ToString(worksheet.Cells[row, 3].Value);
                                chasePayments.Amount = Convert.ToDecimal(worksheet.Cells[row, 4].Value);
                                chasePayments.ChaseType = chaseType;
                                if (worksheet.Cells[row, 6].Value != null && !string.IsNullOrWhiteSpace(worksheet.Cells[row, 6].Value.ToString()))
                                    chasePayments.Balance = Convert.ToDecimal(worksheet.Cells[row, 6].Value);
                                if (worksheet.Cells[row, 7].Value != null)
                                    chasePayments.CheckOrSlip = Convert.ToString(worksheet.Cells[row, 7].Value);
                                lstChasePayment.Add(chasePayments);
                                chasePayments.CreatedBy = this.LoggedUser.UserName;
                                chasePayments.CreatedDate = DateTime.Now;
                                chasePayments.MonthId = monthId;
                                chasePayments.YearId = yearId;
                            }
                            catch (Exception ex)
                            {

                              
                            }
                            
                        }
                    }

                }
                if (lstChasePayment.Count > 0)
                {
                    await this._chasePaymentsRepository.AddBulk(lstChasePayment);
                }
                return "true";

            }
            catch
            {
                throw;
            }
            finally
            {
                try
                {
                    await FileOperations.DeleteFiles(filesToDelete);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
            }
        }

        public DateTime FromExcelSerialDate(int SerialDate)
        {
            if (SerialDate > 59) SerialDate -= 1; //Excel/Lotus 2/29/1900 bug   
            return new DateTime(1899, 12, 31).AddDays(SerialDate);
        }


    }

    //public class ChasePayments
    //{
    //    public string Details { get; set; }
    //    public string PostingDate { get; set; }
    //    public string Description { get; set; }
    //    public string Amount { get; set; }
    //    public string Type { get; set; }
    //    public string Balance { get; set; }
    //    public string CheckOrSlip { get; set; }
    //}
}
