using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BoughtLeafDataAccess;

namespace BoughtLeafBusinessLayer
{
    public class OtherAdditions
    {
        public DataTable ListAdditions(int pYear, int pMonth)
        {
            return SQLHelper.FillDataSet("SELECT dbo.OtherAdditions.YearCode, dbo.OtherAdditions.MonthCode, dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.OtherAdditions.Amount, dbo.OtherAdditions.Remarks, dbo.OtherAdditions.UserID, dbo.OtherAdditions.CreateDateTime, dbo.OtherAdditions.Cancel, dbo.OtherAdditions.Processed FROM dbo.OtherAdditions INNER JOIN dbo.Supplier ON dbo.OtherAdditions.SupplierCode = dbo.Supplier.SupplierCode WHERE (dbo.OtherAdditions.MonthCode = " + pMonth + ") AND (dbo.OtherAdditions.YearCode = " + pYear + ")", CommandType.Text).Tables[0];
        }

        public DataTable ListOtherAdditionForApproval(int pYear, int pMonth)
        {
            return SQLHelper.FillDataSet("SELECT dbo.OtherAdditions.SupplierCode, dbo.Supplier.SupplierName, dbo.OtherAdditions.YearCode, dbo.OtherAdditions.MonthCode, dbo.OtherAdditions.Approval, dbo.OtherAdditions.Amount, dbo.OtherAdditions.RouteNo, dbo.OtherAdditions.Remarks FROM dbo.OtherAdditions INNER JOIN dbo.Supplier ON dbo.OtherAdditions.SupplierCode = dbo.Supplier.SupplierCode WHERE (dbo.OtherAdditions.Cancel = 0) AND dbo.OtherAdditions.YearCode =" + pYear + " AND dbo.OtherAdditions.MonthCode = " + pMonth + "", CommandType.Text).Tables[0];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pYear"></param>
        /// <param name="pMonth"></param>
        /// <param name="pIssueDate"></param>
        /// <param name="pType"></param>
        /// <param name="pSupCode"></param>
        /// <param name="pRoute"></param>
        /// <param name="pApproval"></param>
        public void ApprovalOtherAddition(int pYear, int pMonth, string pSupCode, bool pApproval)
        {
            SQLHelper.ExecuteNonQuery("update OtherAdditions set Approval = '" + pApproval + "' where YearCode = '" + pYear + "' and MonthCode= '" + pMonth + "' and SupplierCode = '" + pSupCode + "'", CommandType.Text);
        }

        public void InsertAdditions(Int32 YearCode, Int32 MonthCode, String SupplierCode, Decimal Amount, String Remarks, String Route)
        {
            SQLHelper.ExecuteNonQuery("insert into OtherAdditions (YearCode,MonthCode,SupplierCode,Amount,Remarks,UserID,RouteNo) values ('" + YearCode + "','" + MonthCode + "','" + SupplierCode + "','" + Amount + "','" + Remarks + "','" + BoughtLeafBusinessLayer.BLUser.StrUserName + "','" + Route + "')", CommandType.Text);
        }

        public void UpdateAdditions(Int32 YearCode, Int32 MonthCode, String SupplierCode, Decimal Amount, String Remarks)
        {
            SQLHelper.ExecuteNonQuery("UPDATE OtherAdditions set Remarks='" + Remarks + "', Amount = '" + Amount + "' where (YearCode='" + YearCode + "' AND MonthCode='" + MonthCode + "' AND SupplierCode='" + SupplierCode + "' AND Processed = 0 AND Approval = 0)", CommandType.Text);
        }

        public void DeleteAdditions(Int32 YearCode, Int32 MonthCode, String SupplierCode)
        {
            SQLHelper.ExecuteNonQuery("DELETE FROM OtherAdditions WHERE (YearCode='" + YearCode + "' AND MonthCode='" + MonthCode + "' AND SupplierCode='" + SupplierCode + "' AND Processed = 0 AND Approval = 0)", CommandType.Text);
        }

        public Decimal getSupplierAdditions(Int32 Year, Int32 Month, String SupplierCode)
        {
            Decimal GreenLeaf = 0;

            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT SUM(Amount) AS Amount FROM dbo.OtherAdditions WHERE (YearCode = '" + Year + "') AND (MonthCode = '" + Month + "') AND (SupplierCode = '" + SupplierCode + "') AND (Cancel = 0) AND (Processed = 0)", CommandType.Text);
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

        public void CancelUpdateAsProcessed(Int32 pYear, Int32 pMonth, String pRouteCode)
        {
            SQLHelper.ExecuteNonQuery("update OtherAdditions set Processed=0, AmountSettled = 0 where YearCode = '" + pYear + "' and MonthCode = '" + pMonth + "' and RouteNo = '" + pRouteCode + "'", CommandType.Text);

            SQLHelper.ExecuteNonQuery("delete from OtherAdditionSettlement where YearCode = '" + pYear + "' and MonthCode = '" + pMonth + "' and RouteNo = '" + pRouteCode + "'", CommandType.Text);
        }

        //SACHINTHA -20161028
        //REMOVE ROUTE FROM FILTERING
        public Decimal getSupplierOtherPayments(Int32 pYear, Int32 pMonth, String pSupplierCode)
        {
            Decimal GreenLeaf = 0;

            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT Amount - AmountSettled AS Balance, YearCode, MonthCode, RouteNo FROM dbo.OtherAdditions WHERE (Amount - AmountSettled > 0) AND (SupplierCode = '" + pSupplierCode + "') AND (YearCode = '" + pYear + "') AND (MonthCode = '" + pMonth + "') AND (Approval = 1)", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    GreenLeaf = GreenLeaf + dataReader.GetDecimal(0);
                    SQLHelper.ExecuteNonQuery("insert into OtherAdditionSettlement (YearCode,MonthCode,SupplierCode,RouteNo,SettledAmount) values ('" + dataReader.GetInt32(1) + "','" + dataReader.GetInt32(2) + "','" + pSupplierCode + "','" + dataReader.GetString(3) + "','" + dataReader.GetDecimal(0) + "')", CommandType.Text);
                }
            }
            dataReader.Close();

            SQLHelper.ExecuteNonQuery("update OtherAdditions set AmountSettled=Amount,Processed=1 where (SupplierCode = '" + pSupplierCode + "') AND (YearCode = '" + pYear + "') AND (MonthCode = '" + pMonth + "')", CommandType.Text);

            return GreenLeaf;
        }
    }
}
