using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BoughtLeafDataAccess;

namespace BoughtLeafBusinessLayer
{
    public class GreenLeaf
    {
        private String strRouteNo;

        public String StrRouteNo
        {
            get { return strRouteNo; }
            set { strRouteNo = value; }
        }
        private DateTime datCollectedDate;

        public DateTime DatCollectedDate
        {
            get { return datCollectedDate; }
            set { datCollectedDate = value; }
        }
        private String strSupplierCode;

        public String StrSupplierCode
        {
            get { return strSupplierCode; }
            set { strSupplierCode = value; }
        }

        private string strCollectorCode;

        public string StrCollectorCode
        {
            get { return strCollectorCode; }
            set { strCollectorCode = value; }
        }

        private Decimal decGreenLeafCollected;

        public Decimal DecGreenLeafCollected
        {
            get { return decGreenLeafCollected; }
            set { decGreenLeafCollected = value; }
        }
        private Decimal decModifiedGreenLeaf;

        public Decimal DecModifiedGreenLeaf
        {
            get { return decModifiedGreenLeaf; }
            set { decModifiedGreenLeaf = value; }
        }

        private String strReason;

        public String StrReason
        {
            get { return strReason; }
            set { strReason = value; }
        }
        private Decimal decNoofBags;

        public Decimal DecNoofBags
        {
            get { return decNoofBags; }
            set { decNoofBags = value; }
        }
        private Decimal decSackKilos;

        public Decimal DecSackKilos
        {
            get { return decSackKilos; }
            set { decSackKilos = value; }
        }
        private String strTownCode;

        public String StrTownCode
        {
            get { return strTownCode; }
            set { strTownCode = value; }
        }
        private String strTranCode;

        public String StrTranCode
        {
            get { return strTranCode; }
            set { strTranCode = value; }
        }

        private String strGreeLeafType;

        public String StrGreeLeafType
        {
            get { return strGreeLeafType; }
            set { strGreeLeafType = value; }
        }
        //-new fields
        private String strTransportType;

        public String StrTransportType
        {
            get { return strTransportType; }
            set { strTransportType = value; }
        }
        private String strContainerType;

        public String StrContainerType
        {
            get { return strContainerType; }
            set { strContainerType = value; }
        }
        private Decimal decNoOfContainers;

        public Decimal DecNoOfContainers
        {
          get { return decNoOfContainers; }
          set { decNoOfContainers = value; }
        }
       
        private Decimal decGrossWeight;

        public Decimal DecGrossWeight
        {
            get { return decGrossWeight; }
            set { decGrossWeight = value; }
        }
        private Decimal decContainerDeduction;

        public Decimal DecContainerDeduction
        {
            get { return decContainerDeduction; }
            set { decContainerDeduction = value; }
        }
        private Decimal decWaterDeduction;

        public Decimal DecWaterDeduction
        {
            get { return decWaterDeduction; }
            set { decWaterDeduction = value; }
        }
        private Decimal decCoarseLeafDeduction;

        public Decimal DecCoarseLeafDeduction
        {
            get { return decCoarseLeafDeduction; }
            set { decCoarseLeafDeduction = value; }
        }
        private Decimal decOtherDeduction;

        public Decimal DecOtherDeduction
        {
            get { return decOtherDeduction; }
            set { decOtherDeduction = value; }
        }
        private Decimal decNetWeight;

        public Decimal DecNetWeight
        {
            get { return decNetWeight; }
            set { decNetWeight = value; }
        }
        
       

        /// <summary>
        /// Sachintha Udara 2017.02.01
        /// </summary>
        /// <param name="pRoute"></param>
        /// <param name="pDate"></param>
        /// <returns></returns>
        public DataTable ListGreenLeafApproval(string pRoute, DateTime pDate) 
        {
            return SQLHelper.FillDataSet("SELECT dbo.DailyGreenLeaf.SupplierCode, dbo.Supplier.SupplierName, dbo.DailyGreenLeaf.CollectorCode, dbo.DailyGreenLeaf.Approval, dbo.DailyGreenLeaf.RouteNo, CollectedDate, dbo.DailyGreenLeaf.GreenLeafCollected, dbo.DailyGreenLeaf.ModifiedGreenLeaf, dbo.DailyGreenLeaf.NoofBags, dbo.DailyGreenLeaf.SackKilos, dbo.DailyGreenLeaf.transportCost, dbo.DailyGreenLeaf.TransportCode FROM dbo.DailyGreenLeaf INNER JOIN dbo.Supplier ON dbo.DailyGreenLeaf.SupplierCode = dbo.Supplier.SupplierCode WHERE (dbo.DailyGreenLeaf.CollectedDate = CONVERT(DATETIME, '" + pDate + "', 102)) AND (dbo.DailyGreenLeaf.RouteNo LIKE '" + pRoute + "') order by RouteNo", CommandType.Text).Tables[0];
        }

        /// <summary>
        /// Sachintha Udara 2017.02.01
        /// </summary>
        /// <param name="pRoute"></param>
        /// <param name="pDate"></param>
        /// <returns></returns>
        public DataTable GetTotalGreenLeafDeatailForApproval(string pRoute, DateTime pDate) 
        {
            return SQLHelper.FillDataSet("SELECT SUM(GreenLeafCollected) as 'GreenLeaf Total', SUM(NoofBags) as 'No.Bag Total', SUM(SackKilos) as 'SackKillo Total', SUM(transportCost) as 'Transport Cost' FROM dbo.DailyGreenLeaf WHERE (CollectedDate = CONVERT(DATETIME, '" + pDate + "', 102)) AND (RouteNo LIKE '" + pRoute + "')", CommandType.Text).Tables[0];
        }

