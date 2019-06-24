using System;
using System.Collections.Generic;
using System.Text;
using BoughtLeafDataAccess;
using System.Data;
using System.Data.SqlClient;

namespace BoughtLeafBusinessLayer
{
    public class BLCollector
    {
        private string collectorCode;

        public string CollectorCode
        {
            get { return collectorCode; }
            set { collectorCode = value; }
        }

        private string collectorName;

        public string CollectorName
        {
            get { return collectorName; }
            set { collectorName = value; }
        }

        public void insertCollector() 
        {
            SQLHelper.ExecuteNonQuery("INSERT INTO [dbo].[CollectorMaster]([CollectorCode],[CollectorName],[EditUser],[EditDate]) VALUES('" + collectorCode + "','" + collectorName + "','" + BLUser.StrUserName + "','" + DateTime.Now.Date + "')", CommandType.Text);
        }

        public void updateCollector()
        {
            SQLHelper.ExecuteNonQuery("UPDATE [dbo].[CollectorMaster] SET [CollectorName] = '" + collectorName + "',[EditUser] = '" + BLUser.StrUserName + "',[EditDate] = '" + DateTime.Now.Date + "' WHERE [CollectorCode] = '" + collectorCode + "'", CommandType.Text);
        }

        public void deleteCollector()
        {
            SQLHelper.ExecuteNonQuery("DELETE FROM [dbo].[CollectorMaster] WHERE [CollectorCode] = '" + collectorCode + "'", CommandType.Text);
        }

        public int checkCanDelete(string pColCode) 
        {
            int count = 0;
            SqlDataReader reader;

            reader = SQLHelper.ExecuteReader("SELECT COUNT(CollectorCode) FROM [dbo].[DailyGreenLeaf] WHERE CollectorCode='" + pColCode + "'", CommandType.Text);
            while (reader.Read())
            {
                if (!reader.IsDBNull(0))
                {
                    count = reader.GetInt32(0);
                }
            }
            return count;
        }

        public DataTable getCollectors()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("CollectorCode")); //0
            dt.Columns.Add(new DataColumn("CollectorName")); //1
            dt.Columns.Add(new DataColumn("EditUser")); //2
            dt.Columns.Add(new DataColumn("EditDate")); //3
            DataRow dtrow;
            SqlDataReader reader;
            dtrow = dt.NewRow();

            reader = SQLHelper.ExecuteReader("SELECT [CollectorCode],[CollectorName],[EditUser],[EditDate] FROM [dbo].[CollectorMaster]", CommandType.Text);
            while (reader.Read())
            {
                dtrow = dt.NewRow();
                if (!reader.IsDBNull(0))
                {
                    dtrow[0] = reader.GetString(0);
                }
                if (!reader.IsDBNull(1))
                {
                    dtrow[1] = reader.GetString(1);
                }
                if (!reader.IsDBNull(2))
                {
                    dtrow[2] = reader.GetString(2);
                }
                if (!reader.IsDBNull(3))
                {
                    dtrow[3] = reader.GetDateTime(3).ToString();
                }

                dt.Rows.Add(dtrow);
            }
            reader.Close();
            return dt;
        }

        public String getCollectorName(String strCollectorCode)
        {
            String strName = "";
            SqlDataReader reader;

            reader = SQLHelper.ExecuteReader("SELECT [CollectorName] FROM [dbo].[CollectorMaster] where ([CollectorCode]='"+strCollectorCode+"')", CommandType.Text);
            while (reader.Read())
            {
                if (!reader.IsDBNull(0))
                {
                    strName = reader.GetString(0);
                }
            }
            reader.Close();
            return strName;
        }
    }
}
