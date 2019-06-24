using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BoughtLeafDataAccess;

namespace BoughtLeafBusinessLayer
{
    public class AdvancePayment
    {
        private Int32 intYearCode;

        public Int32 IntYearCode
        {
            get { return intYearCode; }
            set { intYearCode = value; }
        }
        private Int32 intMonthCode;

        public Int32 IntMonthCode
        {
            get { return intMonthCode; }
            set { intMonthCode = value; }
        }
        private String strSupplierCode;

        public String StrSupplierCode
        {
            get { return strSupplierCode; }
            set { strSupplierCode = value; }
        }
        private DateTime datAdvanceIssueDate;

        public DateTime DatAdvanceIssueDate
        {
            get { return datAdvanceIssueDate; }
            set { datAdvanceIssueDate = value; }
        }
        private Decimal decTotalGreenLeaf;

        public Decimal DecTotalGreenLeaf
        {
            get { return decTotalGreenLeaf; }
            set { decTotalGreenLeaf = value; }
        }
        private Decimal decGreenLeafForAdvance;

        public Decimal DecGreenLeafForAdvance
        {
            get { return decGreenLeafForAdvance; }
            set { decGreenLeafForAdvance = value; }
        }
        private Decimal decAdvanceAmount;

        public Decimal DecAdvanceAmount
        {
            get { return decAdvanceAmount; }
            set { decAdvanceAmount = value; }
        }
        private Decimal decOustandingAmount;

        public Decimal DecOustandingAmount
        {
            get { return decOustandingAmount; }
            set { decOustandingAmount = value; }
        }
        private String strTownCode;

        public String StrTownCode
        {
            get { return strTownCode; }
            set { strTownCode = value; }
        }

        public void InsertAdvance(String RouteNo, Decimal AdvancePaymentRate, Decimal AdvanceGivenPercentage)
        {
            SQLHelper.ExecuteNonQuery("insert into SupplierAdvances (YearCode,MonthCode,SupplierCode,AdvanceIssueDate,TotalGreenLeaf,GreenLeafForAdvance,AdvanceAmount,OustandingAmount,UserID,RouteNo,AdvancePaymentRate,AdvanceGivenPercentage) values ('" + IntYearCode + "','" + IntMonthCode + "','" + StrSupplierCode + "','" + DatAdvanceIssueDate + "','" + DecTotalGreenLeaf + "','" + DecGreenLeafForAdvance + "','" + DecAdvanceAmount + "','" + DecOustandingAmount + "','" + BoughtLeafBusinessLayer.BLUser.StrUserName + "','" + RouteNo + "','" + AdvancePaymentRate + "','" + AdvanceGivenPercentage + "')", CommandType.Text);
        }

        /// <summary>
        /// Sachintha Udara  2017.02.01
        /// </summary>
        /// <returns></returns>
        
        public DataTable AdvanceApprovalList() 
        {
            return SQLHelper.FillDataSet("SELECT dbo.SupplierAdvances.Approval, dbo.SupplierAdvances.SupplierCode, dbo.Supplier.SupplierName, dbo.SupplierAdvances.RouteNo, dbo.SupplierAdvances.YearCode, dbo.SupplierAdvances.MonthCode, dbo.SupplierAdvances.AdvanceIssueDate, dbo.SupplierAdvances.AdvanceAmount FROM dbo.SupplierAdvances INNER JOIN dbo.Supplier ON dbo.SupplierAdvances.SupplierCode = dbo.Supplier.SupplierCode WHERE (dbo.SupplierAdvances.CancelEntry = 0)", CommandType.Text).Tables[0];
        }

        public void ApprovalAdvance(int pYear, int pMonth, DateTime pIssueDate, string pSupCode, string pRoute, bool pApproval) 
        {
            SQLHelper.ExecuteNonQuery("update SupplierAdvances set Approval = '" + pApproval + "' where YearCode = '" + pYear + "' and MonthCode= '" + pMonth + "' and AdvanceIssueDate = '" + pIssueDate + "' and SupplierCode = '" + pSupCode + "' and RouteNo = '" + pRoute + "'", CommandType.Text);
        }

