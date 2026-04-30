using Microsoft.Extensions.Configuration;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Object.PracticeCentral;
using PractiZing.Base.Repositories.SecurityService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.SecurityService;
using PractiZing.DataAccess.SecurityService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.SecurityService.Repositories
{
    public class PracticeCentralPracticeRepository : ModuleBaseRepository<IPracticeCentralPractice>, IPracticeCentralPracticeRepository
    {
        SqlConnection connection;

        public PracticeCentralPracticeRepository(ValidationErrorCodes errorCodes,
                                                 DataBaseContext dbContext,
                                                 ILoginUser loggedUser, IConfiguration configuration)
                                               : base(errorCodes, dbContext, loggedUser)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            connection = new SqlConnection(connectionString);
        }

        public async Task<IPracticePracticeCentralDTO> GetPracticeByPracticeCode(string practiceCode)
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

        public async Task<IEnumerable<IPracticeCentralPractice>> GetAllPractices()
        {
            try
            {
                var practices = await this.Connection.SelectAsync<PracticeCentralPractice>();
                return practices.Where(i => !string.IsNullOrEmpty(i.DBConnectionString)).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                base.DbContext?.Dispose();
                GC.Collect();
            }
        }
    }
}