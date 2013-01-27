﻿/********************************************************************************
** Class Name:   MSSqlHelp
** Author：      spring yang
** Create date： 2012-9-1
** Modify：      spring yang
** Modify Date： 2012-9-25
** Summary：     MSSqlHelp class
*********************************************************************************/

using System.Data.Common;
using System.Data.SqlClient;

namespace DBHelp
{
    public class MSSqlHelp : AbstractDBHelp
    {
        #region Protected Method

        protected override DbDataAdapter GetDataAdapter(DbCommand command)
        {
            return new SqlDataAdapter(command as SqlCommand);
        }

        protected override DbConnection GetConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
        #endregion

        #region Public Mehtod

        public override SqlSourceType DataSqlSourceType
        {
            get { return SqlSourceType.MSSql; }
        }

        public override DbParameter GetDbParameter(string key, object value)
        {
            return new SqlParameter(key, value);
        }
        #endregion
    }
}