        public DataTable ListAdvancess(String RoughtNo)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Year"));
            dt.Columns.Add(new DataColumn("MonthCode"));
            dt.Columns.Add(new DataColumn("MonthName"));
            dt.Columns.Add(new DataColumn("SupplierCode"));
            dt.Columns.Add(new DataColumn("SupplierName"));
            dt.Columns.Add(new DataColumn("AdvanceIssueDate"));
            dt.Columns.Add(new DataColumn("TotalGreenLeaf"));
            dt.Columns.Add(new DataColumn("GreenLeafForAdvance"));
            dt.Columns.Add(new DataColumn("AdvanceAmount"));
            dt.Columns.Add(new DataColumn("OustandingAmount"));
            dt.Columns.Add(new DataColumn("CreateDateTime"));
            dt.Columns.Add(new DataColumn("UserID"));
            dt.Columns.Add(new DataColumn("CancelEntry"));
            dt.Columns.Add(new DataColumn("Processed"));
            dt.Columns.Add(new DataColumn("AdvancePaymentRate"));
            dt.Columns.Add(new DataColumn("AdvanceGivenPercentage"));
          //  dt.Columns.Add(new DataColumn("RouteNo"));


            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT dbo.SupplierAdvances.YearCode, dbo.SupplierAdvances.MonthCode, dbo.Month.MonthName, dbo.SupplierAdvances.SupplierCode, dbo.Supplier.SupplierName, dbo.SupplierAdvances.AdvanceIssueDate, dbo.SupplierAdvances.TotalGreenLeaf, dbo.SupplierAdvances.GreenLeafForAdvance, dbo.SupplierAdvances.AdvanceAmount, dbo.SupplierAdvances.OustandingAmount, dbo.SupplierAdvances.CreateDateTime, dbo.SupplierAdvances.UserID, dbo.SupplierAdvances.CancelEntry, dbo.SupplierAdvances.Processed,dbo.SupplierAdvances.AdvancePaymentRate,dbo.SupplierAdvances.AdvanceGivenPercentage FROM dbo.SupplierAdvances INNER JOIN dbo.Month ON dbo.SupplierAdvances.MonthCode = dbo.Month.MonthCode INNER JOIN dbo.Supplier ON dbo.SupplierAdvances.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.Town ON dbo.Supplier.TownCode = dbo.Town.TownCode AND dbo.SupplierAdvances.RouteNo = dbo.Town.TownName WHERE (dbo.SupplierAdvances.RouteNo = '" + RoughtNo + "')", CommandType.Text);

