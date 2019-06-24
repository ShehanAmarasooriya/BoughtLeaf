using System;
using System.Collections.Generic;
using System.Text;
using BoughtLeafDataAccess;
using System.Data;
using System.Data.SqlClient;

namespace BoughtLeafBusinessLayer
{
    public class BLTransportCost
    {
        private string _TrnsCode;

        public string TrnsCode
        {
            get { return _TrnsCode; }
            set { _TrnsCode = value; }
        }
        private decimal _TrnsCost;

        public decimal TrnsCost
        {
            get { return _TrnsCost; }
            set { _TrnsCost = value; }
        }

        private string trnsAccNo;

        public string TrnsAccNo
        {
            get { return trnsAccNo; }
            set { trnsAccNo = value; }
        }

        public void InsertTransportCost()
        {
            SQLHelper.ExecuteNonQuery("insert into TransportCost(trnCode,trnCost,trnAccNo) values ('" + _TrnsCode + "','" + _TrnsCost + "','" + trnsAccNo + "')", CommandType.Text);
        }

        public void UpdateTransportCode(int pId)
        {
            //SQLHelper.ExecuteNonQuery("update TransportCost set trnCode = '" + _TrnsCode + "',trnCost='" + _TrnsCost + "' where id = '" + pId + "'", CommandType.Text);
            SQLHelper.ExecuteNonQuery("update TransportCost set trnCost='" + _TrnsCost + "', trnAccNo='" + trnsAccNo + "' where id = '" + pId + "'", CommandType.Text);
        }

        public void DeleteTransportCode(int pId)
        {
            SQLHelper.ExecuteNonQuery("delete from TransportCost where id = '" + pId + "'", CommandType.Text);
        }

        public DataTable getTransportCost()
        {
            DataTable dt = new DataTable("Trn");
            dt.Columns.Add("Code");
            dt.Columns.Add("Cost");
            dt.Columns.Add("ID");
            dt.Columns.Add("GLAccountNo");

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT trnCode,trnCost,id,trnAccNo FROM TransportCost", CommandType.Text);
            while (dataReader.Read())
            {
                dtrow = dt.NewRow();

                if (!dataReader.IsDBNull(0))
                {
                    dtrow[0] = dataReader.GetString(0).Trim();
                }

                if (!dataReader.IsDBNull(1))
                {
                    dtrow[1] = dataReader.GetDecimal(1);
                }
                if (!dataReader.IsDBNull(2))
                {
                    dtrow[2] = dataReader.GetInt32(2);
                }
                if (!dataReader.IsDBNull(3))
                {
                    dtrow[3] = dataReader.GetString(3).Trim();
                }
                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }

        //SACHINTHA -20161028
        //REMOVE ROUTE FROM FILTERING
        public Decimal getTransportDeduction(int year, int month, string supCode)
        {
            Decimal Distance = 0;

            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT SUM(dbo.DailyGreenLeaf.transportCost) + [dbo].[FixedPaymentSettings].PaySlipCharge AS Expr3 FROM dbo.DailyGreenLeaf CROSS JOIN  [dbo].[FixedPaymentSettings] WHERE (YEAR(dbo.DailyGreenLeaf.CollectedDate) = '" + year + "') AND (MONTH(dbo.DailyGreenLeaf.CollectedDate) = '" + month + "') AND (dbo.DailyGreenLeaf.SupplierCode = '" + supCode + "') AND (dbo.DailyGreenLeaf.Approval = 1) GROUP BY YEAR(dbo.DailyGreenLeaf.CollectedDate), dbo.DailyGreenLeaf.RouteNo, dbo.DailyGreenLeaf.SupplierCode, MONTH(dbo.DailyGreenLeaf.CollectedDate),[dbo].[FixedPaymentSettings].PaySlipCharge", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    Distance += dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();
            return Distance;
        }
    }
}
