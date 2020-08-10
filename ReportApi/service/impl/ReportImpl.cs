using Dapper;
using ModelClass.auth;
using ModelClass.model.oracle;
using ModelClass.model.report.request;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Linq;
using WebApi.data;

namespace REPORT.service.impl
{
    public class ReportImpl : IReport
    {
        public ReportImpl()
        {
        }
        /*
         * execure querery
         */
        public dynamic execureQuery()
        {
            object result = null;
            try
            {
                string connString = new ConnectionString().returnConnection();
                OracleConnection conn = new OracleConnection(connString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                var dyParam = new OracleDynamicParameters();
                if (conn.State == ConnectionState.Open)
                {
                    var query = "select * from queue_privileges";
                    result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.Text);
                }
            }
            catch (Exception e)
            {
                result = e;
            }

            return result;
        }

        /*
        * execure store procedures
        */
        public dynamic execureStoreProcedure(int test)
        {
            object result = null;
            var dyParam = new OracleDynamicParameters();

            /*
             * Truyền biến nếu có
             * gồm tên biến, biến input và output
             */

            //dyParam.Add("v_test", OracleDbType.Int32, ParameterDirection.Input, test);
            //dyParam.Add("name variable", OracleDbType.Varchar2, ParameterDirection.Input, "data of variable ");

            dyParam.Add("out_param", OracleDbType.RefCursor, ParameterDirection.Output);
            string connString = new ConnectionString().returnConnection();
            OracleConnection conn = new OracleConnection(connString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            if (conn.State == ConnectionState.Open)
            {

                var query = "PKG_BANG.TestByKhanhIT";
                var query1 = "PKG_BANG.getAll";
                //result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
                result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public dynamic getReportDasboard(ReportRequest rq)
        {
            object result = null;
            var dyParam = new OracleDynamicParameters();

            /*
             * Truyền biến nếu có
             * gồm tên biến, biến input và output
             */
            dyParam.Add("v_FROM_DATE", OracleDbType.Date, ParameterDirection.Input, rq.v_FROM_DATE);
            dyParam.Add("v_TO_DATE", OracleDbType.Date, ParameterDirection.Input, rq.v_TO_DATE);
            dyParam.Add("out_Param", OracleDbType.RefCursor, ParameterDirection.Output);
            string connString = new ConnectionString().returnConnection();
            OracleConnection conn = new OracleConnection(connString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            if (conn.State == ConnectionState.Open)
            {

                var query = "PKG_CNTT.sp_GetReportDashboard";
                result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public dynamic getReportTongYeuCau(ReportRequest rq)
        {
            object result = null;
            var dyParam = new OracleDynamicParameters();
            /*
             * Truyền biến nếu có
             * gồm tên biến, biến input và output
             */
            dyParam.Add("v_FROM_DATE", OracleDbType.Date, ParameterDirection.Input, rq.v_FROM_DATE);
            dyParam.Add("v_TO_DATE", OracleDbType.Date, ParameterDirection.Input, rq.v_TO_DATE);
            dyParam.Add("out_Param", OracleDbType.RefCursor, ParameterDirection.Output);
            string connString = new ConnectionString().returnConnection();
            OracleConnection conn = new OracleConnection(connString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            if (conn.State == ConnectionState.Open)
            {
                var query = "PKG_CNTT.sp_GetReportTongYeuCau";
                result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public dynamic getListReportSLA(ReportRequest rq)
        {
            object result = null;
            var dyParam = new OracleDynamicParameters();
            /*
             * Truyền biến nếu có
             * gồm tên biến, biến input và output
             */
            dyParam.Add("v_ID_NHOM_GIAI_DOAN", OracleDbType.Int16, ParameterDirection.Input, rq.v_ID_NHOM_GIAI_DOAN);
            dyParam.Add("v_YEAR", OracleDbType.Int16, ParameterDirection.Input, rq.v_YEAR);
            dyParam.Add("v_MONTH", OracleDbType.Int16, ParameterDirection.Input, rq.v_MONTH);
            dyParam.Add("out_Param", OracleDbType.RefCursor, ParameterDirection.Output);
            string connString = new ConnectionString().returnConnection();
            OracleConnection conn = new OracleConnection(connString);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            if (conn.State == ConnectionState.Open)
            {
                var query = "PKG_CNTT.sp_Report_SLA";
                result = SqlMapper.Query(conn, query, param: dyParam, commandType: CommandType.StoredProcedure);
            }
            return result;
        }

        public dynamic TestSql()
        {
            //DataContext db = new DataContext();
            //Users us = db.Users.FirstOrDefault();
            //return us;
            return null;
        }
    }
}