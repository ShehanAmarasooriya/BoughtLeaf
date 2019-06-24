using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using BoughtLeafDataAccess;
using System.Data;


namespace BoughtLeafBusinessLayer
{
    public class BLCalculateMonthPayment
    {
        private Int32 intProYear;

        public Int32 IntProYear
        {
            get { return intProYear; }
            set { intProYear = value; }
        }
        private Int32 intProMonth;

        public Int32 IntProMonth
        {
            get { return intProMonth; }
            set { intProMonth = value; }
        }
        private DateTime dtFromDate;

        public DateTime DtFromDate
        {
            get { return dtFromDate; }
            set { dtFromDate = value; }
        }

        private DateTime dtToDate;

        public DateTime DtToDate
        {
            get { return dtToDate; }
            set { dtToDate = value; }
        }
        private String strSupplierCode;

        public String StrSupplierCode
        {
            get { return strSupplierCode; }
            set { strSupplierCode = value; }
        }
        private String strRouteCode;

        public String StrRouteCode
        {
            get { return strRouteCode; }
            set { strRouteCode = value; }
        }

        private String strCollector;

        public String StrCollector
        {
            get { return strCollector; }
            set { strCollector = value; }
        }



        public String CalculateMonthBLPayment(String strSupplier,String strRoute,Decimal minrate)
        {
            // using (TransactionScope trnScope = new TransactionScope())
            //{
            String Status = "";
            SqlParameter param = new SqlParameter();
            SqlParameter statusParam = new SqlParameter();
            List<SqlParameter> paramList = new List<SqlParameter>();
            param = SQLHelper.CreateParameter("@FromDate", SqlDbType.DateTime);
            param.Value = Convert.ToDateTime(DtFromDate.ToShortDateString());
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@ToDate", SqlDbType.DateTime);
            param.Value = Convert.ToDateTime(DtToDate.ToShortDateString());
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@Route", SqlDbType.VarChar, 50);
            param.Value = strRoute;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@SupplierCode", SqlDbType.VarChar, 50);
            param.Value = strSupplier;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@userId", SqlDbType.VarChar, 50);
            param.Value = BLUser.StrUserName;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@BLminvalue", SqlDbType.Decimal);
            param.Value = minrate;
            paramList.Add(param);
            SqlCommand cmd = new SqlCommand();
            cmd = SQLHelper.CreateCommand("spCalculateBLPayment", CommandType.StoredProcedure, paramList);
            statusParam = cmd.Parameters.Add("@state", SqlDbType.VarChar, 50);
            statusParam.Direction = ParameterDirection.Output;
            SQLHelper.ExecuteNonQuery(cmd);
            Status = statusParam.Value.ToString();
            cmd.Dispose();
            return Status;
            // trnScope.Complete();
            //}
        }

        public String CalculateMonthCollectorBLPayment(String strCollector)
        {
            // using (TransactionScope trnScope = new TransactionScope())
            //{
            String Status = "";
            SqlParameter param = new SqlParameter();
            SqlParameter statusParam = new SqlParameter();
            List<SqlParameter> paramList = new List<SqlParameter>();
            param = SQLHelper.CreateParameter("@FromDate", SqlDbType.DateTime);
            param.Value = Convert.ToDateTime(DtFromDate.ToShortDateString());
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@ToDate", SqlDbType.DateTime);
            param.Value = Convert.ToDateTime(DtToDate.ToShortDateString());
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@CollectorCode", SqlDbType.VarChar, 50);
            param.Value = StrCollector;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@userId", SqlDbType.VarChar, 50);
            param.Value = BLUser.StrUserName;
            paramList.Add(param);
            SqlCommand cmd = new SqlCommand();
            cmd = SQLHelper.CreateCommand("spCalculateBLCollectorPayment", CommandType.StoredProcedure, paramList);
            statusParam = cmd.Parameters.Add("@state", SqlDbType.VarChar, 50);
            statusParam.Direction = ParameterDirection.Output;
            SQLHelper.ExecuteNonQuery(cmd);
            Status = statusParam.Value.ToString();
            cmd.Dispose();
            return Status;
            // trnScope.Complete();
            //}
        }

        public String ConfirmMonthBLPayment(String strSupplier, String strRoute)
        {
            // using (TransactionScope trnScope = new TransactionScope())
            //{
            String Status = "";
            SqlParameter param = new SqlParameter();
            SqlParameter statusParam = new SqlParameter();
            List<SqlParameter> paramList = new List<SqlParameter>();
            param = SQLHelper.CreateParameter("@ProYear", SqlDbType.Int);
            param.Value = IntProYear;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@ProMonth", SqlDbType.Int);
            param.Value = IntProMonth;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@Route", SqlDbType.VarChar, 50);
            param.Value = strRoute;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@SupplierCode", SqlDbType.VarChar, 50);
            param.Value = strSupplier;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@userId", SqlDbType.VarChar, 50);
            param.Value = BLUser.StrUserName;
            paramList.Add(param);
            SqlCommand cmd = new SqlCommand();
            cmd = SQLHelper.CreateCommand("spConfirmBLPayment", CommandType.StoredProcedure, paramList);
            statusParam = cmd.Parameters.Add("@state", SqlDbType.VarChar, 50);
            statusParam.Direction = ParameterDirection.Output;
            SQLHelper.ExecuteNonQuery(cmd);
            Status = statusParam.Value.ToString();
            cmd.Dispose();
            return Status;
            // trnScope.Complete();
            //}
        }

