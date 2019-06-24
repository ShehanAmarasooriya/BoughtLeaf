using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BoughtLeafDataAccess;

namespace BoughtLeafBusinessLayer
{
    public class BLFinancialYear
    {
        public DataTable ListAllMonths()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("MonthCode"));
            dt.Columns.Add(new DataColumn("MonthName"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT MonthCode, MonthName FROM  dbo.Month  ", CommandType.Text);

            while (dataReader.Read())
            {
                dtrow = dt.NewRow();

                if (!dataReader.IsDBNull(0))
                {
                    dtrow[0] = dataReader.GetInt32(0).ToString();
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

        public DataTable ListAllMonths(Int32 intYear)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("MonthCode"));
            dt.Columns.Add(new DataColumn("MonthName"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT MonthCode, MonthName FROM  dbo.Month WHERE  (Year = '"+intYear+"')", CommandType.Text);

            while (dataReader.Read())
            {
                dtrow = dt.NewRow();

                if (!dataReader.IsDBNull(0))
                {
                    dtrow[0] = dataReader.GetInt32(0).ToString();
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

        public DataTable ListAllVisibleYears()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("YearCode"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT Year FROM dbo.Month GROUP BY Year", CommandType.Text);

            while (dataReader.Read())
            {
                dtrow = dt.NewRow();

                if (!dataReader.IsDBNull(0))
                {
                    dtrow[0] = dataReader.GetInt32(0).ToString();
                }
                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }

        public DataTable ListLastYearMonth()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("YearCode"));
            dt.Columns.Add(new DataColumn("MonthCode"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT TOP (1) PERCENT Year, MonthCode FROM dbo.Month GROUP BY Year, MonthCode ORDER BY Year DESC, MonthCode DESC", CommandType.Text);

            while (dataReader.Read())
            {
                dtrow = dt.NewRow();

                if (!dataReader.IsDBNull(0))
                {
                    dtrow[0] = dataReader.GetInt32(0).ToString();
                }
                if (!dataReader.IsDBNull(01))
                {
                    dtrow[1] = dataReader.GetInt32(1).ToString();
                }
                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }
    }
}