        public void UpdateApprovalGreenLeaf(DateTime pDate, string pSupCode, string pRoute, bool pApproval) 
        {
            SQLHelper.ExecuteNonQuery("UPDATE DailyGreenLeaf SET Approval = '" + pApproval + "' WHERE (CollectedDate = CONVERT(DATETIME, '" + pDate + "', 102)) AND (RouteNo = '" + pRoute + "') AND (SupplierCode = '" + pSupCode + "')", CommandType.Text);
        }

        public void InsertGreenLeaf(decimal trnCost)
        {
            SQLHelper.ExecuteNonQuery("insert into DailyGreenLeaf (RouteNo,CollectedDate,SupplierCode,CollectorCode,GreenLeafCollected,ModifiedGreenLeaf,UserID,NoofBags,SackKilos, TransportCode,transportCost,LeafType,ContainerType,TransportType,NoOfContainers,ContainerDeduction,WaterDeduction,CoarseLeafDeduction,OtherDeduction,GrossWeight,NetWeight,TransportToBeCharged ) " +
            " values ('" + StrRouteNo + "','" + DatCollectedDate + "','" + StrSupplierCode + "','" + StrCollectorCode + "','" + DecGreenLeafCollected + "','" + DecModifiedGreenLeaf + "','" + BoughtLeafBusinessLayer.BLUser.StrUserName + "','" + DecNoofBags + "','" + DecSackKilos + "','" + strTranCode + "','" + trnCost * DecGrossWeight + "','" + StrGreeLeafType + "','" + StrContainerType + "','" + StrTransportType + "','" + DecNoOfContainers + "','" + DecContainerDeduction + "','" + DecWaterDeduction + "','" + DecCoarseLeafDeduction + "','" + DecOtherDeduction + "','" + DecGrossWeight + "','" + DecNetWeight + "',0)", CommandType.Text);
        }
        //sachintha udara 2016.11.02 new update
        public void UpdateGreenLeaf(decimal trnCost)
        {
            SQLHelper.ExecuteNonQuery("UPDATE [dbo].[DailyGreenLeaf] SET   [GreenLeafCollected] = '" + DecGreenLeafCollected + "',[TransportToBeCharged]='0',[UserID]='" + BoughtLeafBusinessLayer.BLUser.StrUserName + "',[CreateDateTime] = '" + DateTime.Now.ToString() + "',[NoofBags]='" + DecNoofBags + "',[SackKilos]='" + DecSackKilos + "',[transportCost]='" + trnCost * DecGreenLeafCollected + "',TransportCode ='" + StrTranCode + "',NoOfContainers='" + DecNoOfContainers + "',ContainerDeduction='" + DecContainerDeduction + "',WaterDeduction='" + DecWaterDeduction + "',CoarseLeafDeduction='" + DecCoarseLeafDeduction + "',OtherDeduction='" + DecOtherDeduction + "',GrossWeight='" + DecGrossWeight + "',NetWeight='" + DecNetWeight + "' WHERE [Approval]=0  AND [CollectedDate]='" + DatCollectedDate + "' AND [SupplierCode] = '" + StrSupplierCode + "' AND (ContainerType='" + StrContainerType + "') AND (TransportType='" + StrTransportType + "') AND (LeafType like '%" + StrGreeLeafType + "%') AND (CollectorCode='" + StrCollectorCode + "') ", CommandType.Text);
        }

