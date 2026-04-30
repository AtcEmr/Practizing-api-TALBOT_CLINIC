using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using PractiZing.Base.Entities;
using PractiZing.Base.Object.PracticeCentral;
using PractiZing.Base.Repositories;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PractiZing.BusinessLogic.Common
{
    public class PracticeCentralDataRepository : IPracticeCentralDataRepository
    {
        SqlConnection connection;
        private IHttpContextAccessor _httpContextAccessor;
        public PracticeCentralDataRepository(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            string connectionString = configuration.GetConnectionString("PracticeCentralDBContext");
            connection = new SqlConnection(connectionString);
            this._httpContextAccessor = httpContextAccessor;
        }

        public IPracticePracticeCentralDTO GetPractice(string headerOrigin = "")
        {
            Console.WriteLine("Header Origin test - ");
            if (headerOrigin == "")
            {
                var headers = this._httpContextAccessor.HttpContext.Request.Headers;
                Console.WriteLine("Total headers - " + headers.Count);

                foreach (var item in headers)
                {
                    Console.WriteLine(string.Format("header - {0} - value - {1}", item.Key, item.Value));
                }
                if (headers.ContainsKey("origin"))
                    headerOrigin = headers["Origin"];
                else if (headers.ContainsKey("Referer"))
                    headerOrigin = headers["Referer"];
                else
                    headerOrigin = headers["Host"];
            }
            if (headerOrigin.Contains(".com/"))
            {
                headerOrigin = headerOrigin.Replace(".com/", ".com");
            }
            Console.WriteLine("Header Origin - " + headerOrigin);

            string practiceURL = headerOrigin.Replace("https://", "").Replace("http://", "");
            string query = $"SELECT PracticeName,PracticeCode,StripeKey,CustomerKey FROM Practice WHERE PracticeURL='{practiceURL}'";
            var dt = GetData(query);

            PracticePracticeCentralDTO practice = new PracticePracticeCentralDTO();
            practice.PracticeName = dt.Rows[0]["PracticeName"].ToString();
            practice.PracticeCode = dt.Rows[0]["PracticeCode"].ToString();
            practice.StripeKey = dt.Rows[0]["StripeKey"].ToString();
            practice.CustomerKey = dt.Rows[0]["CustomerKey"].ToString();
            return practice;
        }

        public IPracticePracticeCentralDTO GetPracticeByPracticeCode(string practiceCode)
        {
            string query = $"SELECT PracticeName,PracticeCode,StripeKey,CustomerKey FROM Practice WHERE PracticeCode='{practiceCode}'";
            var dt = GetData(query);

            PracticePracticeCentralDTO practice = new PracticePracticeCentralDTO();
            practice.PracticeName = dt.Rows[0]["PracticeName"].ToString();
            practice.PracticeCode = dt.Rows[0]["PracticeCode"].ToString();
            practice.StripeKey = dt.Rows[0]["StripeKey"].ToString();
            practice.CustomerKey = dt.Rows[0]["CustomerKey"].ToString();
            return practice;
        }

        public IPracticePracticeCentralDTO GetPracticeByCustomerKey(string customerKey)
        {
            string query = $"SELECT PracticeName,PracticeCode,StripeKey FROM Practice WHERE CustomerKey='{customerKey}'";
            var dt = GetData(query);

            PracticePracticeCentralDTO practice = new PracticePracticeCentralDTO();
            practice.PracticeName = dt.Rows[0]["PracticeName"].ToString();
            practice.PracticeCode = dt.Rows[0]["PracticeCode"].ToString();
            practice.StripeKey = dt.Rows[0]["StripeKey"].ToString();
            return practice;
        }

        public IEnumerable<IPracticePracticeCentralDTO> GetPractices()
        {
            string query = "select PracticeId,PracticeName,PracticeCode,PracticeURL,StripeKey,DBName,LabDBName from Practice";
            var dt = GetData(query);

            List<PracticePracticeCentralDTO> practices = new List<PracticePracticeCentralDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                PracticePracticeCentralDTO practice = new PracticePracticeCentralDTO();
                practice.PracticeName = dt.Rows[i]["PracticeName"].ToString();
                practice.PracticeCode = dt.Rows[i]["PracticeCode"].ToString();
                practice.DBName = dt.Rows[i]["DBName"].ToString();
                practice.LabDBName = dt.Rows[i]["LabDBName"].ToString();
                practices.Add(practice);
            }
            return practices;
        }

        private DataTable GetData(string query)
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();

            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            connection.Close();

            return dt;
        }
    }
}