using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BoughtLeafDataAccess;



namespace BoughtLeafBusinessLayer
{

    public class SlabIncentive
    {
        public String status = "", status2 = "";
        //private string code;

        //public string Code
        //{
        //    get { return code; }
        //    set { code = value; }
        //}
        //private string name;

        //public string Name
        //{
        //    get { return name; }
        //    set { name = value; }
        //}
        //private int from;

        //public int From
        //{
        //    get { return from; }
        //    set { from = value; }
        //}
        //private int to;

        //public int To
        //{
        //    get { return to; }
        //    set { to = value; }
        //}

        //private decimal Incentives;

        //public decimal Incentives1
        //{
        //    get { return Incentives; }
        //    set { Incentives = value; }
        //}





        public DataTable SlabAdd(string Code, string Name, int From, int To, decimal Incentives)
        {
         
            SqlParameter statusParam = new SqlParameter();
            DataTable dt = SQLHelper.FillDataSet("SlabIncenstiveADD", CommandType.StoredProcedure, setParameterList(Code, Name, From, To, Incentives)).Tables[0];

            return dt;


        }
        public DataTable SlabDelete(string Code)
        {
            DataTable dt = SQLHelper.FillDataSet("SlabIncentiveDelete", CommandType.StoredProcedure, setparameterListDelete(Code)).Tables[0];
            return dt;
        }

        private List<SqlParameter> setParameterList(string Code, string Name, int From, int To, decimal Incentives)
        {
            SqlParameter param = new SqlParameter();
            List<SqlParameter> paramList = new List<SqlParameter>();

            param = SQLHelper.CreateParameter("@Code", SqlDbType.VarChar,50);
            param.Value = Code;
            paramList.Add(param);

            param = SQLHelper.CreateParameter("@Name", SqlDbType.VarChar,50);
            param.Value = Name;
            paramList.Add(param);

            param = SQLHelper.CreateParameter("@From", SqlDbType.Int);
            param.Value = From;
            paramList.Add(param);

            param = SQLHelper.CreateParameter("@To", SqlDbType.Int);
            param.Value = To;
            paramList.Add(param);

            param = SQLHelper.CreateParameter("@incentives", SqlDbType.Decimal);
            param.Value = Incentives;
            paramList.Add(param);

            return paramList;
        }

        private List<SqlParameter> setparameterListDelete(string code)
        {
            SqlParameter param = new SqlParameter();
            List<SqlParameter> paramList = new List<SqlParameter>();

            param = SQLHelper.CreateParameter("@Code", SqlDbType.VarChar, 50);
            param.Value = code;
            paramList.Add(param);

            return paramList;
        }

        public DataSet fillHeadSlabdgv()
        {
            DataSet ds = new DataSet();
            ds = SQLHelper.FillDataSet("SELECT        Code, Name  FROM            dbo.SlabInsentiveHeader", CommandType.Text);
            return ds;
        }
        public DataSet FillDetaillabdgv(string code)
        {
            DataSet ds = new DataSet();
            ds = SQLHelper.FillDataSet("SELECT    [From], [To], Insentive FROM   dbo.SlabInsentiveDetails WHERE    (Code = '"+code+"')", CommandType.Text);
            return ds;
        }

    }
}