        public DataTable ListRoutes()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("RouteNo"));
            dt.Columns.Add(new DataColumn("CollectedDate"));
            dt.Columns.Add(new DataColumn("UserID"));
            dt.Columns.Add(new DataColumn("Processed"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT DISTINCT TOP (100) PERCENT RouteNo, CollectedDate, UserID, Processed FROM dbo.DailyGreenLeaf", CommandType.Text);

            while (dataReader.Read())
            {
                dtrow = dt.NewRow();

                if (!dataReader.IsDBNull(0))
                {
                    dtrow[0] = dataReader.GetString(0).Trim();
                }

                if (!dataReader.IsDBNull(1))
                {
                    dtrow[1] = dataReader.GetDateTime(1).ToShortDateString();
                }
                if (!dataReader.IsDBNull(2))
                {
                    dtrow[2] = dataReader.GetString(2).ToString();
                }
                if (!dataReader.IsDBNull(3))
                {
                    dtrow[3] = dataReader.GetBoolean(3);
                }
                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }

        public DataTable ListRoutes(int pYear, int pMonth)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("RouteNo"));
            dt.Columns.Add(new DataColumn("CollectedDate"));
            dt.Columns.Add(new DataColumn("UserID"));
            dt.Columns.Add(new DataColumn("Processed"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT dbo.Route.RouteName, dbo.DailyGreenLeaf.CollectedDate, dbo.DailyGreenLeaf.UserID, dbo.DailyGreenLeaf.Processed FROM dbo.DailyGreenLeaf INNER JOIN dbo.Route ON dbo.DailyGreenLeaf.RouteNo = dbo.Route.RouteCode WHERE (YEAR(dbo.DailyGreenLeaf.CollectedDate) = '" + pYear + "') AND (MONTH(dbo.DailyGreenLeaf.CollectedDate) = '" + pMonth + "') GROUP BY dbo.Route.RouteName, dbo.DailyGreenLeaf.CollectedDate, dbo.DailyGreenLeaf.UserID, dbo.DailyGreenLeaf.Processed", CommandType.Text);

            while (dataReader.Read())
            {
                dtrow = dt.NewRow();

                if (!dataReader.IsDBNull(0))
                {
                    dtrow[0] = dataReader.GetString(0).Trim();
                }

                if (!dataReader.IsDBNull(1))
                {
                    dtrow[1] = dataReader.GetDateTime(1).ToShortDateString();
                }
                if (!dataReader.IsDBNull(2))
                {
                    dtrow[2] = dataReader.GetString(2).ToString();
                }
                if (!dataReader.IsDBNull(3))
                {
                    dtrow[3] = dataReader.GetBoolean(3);
                }
                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }

        public DataTable ListRoutes(DateTime dtDate)
        {
            DataTable dt = new DataTable();
         
            dt.Columns.Add(new DataColumn("RouteName"));//2
            dt.Columns.Add(new DataColumn("Green Leaf Collected"));//3
            dt.Columns.Add(new DataColumn("NoOfContainers"));//4
            dt.Columns.Add(new DataColumn("GrossWeight"));//14
            dt.Columns.Add(new DataColumn("ContainerDeduction"));//5
            dt.Columns.Add(new DataColumn("WaterDeduction"));//11
            dt.Columns.Add(new DataColumn("CoarseLeafDeduction"));//12
            dt.Columns.Add(new DataColumn("OtherDeduction"));//13
           
            dt.Columns.Add(new DataColumn("NetWeight"));//15


            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();

            
            //dataReader = SQLHelper.ExecuteReader("SELECT    dbo.Route.RouteName, SUM(dbo.DailyGreenLeaf.GreenLeafCollected) AS GreenLeaf,  dbo.DailyGreenLeaf.NoOfContainers, dbo.DailyGreenLeaf.ContainerDeduction, dbo.DailyGreenLeaf.LeafType, dbo.DailyGreenLeaf.ContainerType, dbo.DailyGreenLeaf.WaterDeduction,  dbo.DailyGreenLeaf.CoarseLeafDeduction, dbo.DailyGreenLeaf.OtherDeduction, dbo.DailyGreenLeaf.GrossWeight, dbo.DailyGreenLeaf.NetWeight FROM dbo.DailyGreenLeaf INNER JOIN dbo.Route ON dbo.DailyGreenLeaf.RouteNo = dbo.Route.RouteCode WHERE  (dbo.DailyGreenLeaf.CollectedDate = '" + dtDate + "') GROUP BY dbo.Route.RouteName", CommandType.Text);
            dataReader = SQLHelper.ExecuteReader("SELECT   dbo.Route.RouteName, SUM(dbo.DailyGreenLeaf.GreenLeafCollected),  SUM(dbo.DailyGreenLeaf.NoOfContainers), SUM(dbo.DailyGreenLeaf.GrossWeight), SUM(dbo.DailyGreenLeaf.ContainerDeduction), SUM(dbo.DailyGreenLeaf.WaterDeduction),  SUM(dbo.DailyGreenLeaf.CoarseLeafDeduction), SUM(dbo.DailyGreenLeaf.OtherDeduction), SUM(dbo.DailyGreenLeaf.NetWeight) FROM dbo.DailyGreenLeaf INNER JOIN dbo.Route ON dbo.DailyGreenLeaf.RouteNo = dbo.Route.RouteCode WHERE  (dbo.DailyGreenLeaf.CollectedDate = '" + dtDate + "') GROUP BY dbo.Route.RouteName", CommandType.Text);
            
           
            while (dataReader.Read())
            {
                dtrow = dt.NewRow();

                
                if (!dataReader.IsDBNull(0))
                {
                    dtrow[0] = dataReader.GetString(0).Trim();
                }
                if (!dataReader.IsDBNull(1))
                {
                    dtrow[1] = dataReader.GetDecimal(1).ToString("N");
                }
                if (!dataReader.IsDBNull(2))
                {
                    dtrow[2] = dataReader.GetDecimal(2).ToString("N2");
                }
                if (!dataReader.IsDBNull(3))
                {
                    dtrow[3] = dataReader.GetDecimal(3).ToString("N2");
                }
                else 
                {
                    dtrow[3] = 0;
                }
                if (!dataReader.IsDBNull(4))
                {
                    dtrow[4] = dataReader.GetDecimal(4).ToString("N2");
                }

                if (!dataReader.IsDBNull(5))
                {
                    dtrow[5] = dataReader.GetDecimal(5).ToString("N2");
                }
                else
                {
                    dtrow[5] = 0;
                }
         
                if (!dataReader.IsDBNull(6))
                {
                    dtrow[6] = dataReader.GetDecimal(6).ToString("N2");
                }
                else
                {
                    dtrow[6] = 0;
                }
            
                if (!dataReader.IsDBNull(7))
                {
                    dtrow[7] = dataReader.GetDecimal(7).ToString("N2");
                }
                else
                {
                    dtrow[7] = 0;
                }
          
                if (!dataReader.IsDBNull(8))
                {
                    dtrow[8] = dataReader.GetDecimal(8).ToString("N2");
                }
                else
                {
                    dtrow[8] = 0;
                }
               
       
               

                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;

            
        }

        public DataTable ListRoutesTotal(DateTime dtDate)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("RouteName"));//2
            dt.Columns.Add(new DataColumn("Green Leaf Collected"));//3
            dt.Columns.Add(new DataColumn("NoOfContainers"));//4
            dt.Columns.Add(new DataColumn("GrossWeight"));//14
            dt.Columns.Add(new DataColumn("ContainerDeduction"));//5
            dt.Columns.Add(new DataColumn("WaterDeduction"));//11
            dt.Columns.Add(new DataColumn("CoarseLeafDeduction"));//12
            dt.Columns.Add(new DataColumn("OtherDeduction"));//13

            dt.Columns.Add(new DataColumn("NetWeight"));//15


            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();


            //dataReader = SQLHelper.ExecuteReader("SELECT    dbo.Route.RouteName, SUM(dbo.DailyGreenLeaf.GreenLeafCollected) AS GreenLeaf,  dbo.DailyGreenLeaf.NoOfContainers, dbo.DailyGreenLeaf.ContainerDeduction, dbo.DailyGreenLeaf.LeafType, dbo.DailyGreenLeaf.ContainerType, dbo.DailyGreenLeaf.WaterDeduction,  dbo.DailyGreenLeaf.CoarseLeafDeduction, dbo.DailyGreenLeaf.OtherDeduction, dbo.DailyGreenLeaf.GrossWeight, dbo.DailyGreenLeaf.NetWeight FROM dbo.DailyGreenLeaf INNER JOIN dbo.Route ON dbo.DailyGreenLeaf.RouteNo = dbo.Route.RouteCode WHERE  (dbo.DailyGreenLeaf.CollectedDate = '" + dtDate + "') GROUP BY dbo.Route.RouteName", CommandType.Text);
            dataReader = SQLHelper.ExecuteReader("SELECT   'Total' as RouteName , SUM(dbo.DailyGreenLeaf.GreenLeafCollected),  SUM(dbo.DailyGreenLeaf.NoOfContainers), SUM(dbo.DailyGreenLeaf.GrossWeight), SUM(dbo.DailyGreenLeaf.ContainerDeduction), SUM(dbo.DailyGreenLeaf.WaterDeduction),  SUM(dbo.DailyGreenLeaf.CoarseLeafDeduction), SUM(dbo.DailyGreenLeaf.OtherDeduction), SUM(dbo.DailyGreenLeaf.NetWeight) FROM dbo.DailyGreenLeaf INNER JOIN dbo.Route ON dbo.DailyGreenLeaf.RouteNo = dbo.Route.RouteCode WHERE  (dbo.DailyGreenLeaf.CollectedDate = '" + dtDate + "') ", CommandType.Text);

            while (dataReader.Read())
            {
                dtrow = dt.NewRow();


                if (!dataReader.IsDBNull(0))
                {
                    dtrow[0] = dataReader.GetString(0).Trim();
                }
                if (!dataReader.IsDBNull(1))
                {
                    dtrow[1] = dataReader.GetDecimal(1).ToString("N");
                }
                if (!dataReader.IsDBNull(2))
                {
                    dtrow[2] = dataReader.GetDecimal(2).ToString("N2");
                }
                if (!dataReader.IsDBNull(3))
                {
                    dtrow[3] = dataReader.GetDecimal(3).ToString("N2");
                }
                else
                {
                    dtrow[3] = 0;
                }
                if (!dataReader.IsDBNull(4))
                {
                    dtrow[4] = dataReader.GetDecimal(4).ToString("N2");
                }

                if (!dataReader.IsDBNull(5))
                {
                    dtrow[5] = dataReader.GetDecimal(5).ToString("N2");
                }
                else
                {
                    dtrow[5] = 0;
                }

                if (!dataReader.IsDBNull(6))
                {
                    dtrow[6] = dataReader.GetDecimal(6).ToString("N2");
                }
                else
                {
                    dtrow[6] = 0;
                }

                if (!dataReader.IsDBNull(7))
                {
                    dtrow[7] = dataReader.GetDecimal(7).ToString("N2");
                }
                else
                {
                    dtrow[7] = 0;
                }

                if (!dataReader.IsDBNull(8))
                {
                    dtrow[8] = dataReader.GetDecimal(8).ToString("N2");
                }
                else
                {
                    dtrow[8] = 0;
                }




                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;


        }

        //public DataTable ListRoutes(DateTime dtDate)
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add(new DataColumn("RouteNo"));
        //    dt.Columns.Add(new DataColumn("CollectedDate"));
        //    dt.Columns.Add(new DataColumn("UserID"));
        //    dt.Columns.Add(new DataColumn("Processed"));
        //    dt.Columns.Add(new DataColumn("GreenLeaf"));

        //    DataRow dtrow;
        //    SqlDataReader dataReader;
        //    dtrow = dt.NewRow();
        //    dataReader = SQLHelper.ExecuteReader("SELECT dbo.Route.RouteName, dbo.DailyGreenLeaf.CollectedDate, dbo.DailyGreenLeaf.UserID, dbo.DailyGreenLeaf.Processed,SUM(dbo.DailyGreenLeaf.GreenLeafCollected) AS GreenLeaf FROM dbo.DailyGreenLeaf INNER JOIN dbo.Route ON dbo.DailyGreenLeaf.RouteNo = dbo.Route.RouteCode WHERE  (dbo.DailyGreenLeaf.CollectedDate = '" + dtDate + "') GROUP BY dbo.Route.RouteName, dbo.DailyGreenLeaf.CollectedDate, dbo.DailyGreenLeaf.UserID, dbo.DailyGreenLeaf.Processed", CommandType.Text);

        //    while (dataReader.Read())
        //    {
        //        dtrow = dt.NewRow();

        //        if (!dataReader.IsDBNull(0))
        //        {
        //            dtrow[0] = dataReader.GetString(0).Trim();
        //        }

        //        if (!dataReader.IsDBNull(1))
        //        {
        //            dtrow[1] = dataReader.GetDateTime(1).ToShortDateString();
        //        }
        //        if (!dataReader.IsDBNull(2))
        //        {
        //            dtrow[2] = dataReader.GetString(2).ToString();
        //        }
        //        if (!dataReader.IsDBNull(3))
        //        {
        //            dtrow[3] = dataReader.GetBoolean(3);
        //        }
        //        if (!dataReader.IsDBNull(4))
        //        {
        //            dtrow[4] = dataReader.GetDecimal(4);
        //        }
        //        dt.Rows.Add(dtrow);
        //    }
        //    dataReader.Close();
        //    return dt;
        //}
        //sachintha create new method
        //2016-11-9
        public decimal MonthGreenLeafTotal(int pYear, int pMonth) 
        {
            decimal total = 0;
            SqlDataReader dataReader;
            //dataReader = SQLHelper.ExecuteReader("SELECT SUM(GreenLeafCollected) AS Expr1 FROM dbo.DailyGreenLeaf WHERE (YEAR(CollectedDate) = " + pYear + ") AND (MONTH(CollectedDate) = " + pMonth + ")", CommandType.Text);
            dataReader = SQLHelper.ExecuteReader("SELECT SUM(NetWeight) AS Expr1 FROM dbo.DailyGreenLeaf WHERE (YEAR(CollectedDate) = " + pYear + ") AND (MONTH(CollectedDate) = " + pMonth + ")", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    total = dataReader.GetDecimal(0);
                }
            }
            return total;
        }

        public decimal MonthGreenLeafTotal(DateTime dtDate)
        {
            decimal total = 0;
            SqlDataReader dataReader;
            //dataReader = SQLHelper.ExecuteReader("SELECT SUM(GreenLeafCollected) AS Expr1 FROM dbo.DailyGreenLeaf WHERE (CollectedDate = '" + dtDate + "') ", CommandType.Text);
            dataReader = SQLHelper.ExecuteReader("SELECT SUM(NetWeight) AS Expr1 FROM dbo.DailyGreenLeaf WHERE (CollectedDate = '" + dtDate + "') ", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    total = dataReader.GetDecimal(0);
                }
            }
            return total;
        }

        public DataTable getSuppliyerGreenLeafTotal(DateTime dtDate, string route, String strSupp)
        {
            SqlDataReader dataReader;
            SqlDataReader dataReader1;
            DateTime dtFromDate = new DateTime(dtDate.Year, dtDate.Month, 1);
            DataTable dt = new DataTable("SuppliyerGreenLeafSummary");
            dt.Columns.Add(new DataColumn("SelectedDateTotal"));//0
            dt.Columns.Add(new DataColumn("ToDateTotal"));//1

            DataRow dtrow;
            dtrow = dt.NewRow();

            dataReader = SQLHelper.ExecuteReader("SELECT  SUM(NetWeight) AS Expr1 FROM dbo.DailyGreenLeaf WHERE (SupplierCode = '" + strSupp + "') AND (RouteNo = '" + route + "') AND (CollectedDate between CONVERT(DATETIME, '" + dtFromDate + "', 102) and CONVERT(DATETIME, '" + dtDate + "', 102)) ", CommandType.Text);

            while (dataReader.Read())
            {
                dtrow = dt.NewRow();

                if (!dataReader.IsDBNull(0))
                {
                    dtrow[1] = dataReader.GetDecimal(0);
                }
                else
                    dtrow[1] = 0;

                dataReader1 = SQLHelper.ExecuteReader("SELECT  SUM(NetWeight) AS Expr1 FROM dbo.DailyGreenLeaf WHERE (SupplierCode = '" + strSupp + "') AND (RouteNo = '" + route + "') AND (CollectedDate = CONVERT(DATETIME, '" + dtDate + "', 102)) ", CommandType.Text);

                while (dataReader1.Read())
                {

                    if (!dataReader1.IsDBNull(0))
                    {
                        dtrow[0] = dataReader1.GetDecimal(0);
                    }
                    else
                        dtrow[0] = 0;


                }
                dt.Rows.Add(dtrow);
                dataReader1.Close();
            }
            dataReader.Close();
            return dt;
        }

        //sachintha udara created new datatable retrive with
        //parameters route and specific date
        //2016.10.25
        //start
        public DataTable getGreenLeafDetailByDateAndRoute(DateTime date, string route, int chkAllRoutes) 
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("SupplierCode"));//0
            dt.Columns.Add(new DataColumn("SupplierName"));//1
            dt.Columns.Add(new DataColumn("CollectorCode"));//2
            dt.Columns.Add(new DataColumn("Green Leaf Collected"));//3
            dt.Columns.Add(new DataColumn("NoOfContainers"));//4
            dt.Columns.Add(new DataColumn("ContainerDeduction"));//5
            dt.Columns.Add(new DataColumn("Route"));//6
            dt.Columns.Add(new DataColumn("TransportCode"));//7
            dt.Columns.Add(new DataColumn("LeafType"));//8
            dt.Columns.Add(new DataColumn("TransportType"));//9
            dt.Columns.Add(new DataColumn("ContainerType"));//10
            dt.Columns.Add(new DataColumn("WaterDeduction"));//11
            dt.Columns.Add(new DataColumn("CoarseLeafDeduction"));//12
            dt.Columns.Add(new DataColumn("OtherDeduction"));//13
            dt.Columns.Add(new DataColumn("GrossWeight"));//14
            dt.Columns.Add(new DataColumn("NetWeight"));//15
            

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            if (chkAllRoutes == 1) 
            {
                dataReader = SQLHelper.ExecuteReader("SELECT    dbo.DailyGreenLeaf.SupplierCode, dbo.Supplier.SupplierName, dbo.DailyGreenLeaf.CollectorCode, dbo.DailyGreenLeaf.GreenLeafCollected,  dbo.DailyGreenLeaf.NoOfContainers, dbo.DailyGreenLeaf.ContainerDeduction, dbo.DailyGreenLeaf.RouteNo, dbo.DailyGreenLeaf.TransportCode,  dbo.DailyGreenLeaf.LeafType, dbo.DailyGreenLeaf.TransportType, dbo.DailyGreenLeaf.ContainerType, dbo.DailyGreenLeaf.WaterDeduction,  dbo.DailyGreenLeaf.CoarseLeafDeduction, dbo.DailyGreenLeaf.OtherDeduction, dbo.DailyGreenLeaf.GrossWeight, dbo.DailyGreenLeaf.NetWeight FROM dbo.DailyGreenLeaf INNER JOIN dbo.Supplier ON dbo.DailyGreenLeaf.SupplierCode = dbo.Supplier.SupplierCode WHERE (dbo.DailyGreenLeaf.CollectedDate = '" + date + "')", CommandType.Text);
            }
            else
            {
                dataReader = SQLHelper.ExecuteReader("SELECT    dbo.DailyGreenLeaf.SupplierCode, dbo.Supplier.SupplierName, dbo.DailyGreenLeaf.CollectorCode, dbo.DailyGreenLeaf.GreenLeafCollected,  dbo.DailyGreenLeaf.NoOfContainers, dbo.DailyGreenLeaf.ContainerDeduction, dbo.DailyGreenLeaf.RouteNo, dbo.DailyGreenLeaf.TransportCode,  dbo.DailyGreenLeaf.LeafType, dbo.DailyGreenLeaf.TransportType, dbo.DailyGreenLeaf.ContainerType, dbo.DailyGreenLeaf.WaterDeduction,  dbo.DailyGreenLeaf.CoarseLeafDeduction, dbo.DailyGreenLeaf.OtherDeduction, dbo.DailyGreenLeaf.GrossWeight, dbo.DailyGreenLeaf.NetWeight FROM dbo.DailyGreenLeaf INNER JOIN dbo.Supplier ON dbo.DailyGreenLeaf.SupplierCode = dbo.Supplier.SupplierCode WHERE (dbo.DailyGreenLeaf.CollectedDate = '" + date + "') AND (dbo.DailyGreenLeaf.RouteNo LIKE '" + route + "')", CommandType.Text);
            }
            while (dataReader.Read())
            {
                dtrow = dt.NewRow();

                if (!dataReader.IsDBNull(0))
                {
                    dtrow[0] = dataReader.GetString(0).Trim();
                }
                if (!dataReader.IsDBNull(1))
                {
                    dtrow[1] = dataReader.GetString(1);
                }
                if (!dataReader.IsDBNull(2))
                {
                    dtrow[2] = dataReader.GetString(2);
                }
                if (!dataReader.IsDBNull(3))
                {
                    dtrow[3] = dataReader.GetDecimal(3).ToString("N2");
                }
                if (!dataReader.IsDBNull(4))
                {
                    dtrow[4] = dataReader.GetDecimal(4).ToString("N2");
                }
                if (!dataReader.IsDBNull(5))
                {
                    dtrow[5] = dataReader.GetDecimal(5).ToString("N2");
                }
                if (!dataReader.IsDBNull(6))
                {
                    dtrow[6] = dataReader.GetString(6);
                }
                //Transport Code
                if (!dataReader.IsDBNull(7))
                {
                    dtrow[7] = dataReader.GetString(7);
                }
                //Leaf Type
                if (!dataReader.IsDBNull(8))
                {
                    dtrow[8] = dataReader.GetString(8);
                }
                //Transport Type
                if (!dataReader.IsDBNull(9))
                {
                    dtrow[9] = dataReader.GetString(9);
                }
                //Container type
                if (!dataReader.IsDBNull(10))
                {
                    dtrow[10] = dataReader.GetString(10);
                }
                //Water Deduction
                if (!dataReader.IsDBNull(11))
                {
                    dtrow[11] = dataReader.GetDecimal(11).ToString("N2");
                }
                else
                {
                    dtrow[11] = 0;
                }
                //Coarse Leaf Deduction
                if (!dataReader.IsDBNull(12))
                {
                    dtrow[12] = dataReader.GetDecimal(12).ToString("N2");
                }
                else
                {
                    dtrow[12] = 0;
                }
                //Other Deduction
                if (!dataReader.IsDBNull(13))
                {
                    dtrow[13] = dataReader.GetDecimal(13).ToString("N2");
                }
                else
                {
                    dtrow[13] = 0;
                }
                //Gross Weight
                if (!dataReader.IsDBNull(14))
                {
                    dtrow[14] = dataReader.GetDecimal(14).ToString("N2");
                }
                else
                {
                    dtrow[14] =0;
                }
                //Net Weight
                if (!dataReader.IsDBNull(15))
                {
                    dtrow[15] = dataReader.GetDecimal(15).ToString("N2");
                }
                else
                {
                    dtrow[15] = 0;
                }

                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }

