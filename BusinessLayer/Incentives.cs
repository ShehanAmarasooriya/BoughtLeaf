using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BoughtLeafDataAccess;

namespace BoughtLeafBusinessLayer
{
    public class Incentives
    {
        public void InsertIncentives( String RouteNo, String SupplierCode, DateTime DateGenerated, Decimal Incentive, String UserID, Decimal Trans,Decimal RegIncen)
        {
            SQLHelper.ExecuteNonQuery("insert into BLMasterSupplierIncentives (RouteNo,SupplierCode,DateGenerated,Incentive,transportIncentive,UserID,RegularIncentive) values ('" + RouteNo + "','" + SupplierCode + "','" + DateGenerated + "','" + Incentive + "','" + Trans + "','" + UserID + "','"+RegIncen+"')", CommandType.Text);
        }
        public void DeleteIncentives( String RouteNo)
        {
            SQLHelper.ExecuteNonQuery("delete from BLMasterSupplierIncentives where  RouteNo = '" + RouteNo + "' and Approval = 0", CommandType.Text);
        }
        //public DataSet ListIncentivesWithSuppliers(Int32 Year, Int32 Month, String RouteNo)
        //{
        //    DataSet ds = new DataSet();
        //    SqlDataAdapter da = new SqlDataAdapter();
        //    SqlCommand command = new SqlCommand();
        //    da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.SupplierIncentives.SupplierCode, dbo.Supplier.SupplierName, dbo.SupplierIncentives.Incentive,dbo.SupplierIncentives.transportIncentive FROM dbo.SupplierIncentives INNER JOIN dbo.Supplier ON dbo.SupplierIncentives.SupplierCode = dbo.Supplier.SupplierCode AND dbo.SupplierIncentives.RouteNo = dbo.Supplier.RouteCode WHERE (dbo.SupplierIncentives.Year = '" + Year + "') AND (dbo.SupplierIncentives.Month = '" + Month + "') AND (dbo.SupplierIncentives.RouteNo = '" + RouteNo + "')ORDER BY ABS(dbo.SupplierIncentives.SupplierCode)", CommandType.Text);

        //    da.Fill(ds, "SuplierList");
        //    return ds;
        //}

        public DataSet ListIncentivesWithSuppliers(Int32 Year, Int32 Month, String RouteNo)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            da.SelectCommand = SQLHelper.CreateCommand("SELECT SupplierCode, SupplierName, ISNULL ((SELECT ISNULL(Incentive, 0) AS Expr1 FROM dbo.SupplierIncentives AS SupplierIncentives_1 WHERE  (RouteNo = dbo.Supplier.RouteCode) AND (SupplierCode = dbo.Supplier.SupplierCode ) ), 0) AS Incentive, ISNULL ((SELECT        ISNULL(transportIncentive, 0) AS Expr1 FROM dbo.SupplierIncentives WHERE (RouteNo = dbo.Supplier.RouteCode) AND (SupplierCode = dbo.Supplier.SupplierCode ) ), 0) AS TransportIncentive FROM dbo.Supplier WHERE (RouteCode = '"+RouteNo+"')", CommandType.Text);
            da.Fill(ds, "SuplierList");
            return ds;
        }
        public DataSet ListIncentiveLevels()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            da.SelectCommand = SQLHelper.CreateCommand("SELECT LeafFrom, LeafTo, IncentivePerKilo, CreateDateTime, UserID, RouteNo, AutoKey FROM dbo.IncentiveLevels", CommandType.Text);

