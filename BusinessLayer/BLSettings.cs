using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using BoughtLeafDataAccess;

namespace BoughtLeafBusinessLayer
{
    public class BLSettings
    {
        public String GetBackUpLocation(String strType)
        {
            SqlDataReader reader1;
            String strLocation = "NA";
            reader1 = SQLHelper.ExecuteReader("SELECT Name FROM dbo.BLMasterSettings WHERE (Type = '" + strType + "')", CommandType.Text);
            while (reader1.Read())
            {
                if (!reader1.IsDBNull(0))
                {
                    strLocation = reader1.GetString(0).Trim();
                }
            }
            return strLocation;
        }

        

        public DataTable ListBLMasterRates(String strType)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Name"));
            dt.Columns.Add(new DataColumn("Amount"));
            DataRow dtRow;
            SqlDataReader dataReader;
            dtRow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT Name, Amount FROM dbo.BLMasterRates WHERE (Type = '" + strType + "') ", CommandType.Text);
            while (dataReader.Read())
            {
                dtRow = dt.NewRow();
                if (!dataReader.IsDBNull(0))
                {
                    dtRow[0] = dataReader.GetString(0).Trim();
                }
                if (!dataReader.IsDBNull(1))
                {
                    dtRow[1] = dataReader.GetDecimal(1);
                }
                dt.Rows.Add(dtRow);
            }
            dataReader.Close();
            return dt;
        }

        public DataTable ListBLSlabIncentiveMethod()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Code"));
            dt.Columns.Add(new DataColumn("Name"));
            DataRow dtRow;
            SqlDataReader dataReader;
            dtRow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT Code, Name FROM dbo.SlabInsentiveHeader order by (case Code when 'NA' then 1 end) DESC", CommandType.Text);
            //dataReader = SQLHelper.ExecuteReader("SELECT Code, Name FROM dbo.SlabInsentiveHeader", CommandType.Text);
            while (dataReader.Read())
            {
                dtRow = dt.NewRow();
                if (!dataReader.IsDBNull(0))
                {
                    dtRow[0] = dataReader.GetString(0).Trim();
                }
                if (!dataReader.IsDBNull(1))
                {
                    dtRow[1] = dataReader.GetString(1).Trim();
                }
                dt.Rows.Add(dtRow);
            }
            dataReader.Close();
            return dt;
        }

        public DataTable ListBLMasterSettings(String strType)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Code"));
            dt.Columns.Add(new DataColumn("Name"));
            DataRow dtRow;
            SqlDataReader dataReader;
            dtRow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT Code, Name FROM dbo.BLMasterSettings WHERE (Type = '"+strType+"')", CommandType.Text);
            while (dataReader.Read())
            {
                dtRow = dt.NewRow();
                if (!dataReader.IsDBNull(0))
                {
                    dtRow[0] = dataReader.GetInt32(0);
                }
                if (!dataReader.IsDBNull(1))
                {
                    dtRow[1] = dataReader.GetString(1).Trim();
                }
                dt.Rows.Add(dtRow);
            }
            dataReader.Close();
            return dt;
        }

        public Int32 GetSettingValue(String strType)
        {
            Int32 intValue = 0;
            SqlDataReader readerSettings = SQLHelper.ExecuteReader("SELECT top 1  Code FROM dbo.BLMasterSettings WHERE (Type = '"+strType+"')",CommandType.Text);
            while(readerSettings.Read())
            {
                if(!readerSettings.IsDBNull(0))
                {
                    intValue = readerSettings.GetInt32(0);
                }
            }
            return intValue;
        }

        public Decimal GetSettingRateValue(String strType,String strName)
        {
            Decimal decValue = 0;
            SqlDataReader readerSettings = SQLHelper.ExecuteReader("SELECT isnull(Amount,0) FROM dbo.BLMasterRates WHERE (Type = '" + strType + "') AND (Name = '"+strName+"')", CommandType.Text);
            while (readerSettings.Read())
            {
                if (!readerSettings.IsDBNull(0))
                {
                    decValue = readerSettings.GetDecimal(0);
                }
            }
            return decValue;
        }

        public String UpdateBLMonthlySetting(String settingType, String settingName, Decimal decAmount)
        {
            try
            {
                SQLHelper.ExecuteNonQuery("UPDATE BLMasterRates SET Amount='" + decAmount + "' WHERE (Type = '" + settingType + "') AND (Name = '" + settingName + "')", CommandType.Text);
                return "UPDATED";
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }
    }
}
