using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.Base.Model.ChargePaymentService
{
    public interface IPliadTransactionRequest
    {
         string client_id { get; set; }
         string secret { get; set; }
         string access_token { get; set; }
         string start_date { get; set; }
         string end_date { get; set; }       
    }

    public interface ITransaction
    {
         string account_id { get; set; }
         object account_owner { get; set; }
         float amount { get; set; }
         string authorized_date { get; set; }
         object authorized_datetime { get; set; }
         string[] category { get; set; }
         string category_id { get; set; }
         object check_number { get; set; }
         string date { get; set; }
         object datetime { get; set; }
         string iso_currency_code { get; set; }
         ILocation location { get; set; }
         string merchant_name { get; set; }
         string name { get; set; }
         string payment_channel { get; set; }
         IPayment_Meta payment_meta { get; set; }
         bool pending { get; set; }
         object pending_transaction_id { get; set; }
         object personal_finance_category { get; set; }
         object transaction_code { get; set; }
         string transaction_id { get; set; }
         string transaction_type { get; set; }
         object unofficial_currency_code { get; set; }
    }

    public interface ILocation
    {
         string address { get; set; }
         string city { get; set; }
         object country { get; set; }
         object lat { get; set; }
         object lon { get; set; }
         object postal_code { get; set; }
         string region { get; set; }
         string store_number { get; set; }
    }

    public interface IPayment_Meta
    {
         object by_order_of { get; set; }
         object payee { get; set; }
         object payer { get; set; }
         object payment_method { get; set; }
         string payment_processor { get; set; }
         object ppd_id { get; set; }
         object reason { get; set; }
         object reference_number { get; set; }
    }

    public interface IPlaidPaymentSearch
    {
        string StartDate { get; set; }
        string EndDate { get; set; }
    }
}
