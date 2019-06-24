using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BoughtLeafDataAccess;

namespace BoughtLeafBusinessLayer
{
    public class OtherIssues
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
        private DateTime datIssueDate;

        public DateTime DatIssueDate
        {
            get { return datIssueDate; }
            set { datIssueDate = value; }
        }
        private String strIssuedItem;

        public String StrIssuedItem
        {
            get { return strIssuedItem; }
            set { strIssuedItem = value; }
        }
        private Decimal decAmount;

        public Decimal DecAmount
        {
            get { return decAmount; }
            set { decAmount = value; }
        }
        private Decimal decAmountSettled;

        public Decimal DecAmountSettled
        {
            get { return decAmountSettled; }
            set { decAmountSettled = value; }
        }
        private String strRemarks;

        public String StrRemarks
        {
            get { return strRemarks; }
            set { strRemarks = value; }
        }
        public void InsertIssues(String Route)
        {
            SQLHelper.ExecuteNonQuery("insert into OtherIssues (YearCode,MonthCode,IssueDate,SupplierCode,IssuedItem,Amount,AmountSettled,Remarks,UserID,RouteNo) values ('" + IntYearCode + "','" + IntMonthCode + "','" + DatIssueDate + "','" + StrSupplierCode + "','" + StrIssuedItem + "','" + DecAmount + "','" + DecAmountSettled + "','" + StrRemarks + "','" + BoughtLeafBusinessLayer.BLUser.StrUserName + "','" + Route + "')", CommandType.Text);
        }
        public DataTable ListIssues(String RoughtNo)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Year"));
            dt.Columns.Add(new DataColumn("MonthCode"));
            dt.Columns.Add(new DataColumn("MonthName"));
            dt.Columns.Add(new DataColumn("SupplierCode"));
            dt.Columns.Add(new DataColumn("SupplierName"));
            dt.Columns.Add(new DataColumn("IssueDate"));
            dt.Columns.Add(new DataColumn("IssueItem"));
            dt.Columns.Add(new DataColumn("Amount"));
            dt.Columns.Add(new DataColumn("AmountSettled"));
            dt.Columns.Add(new DataColumn("Remarks"));
            dt.Columns.Add(new DataColumn("CreateDateTime"));
            dt.Columns.Add(new DataColumn("UserID"));
            dt.Columns.Add(new DataColumn("CancelEntry"));
            dt.Columns.Add(new DataColumn("Processed"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT dbo.OtherIssues.YearCode, dbo.OtherIssues.MonthCode, dbo.Month.MonthName, dbo.OtherIssues.SupplierCode, dbo.Supplier.SupplierName, dbo.OtherIssues.IssueDate, dbo.OtherIssues.IssuedItem, dbo.OtherIssues.Amount, dbo.OtherIssues.AmountSettled, dbo.OtherIssues.Remarks, dbo.OtherIssues.CreateDateTime, dbo.OtherIssues.UserID, dbo.OtherIssues.Cancel, dbo.OtherIssues.Processed FROM dbo.OtherIssues INNER JOIN dbo.Month ON dbo.OtherIssues.MonthCode = dbo.Month.MonthCode INNER JOIN dbo.Supplier ON dbo.OtherIssues.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.Town ON dbo.Supplier.TownCode = dbo.Town.TownCode AND dbo.OtherIssues.RouteNo = dbo.Town.TownName WHERE (dbo.OtherIssues.RouteNo = '"+RoughtNo+"')", CommandType.Text);

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
                    dtrow[6] = dataReader.GetString(6);
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
                    dtrow[9] = dataReader.GetString(9);
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
                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }
        public Decimal getSupplierIssues(Int32 Year, Int32 Month)
        {
            Decimal GreenLeaf = 0;

            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT SUM(Amount) AS Amount FROM dbo.OtherIssues WHERE (Cancel = 0) AND (Processed = 0) AND (YearCode = '" + Year + "') AND (MonthCode = '" + Month + "') AND (SupplierCode = '" + StrSupplierCode + "')", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    GreenLeaf = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();
            return GreenLeaf;
        }
        public void UpdateAsProcessed(Int32 year, Int32 month)
        {
            SQLHelper.ExecuteNonQuery("update OtherIssues set Processed=1 where YearCode = '" + year + "' and MonthCode = '" + month + "' and SupplierCode = '" + StrSupplierCode + "'", CommandType.Text);
        }
        public void CancelUpdateAsProcessed(Int32 year, Int32 month)
        {
            SQLHelper.ExecuteNonQuery("update OtherIssues set Processed=0 where YearCode = '" + year + "' and MonthCode = '" + month + "'", CommandType.Text);
        }
    }
}
