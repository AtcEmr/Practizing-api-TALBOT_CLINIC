using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.ChargePaymentService.Model
{

    public class RootobjectTransactionSync
    {
        public Added[] added { get; set; }
        public bool has_more { get; set; }
        public object[] modified { get; set; }
        public string next_cursor { get; set; }
        public object[] removed { get; set; }
        public string request_id { get; set; }
    }

    public class Added
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
        //public object personal_finance_category { get; set; }
        public object transaction_code { get; set; }
        public string transaction_id { get; set; }
        public string transaction_type { get; set; }
        public object unofficial_currency_code { get; set; }
        public Personal_Finance_Category personal_finance_category { get; set; }
    }

    public class PlaidExceptionModel
    {
        public object display_message { get; set; }
        public string error_code { get; set; }
        public string error_message { get; set; }
        public string error_type { get; set; }
        public string request_id { get; set; }
        public object suggested_action { get; set; }
    }

}
