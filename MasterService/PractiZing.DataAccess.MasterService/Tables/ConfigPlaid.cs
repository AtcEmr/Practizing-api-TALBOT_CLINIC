using PractiZing.Base.Entities.MasterService;
using ServiceStack.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace PractiZing.DataAccess.MasterService.Tables
{
    public class ConfigPlaid : IConfigPlaid
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
        public string ClientId { get; set; }
        public string SecretKey { get; set; }
        public string AccessToken { get; set; }
        public int PracticeId { get; set; }
        public string PlaidURL { get; set; }
    }
}
