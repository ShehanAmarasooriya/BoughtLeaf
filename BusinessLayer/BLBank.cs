using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BoughtLeafDataAccess;

namespace BoughtLeafBusinessLayer
{
    public class BLBank
    {
        private String strBankCode;

        public String StrBankCode
        {
            get { return strBankCode; }
            set { strBankCode = value; }
        }
        private String strBankName;

        public String StrBankName
        {
            get { return strBankName; }
            set { strBankName = value; }
        }

        public void InsertBank()
        {
            SQLHelper.ExecuteNonQuery("insert into Bank (BankCode,BankName) values ('" + StrBankCode + "','" + StrBankName + "')", CommandType.Text);
        }

        public void UpdateBank()
        {
            SQLHelper.ExecuteNonQuery("update Bank set BankName = '" + StrBankName + "' where BankCode = '" + StrBankCode + "'", CommandType.Text);
        }

        public void DeleteBank()
        {
            SQLHelper.ExecuteNonQuery("delete from Bank where BankCode = '" + StrBankCode + "'", CommandType.Text);
        }

        public DataTable ListBankDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("BankCode"));
            dt.Columns.Add(new DataColumn("BankName"));
            dt.Columns.Add(new DataColumn("CreateDateTime"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT BankCode, BankName, CreateDateTime FROM dbo.Bank order by BankName", CommandType.Text);

            while (dataReader.Read())
            {
                dtrow = dt.NewRow();

                if (!dataReader.IsDBNull(0))
                {
                    dtrow[0] = dataReader.GetString(0).Trim();
                }

                if (!dataReader.IsDBNull(1))
                {
                    dtrow[1] = dataReader.GetString(1).Trim();
                }
                if (!dataReader.IsDBNull(2))
                {
                    dtrow[2] = dataReader.GetDateTime(2).ToString();
                }
                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }

        public DataSet getBankwiseReport(int pYear, int pMonth)
        {

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            //da.SelectCommand = SQLHelper.CreateCommand("SELECT SUM(dbo.MonthlyPaymentSummary.NetPay) AS FinalBalance, dbo.Supplier.BankBranch, dbo.BankBranch.BranchName, dbo.Bank.BankName, dbo.Bank.BankCode,dbo.MonthlyPaymentSummary.SupplierCode FROM dbo.Bank INNER JOIN dbo.Supplier ON dbo.Bank.BankCode = dbo.Supplier.BankCode INNER JOIN dbo.MonthlyPaymentSummary ON dbo.Supplier.SupplierCode = dbo.MonthlyPaymentSummary.SupplierCode INNER JOIN dbo.BankBranch ON dbo.Supplier.BankBranch = dbo.BankBranch.BranchCode WHERE (dbo.MonthlyPaymentSummary.Year = '" + pYear + "') AND (dbo.MonthlyPaymentSummary.Month = '" + pMonth + "') GROUP BY dbo.Supplier.BankBranch, dbo.Bank.BankName, dbo.Bank.BankCode, dbo.MonthlyPaymentSummary.SupplierCode, dbo.BankBranch.BranchName HAVING (dbo.Supplier.BankBranch <> N'NA') AND (SUM(dbo.MonthlyPaymentSummary.NetPay) >= 0) AND (dbo.Bank.BankName <> 'NA') AND (dbo.Bank.BankCode <> 'NA')", CommandType.Text);
            da.SelectCommand = SQLHelper.CreateCommand("SELECT SUM(dbo.MonthlyPaymentSummary.PaymentDue) AS FinalBalance, dbo.Supplier.BankBranch, dbo.BankBranch.BranchName, dbo.Bank.BankName, dbo.Bank.BankCode,  dbo.MonthlyPaymentSummary.SupplierCode FROM            dbo.MonthlyPaymentSummary INNER JOIN dbo.Supplier ON dbo.MonthlyPaymentSummary.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.BankBranch ON dbo.Supplier.BankBranch = dbo.BankBranch.BranchCode AND dbo.Supplier.BankCode = dbo.BankBranch.BankCode INNER JOIN dbo.Bank ON dbo.BankBranch.BankCode = dbo.Bank.BankCode WHERE        (dbo.MonthlyPaymentSummary.Year = '" + pYear + "') AND (dbo.MonthlyPaymentSummary.Month = '" + pMonth + "') AND (dbo.Supplier.SalarySendBank = 1) GROUP BY dbo.Supplier.BankBranch, dbo.Bank.BankName, dbo.Bank.BankCode, dbo.MonthlyPaymentSummary.SupplierCode, dbo.BankBranch.BranchName HAVING        (SUM(dbo.MonthlyPaymentSummary.PaymentDue) >= 0)", CommandType.Text);
            da.Fill(ds, "bankReport");
            return ds;
        }

        public DataSet getBankwiseReportRouteWise(Int32 Year, Int32 Month, string route)
        {

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            //da.SelectCommand = SQLHelper.CreateCommand("SELECT     SUM(dbo.MonthlyPayments.FinalBalance) AS FinalBalance, dbo.Supplier.BankBranch, dbo.Branch.BranchCode, dbo.Bank.BankName, dbo.Bank.BankCode FROM         dbo.MonthlyPayments INNER JOIN dbo.Supplier ON dbo.MonthlyPayments.SupplierCode = dbo.Supplier.SupplierCode AND dbo.MonthlyPayments.RouteNo = dbo.Supplier.TownCode INNER JOIN  dbo.Bank ON dbo.Supplier.BankCode = dbo.Bank.BankCode INNER JOIN   dbo.Branch ON dbo.Supplier.BankBranch = dbo.Branch.BankCode WHERE     (dbo.MonthlyPayments.Year = '" + Year + "') AND (dbo.MonthlyPayments.Month = '" + Month + "') AND (dbo.MonthlyPayments.RouteNo = '" + route + "') GROUP BY dbo.Supplier.BankBranch, dbo.Bank.BankName, dbo.Bank.BankCode, dbo.Branch.BranchCode", CommandType.Text);
            da.SelectCommand = SQLHelper.CreateCommand("SELECT     SUM(dbo.MonthlyPaymentSummary.NetPay) AS FinalBalance, dbo.Supplier.BankBranch, dbo.BankBranch.BranchName, dbo.Bank.BankName, dbo.Bank.BankCode FROM         dbo.MonthlyPaymentSummary INNER JOIN dbo.Supplier ON dbo.MonthlyPaymentSummary.SupplierCode = dbo.Supplier.SupplierCode AND dbo.MonthlyPaymentSummary.RouteCode = dbo.Supplier.RouteCode INNER JOIN  dbo.Bank ON dbo.Supplier.BankCode = dbo.Bank.BankCode INNER JOIN   dbo.BankBranch ON dbo.Supplier.BankBranch = dbo.BankBranch.BranchCode WHERE     (dbo.MonthlyPaymentSummary.Year = '" + Year + "') AND (dbo.MonthlyPaymentSummary.Month = '" + Month + "') AND (dbo.MonthlyPaymentSummary.RouteCode = '" + route + "') GROUP BY dbo.Supplier.BankBranch, dbo.Bank.BankName, dbo.Bank.BankCode, dbo.BankBranch.BranchName", CommandType.Text);

            da.Fill(ds, "bankReport");
            return ds;
        }


        public DataSet getCheckPaymentReport(Int32 pYear, Int32 pMonth)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();

            da.SelectCommand = SQLHelper.CreateCommand("SELECT        TOP (100) PERCENT dbo.MonthlyPaymentSummary.SupplierCode, dbo.Supplier.SupplierName, dbo.Supplier.TrnCode, dbo.MonthlyPaymentSummary.GreenLeafKillo,  dbo.MonthlyPaymentSummary.PaymentDue AS 'FinalBalance', dbo.Supplier.RouteCode FROM            dbo.Supplier INNER JOIN dbo.MonthlyPaymentSummary ON dbo.Supplier.SupplierCode = dbo.MonthlyPaymentSummary.SupplierCode INNER JOIN dbo.Route ON dbo.Supplier.RouteCode = dbo.Route.RouteCode WHERE        (dbo.MonthlyPaymentSummary.Month = '" + pMonth + "') AND (dbo.MonthlyPaymentSummary.Year = '" + pYear + "') AND  (dbo.MonthlyPaymentSummary.PaymentDue > 0) AND (dbo.MonthlyPaymentSummary.PaymentMode = 'cheque')   ORDER BY ABS(dbo.Supplier.SupplierCode)", CommandType.Text);
            da.Fill(ds, "checkPayment");
            return ds;
        }

        public Decimal getCheckPaymentTotal(Int32 Year, Int32 Month)
        {
            Decimal decCheckTotal = 0;
            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT SUM(PaymentDue) AS Expr2 FROM dbo.MonthlyPaymentSummary WHERE (Year = '"+ Year + "') AND (Month = '"+ Month +"') AND (PaymentDue > 0) AND (PaymentMode = 'Cheque')", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                    decCheckTotal = dataReader.GetDecimal(0);
            }
            dataReader.Close();
            return decCheckTotal;
        }

