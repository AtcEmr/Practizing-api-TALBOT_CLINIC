namespace PractiZing.BusinessLogic.MasterService.Repositories
{
    internal class PaginationQuery<T1, T2>
    {
        private object data;
        private object totalRecords;

        public PaginationQuery(object data, object totalRecords)
        {
            this.data = data;
            this.totalRecords = totalRecords;
        }
    }
}