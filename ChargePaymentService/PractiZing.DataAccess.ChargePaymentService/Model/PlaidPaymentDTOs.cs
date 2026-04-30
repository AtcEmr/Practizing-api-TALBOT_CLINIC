using System;
using System.Collections.Generic;
using System.Text;
using PractiZing.Base.Model.ChargePaymentService;

namespace PractiZing.DataAccess.ChargePaymentService.Model
{


    public class Rootobject
    {
        public Account[] accounts { get; set; }
        public Item item { get; set; }
        public string request_id { get; set; }
        public int total_transactions { get; set; }
        public Transaction[] transactions { get; set; }
    }

    public class Item
    {
        public object[] available_products { get; set; }
        public string[] billed_products { get; set; }
        public object consent_expiration_time { get; set; }
        public object error { get; set; }
        public string institution_id { get; set; }
        public string item_id { get; set; }
        public object optional_products { get; set; }
        public string[] products { get; set; }
        public string update_type { get; set; }
        public string webhook { get; set; }
    }

    public class Account
    {
        public string account_id { get; set; }
        public Balances balances { get; set; }
        public string mask { get; set; }
        public string name { get; set; }
        public object official_name { get; set; }
        public string subtype { get; set; }
        public string type { get; set; }
    }

    public class Balances
    {
        public float available { get; set; }
        public float current { get; set; }
        public string iso_currency_code { get; set; }
        public object limit { get; set; }
        public object unofficial_currency_code { get; set; }
    }



    public class PliadTransactionRequest: IPliadTransactionRequest
    {
        public string client_id { get; set; }
        public string secret { get; set; }
        public string access_token { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public options options { get; set; }
    }

    public class PliadTransactionSyncRequest 
    {
        public string client_id { get; set; }
        public string secret { get; set; }
        public string access_token { get; set; }
        public string cursor { get; set; }
        public int count { get; set; }
        public optionsSync options { get; set; }
    }

    public class options
    {
        public int count { get; set; }
        public int offset { get; set; }
    }

    public class optionsSync
    {
        public bool include_original_description { get; set; }
        public bool include_personal_finance_category { get; set; }
    }

    public class Transaction
    {
        public string account_id { get; set; }
        public object account_owner { get; set; }
        public float amount { get; set; }
        public string authorized_date { get; set; }
        public object authorized_datetime { get; set; }
        public string[] category { get; set; }
        public string category_id { get; set; }
        public object check_number { get; set; }
        public string date { get; set; }
        public object datetime { get; set; }
        public string iso_currency_code { get; set; }
        public Location location { get; set; }
        public string merchant_name { get; set; }
        public string name { get; set; }
        public string payment_channel { get; set; }
        public Payment_Meta payment_meta { get; set; }
        public bool pending { get; set; }
        public object pending_transaction_id { get; set; }
        public object personal_finance_category { get; set; }
        public object transaction_code { get; set; }
        public string transaction_id { get; set; }
        public string transaction_type { get; set; }
        public object unofficial_currency_code { get; set; }
    }

    public class Location
    {
        public string address { get; set; }
        public string city { get; set; }
        public object country { get; set; }
        public object lat { get; set; }
        public object lon { get; set; }
        public object postal_code { get; set; }
        public string region { get; set; }
        public string store_number { get; set; }
    }

    public class Payment_Meta
    {
        public object by_order_of { get; set; }
        public object payee { get; set; }
        public object payer { get; set; }
        public object payment_method { get; set; }
        public string payment_processor { get; set; }
        public object ppd_id { get; set; }
        public object reason { get; set; }
        public object reference_number { get; set; }
    }

    public class Personal_Finance_Category
    {
        public string detailed { get; set; }
        public string primary { get; set; }        
    }

    public class PlaidPaymentSearch:IPlaidPaymentSearch
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }

    

}
