using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BoughtLeafDataAccess;

namespace BoughtLeafBusinessLayer
{
    public class BLMonthlySettings
    {
        private Int32 intYear;

        public Int32 IntYear
        {
            get { return intYear; }
            set { intYear = value; }
        }
        private Int32 intMonth;

        public Int32 IntMonth
        {
            get { return intMonth; }
            set { intMonth = value; }
        }
        private Decimal decKiloRate;

        public Decimal DecKiloRate
        {
            get { return decKiloRate; }
            set { decKiloRate = value; }
        }

        private Decimal decGLPerKg;

        public Decimal DecGLPerKg
        {
            get { return decGLPerKg; }
            set { decGLPerKg = value; }
        }

        public void InsertSettings()
        {
            SQLHelper.ExecuteNonQuery("insert into dbo.MonthlySettings(YearCode,MonthCode,KiloRate,UserID,GoodLeafAdditionPerKg) values ('" + IntYear + "', '" + IntMonth + "', '" + DecKiloRate + "', '" + BLUser.StrUserName + "','"+DecGLPerKg+"')", CommandType.Text);
        }
        public void UpdateSettings()
        {
            SQLHelper.ExecuteNonQuery("update dbo.MonthlySettings set KiloRate = '" + DecKiloRate + "', UserID = '" + BoughtLeafBusinessLayer.BLUser.StrUserName + "',GoodLeafAdditionPerKg='"+DecGLPerKg+"' where YearCode = '" + IntYear + "' and MonthCode = '" + IntMonth + "'", CommandType.Text);
        }
        public DataTable ListSettings()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("YearCode")); // 0
            dt.Columns.Add(new DataColumn("MonthCode")); // 1
            dt.Columns.Add(new DataColumn("KiloRate")); // 2
            dt.Columns.Add(new DataColumn("GLAddition")); // 3
            dt.Columns.Add(new DataColumn("UserID")); // 4
            dt.Columns.Add(new DataColumn("CreateDateTime")); // 5

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT YearCode, MonthCode, KiloRate,GoodLeafAdditionPerKg, UserID, CreateDateTime FROM dbo.MonthlySettings  ORDER BY YearCode DESC, MonthCode DESC", CommandType.Text);

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
                    dtrow[2] = dataReader.GetDecimal(2).ToString("N2");
                }
                if (!dataReader.IsDBNull(3))
                {
                    dtrow[3] = dataReader.GetDecimal(3).ToString("N2");
                }
                if (!dataReader.IsDBNull(4))
                {
                    dtrow[4] = dataReader.GetString(4);
                }
                if (!dataReader.IsDBNull(5))
                {
                    dtrow[5] = dataReader.GetDateTime(5);
                }

                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }

        public decimal getKiloRate(int pYear, int pMonth)
        {
            decimal KiloRate = 0;

            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT KiloRate FROM dbo.MonthlySettings WHERE (MonthCode = '" + pMonth + "') AND (YearCode = '" + pYear + "')", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    KiloRate = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();
            return KiloRate;
        }
        //previous month rate
        public decimal previousmonthrate(int pYear, int pMonth)
        {
            decimal KiloRate = 0;

            SqlDataReader dataReader;
            //dataReader = SQLHelper.ExecuteReader("SELECT KiloRate FROM dbo.MonthlySettings WHERE (MonthCode = '" + pMonth + "') AND (YearCode = '" + pYear + "')", CommandType.Text);
            //while (dataReader.Read())
            //{
            //    if (!dataReader.IsDBNull(0))
            //    {
            //        KiloRate = dataReader.GetDecimal(0);
            //    }
            //}
            //dataReader.Close();
            //if (KiloRate == 0)
            //{
                DateTime dtPreviousMonthDate = new DateTime(pYear, pMonth, 1).AddDays(-1);
                dataReader = SQLHelper.ExecuteReader("SELECT KiloRate FROM dbo.MonthlySettings WHERE (MonthCode = '" +dtPreviousMonthDate.Month + "') AND (YearCode = '" + dtPreviousMonthDate.Year + "')", CommandType.Text);
                while (dataReader.Read())
                {
                    if (!dataReader.IsDBNull(0))
                    {
                        KiloRate = dataReader.GetDecimal(0);
                    }
                }
                dataReader.Close();
            //}
            return KiloRate;
        }

        public Boolean IsMonthlySettingsAvailable(Int32 intYear, Int32 intMonth)
        {
            Boolean boolAvailable = false;
            DataSet dsSettings = new DataSet();
            dsSettings = SQLHelper.FillDataSet("SELECT TOP (100) PERCENT YearCode, MonthCode, KiloRate FROM dbo.MonthlySettings WHERE (YearCode = '" + intYear + "') AND (MonthCode = '" + intMonth + "') ORDER BY YearCode DESC, MonthCode DESC", CommandType.Text);
            if (dsSettings.Tables[0].Rows.Count > 0)
            {
                boolAvailable = true;
            }
            return boolAvailable;
        }
    }
}
