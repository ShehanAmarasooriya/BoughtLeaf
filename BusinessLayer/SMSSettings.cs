using System;
using System.Collections.Generic;
using System.Text;
using BoughtLeafDataAccess;
using System.Data;
using System.Data.SqlClient;
using System.IO.Ports;

namespace BoughtLeafBusinessLayer
{
    public class SMSSettings
    {
        public void saveSMSSend(bool pValue)
        {
            SQLHelper.ExecuteNonQuery("UPDATE [dbo].[Setting] SET [Value] = '" + pValue + "' WHERE [Type] = 'SMSSend'", CommandType.Text);
        }

        public void saveSMSSettings(string pPortName, int pBaundRate, int pDataBits, int pReadTimeout, int pWriteTimeout)
        {
            SQLHelper.ExecuteNonQuery("UPDATE [dbo].[SMSSettings] SET [Port] = '" + pPortName + "', [BounRate] = '" + pBaundRate + "', [DataBit] = '" + pDataBits + "', [ReadTimeOut] = '" + pReadTimeout + "', [WriteTimeOut] = '" + pWriteTimeout + "'", CommandType.Text);
        }

        public DataTable getSMSSettings()
        {
            return SQLHelper.FillDataSet("SELECT [Port], [BounRate], [DataBit], [ReadTimeOut], [WriteTimeOut] FROM [dbo].[SMSSettings]", CommandType.Text).Tables[0];
        }

        public DataTable getSMSSendData()
        {
            return SQLHelper.FillDataSet("SELECT [Value] FROM [dbo].[Setting] WHERE [Type] = 'SMSSend'", CommandType.Text).Tables[0];
        }
    }
}
