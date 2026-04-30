using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.DataAccess.Common
{
    public class NoLockTableHint
    {
        public static JoinFormatDelegate NoLock = (dialect, tableDef, expr) => $"{dialect.GetQuotedTableName(tableDef)} WITH (NOLOCK) {expr}";
    }
}