        public void InsertProcessConfirmationDetails(String Route, Int32 intYear,Int32 intMonth)
        {
            SQLHelper.ExecuteNonQuery(" INSERT INTO [dbo].[BLProcessDetails] ([Route] ,[ProcessedYear] ,[ProcessedMonth] ,[ProcessedYesNo] ,[CreatedDatetime] ,[UserID]) VALUES ('" + Route + "' ,'" + intYear + "' ,'" + intMonth + "',1,getdate() ,'User')", CommandType.Text);
        }

        public String CancleMonthBLPayment( String strRoute)
        {
            // using (TransactionScope trnScope = new TransactionScope())
            //{
            String Status = "";
            SqlParameter param = new SqlParameter();
            SqlParameter statusParam = new SqlParameter();
            List<SqlParameter> paramList = new List<SqlParameter>();
            param = SQLHelper.CreateParameter("@PROYear", SqlDbType.Int);
            param.Value = IntProYear;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@PROMonth", SqlDbType.Int);
            param.Value = IntProMonth;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@Route", SqlDbType.VarChar, 50);
            param.Value = strRoute;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@userId", SqlDbType.VarChar, 50);
            param.Value = BLUser.StrUserName;
            paramList.Add(param);
            SqlCommand cmd = new SqlCommand();
            cmd = SQLHelper.CreateCommand("spCancelBLPayment", CommandType.StoredProcedure, paramList);
            statusParam = cmd.Parameters.Add("@state", SqlDbType.VarChar, 50);
            statusParam.Direction = ParameterDirection.Output;
            SQLHelper.ExecuteNonQuery(cmd);
            Status = statusParam.Value.ToString();
            cmd.Dispose();
            return Status;
            // trnScope.Complete();
            //}
        }

        public String CancleMonthCollectorBLPayment(String strCollector)
        {
            // using (TransactionScope trnScope = new TransactionScope())
            //{
            String Status = "";
            SqlParameter param = new SqlParameter();
            SqlParameter statusParam = new SqlParameter();
            List<SqlParameter> paramList = new List<SqlParameter>();
            param = SQLHelper.CreateParameter("@PROYear", SqlDbType.Int);
            param.Value = IntProYear;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@PROMonth", SqlDbType.Int);
            param.Value = IntProMonth;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@CollectorCode", SqlDbType.VarChar, 50);
            param.Value = StrCollector;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@userId", SqlDbType.VarChar, 50);
            param.Value = BLUser.StrUserName;
            paramList.Add(param);
            SqlCommand cmd = new SqlCommand();
            cmd = SQLHelper.CreateCommand("spCancelBLCollectorPayment", CommandType.StoredProcedure, paramList);
            statusParam = cmd.Parameters.Add("@state", SqlDbType.VarChar, 50);
            statusParam.Direction = ParameterDirection.Output;
            SQLHelper.ExecuteNonQuery(cmd);
            Status = statusParam.Value.ToString();
            cmd.Dispose();
            return Status;
            // trnScope.Complete();
            //}
        }

        public DataSet getProcessEntries(Int32 intYear,Int32 intMonth,String strRoute)
        {
            DataSet ds = SQLHelper.FillDataSet("SELECT ProcessedYear, ProcessedMonth, Route, ProcessedYesNo FROM  dbo.BLProcessDetails WHERE (ProcessedYesNo = 1) AND (ProcessedYear = '" + intYear + "') AND (ProcessedMonth = '" + intMonth + "')", CommandType.Text);
            return ds;
        }

        public String OpenNewMonth(Int32 intYear, Int32 intMonth, DateTime dtStartDate,String userID)
        {
            String Status = "";
            SqlParameter param = new SqlParameter();
            SqlParameter statusParam = new SqlParameter();
            List<SqlParameter> paramList = new List<SqlParameter>();
            param = SQLHelper.CreateParameter("@nxYear", SqlDbType.Int);
            param.Value = intYear;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@nxMonth", SqlDbType.Int);
            param.Value = intMonth;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@nxStDate", SqlDbType.Date);
            param.Value = dtStartDate;
            paramList.Add(param);
            param = SQLHelper.CreateParameter("@userId", SqlDbType.VarChar, 50);
            param.Value = BLUser.StrUserName;
            paramList.Add(param);
            SqlCommand cmd = new SqlCommand();
            cmd = SQLHelper.CreateCommand("SPAddNewMonth", CommandType.StoredProcedure, paramList);
            statusParam = cmd.Parameters.Add("@state", SqlDbType.VarChar, 50);
            statusParam.Direction = ParameterDirection.Output;
            SQLHelper.ExecuteNonQuery(cmd);
            Status = statusParam.Value.ToString();
            cmd.Dispose();
            return Status;
        }

        

    }
}
