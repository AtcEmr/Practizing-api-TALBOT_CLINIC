using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.Common
{
    public interface IDefaultConnection
    {
        void GetAll();
    }
    public class DefaultConnection : IDefaultConnection
    {

        public DefaultConnection()
        {
        }

        public void GetAll()
        {
            // do something
        }
    }
}