        //edited sachintha 2016.10.17

        //illukthanna value not taly
        public Decimal getCheckPaymentTotalIlluk(Int32 Year, Int32 Month)
        {
            Decimal decCheckTotal = 0;
            DataSet ds;
            //da.SelectCommand = SQLHelper.CreateCommand("SELECT  dbo.MonthlyPayments.SupplierCode, dbo.Supplier.SupplierName, dbo.Supplier.TrnCode, dbo.MonthlyPayments.TotalGreenLeaf,dbo.MonthlyPayments.FinalBalance, dbo.trabsportCost.trnCost FROM  dbo.trabsportCost FULL OUTER JOIN dbo.Supplier ON dbo.trabsportCost.trnCode = dbo.Supplier.TrnCode FULL OUTER JOIN dbo.MonthlyPayments ON dbo.Supplier.SupplierCode = dbo.MonthlyPayments.SupplierCode AND  dbo.Supplier.TownCode = dbo.MonthlyPayments.RouteNo FULL OUTER JOIN dbo.Route ON dbo.Supplier.TownCode = dbo.Route.TownCode CROSS JOIN dbo.OtherPaymentSettings WHERE     (dbo.Supplier.BankCode = 'NA') AND (dbo.MonthlyPayments.Year = '"+ Year +"') AND (dbo.MonthlyPayments.Month = '"+ Month +"') AND (dbo.MonthlyPayments.TotalAmount <> 0)ORDER BY ABS(dbo.Supplier.SupplierCode)", CommandType.Text); 
            ds = SQLHelper.FillDataSet("SELECT     SUM(dbo.MonthlyPayments.FinalBalance) AS Expr1 FROM         dbo.Supplier INNER JOIN dbo.MonthlyPayments ON dbo.Supplier.SupplierCode = dbo.MonthlyPayments.SupplierCode INNER JOIN dbo.Route ON dbo.Supplier.TownCode = dbo.Route.TownCode WHERE     (dbo.MonthlyPayments.Year = '" + Year + "') AND (dbo.MonthlyPayments.Month = '" + Month + "') AND (dbo.Supplier.BankCode = 'NA') AND  (dbo.MonthlyPayments.FinalBalance > 0)", CommandType.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                decCheckTotal = Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString());
            }
            return decCheckTotal;
        }


        public DataSet GetSupplierPaymentToBank(int payYear, int payMonth, string routeCode)
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
                ds = SQLHelper.FillDataSet("GetSupplierPaymentToBank", CommandType.StoredProcedure, paramList);
                return ds;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
