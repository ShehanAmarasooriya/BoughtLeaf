using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BoughtLeafDataAccess;

namespace BoughtLeafBusinessLayer
{
    public class PayslipCls
    {

        public DataSet getmastersetingforpayslip()
        {
            DataSet ds = new DataSet();
            ds = SQLHelper.FillDataSet("SELECT Name,Type  FROM [dbo].[BLMasterSettings] where Type = 'PrePrintedPaySlip'", CommandType.Text);
            //return SQLHelper.FillDataSet("SELECT f.[RegNo],f.[FactoryName],f.[Extent],ps.[SupplierCode],s.[SupplierName],ps.[Year],ps.[Month],ps.[TownCode] ,ps.[GreenLeafKillo],ps.[GreenLeafRate],ps.[GreenLeafValue],ps.[Incentive],ps.[OtherAddition],ps.[TotalEarning],ps.[TotalDeduction],ps.[PaymentDue],ps.[NetPay] FROM [dbo].[MonthlyPaymentSummary] ps, [dbo].[Supplier] s CROSS JOIN [dbo].[Factory] f WHERE S.SupplierCode = ps.SupplierCode AND ps.Year = " + year + " AND ps.Month = " + month + " AND ps.TownCode = '" + routeCode + "' ORDER BY CONVERT(int, ps.[SupplierCode])", CommandType.Text).Tables[0];

            return ds;
        }

        public DataSet GetSupplierPaymentForPaySlipGeneral(int payYear, int payMonth, string routeCode)
        {
            try
            {
                SqlParameter param = new SqlParameter();
                List<SqlParameter> paramList = new List<SqlParameter>();

                param = SQLHelper.CreateParameter("@PayYear", SqlDbType.Int);
                param.Value = payYear;
                paramList.Add(param);
                param = SQLHelper.CreateParameter("@PayMonth", SqlDbType.Int);
                param.Value = payMonth;
                paramList.Add(param);
                param = SQLHelper.CreateParameter("@RouteCode", SqlDbType.VarChar, 50);
                param.Value = routeCode;
                paramList.Add(param);
                DataSet ds;
                ds = SQLHelper.FillDataSet("GetSupplierPaymentForPaySlipGeneral", CommandType.StoredProcedure, paramList);
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet GetSupplierPaymentForPaySlipGreenLeaf(int payYear, int payMonth, string routeCode)
        {
            try
            {
                SqlParameter param = new SqlParameter();
                List<SqlParameter> paramList = new List<SqlParameter>();

                param = SQLHelper.CreateParameter("@PayYear", SqlDbType.Int);
                param.Value = payYear;
                paramList.Add(param);
                param = SQLHelper.CreateParameter("@PayMonth", SqlDbType.Int);
                param.Value = payMonth;
                paramList.Add(param);
                param = SQLHelper.CreateParameter("@RouteCode", SqlDbType.VarChar, 50);
                param.Value = routeCode;
                paramList.Add(param);
                DataSet ds;
                ds = SQLHelper.FillDataSet("GetSupplierPaymentForPaySlipGreenLeaf_new", CommandType.StoredProcedure, paramList);
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet GetSupplierPaymentForPaySlipThisMonthIssues(int payYear, int payMonth, string routeCode)
        {
            try
            {
                SqlParameter param = new SqlParameter();
                List<SqlParameter> paramList = new List<SqlParameter>();

                param = SQLHelper.CreateParameter("@PayYear", SqlDbType.Int);
                param.Value = payYear;
                paramList.Add(param);
                param = SQLHelper.CreateParameter("@PayMonth", SqlDbType.Int);
                param.Value = payMonth;
                paramList.Add(param);
                param = SQLHelper.CreateParameter("@RouteCode", SqlDbType.VarChar, 50);
                param.Value = routeCode;
                paramList.Add(param);
                DataSet ds;
                ds = SQLHelper.FillDataSet("GetSupplierPaymentForPaySlipThisMonthIssues_new", CommandType.StoredProcedure, paramList);
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

}