            while (dataReader.Read())
            {
                dtrow = dt.NewRow();

                if (!dataReader.IsDBNull(0))
                {
                    dtrow[0] = dataReader.GetInt32(0);
                }
                if (!dataReader.IsDBNull(1))
                {
                    dtrow[1] = dataReader.GetInt32(1);
                }
                if (!dataReader.IsDBNull(2))
                {
                    dtrow[2] = dataReader.GetString(2).ToString();
                }
                if (!dataReader.IsDBNull(3))
                {
                    dtrow[3] = dataReader.GetString(3);
                }
                if (!dataReader.IsDBNull(4))
                {
                    dtrow[4] = dataReader.GetString(4);
                }
                if (!dataReader.IsDBNull(5))
                {
                    dtrow[5] = dataReader.GetDateTime(5).ToShortDateString();
                }
                if (!dataReader.IsDBNull(6))
                {
                    dtrow[6] = dataReader.GetDecimal(6);
                }
                if (!dataReader.IsDBNull(7))
                {
                    dtrow[7] = dataReader.GetDecimal(7);
                }
                if (!dataReader.IsDBNull(8))
                {
                    dtrow[8] = dataReader.GetDecimal(8);
                }
                if (!dataReader.IsDBNull(9))
                {
                    dtrow[9] = dataReader.GetDecimal(9);
                }
                if (!dataReader.IsDBNull(10))
                {
                    dtrow[10] = dataReader.GetDateTime(10);
                }
                if (!dataReader.IsDBNull(11))
                {
                    dtrow[11] = dataReader.GetString(11);
                }
                if (!dataReader.IsDBNull(12))
                {
                    dtrow[12] = dataReader.GetBoolean(12);
                }
                if (!dataReader.IsDBNull(13))
                {
                    dtrow[13] = dataReader.GetBoolean(13);
                }
                if (!dataReader.IsDBNull(14))
                {
                    dtrow[14] = dataReader.GetDecimal(14);
                }
                if (!dataReader.IsDBNull(15))
                {
                    dtrow[15] = dataReader.GetDecimal(15);
                }
                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }
        public DataTable ListAdvances(String RoughtNo, DateTime AdvanceDate)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Year"));
            dt.Columns.Add(new DataColumn("MonthCode"));
            dt.Columns.Add(new DataColumn("MonthName"));
            dt.Columns.Add(new DataColumn("SupplierCode"));
            dt.Columns.Add(new DataColumn("SupplierName"));
            dt.Columns.Add(new DataColumn("AdvanceIssueDate"));
            dt.Columns.Add(new DataColumn("TotalGreenLeaf"));
            dt.Columns.Add(new DataColumn("GreenLeafForAdvance"));
            dt.Columns.Add(new DataColumn("AdvanceAmount"));
            dt.Columns.Add(new DataColumn("OustandingAmount"));
            dt.Columns.Add(new DataColumn("CreateDateTime"));
            dt.Columns.Add(new DataColumn("UserID"));
            dt.Columns.Add(new DataColumn("CancelEntry"));
            dt.Columns.Add(new DataColumn("Processed"));
            dt.Columns.Add(new DataColumn("AdvancePaymentRate"));
            dt.Columns.Add(new DataColumn("AdvanceGivenPercentage"));
            //  dt.Columns.Add(new DataColumn("RouteNo"));


            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT dbo.SupplierAdvances.YearCode, dbo.SupplierAdvances.MonthCode, dbo.Month.MonthName, dbo.SupplierAdvances.SupplierCode, dbo.Supplier.SupplierName, dbo.SupplierAdvances.AdvanceIssueDate, dbo.SupplierAdvances.TotalGreenLeaf, dbo.SupplierAdvances.GreenLeafForAdvance, dbo.SupplierAdvances.AdvanceAmount, dbo.SupplierAdvances.OustandingAmount, dbo.SupplierAdvances.CreateDateTime, dbo.SupplierAdvances.UserID, dbo.SupplierAdvances.CancelEntry, dbo.SupplierAdvances.Processed,dbo.SupplierAdvances.AdvancePaymentRate,dbo.SupplierAdvances.AdvanceGivenPercentage FROM dbo.SupplierAdvances INNER JOIN dbo.Month ON dbo.SupplierAdvances.MonthCode = dbo.Month.MonthCode INNER JOIN dbo.Supplier ON dbo.SupplierAdvances.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.Town ON dbo.Supplier.TownCode = dbo.Town.TownCode AND dbo.SupplierAdvances.RouteNo = dbo.Town.TownName WHERE (dbo.SupplierAdvances.RouteNo = '" + RoughtNo + "') AND (dbo.SupplierAdvances.AdvanceIssueDate = CONVERT(DATETIME, '" + AdvanceDate + "',102))", CommandType.Text);

