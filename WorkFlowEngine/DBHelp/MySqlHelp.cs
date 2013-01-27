﻿/********************************************************************************
** Class Name:   MySqlHelp
** Author：      spring yang
** Create date： 2012-9-1
** Modify：      spring yang
** Modify Date： 2012-9-25
** Summary：     MySqlHelp class
*********************************************************************************/

using System.Data.Common;
using MySql.Data.MySqlClient;

namespace DBHelp
{
    public class MySqlHelp : AbstractDBHelp
    {
        #region Protected Method

        protected override DbDataAdapter GetDataAdapter(DbCommand command)
        {
            return new MySqlDataAdapter();
        }

        protected override DbConnection GetConnection(string connectionString)
        {
            return new MySqlConnection(connectionString);
        }

        #endregion

        #region Public Mehtod

        public override DbParameter GetDbParameter(string key, object value)
        {
            return new MySqlParameter(key, value);
        }

        public override SqlSourceType DataSqlSourceType
        {
            get { return SqlSourceType.MySql; }
        }

        #endregion

    }
}
