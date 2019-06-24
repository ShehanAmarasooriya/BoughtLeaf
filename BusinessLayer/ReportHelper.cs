using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BoughtLeafDataAccess;

namespace BoughtLeafBusinessLayer
{
    public class ReportHelper
    {
        public String getCompanyName()
        {
            DataSet ds = SQLHelper.FillDataSet("SELECT dbo.Company.CompanyName FROM dbo.Company", CommandType.Text);

            return ds.Tables[0].Rows[0][0].ToString();

        }

        public String getFactoryName()
        {
            DataSet ds = SQLHelper.FillDataSet("SELECT FactoryName FROM dbo.Factory", CommandType.Text);

            return ds.Tables[0].Rows[0][0].ToString();
        }

        public DataSet getAdvancePayment(int pYear, int pMonth, string pRoute)
        {
            DataSet ds = SQLHelper.FillDataSet("SELECT dbo.SupplierAdvances.OustandingAmount, dbo.SupplierAdvances.YearCode, dbo.SupplierAdvances.MonthCode, dbo.SupplierAdvances.AdvanceIssueDate,  dbo.SupplierAdvances.RouteNo, dbo.Supplier.SupplierName, dbo.SupplierAdvances.SupplierCode, dbo.SupplierAdvances.AdvanceAmount, dbo.SupplierAdvances.AdvancePaymentRate, dbo.SupplierAdvances.AdvanceGivenPercentage, dbo.SupplierAdvances.GreenLeafForAdvance, dbo.SupplierAdvances.TotalGreenLeaf FROM dbo.SupplierAdvances INNER JOIN dbo.Supplier ON dbo.SupplierAdvances.SupplierCode = dbo.Supplier.SupplierCode WHERE (dbo.SupplierAdvances.YearCode = " + pYear + ") AND (dbo.SupplierAdvances.MonthCode = " + pMonth + ") AND  (dbo.SupplierAdvances.RouteNo = '" + pRoute + "')", CommandType.Text);

            return ds;
        }
    }
}