        public DataTable getGreenLeafDetailByDateAndRoute(DateTime date)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("SupplierCode"));//0
            dt.Columns.Add(new DataColumn("SupplierName"));//1
            dt.Columns.Add(new DataColumn("CollectorCode"));//2
            dt.Columns.Add(new DataColumn("Green Leaf Collected"));//3
            dt.Columns.Add(new DataColumn("NoofBags"));//4
            dt.Columns.Add(new DataColumn("SackKilos"));//5
            dt.Columns.Add(new DataColumn("Route"));//6

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();

            dataReader = SQLHelper.ExecuteReader("SELECT dbo.DailyGreenLeaf.SupplierCode, dbo.Supplier.SupplierName, dbo.DailyGreenLeaf.CollectorCode, dbo.DailyGreenLeaf.GreenLeafCollected, dbo.DailyGreenLeaf.NoofBags, dbo.DailyGreenLeaf.SackKilos, dbo.DailyGreenLeaf.RouteNo FROM dbo.DailyGreenLeaf INNER JOIN dbo.Supplier ON dbo.DailyGreenLeaf.SupplierCode = dbo.Supplier.SupplierCode WHERE (dbo.DailyGreenLeaf.CollectedDate = '" + date + "') ", CommandType.Text);

            while (dataReader.Read())
            {
                dtrow = dt.NewRow();

                if (!dataReader.IsDBNull(0))
                {
                    dtrow[0] = dataReader.GetString(0).Trim();
                }
                if (!dataReader.IsDBNull(1))
                {
                    dtrow[1] = dataReader.GetString(1);
                }
                if (!dataReader.IsDBNull(2))
                {
                    dtrow[2] = dataReader.GetString(2);
                }
                if (!dataReader.IsDBNull(3))
                {
                    dtrow[3] = dataReader.GetDecimal(3).ToString("N2");
                }
                if (!dataReader.IsDBNull(4))
                {
                    dtrow[4] = dataReader.GetDecimal(4).ToString("N2");
                }
                if (!dataReader.IsDBNull(5))
                {
                    dtrow[5] = dataReader.GetDecimal(5).ToString("N2");
                }
                if (!dataReader.IsDBNull(6))
                {
                    dtrow[6] = dataReader.GetString(6);
                }
                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }

        public decimal getGreenLeafTotal(DateTime date, string route) 
        {

            decimal total = 0;
            SqlDataReader dataReader;
            //dataReader = SQLHelper.ExecuteReader("SELECT SUM([GreenLeafCollected]) AS 'EXPR' FROM [dbo].[DailyGreenLeaf] WHERE [RouteNo] LIKE '" + route + "' AND [CollectedDate] = '" + date + "'", CommandType.Text);
            dataReader = SQLHelper.ExecuteReader("SELECT SUM([NetWeight]) AS 'EXPR' FROM [dbo].[DailyGreenLeaf] WHERE [RouteNo] LIKE '" + route + "' AND [CollectedDate] = '" + date + "'", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    total = dataReader.GetDecimal(0);
                }
            }
            return total;
        }
        //end

        public void DeleteGreenLeaf()
        {
            SQLHelper.ExecuteNonQuery("delete from  DailyGreenLeaf where RouteNo = '" + StrRouteNo + "' and CollectedDate = '" + DatCollectedDate + "' and SupplierCode = '" + StrSupplierCode + "' and Approval = 0   AND (ContainerType='" + StrContainerType + "') AND (TransportType='" + StrTransportType + "') AND (LeafType like '%" + StrGreeLeafType + "%')", CommandType.Text);
        }
        public void DeleteGreenLeafAll(DateTime pDate, string pRoute)
        {
            SQLHelper.ExecuteNonQuery("delete from  DailyGreenLeaf where RouteNo = '" + pRoute + "' and CollectedDate = '" + pDate + "' and Approval=0", CommandType.Text);
        }
        public Decimal getSupplierWiseGreenLeaf(Int32 Year,Int32 Month)
        {
            Decimal GreenLeaf = 0;

            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT SUM(GreenLeafCollected) AS GreenLeafCollected FROM dbo.DailyGreenLeaf WHERE (YEAR(CollectedDate) = '" + Year + "') AND (MONTH(CollectedDate) = '" + Month + "') AND (SupplierCode = '" + StrSupplierCode + "')", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    GreenLeaf = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();
            return GreenLeaf;
        }
        public Decimal getSupplierWiseGreenLeafToDate(int FromDate, int ToDate,string supCode, string route)
        {
            Decimal GreenLeaf = 0;

            SqlDataReader dataReader;
            //dataReader = SQLHelper.ExecuteReader("SELECT SUM(GreenLeafCollected) AS GreenLeafCollected FROM  dbo.DailyGreenLeaf WHERE     (SupplierCode = '" + supCode + "') AND (CollectedDate BETWEEN CONVERT(DATETIME, '" + FromDate + "',102) AND CONVERT(DATETIME, '" + ToDate + "',102))GROUP BY RouteNo HAVING (RouteNo = '" + route + "')", CommandType.Text);
            dataReader = SQLHelper.ExecuteReader("SELECT SUM(GreenLeafCollected) AS Expr4 FROM DailyGreenLeaf GROUP BY YEAR(CollectedDate), MONTH(CollectedDate), SupplierCode, RouteNo HAVING      (YEAR(CollectedDate) = 2016) AND (MONTH(CollectedDate) = '"+ ToDate +"') AND (SupplierCode = '"+ supCode +"') AND (RouteNo = '"+ route +"')", CommandType.Text); 
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    GreenLeaf = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();
            return GreenLeaf;
        }
        public Decimal getUnProcessedSupplierWiseGreenLeaf(Int32 Year, Int32 Month,String RouteName, string sCode)
        {
            Decimal GreenLeaf = 0;

            SqlDataReader dataReader;

           
            dataReader = SQLHelper.ExecuteReader("SELECT SUM(GreenLeafCollected) AS GreenLeafCollected FROM dbo.DailyGreenLeaf WHERE (YEAR(CollectedDate) = '" + Year + "') AND (MONTH(CollectedDate) = '" + Month + "') AND (SupplierCode = '" + sCode + "') AND  (Processed = 0) and (RouteNo = '" + RouteName + "')", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    GreenLeaf = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();
            SQLHelper.ExecuteNonQuery("update DailyGreenLeaf set Processed=1 where year(CollectedDate) = '" + Year + "' and month(CollectedDate) = '" + Month + "' and SupplierCode = '" + StrSupplierCode + "' and RouteNo = '" + RouteName + "'", CommandType.Text);

            return GreenLeaf;
        }

        //SACHINTHA -20161028
        //REMOVE ROUTE FROM FILTERING
        public Decimal getUnProcessedSupplierWiseGreenLeaf(int pYear, int pMonth, string pSupCode)
        {
            Decimal GreenLeaf = 0;

            SqlDataReader dataReader;


           // dataReader = SQLHelper.ExecuteReader("SELECT SUM(GreenLeafCollected) AS GreenLeafCollected FROM dbo.DailyGreenLeaf WHERE (YEAR(CollectedDate) = '" + pYear + "') AND (MONTH(CollectedDate) = '" + pMonth + "') AND (SupplierCode = '" + pSupCode + "') AND  (Processed = 0) AND (Approval = 1) ", CommandType.Text);
            dataReader = SQLHelper.ExecuteReader("SELECT ISNULL(SUM(GreenLeafCollected),0) AS GreenLeafCollected FROM dbo.DailyGreenLeaf WHERE (YEAR(CollectedDate) = '" + pYear + "') AND (MONTH(CollectedDate) = '" + pMonth + "') AND (SupplierCode = '" + pSupCode + "') AND  (Processed = 0)  ", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    GreenLeaf = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();
            //SQLHelper.ExecuteNonQuery("update DailyGreenLeaf set Processed=1 where year(CollectedDate) = '" + pYear + "' and month(CollectedDate) = '" + pMonth + "' and SupplierCode = '" + pSupCode + "' ", CommandType.Text);

            return GreenLeaf;
        }

        public Decimal getLeaftoEdit()
        {
            Decimal GreenLeaf = 0;

            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT GreenLeafCollected FROM dbo.DailyGreenLeaf WHERE (RouteNo = '" + StrRouteNo + "') AND (CollectedDate = CONVERT(DATETIME, '" + DatCollectedDate + "',102)) AND (SupplierCode = '" + StrSupplierCode + "') AND (Processed = 0)", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    GreenLeaf = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();
            return GreenLeaf;
        }

        public void InsertGreenLeafEdit()
        {
            SQLHelper.ExecuteNonQuery("insert into DailyGreenLeafEdit (RouteNo,CollectedDate,SupplierCode,OriginalLeaf,NewLeaf,Reason,UserID) values ('" + StrRouteNo + "','" + DatCollectedDate + "','" + StrSupplierCode + "','" + DecGreenLeafCollected + "','" + DecModifiedGreenLeaf + "','" + StrReason + "','" + BoughtLeafBusinessLayer.BLUser.StrUserName + "')", CommandType.Text);
        }

        public void UpdateAsProcessed(Int32 year, Int32 month)
        {
            SQLHelper.ExecuteNonQuery("update DailyGreenLeaf set Processed=1 where year(CollectedDate) = '" + year + "' and month(CollectedDate) = '" + month + "' and SupplierCode = '" + StrSupplierCode + "'", CommandType.Text);
        }

        public void CancelUpdateAsProcessed(Int32 year, Int32 month, String RouteName)
        {
            SQLHelper.ExecuteNonQuery("update DailyGreenLeaf set Processed=0 where year(CollectedDate) = '" + year + "' and month(CollectedDate) = '" + month + "' and RouteNo = '" + RouteName + "'", CommandType.Text);
        }

        public DataSet ListGreenLeafRegister(DateTime dtFrom, DateTime dtTo, String strRoute, String strSupp)
        {
            DataSet dsGLReg = new DataSet();
            dsGLReg=SQLHelper.FillDataSet("SELECT RouteNo, SupplierCode, CollectedDate, GrossWeight, ContainerType, NoOfContainers, ContainerDeduction, WaterDeduction, CoarseLeafDeduction, OtherDeduction, NetWeight, TransportCode, LeafType, TransportType,  CollectorCode FROM            dbo.DailyGreenLeaf WHERE        (CollectedDate BETWEEN CONVERT(DATETIME, '" + dtFrom + "', 102) AND CONVERT(DATETIME, '" + dtTo + "', 102)) AND (SupplierCode like  '" + strSupp + "') AND (RouteNo like '" + strRoute + "')", CommandType.Text);
            return dsGLReg;
        }

        

    }
}
