using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BoughtLeafDataAccess;

namespace BoughtLeafBusinessLayer
{
    public class AdvanceBookRate
    {
        private string routeNo;

        public string RouteCode
        {
            get { return routeNo; }
            set { routeNo = value; }
        }

        private Int32 year;

        public Int32 Year
        {
            get { return year; }
            set { year = value; }
        }

        
        private int month;

        public int Month
        {
            get { return month; }
            set { month = value; }
        }

        private decimal minimumQty;

        public decimal MinimumQty
        {
            get { return minimumQty; }
            set { minimumQty = value; }
        }

        private decimal minimumrate;

        public decimal Minimumrate
        {
            get { return minimumrate; }
            set { minimumrate = value; }
        }

        private decimal advMinCheAmount;

        public decimal AdvMinCheAmount
        {
            get { return advMinCheAmount; }
            set { advMinCheAmount = value; }
        }

        private int checkAllRoute;

        public int CheckAllRoute
        {
            get { return checkAllRoute; }
            set { checkAllRoute = value; }
        }

        public DataTable ListAdvBookRate()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("Route code"));
            dt.Columns.Add(new DataColumn("Route Name"));
            dt.Columns.Add(new DataColumn("Yaear"));
            dt.Columns.Add(new DataColumn("Month"));
            dt.Columns.Add(new DataColumn("Minimum Qty"));
            dt.Columns.Add(new DataColumn("Minimum Rate"));
            dt.Columns.Add(new DataColumn("Advanced Minimum Cheque Amount"));


            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();

            if (checkAllRoute == 1)
            {
                dataReader = SQLHelper.ExecuteReader("SELECT dbo.Route.RouteCode,dbo.Route.RouteName, dbo.BLAdvancedMinimumRate.YearCode, dbo.BLAdvancedMinimumRate.MonthCode, dbo.BLAdvancedMinimumRate.MinimumQty, dbo.BLAdvancedMinimumRate.MinimumRate, dbo.BLAdvancedMinimumRate.advMinCheAmount FROM dbo.BLAdvancedMinimumRate INNER JOIN dbo.Route ON dbo.BLAdvancedMinimumRate.RouteCode = dbo.Route.RouteCode WHERE (dbo.BLAdvancedMinimumRate.YearCode = '" + Year + "') AND (dbo.BLAdvancedMinimumRate.MonthCode = '" + Month + "')", CommandType.Text);
            }
            else
            {
                dataReader = SQLHelper.ExecuteReader("SELECT dbo.Route.RouteCode,dbo.Route.RouteName, dbo.BLAdvancedMinimumRate.YearCode, dbo.BLAdvancedMinimumRate.MonthCode, dbo.BLAdvancedMinimumRate.MinimumQty, dbo.BLAdvancedMinimumRate.MinimumRate, dbo.BLAdvancedMinimumRate.advMinCheAmount FROM dbo.BLAdvancedMinimumRate INNER JOIN dbo.Route ON dbo.BLAdvancedMinimumRate.RouteCode = dbo.Route.RouteCode WHERE (dbo.BLAdvancedMinimumRate.YearCode = '" + Year + "') AND (dbo.BLAdvancedMinimumRate.MonthCode = '" + Month + "') AND (dbo.BLAdvancedMinimumRate.RouteCode = '" + RouteCode + "')", CommandType.Text);
            }

            while (dataReader.Read())
            {
                dtrow = dt.NewRow();

                if (!dataReader.IsDBNull(0))
                {
                    dtrow[0] = dataReader.GetString(0).Trim();   //Route Code
                } 
                if (!dataReader.IsDBNull(1))
                {
                    dtrow[1] = dataReader.GetString(1).Trim();   //Route Name
                }
                if (!dataReader.IsDBNull(2))
                {
                    dtrow[2] = dataReader.GetInt32(2).ToString();   //Year
                }
                if (!dataReader.IsDBNull(3))
                {
                    dtrow[3] = dataReader.GetInt32(3).ToString();   //Month
                }
                if (!dataReader.IsDBNull(4))
                {
                    dtrow[4] = dataReader.GetDecimal(4).ToString("N2");  //MinimumQty
                }
                if (!dataReader.IsDBNull(5))
                {
                    dtrow[5] = dataReader.GetDecimal(5).ToString("N2");  //MinimumRate
                }
                if (!dataReader.IsDBNull(6))
                {
                    dtrow[6] = dataReader.GetDecimal(6).ToString("N2");  //advMinCheAmount
                }

                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;


        }

        public void insertAdvBookRate()
        {
            SQLHelper.ExecuteNonQuery("Insert into BLAdvancedMinimumRate (RouteCode,YearCode,MonthCode,MinimumQty,MinimumRate,advMinCheAmount,CreatedDateTime) values ('" +RouteCode + "','" + Year + "','" + Month + "','" + MinimumQty + "','" + Minimumrate + "','" + AdvMinCheAmount + "',getdate())", CommandType.Text);

        }

        public void deleteAdvBookRate()
        {
            SQLHelper.ExecuteNonQuery("DELETE s FROM [dbo].[BLAdvancedMinimumRate] AS s INNER JOIN [dbo].[Route] AS n ON s.RouteCode = n.RouteCode WHERE s.RouteCode='" + RouteCode + "'", CommandType.Text);
        }

        public void updateAdvBookRate()
        {
            SQLHelper.ExecuteNonQuery("UPDATE [dbo].[BLAdvancedMinimumRate] SET MinimumQty='" + MinimumQty + "',MinimumRate='" + Minimumrate + "',advMinCheAmount='" + advMinCheAmount + "' WHERE (RouteCode= '" + RouteCode + "') AND (YearCode='" + Convert.ToInt16(year) + "') AND (MonthCode='" + Convert.ToInt16(month)+ "')", CommandType.Text);
        }

    }
}
