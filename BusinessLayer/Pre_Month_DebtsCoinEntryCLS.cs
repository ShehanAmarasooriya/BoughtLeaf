using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BoughtLeafDataAccess;
using System.Data.SqlClient;
namespace BoughtLeafBusinessLayer
{
    public class Pre_Month_DebtsCoinEntryCLS
    {
        public static int year;
        public static int month;
        public static string routCode;
        public static string SCode;
        public static double coin;
        public static double debt;

        public static DataTable getAllRouteCode()
        {

            DataSet ds = new DataSet();
            ds = SQLHelper.FillDataSet("SELECT        TOP (100) PERCENT RouteCode+' - '+RouteName as RouteName, RouteCode FROM  dbo.Route ", CommandType.Text);
            DataRow dr = ds.Tables[0].NewRow();
            dr["RouteName"] = "ALL - All Division";
            dr["RouteCode"] = "ALL";
            ds.Tables[0].Rows.Add(dr);
            ds.Tables[0].DefaultView.Sort = "RouteName ASC";

            return ds.Tables[0];

        }


        public static DataTable getSupllierByRouteCode()
        {

            DataTable table = new DataTable();
            table.Columns.Add("SupplierCode", typeof(string));
            table.Columns.Add("SupplierName", typeof(string));
            table.Columns.Add("RouteCode", typeof(string));
            table.Columns.Add("coin", typeof(decimal));
            table.Columns.Add("Debts", typeof(decimal));


            #region Get Supliers for route
            string str;
            if (routCode.ToUpper().Equals("ALL"))
            {
                str = "select  s.SupplierCode,s.SupplierName,s.RouteCode from Supplier s ";

            }
            else
            {
                str = "	 select  s.SupplierCode,s.SupplierName,s.RouteCode from Supplier s where s.RouteCode ='" + routCode + "'";

            }
            DataTable dt = SQLHelper.FillDataSet(str, CommandType.Text).Tables[0];
            #endregion



            foreach (DataRow dr in dt.Rows)
            {
                String debts = "(SELECT       isnull(sum( CFDebtBalance),0) as debt FROM dbo.MonthlyPaymentSummary WHERE (Month = " + month + ") AND (Year = " + year + ") AND (SupplierCode = '" + dr["SupplierCode"].ToString() + "') AND (RouteCode = '" + routCode + "') )";
                String coin = "(SELECT  ISNULL(CoinAmount,0) as coin FROM  dbo.BLMadeUpCoins WHERE (ProYear = " + year + ") AND (ProMonth = " + month + ") AND (SupplierCode ='" + dr["SupplierCode"].ToString() + "'))";

                Double debtsAmount;
                Double coinsAmount;


                if (SQLHelper.FillDataSet(debts, CommandType.Text).Tables[0].Rows.Count<1)
                    debtsAmount = 0.00;
                else
                    debtsAmount = Convert.ToDouble(SQLHelper.FillDataSet(debts, CommandType.Text).Tables[0].Rows[0]["debt"].ToString());



                if (SQLHelper.FillDataSet(coin, CommandType.Text).Tables[0].Rows.Count<1)
                    coinsAmount = 0;
                else
                    coinsAmount = Convert.ToDouble(SQLHelper.FillDataSet(coin, CommandType.Text).Tables[0].Rows[0]["coin"].ToString());


                table.Rows.Add(dr["SupplierCode"], dr["SupplierName"], dr["RouteCode"], coinsAmount, debtsAmount);
            }


            return table;
        }



        public static void InsertUpdateCoins()
        {
            String strProcedureName;
            SqlParameter param = new SqlParameter();
            SqlParameter identityParam = new SqlParameter();
            SqlParameter statusParam = new SqlParameter();
            List<SqlParameter> paramList = new List<SqlParameter>();

            strProcedureName = "insertCoinsDebts";
            param = SQLHelper.CreateParameter("@Route", SqlDbType.VarChar, 50);
            param.Value =routCode;
            paramList.Add(param);

            

            param = SQLHelper.CreateParameter("@SupplierCode", SqlDbType.VarChar, 50);
            param.Value = SCode;
            paramList.Add(param);
            

            param = SQLHelper.CreateParameter("@ProYear", SqlDbType.Int);
            param.Value = year;
            paramList.Add(param);
            

            param = SQLHelper.CreateParameter("@ProMonth", SqlDbType.Int);
            param.Value =month;
            paramList.Add(param);
            

            param = SQLHelper.CreateParameter("@CoinAmount", SqlDbType.Decimal);
            param.Value = coin;
            paramList.Add(param);
  
            param = SQLHelper.CreateParameter("@Debts ", SqlDbType.Decimal);
            param.Value =debt;
            paramList.Add(param);
            
   
            SQLHelper.FillDataSet(strProcedureName, CommandType.StoredProcedure, paramList);       
        }

    }
}
