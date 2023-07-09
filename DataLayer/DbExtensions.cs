using Core.BusinessObject;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    internal static class DbExtensions
    {

        /// <summary>
        /// Add Create Params
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="command"></param>
        public static void AddCreateParams(this BaseObject obj, DbCommand command)
        {
            command.AddInParameterDateTime("@CreatedOnUtc", obj.CreatedOnUtc);
            command.AddInParameterString("@CreatedBy", obj.CreatedBy);
            command.AddInParameterString("@CreatedIp", obj.CreatedIp);
            command.AddInParameterString("@UpdatedBy", obj.UpdatedBy);
            command.AddInParameterDateTime("@UpdatedOnUtc", obj.UpdatedOnUtc);
            command.AddInParameterString("@UpdatedIp", obj.UpdatedIp);

        }

        /// <summary>
        /// Add Update Params
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="command"></param>
        public static void AddUpdateParams(this BaseObject obj, DbCommand command)
        {
            command.AddInParameterDateTime("@CreatedOnUtc", obj.CreatedOnUtc);
            command.AddInParameterDateTime("@UpdatedOnUtc", obj.UpdatedOnUtc);
            command.AddInParameterString("@CreatedBy", obj.CreatedBy);
            command.AddInParameterString("@UpdatedBy", obj.UpdatedBy);
            command.AddInParameterString("@CreatedIp", obj.CreatedIp);
            command.AddInParameterString("@UpdatedIp", obj.UpdatedIp);

        }

        /// <summary>
        /// Get Sql String Command
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DbCommand GetSqlStringComamnd(this DbConnection conn, string sql)
        {
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            return cmd;
        }
        /// <summary>
        /// Get Proc Command
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="proc"></param>
        /// <returns></returns>
        public static DbCommand GetProcCommand(this DbConnection conn, string proc)
        {
            DbCommand cmd = conn.CreateCommand();
            cmd.CommandText = proc;
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }

        /// <summary>
        /// Add In Parameter
        /// </summary>
        /// <param name="dbCommand"></param>
        /// <param name="param"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public static void AddInParameter(this DbCommand dbCommand, string param, DbType type, object value)
        {
            DbParameter parameter = dbCommand.CreateParameter();
            parameter.ParameterName = param;
            parameter.DbType = type;
            parameter.Value = value;
            parameter.Direction = ParameterDirection.Input;
            dbCommand.Parameters.Add(parameter);
        }

        /// <summary>
        /// Add In Parameter Int
        /// </summary>
        /// <param name="dbCommand"></param>
        /// <param name="param"></param>
        /// <param name="value"></param>
        public static void AddInParameterInt(this DbCommand dbCommand, string param, int value)
        {
            DbParameter parameter = dbCommand.CreateParameter();
            parameter.ParameterName = param;
            parameter.DbType = DbType.Int32;
            parameter.Value = value;
            parameter.Direction = ParameterDirection.Input;
            dbCommand.Parameters.Add(parameter);
        }

        /// <summary>
        /// Add In Parameter Decimal
        /// </summary>
        /// <param name="dbCommand"></param>
        /// <param name="param"></param>
        /// <param name="value"></param>
        public static void AddInParameterDecimal(this DbCommand dbCommand, string param, decimal value)
        {
            DbParameter parameter = dbCommand.CreateParameter();
            parameter.ParameterName = param;
            parameter.DbType = DbType.Decimal;
            parameter.Value = value;
            parameter.Direction = ParameterDirection.Input;
            dbCommand.Parameters.Add(parameter);
        }

        /// <summary>
        /// Add In Parameter String
        /// </summary>
        /// <param name="dbCommand"></param>
        /// <param name="param"></param>
        /// <param name="value"></param>
        public static void AddInParameterString(this DbCommand dbCommand, string param, string value)
        {
            DbParameter parameter = dbCommand.CreateParameter();
            parameter.ParameterName = param;
            parameter.DbType = DbType.String;
            parameter.Value = value;
            parameter.Direction = ParameterDirection.Input;
            dbCommand.Parameters.Add(parameter);
        }

        /// <summary>
        /// Add In Parameter Bool
        /// </summary>
        /// <param name="dbCommand"></param>
        /// <param name="param"></param>
        /// <param name="value"></param>
        public static void AddInParameterBool(this DbCommand dbCommand, string param, Boolean value)
        {
            DbParameter parameter = dbCommand.CreateParameter();
            parameter.ParameterName = param;
            parameter.DbType = DbType.Boolean;
            parameter.Value = value;
            parameter.Direction = ParameterDirection.Input;
            dbCommand.Parameters.Add(parameter);
        }

        /// <summary>
        /// Add In Parameter Date Time
        /// </summary>
        /// <param name="dbCommand"></param>
        /// <param name="param"></param>
        /// <param name="value"></param>
        public static void AddInParameterDateTime(this DbCommand dbCommand, string param, DateTime value)
        {
            DbParameter parameter = dbCommand.CreateParameter();
            parameter.ParameterName = param;
            parameter.DbType = DbType.DateTime;
            parameter.Value = value;
            parameter.Direction = ParameterDirection.Input;
            dbCommand.Parameters.Add(parameter);
        }

        /// <summary>
        /// Add Out Parameter
        /// </summary>
        /// <param name="dbCommand"></param>
        /// <param name="param"></param>
        /// <param name="type"></param>
        /// <param name="value"></param>
        public static void AddOutParameter(this DbCommand dbCommand, string param, DbType type, object value)
        {
            DbParameter parameter = dbCommand.CreateParameter();
            parameter.ParameterName = param;
            parameter.DbType = type;
            parameter.Value = value;
            parameter.Direction = ParameterDirection.Output;
            dbCommand.Parameters.Add(parameter);
        }

        /// <summary>
        /// Add Out Parameter Int
        /// </summary>
        /// <param name="dbCommand"></param>
        /// <param name="param"></param>
        /// <param name="value"></param>
        public static void AddOutParameterInt(this DbCommand dbCommand, string param, object value)
        {
            DbParameter parameter = dbCommand.CreateParameter();
            parameter.ParameterName = param;
            parameter.DbType = DbType.Int32;
            parameter.Value = value;
            parameter.Direction = ParameterDirection.Output;
            dbCommand.Parameters.Add(parameter);
        }


    }
}