            da.Fill(ds, "Incentives");
            return ds;
        }
        public DataSet ListIncentiveLevelsSupplierWise()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            da.SelectCommand = SQLHelper.CreateCommand("SELECT LeafFrom, LeafTo, IncentivePerKilo, CreateDateTime, UserID, RouteNo, AutoKey,SupCode FROM dbo.IncentiveLevels", CommandType.Text);

            da.Fill(ds, "Incentives");
            return ds;
        }

        public void InsertIncentiveLevels(Decimal LeafFrom, Decimal LeafTo, Decimal IncentivePerKilo, String UserID, String RouteNo)
        {
            SQLHelper.ExecuteNonQuery("insert into IncentiveLevels (LeafFrom,LeafTo,IncentivePerKilo,UserID,RouteNo) values ('" + LeafFrom + "','" + LeafTo + "','" + IncentivePerKilo + "','" + UserID + "','" + RouteNo + "')", CommandType.Text);
        }

        public void InsertIncentiveLevels(Decimal LeafFrom, Decimal LeafTo, Decimal IncentivePerKilo, String UserID, String RouteNo, Int32 sup)
        {
            SQLHelper.ExecuteNonQuery("insert into IncentiveLevels (LeafFrom,LeafTo,IncentivePerKilo,UserID,RouteNo,SupCode) values ('" + LeafFrom + "','" + LeafTo + "','" + IncentivePerKilo + "','" + UserID + "','" + RouteNo + "','" + sup + "')", CommandType.Text);
        }

        public void DeleteIncentiveLevels(Int32 AutoKey)
        {
            SQLHelper.ExecuteNonQuery("delete from IncentiveLevels where AutoKey = '" + AutoKey + "'", CommandType.Text);
        }

        public DataTable GetIncentiveWithIncentiveslab()
        {
            DataTable oDataTable = new DataTable();
            oDataTable.Columns.Add("SupplierCode");
            oDataTable.Columns.Add("LeafFrom");
            oDataTable.Columns.Add("LeafTo");
            oDataTable.Columns.Add("IncentivePerRate");
            oDataTable.Columns.Add("GreenLeafCollected");
            oDataTable.Columns.Add("Intive");
            DataRow odatarow;
            SqlDataReader datareader;
            odatarow = oDataTable.NewRow();
            datareader = SQLHelper.ExecuteReader("SELECT dbo.DailyGreenLeaf.SupplierCode, dbo.IncentiveLevels.LeafFrom, dbo.IncentiveLevels.LeafTo, dbo.IncentiveLevels.IncentivePerKilo,dbo.DailyGreenLeaf.GreenLeafCollected, dbo.IncentiveLevels.IncentivePerKilo * dbo.DailyGreenLeaf.GreenLeafCollected AS Incentive FROM dbo.DailyGreenLeaf INNER JOIN dbo.IncentiveLevels ON dbo.DailyGreenLeaf.RouteNo = dbo.IncentiveLevels.RouteNo WHERE (dbo.DailyGreenLeaf.GreenLeafCollected BETWEEN dbo.IncentiveLevels.LeafFrom AND dbo.IncentiveLevels.LeafTo)", CommandType.Text);

            while (datareader.Read())
            {
                odatarow = oDataTable.NewRow();

                if (!datareader.IsDBNull(0))
                {
                    odatarow[0] = datareader.GetString(0);
                }
                if (!datareader.IsDBNull(1))
                {
                    odatarow[1] = datareader.GetDecimal(1);
                }
                if (!datareader.IsDBNull(2))
                {
                    odatarow[2] = datareader.GetDecimal(2);

                }
                if (!datareader.IsDBNull(3))
                {
                    odatarow[3] = datareader.GetDecimal(3);
                }
                if (!datareader.IsDBNull(4))
                {
                    odatarow[4] = datareader.GetDecimal(4);
                }
                if (!datareader.IsDBNull(5))
                {
                    odatarow[5] = datareader.GetDecimal(5);
                }
                oDataTable.Rows.Add(odatarow);
            }


            datareader.Close();
            return oDataTable;
        }


        public DataSet ListIncentiveRouteWise(int year, int month, string route)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.SupplierIncentives.SupplierCode, dbo.SupplierIncentives.Incentive, dbo.SupplierIncentives.RouteNo, dbo.Supplier.SupplierName FROM dbo.SupplierIncentives INNER JOIN dbo.Supplier ON dbo.SupplierIncentives.SupplierCode = dbo.Supplier.SupplierCode WHERE (dbo.SupplierIncentives.RouteNo = '" + route + "') AND (dbo.SupplierIncentives.Incentive > 0) order by ABS (dbo.SupplierIncentives.SupplierCode)", CommandType.Text);

            da.Fill(ds, "IncentivesRoute");
            return ds;
        }

        public DataSet ListIncentiveRouteWise(int year, int month)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.SupplierIncentives.SupplierCode, dbo.SupplierIncentives.Incentive, dbo.SupplierIncentives.RouteNo, dbo.Supplier.SupplierName, dbo.SupplierIncentives.Year, dbo.SupplierIncentives.Month FROM dbo.SupplierIncentives INNER JOIN dbo.Supplier ON dbo.SupplierIncentives.SupplierCode = dbo.Supplier.SupplierCode WHERE     (dbo.SupplierIncentives.Month = '" + month + "') AND (dbo.SupplierIncentives.Year = '" + year + "') AND (dbo.SupplierIncentives.Incentive > 0) order by ABS (dbo.SupplierIncentives.SupplierCode)", CommandType.Text);

            da.Fill(ds, "IncentivesRoute");
            return ds;
        }

        public DataTable ListIncentivesForApproval(int pYear, int pMonth, string pRoute)
        {
            return SQLHelper.FillDataSet("SELECT [Year],[Month],[SupplierCode],[Approval],[RouteNo],[DateGenerated],[Incentive],[transportIncentive] FROM [dbo].[SupplierIncentives] WHERE [Year]=" + pYear + " AND [Month]=" + pMonth + " AND RouteNo LIKE '" + pRoute + "'", CommandType.Text).Tables[0];
        }

        public void ApprovalIncentives(int pYear, int pMonth, string pSupCode, bool pApproval)
        {
            SQLHelper.ExecuteNonQuery("update [dbo].[SupplierIncentives] set Approval = '" + pApproval + "' where Year = '" + pYear + "' and Month= '" + pMonth + "' and SupplierCode = '" + pSupCode + "'", CommandType.Text);
        }
    }
}
