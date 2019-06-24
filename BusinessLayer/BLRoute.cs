using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BoughtLeafDataAccess;

namespace BoughtLeafBusinessLayer
{
    public class BLRoute
    {
        private string _routeCode;

        public string RouteCode
        {
            get { return _routeCode; }
            set { _routeCode = value; }
        }

        private string _routeName;

        public string RouteName
        {
            get { return _routeName; }
            set { _routeName = value; }
        }

        public void InsertRoute()
        {
            SQLHelper.ExecuteNonQuery("INSERT INTO Route (RouteCode,RouteName,UserID) values ('" + _routeCode + "','" + _routeName + "','" + BLUser.StrUserName + "')", CommandType.Text);
        }

        public void UpdateRoute()
        {
            SQLHelper.ExecuteNonQuery("UPDATE Route SET RouteCode='" + _routeCode + "', RouteName='" + _routeName + "', UserID='" + BLUser.StrUserName + "' WHERE RouteCode='" + _routeCode + "'", CommandType.Text);
        }

        public void DeleteRoute()
        {
            SQLHelper.ExecuteNonQuery("delete from Route where RouteCode = '" + _routeCode + "'", CommandType.Text);
        }


        public DataTable ListRouteDetails()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("RouteCode"));
            dt.Columns.Add(new DataColumn("RouteName"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT distinct RouteCode, RouteName FROM dbo.Route", CommandType.Text);

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

        public DataTable ListRouteDetails(string pRouteCode)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("RouteCode"));
            dt.Columns.Add(new DataColumn("RouteName"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT distinct RouteCode, RouteName FROM dbo.Route where RouteCode like '" + pRouteCode + "'", CommandType.Text);

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


        // error with chages sachintha udara comfirm
        public DataTable getTownPerRoute()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Town"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT dbo.Town.TownName FROM dbo.Route INNER JOIN dbo.Town ON dbo.Route.TownCode = dbo.Town.TownCode WHERE (dbo.Route.RouteCode = '" + _routeCode + "')", CommandType.Text);

            while (dataReader.Read())
            {
                dtrow = dt.NewRow();

                if (!dataReader.IsDBNull(0))
                {
                    dtrow[0] = dataReader.GetString(0).Trim();
                }
                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }

        public string getRouteCode(string pRouteName)
        {
            string routeCode = string.Empty;

            SqlDataReader dataReader = SQLHelper.ExecuteReader("SELECT [RouteCode] FROM  [dbo].[Route] WHERE [RouteName] = '" + pRouteName + "'", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    routeCode = dataReader.GetString(0);
                }
            }
            dataReader.Close();
            return routeCode;
        }

        public string getRouteName(string pRouteCode)
        {
            string routeName = string.Empty;

            SqlDataReader dataReader = SQLHelper.ExecuteReader("SELECT [RouteName] FROM  [dbo].[Route] WHERE [RouteCode] = '" + pRouteCode + "'", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    routeName = dataReader.GetString(0);
                }
            }
            dataReader.Close();
            return routeName;
        }
    }
}