            while (dataReader.Read())
            {
                dtrow = dt.NewRow();

                if (!dataReader.IsDBNull(0))
                {
                    dtrow[0] = dataReader.GetInt32(0);
                }
                if (!dataReader.IsDBNull(1))
                {
                    dtrow[1] = dataReader.GetInt32(1);
                }
                if (!dataReader.IsDBNull(2))
                {
                    dtrow[2] = dataReader.GetString(2).ToString();
                }
                if (!dataReader.IsDBNull(3))
                {
                    dtrow[3] = dataReader.GetString(3);
                }
                if (!dataReader.IsDBNull(4))
                {
                    dtrow[4] = dataReader.GetString(4);
                }
                if (!dataReader.IsDBNull(5))
                {
                    dtrow[5] = dataReader.GetDateTime(5).ToShortDateString();
                }
                if (!dataReader.IsDBNull(6))
                {
                    dtrow[6] = dataReader.GetDecimal(6);
                }
                if (!dataReader.IsDBNull(7))
                {
                    dtrow[7] = dataReader.GetDecimal(7);
                }
                if (!dataReader.IsDBNull(8))
                {
                    dtrow[8] = dataReader.GetDecimal(8);
                }
                if (!dataReader.IsDBNull(9))
                {
                    dtrow[9] = dataReader.GetDecimal(9);
                }
                if (!dataReader.IsDBNull(10))
                {
                    dtrow[10] = dataReader.GetDateTime(10);
                }
                if (!dataReader.IsDBNull(11))
                {
                    dtrow[11] = dataReader.GetString(11);
                }
                if (!dataReader.IsDBNull(12))
                {
                    dtrow[12] = dataReader.GetBoolean(12);
                }
                if (!dataReader.IsDBNull(13))
                {
                    dtrow[13] = dataReader.GetBoolean(13);
                }
                if (!dataReader.IsDBNull(14))
                {
                    dtrow[14] = dataReader.GetDecimal(14);
                }
                if (!dataReader.IsDBNull(15))
                {
                    dtrow[15] = dataReader.GetDecimal(15);
                }
                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }
        //commented by sachintha udara
        //2016.12.01
        //public Decimal getSupplierAdvances(Int32 Year, Int32 Month, String RouteNo, String RouteName)
        //{
        //    Decimal GreenLeaf = 0;
            
        //    DateTime IssueDate = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));

        //    SqlDataReader dataReader;
        //    dataReader = SQLHelper.ExecuteReader("SELECT  dbo.SupplierAdvances.AdvanceAmount, dbo.SupplierAdvances.YearCode, dbo.SupplierAdvances.MonthCode, dbo.SupplierAdvances.AdvanceIssueDate FROM dbo.SupplierAdvances INNER JOIN dbo.Route ON dbo.SupplierAdvances.RouteNo = dbo.Route.RouteNo WHERE (dbo.SupplierAdvances.SupplierCode = '" + StrSupplierCode + "') AND (dbo.Route.TownCode = '" + RouteNo + "') AND (dbo.SupplierAdvances.AdvanceIssueDate <= CONVERT(DATETIME, '" + IssueDate + "',102)) AND (dbo.SupplierAdvances.YearCode = '"+ Year +"') AND (dbo.SupplierAdvances.MonthCode = '"+ Month +"') ", CommandType.Text);
        //    while (dataReader.Read())
        //    {
        //        if (!dataReader.IsDBNull(0))
        //        {
        //            GreenLeaf = dataReader.GetDecimal(0);
        //            //SQLHelper.ExecuteNonQuery("insert into SupplierAdvancesSettlement (YearCode,MonthCode,SupplierCode,RouteNo,AdvanceIssueDate,SettledAmount) values ('" + dataReader.GetInt32(1) + "','" + dataReader.GetInt32(2) + "','" + StrSupplierCode + "','" + RouteNo + "','" + dataReader.GetDateTime(3) + "','" + dataReader.GetDecimal(0) + "')", CommandType.Text);
        //        }
        //    }
        //    dataReader.Close();

        //    SQLHelper.ExecuteNonQuery("update SupplierAdvances set OustandingAmount=0,Processed=1 where SupplierCode = '" + StrSupplierCode + "' and RouteNo = '" + RouteName + "' and AdvanceIssueDate <= CONVERT(DATETIME, '" + IssueDate + "',102)", CommandType.Text);

        //    Int32 LastYear = IssueDate.AddMonths(-1).Year;
        //    Int32 LastMonth = IssueDate.AddMonths(-1).Month;

