using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BoughtLeafDataAccess;

namespace BoughtLeafBusinessLayer
{
    public class BLTown
    {
        private String strTownCode;

        public String StrTownCode
        {
            get { return strTownCode; }
            set { strTownCode = value; }
        }
        private String strTownName;

        public String StrTownName
        {
            get { return strTownName; }
            set { strTownName = value; }
        }
        private string strRouteCode;

        public string StrRouteCode
        {
            get { return strRouteCode; }
            set { strRouteCode = value; }
        }
        private Decimal decDistance;

        public Decimal DecDistance
        {
            get { return decDistance; }
            set { decDistance = value; }
        }

        public void InsertTown()
        {
            SQLHelper.ExecuteNonQuery("insert into Town (TownCode,TownName,RouteCode,DistanceFromFactory) values ('" + strTownCode + "','" + strTownName + "','" + strRouteCode + "','" + decDistance + "')", CommandType.Text);
        }

        public void UpdateTown()
        {
            SQLHelper.ExecuteNonQuery("update Town set TownName = '" + strTownName + "',DistanceFromFactory='" + decDistance + "' where RouteCode = '" + strRouteCode + "' AND TownCode = '" + strTownCode + "'", CommandType.Text);
        }

        public void DeleteTown()
        {
            SQLHelper.ExecuteNonQuery("delete Town where RouteCode = '" + strRouteCode + "' AND TownCode = '" + strTownCode + "'", CommandType.Text);
        }

        public DataTable ListTownDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("TownCode"));
            dt.Columns.Add(new DataColumn("TownName"));
            dt.Columns.Add(new DataColumn("RouteCode"));
            dt.Columns.Add(new DataColumn("DistanceFromFactory"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT TownCode, TownName, RouteCode, DistanceFromFactory FROM dbo.Town order by TownName", CommandType.Text);

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
                    dtrow[2] = dataReader.GetString(2).Trim();
                }
                if (!dataReader.IsDBNull(3))
                {
                    dtrow[3] = dataReader.GetDecimal(3);
                }
                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }

        public DataTable ListTownDetails(string pRoute)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("TownCode"));
            dt.Columns.Add(new DataColumn("TownName"));
            dt.Columns.Add(new DataColumn("RouteCode"));
            dt.Columns.Add(new DataColumn("DistanceFromFactory"));
            dt.Columns.Add(new DataColumn("CreateDateTime"));
            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT [TownCode],[TownName],[RouteCode],[DistanceFromFactory],[CreateDateTime] FROM [dbo].[Town] where [RouteCode] = '" + pRoute + "'", CommandType.Text);

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
                    dtrow[2] = dataReader.GetString(2).Trim();
                }
                if (!dataReader.IsDBNull(3))
                {
                    dtrow[3] = dataReader.GetDecimal(3);
                }
                if (!dataReader.IsDBNull(4))
                {
                    dtrow[4] = dataReader.GetDateTime(4);
                }
                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }

        public DataTable ListTownDetailsByRoute(string pRoute)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("TownCode"));
            dt.Columns.Add(new DataColumn("TownName"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT [TownCode],[TownName] FROM [dbo].[Town] where [RouteCode] = '" + pRoute + "'", CommandType.Text);

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
                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }

        public String getTownCodeByName()
        {
            String TownCode = "NA";
            
            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT TownCode FROM dbo.Town WHERE (TownName = '" + StrTownName + "')", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    TownCode = dataReader.GetString(0).Trim();
                }
            }
            dataReader.Close();
            return TownCode;
        }
        public Decimal getDistance()
        {
            Decimal Distance = 0;

            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT Distance FROM dbo.Town WHERE (TownCode = '" + StrTownCode + "')", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    Distance = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();
            return Distance;
        }
    }
}