        //    dataReader = SQLHelper.ExecuteReader("SELECT SUM(CashBalance) AS Expr1 FROM dbo.BFBalances WHERE (RouteNo = '" + RouteNo + "') AND (SupplierCode = '" + StrSupplierCode + "') AND (Year = '" + LastYear + "') AND (Month = '" + LastMonth + "')", CommandType.Text);
        //    while (dataReader.Read())
        //    {
        //        if (!dataReader.IsDBNull(0))
        //        {
        //            if (dataReader.GetDecimal(0) > 0)
        //                GreenLeaf = GreenLeaf + dataReader.GetDecimal(0);
        //            else
        //                GreenLeaf = GreenLeaf - dataReader.GetDecimal(0);
        //            SQLHelper.ExecuteNonQuery("update BFBalances set CashBalance = 0 where RouteNo = '" + RouteNo + "' and SupplierCode = '" + StrSupplierCode + "' and Year = '" + LastYear + "' and Month = '" + LastMonth + "'", CommandType.Text);
        //        }
        //    }
        //    dataReader.Close();

        //    return GreenLeaf;
        //}

        //SACHINTHA -20161028
        //REMOVE ROUTE FROM FILTERING
        public Decimal getSupplierAdvances(Int32 Year, Int32 Month, string pRoute)
        {
            Decimal GreenLeaf = 0;

            DateTime IssueDate = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month));

            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT AdvanceAmount, YearCode, MonthCode, AdvanceIssueDate FROM dbo.SupplierAdvances WHERE (SupplierCode = '" + StrSupplierCode + "') AND (AdvanceIssueDate <= CONVERT(DATETIME, '" + IssueDate + "', 102)) AND (YearCode = '" + Year + "') AND  (MonthCode = '" + Month + "')", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    GreenLeaf = dataReader.GetDecimal(0);
                    SQLHelper.ExecuteNonQuery("insert into SupplierAdvancesSettlement (YearCode,MonthCode,SupplierCode,RouteNo,AdvanceIssueDate,SettledAmount) values ('" + dataReader.GetInt32(1) + "','" + dataReader.GetInt32(2) + "','" + StrSupplierCode + "','" + pRoute + "','" + dataReader.GetDateTime(3) + "','" + dataReader.GetDecimal(0) + "')", CommandType.Text);
                }
            }
            dataReader.Close();

            SQLHelper.ExecuteNonQuery("update SupplierAdvances set OustandingAmount=0,Processed=1 where SupplierCode = '" + StrSupplierCode + "' and AdvanceIssueDate <= CONVERT(DATETIME, '" + IssueDate + "',102)", CommandType.Text);

            return GreenLeaf;
        }

        public void UpdateAsProcessed(Int32 year, Int32 month)
        {
            SQLHelper.ExecuteNonQuery("update SupplierAdvances set Processed=1 where YearCode = '" + year + "' and MonthCode = '" + month + "' and SupplierCode = '" + StrSupplierCode + "'", CommandType.Text);
        }
        public void CancelUpdateAsProcessed(Int32 year, Int32 month, String RouteNo, String RouteName)
        {
            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT SupplierCode, AdvanceIssueDate, SettledAmount FROM dbo.SupplierAdvancesSettlement WHERE (YearCode = '" + year + "') AND (MonthCode = '" + month + "') AND (RouteNo = '" + RouteNo + "')", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    SQLHelper.ExecuteNonQuery("update SupplierAdvances set Processed=0, OustandingAmount= OustandingAmount + '" + dataReader.GetDecimal(2) + "' where SupplierCode = '" + dataReader.GetString(0) + "' and RouteNo = '" + RouteName + "' and AdvanceIssueDate = '" + dataReader.GetDateTime(1) + "'", CommandType.Text);
                }
            }
            dataReader.Close();
            SQLHelper.ExecuteNonQuery("delete from SupplierAdvancesSettlement WHERE YearCode = '" + year + "' AND MonthCode = '" + month + "' AND RouteNo = '" + RouteNo + "'", CommandType.Text);
        }

        public void DeleteAdvance(string Route)
        {
            SQLHelper.ExecuteNonQuery("Delete   dbo.SupplierAdvances WHERE  (YearCode = '"+IntYearCode+"') AND (MonthCode = '"+IntMonthCode+"') AND (SupplierCode = '"+StrSupplierCode+"') AND (RouteNo = '"+Route+"')", CommandType.Text);
        }
    }
}
