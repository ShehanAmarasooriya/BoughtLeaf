using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BoughtLeafDataAccess;


namespace BoughtLeafBusinessLayer
{
    public class Reports
    {
        BLTransportCost myTran = new BLTransportCost();

        public DataSet getGreenLeafSummary(int Year, int Month, String strRoute, String strLeafType)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();

            da.SelectCommand = SQLHelper.CreateCommand("SELECT  YEAR(dbo.DailyGreenLeaf.CollectedDate) AS Year, MONTH(dbo.DailyGreenLeaf.CollectedDate) AS Month, DAY(dbo.DailyGreenLeaf.CollectedDate) AS Day,  dbo.Supplier.SupplierName AS Supplier, sum(dbo.DailyGreenLeaf.NetWeight), dbo.Supplier.SupplierCode, dbo.DailyGreenLeaf.RouteNo,  dbo.Route.RouteName AS 'TownName', dbo.DailyGreenLeaf.LeafType FROM            dbo.DailyGreenLeaf INNER JOIN dbo.Supplier ON dbo.DailyGreenLeaf.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.Route ON dbo.DailyGreenLeaf.RouteNo = dbo.Route.RouteCode WHERE        (YEAR(dbo.DailyGreenLeaf.CollectedDate) = '" + Year + "') AND (MONTH(dbo.DailyGreenLeaf.CollectedDate) = '" + Month + "') AND (dbo.DailyGreenLeaf.RouteNo LIKE '" + strRoute + "') AND  (dbo.DailyGreenLeaf.LeafType LIKE '" + strLeafType + "%') GROUP BY YEAR(dbo.DailyGreenLeaf.CollectedDate), MONTH(dbo.DailyGreenLeaf.CollectedDate), DAY(dbo.DailyGreenLeaf.CollectedDate), dbo.Supplier.SupplierName, dbo.Supplier.SupplierCode, dbo.DailyGreenLeaf.RouteNo, dbo.Route.RouteName, dbo.DailyGreenLeaf.LeafType ", CommandType.Text);
            //da.SelectCommand = SQLHelper.CreateCommand("SELECT        YEAR(dbo.DailyGreenLeaf.CollectedDate) AS Year, MONTH(dbo.DailyGreenLeaf.CollectedDate) AS Month, DAY(dbo.DailyGreenLeaf.CollectedDate) AS Day,  dbo.Supplier.SupplierName AS Supplier, SUM(dbo.DailyGreenLeaf.NetWeight) AS Column1, dbo.Supplier.SupplierCode, dbo.DailyGreenLeaf.RouteNo,  dbo.Route.RouteName AS 'TownName', dbo.DailyGreenLeaf.LeafType FROM            dbo.DailyGreenLeaf INNER JOIN dbo.Supplier ON dbo.DailyGreenLeaf.SupplierCode = dbo.Supplier.SupplierCode AND dbo.DailyGreenLeaf.RouteNo = dbo.Supplier.RouteCode INNER JOIN dbo.Route ON dbo.DailyGreenLeaf.RouteNo = dbo.Route.RouteCode WHERE        (YEAR(dbo.DailyGreenLeaf.CollectedDate) = '" + Year + "') AND (MONTH(dbo.DailyGreenLeaf.CollectedDate) = '" + Month + "') AND  (dbo.DailyGreenLeaf.RouteNo LIKE '" + strRoute + "') AND (dbo.DailyGreenLeaf.LeafType LIKE '" + strLeafType + "') GROUP BY YEAR(dbo.DailyGreenLeaf.CollectedDate), MONTH(dbo.DailyGreenLeaf.CollectedDate), DAY(dbo.DailyGreenLeaf.CollectedDate), dbo.Supplier.SupplierName,  dbo.Supplier.SupplierCode, dbo.DailyGreenLeaf.RouteNo, dbo.Route.RouteName, dbo.DailyGreenLeaf.LeafType ", CommandType.Text);
            da.Fill(ds, "GreenLeafSummary");
            return ds;
        }

        public DataSet getGreenLeafSummary(int Year, int Month, int pApproval, string SupplierCode)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            da.SelectCommand = SQLHelper.CreateCommand("SELECT YEAR(dbo.DailyGreenLeaf.CollectedDate) AS Year, MONTH(dbo.DailyGreenLeaf.CollectedDate) AS Month, DAY(dbo.DailyGreenLeaf.CollectedDate) AS Day, dbo.Supplier.SupplierName AS Supplier, dbo.DailyGreenLeaf.NetWeight, dbo.Supplier.SupplierCode FROM dbo.DailyGreenLeaf INNER JOIN  dbo.Supplier ON dbo.DailyGreenLeaf.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.Town ON dbo.Supplier.TownCode = dbo.Town.TownCode AND dbo.DailyGreenLeaf.RouteNo = dbo.Town.TownName WHERE (dbo.DailyGreenLeaf.Approval = '" + pApproval + "') GROUP BY YEAR(dbo.DailyGreenLeaf.CollectedDate), MONTH(dbo.DailyGreenLeaf.CollectedDate), DAY(dbo.DailyGreenLeaf.CollectedDate), dbo.Supplier.SupplierName, dbo.DailyGreenLeaf.NetWeight, dbo.Supplier.SupplierCode HAVING (YEAR(dbo.DailyGreenLeaf.CollectedDate) = '" + Year + "') AND (MONTH(dbo.DailyGreenLeaf.CollectedDate) = '" + Month + "') AND (dbo.Supplier.SupplierCode = '" + SupplierCode + "')", CommandType.Text);

            da.Fill(ds, "GreenLeafSummary");
            return ds;
        }

        public DataSet getGreenLeafSummary(string RouteNo, int Year, int Month, int pApproval)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            //da.SelectCommand = SQLHelper.CreateCommand("SELECT YEAR(dbo.DailyGreenLeaf.CollectedDate) AS Year, MONTH(dbo.DailyGreenLeaf.CollectedDate) AS Month, DAY(dbo.DailyGreenLeaf.CollectedDate) AS Day, dbo.Supplier.SupplierName AS Supplier, dbo.DailyGreenLeaf.NetWeight, dbo.Supplier.SupplierCode FROM dbo.DailyGreenLeaf INNER JOIN dbo.Supplier ON dbo.DailyGreenLeaf.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.Town ON dbo.Supplier.TownCode = dbo.Town.TownCode AND dbo.DailyGreenLeaf.RouteNo = dbo.Town.TownName WHERE (dbo.DailyGreenLeaf.Approval = '" + pApproval + "') AND (dbo.DailyGreenLeaf.RouteNo = '" + RouteNo + "')GROUP BY YEAR(dbo.DailyGreenLeaf.CollectedDate), MONTH(dbo.DailyGreenLeaf.CollectedDate), DAY(dbo.DailyGreenLeaf.CollectedDate), dbo.Supplier.SupplierName, dbo.DailyGreenLeaf.NetWeight, dbo.Supplier.SupplierCode HAVING (YEAR(dbo.DailyGreenLeaf.CollectedDate) = '" + Year + "') AND (MONTH(dbo.DailyGreenLeaf.CollectedDate) = '" + Month + "')", CommandType.Text);
            da.SelectCommand = SQLHelper.CreateCommand("SELECT YEAR(dbo.DailyGreenLeaf.CollectedDate) AS Year, MONTH(dbo.DailyGreenLeaf.CollectedDate) AS Month, DAY(dbo.DailyGreenLeaf.CollectedDate) AS Day, dbo.Supplier.SupplierName AS Supplier, dbo.DailyGreenLeaf.NetWeight, dbo.Supplier.SupplierCode FROM dbo.DailyGreenLeaf INNER JOIN dbo.Supplier ON dbo.DailyGreenLeaf.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.[Route] ON dbo.Supplier.RouteCode = dbo.[Route].RouteCode  WHERE (dbo.DailyGreenLeaf.Approval = '" + pApproval + "') AND (dbo.DailyGreenLeaf.RouteNo = '" + RouteNo + "')GROUP BY YEAR(dbo.DailyGreenLeaf.CollectedDate), MONTH(dbo.DailyGreenLeaf.CollectedDate), DAY(dbo.DailyGreenLeaf.CollectedDate), dbo.Supplier.SupplierName, dbo.DailyGreenLeaf.NetWeight, dbo.Supplier.SupplierCode HAVING (YEAR(dbo.DailyGreenLeaf.CollectedDate) = '" + Year + "') AND (MONTH(dbo.DailyGreenLeaf.CollectedDate) = '" + Month + "')", CommandType.Text);

            da.Fill(ds, "GreenLeafSummary");
            return ds;
        }

        public DataSet getGreenLeafSummary(String SupplierCode, String RouteNo, Int32 Year, Int32 Month, Boolean ProcessStatus)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            da.SelectCommand = SQLHelper.CreateCommand("SELECT YEAR(dbo.DailyGreenLeaf.CollectedDate) AS Year, MONTH(dbo.DailyGreenLeaf.CollectedDate) AS Month, DAY(dbo.DailyGreenLeaf.CollectedDate) AS Day, dbo.Supplier.SupplierName AS Supplier, dbo.DailyGreenLeaf.NetWeight, dbo.Supplier.SupplierCode FROM dbo.DailyGreenLeaf INNER JOIN dbo.Supplier ON dbo.DailyGreenLeaf.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.Town ON dbo.Supplier.TownCode = dbo.Town.TownCode AND dbo.DailyGreenLeaf.RouteNo = dbo.Town.TownName WHERE (dbo.DailyGreenLeaf.Processed = '" + ProcessStatus + "') AND (dbo.DailyGreenLeaf.RouteNo = '" + RouteNo + "')GROUP BY YEAR(dbo.DailyGreenLeaf.CollectedDate), MONTH(dbo.DailyGreenLeaf.CollectedDate), DAY(dbo.DailyGreenLeaf.CollectedDate), dbo.Supplier.SupplierName, dbo.DailyGreenLeaf.NetWeight, dbo.Supplier.SupplierCode HAVING      (YEAR(dbo.DailyGreenLeaf.CollectedDate) = '" + Year + "') AND (MONTH(dbo.DailyGreenLeaf.CollectedDate) = '" + Month + "') AND (dbo.Supplier.SupplierCode = '" + SupplierCode + "')", CommandType.Text);

            da.Fill(ds, "GreenLeafSummary");
            return ds;
        }
        public DataSet getSupplierAdvancesSummary(Int32 Year, Int32 Month, Boolean ProcessStatus)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.SupplierAdvances.YearCode, dbo.SupplierAdvances.MonthCode, dbo.Supplier.SupplierCode + ' - ' + dbo.Supplier.SupplierName AS Supplier, DAY(dbo.SupplierAdvances.AdvanceIssueDate) AS Day, dbo.SupplierAdvances.AdvanceAmount FROM dbo.SupplierAdvances INNER JOIN dbo.Supplier ON dbo.SupplierAdvances.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.Town ON dbo.Supplier.TownCode = dbo.Town.TownCode AND dbo.SupplierAdvances.RouteNo = dbo.Town.TownName WHERE (dbo.SupplierAdvances.YearCode = '" + Year + "') AND (dbo.SupplierAdvances.MonthCode = '" + Month + "') AND (dbo.SupplierAdvances.Processed = '" + ProcessStatus + "') ORDER BY ABS (dbo.Supplier.SupplierCode)", CommandType.Text);

            da.Fill(ds, "SupplierAdvancesSummary");
            return ds;
        }
        public DataSet getSupplierAdvancesSummary(Int32 Year, Int32 Month, Boolean ProcessStatus, String SupplierCode)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.SupplierAdvances.YearCode, dbo.SupplierAdvances.MonthCode, dbo.Supplier.SupplierCode + ' - ' + dbo.Supplier.SupplierName AS Supplier, DAY(dbo.SupplierAdvances.AdvanceIssueDate) AS Day, dbo.SupplierAdvances.AdvanceAmount FROM dbo.SupplierAdvances INNER JOIN dbo.Supplier ON dbo.SupplierAdvances.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.Town ON dbo.Supplier.TownCode = dbo.Town.TownCode AND dbo.SupplierAdvances.RouteNo = dbo.Town.TownName WHERE (dbo.SupplierAdvances.YearCode = '" + Year + "') AND (dbo.SupplierAdvances.MonthCode = '" + Month + "') AND (dbo.SupplierAdvances.Processed = '" + ProcessStatus + "') AND (dbo.SupplierAdvances.SupplierCode like '" + SupplierCode + "')", CommandType.Text);

            da.Fill(ds, "SupplierAdvancesSummary");
            return ds;
        }
        public DataSet getSupplierAdvancesSummarys(String RouteNo, Int32 Year, Int32 Month, Boolean ProcessStatus)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            //da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.SupplierAdvances.YearCode, dbo.SupplierAdvances.MonthCode, dbo.Supplier.SupplierCode + ' - ' + dbo.Supplier.SupplierName AS Supplier, DAY(dbo.SupplierAdvances.AdvanceIssueDate) AS Day, dbo.SupplierAdvances.AdvanceAmount FROM         dbo.SupplierAdvances INNER JOIN dbo.Supplier ON dbo.SupplierAdvances.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.Town ON dbo.Supplier.TownCode = dbo.Town.TownCode AND dbo.SupplierAdvances.RouteNo = dbo.Town.TownName WHERE     (dbo.SupplierAdvances.YearCode = '" + Year + "') AND (dbo.SupplierAdvances.MonthCode = '" + Month + "') AND (dbo.SupplierAdvances.Processed = '" + ProcessStatus + "') AND (dbo.SupplierAdvances.RouteNo = '"+RouteNo+"')", CommandType.Text);
            da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.SupplierAdvances.YearCode, dbo.SupplierAdvances.MonthCode, dbo.Supplier.SupplierCode + ' - ' + dbo.Supplier.SupplierName AS Supplier, DAY(dbo.SupplierAdvances.AdvanceIssueDate) AS Day, dbo.SupplierAdvances.AdvanceAmount FROM            dbo.SupplierAdvances INNER JOIN dbo.Supplier ON dbo.SupplierAdvances.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.Town ON dbo.Supplier.TownCode = dbo.Town.TownCode AND dbo.SupplierAdvances.RouteNo = dbo.Town.TownName WHERE (dbo.SupplierAdvances.YearCode = '" + Year + "') AND (dbo.SupplierAdvances.MonthCode = '" + Month + "') AND (dbo.Town.TownCode = '" + RouteNo + "')", CommandType.Text);
            da.Fill(ds, "SupplierAdvancesSummary");
            return ds;
        }
        public DataSet getSupplierAdvancesSummary(String RouteNo, String SuplierCode, Int32 Year, Int32 Month, Boolean ProcessStatus)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.SupplierAdvances.YearCode, dbo.SupplierAdvances.MonthCode, dbo.Supplier.SupplierCode + ' - ' + dbo.Supplier.SupplierName AS Supplier, DAY(dbo.SupplierAdvances.AdvanceIssueDate) AS Day, dbo.SupplierAdvances.AdvanceAmount FROM  dbo.SupplierAdvances INNER JOIN dbo.Supplier ON dbo.SupplierAdvances.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.Town ON dbo.Supplier.TownCode = dbo.Town.TownCode AND dbo.SupplierAdvances.RouteNo = dbo.Town.TownName WHERE (dbo.SupplierAdvances.YearCode = '" + Year + "') AND (dbo.SupplierAdvances.MonthCode = '" + Month + "') AND (dbo.SupplierAdvances.Processed = '" + ProcessStatus + "') AND (dbo.SupplierAdvances.SupplierCode = '" + SuplierCode + "') AND (dbo.SupplierAdvances.RouteNo = '" + RouteNo + "')", CommandType.Text);
            //da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.SupplierAdvances.YearCode, dbo.SupplierAdvances.MonthCode, dbo.Supplier.SupplierCode + ' - ' + dbo.Supplier.SupplierName AS Supplier, DAY(dbo.SupplierAdvances.AdvanceIssueDate) AS Day, dbo.SupplierAdvances.AdvanceAmount FROM            dbo.SupplierAdvances INNER JOIN dbo.Supplier ON dbo.SupplierAdvances.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.Town ON dbo.Supplier.TownCode = dbo.Town.TownCode AND dbo.SupplierAdvances.RouteNo = dbo.Town.TownName WHERE        (dbo.SupplierAdvances.YearCode = '"+  Year+"') AND (dbo.SupplierAdvances.MonthCode = '"+ Month +"') AND (dbo.Town.TownCode = '"+ RouteNo +"') ", CommandType.Text);

            da.Fill(ds, "SupplierAdvancesSummary");
            return ds;
        }

        /// <summary>
        /// Sachintha udara 2017.01.26
        /// </summary>
        /// <param name="pYear"></param>
        /// <param name="pMonth"></param>
        /// <param name="pRoute"></param>
        /// <param name="ProcessStatus">whether process or not</param>
        /// <returns></returns>
        public DataSet getMadeTeaIssuesSummary(Int32 pYear, Int32 pMonth, string pRoute, bool ProcessStatus)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();

            if (ProcessStatus)
                da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.MadeTeaIssued.YearCode, dbo.MadeTeaIssued.MonthCode, dbo.MadeTeaIssued.IssueDate, dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.MadeTeaIssued.MadeTeaIssued, dbo.MadeTeaIssued.Remarks, dbo.MadeTeaIssued.Processed, dbo.MadeTeaIssued.Grade, dbo.Route.RouteNo, dbo.MadeTeaIssued.MadeTeaAmount FROM dbo.MadeTeaIssued INNER JOIN  dbo.Supplier ON dbo.MadeTeaIssued.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.Route ON dbo.Supplier.TownCode = dbo.Route.TownCode WHERE (dbo.MadeTeaIssued.MonthCode = " + pMonth + ") AND (dbo.MadeTeaIssued.YearCode = " + pYear + ") AND (dbo.Supplier.TownCode LIKE '" + pRoute + "')", CommandType.Text);
            else
                da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.MadeTeaIssued.YearCode, dbo.MadeTeaIssued.MonthCode, dbo.MadeTeaIssued.IssueDate, dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName, dbo.MadeTeaIssued.MadeTeaIssued, dbo.MadeTeaIssued.Remarks, dbo.MadeTeaIssued.Processed, dbo.MadeTeaIssued.Grade, dbo.Route.RouteNo, dbo.MadeTeaIssued.MadeTeaAmount FROM dbo.MadeTeaIssued INNER JOIN  dbo.Supplier ON dbo.MadeTeaIssued.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.Route ON dbo.Supplier.TownCode = dbo.Route.TownCode WHERE (dbo.MadeTeaIssued.MonthCode = " + pMonth + ") AND (dbo.MadeTeaIssued.YearCode = " + pYear + ") AND (dbo.Supplier.TownCode LIKE '" + pRoute + "') AND (dbo.MadeTeaIssued.Processed = 1)", CommandType.Text);

            da.Fill(ds, "MadeTeaIssueSummary");
            return ds;
        }

        public DataSet getFertlizerIssuesSummary(Int32 pYear, Int32 pMonth)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.SupplierDeductions.DeductCode, dbo.DeductionCode.DeductionName, dbo.SupplierDeductions.StartYear, dbo.SupplierDeductions.StartMonth, dbo.SupplierDeductions.StartDate, dbo.SupplierDeductions.SupplierCode, dbo.Supplier.SupplierName, dbo.SupplierDeductions.RouteNo, dbo.SupplierDeductions.PrincipalAmount, dbo.SupplierDeductions.NoOfMonths, dbo.SupplierDeductions.NoBags, dbo.SupplierDeductions.CostPerBag, dbo.SupplierDeductions.CloseYesNo FROM dbo.SupplierDeductions INNER JOIN dbo.Supplier ON dbo.SupplierDeductions.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.DeductionCode ON dbo.SupplierDeductions.DeductCode = dbo.DeductionCode.DeductionCode WHERE (dbo.SupplierDeductions.StartYear = '" + pYear + "') AND (dbo.SupplierDeductions.StartMonth = '" + pMonth + "') AND (dbo.SupplierDeductions.DeductionGroupCode = 'FET')", CommandType.Text);

            da.Fill(ds, "FertilizerIssueSummary");
            return ds;
        }
        public DataSet getFertlizerIssuesSummaryBySup(Int32 pYear, Int32 pMonth, String pSupplierCode)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();

            da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.SupplierDeductions.DeductCode, dbo.DeductionCode.DeductionName, dbo.SupplierDeductions.StartYear, dbo.SupplierDeductions.StartMonth, dbo.SupplierDeductions.StartDate, dbo.SupplierDeductions.SupplierCode, dbo.Supplier.SupplierName, dbo.SupplierDeductions.RouteNo, dbo.SupplierDeductions.PrincipalAmount, dbo.SupplierDeductions.NoOfMonths, dbo.SupplierDeductions.NoBags, dbo.SupplierDeductions.CostPerBag, dbo.SupplierDeductions.CloseYesNo FROM dbo.SupplierDeductions INNER JOIN dbo.Supplier ON dbo.SupplierDeductions.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.DeductionCode ON dbo.SupplierDeductions.DeductCode = dbo.DeductionCode.DeductionCode WHERE (dbo.SupplierDeductions.StartYear = '" + pYear + "') AND (dbo.SupplierDeductions.StartMonth = '" + pMonth + "') AND (dbo.SupplierDeductions.SupplierCode = '" + pSupplierCode + "') AND (dbo.SupplierDeductions.DeductionGroupCode = 'FET')", CommandType.Text);

            da.Fill(ds, "FertilizerIssueSummary");
            return ds;
        }
        // New Overload method of getFertlizerIssuesSummary
        // and new parameter name as fertilizer code(fertiCode)
        // K.G.Sachintha Udara
        // 2016.10.05
        // previous parameter list = (Int32 Year, Int32 Month, Boolean ProcessStatus)
        public DataSet getFertlizerIssuesSummaryByFert(Int32 pYear, Int32 pMonth, String pFertiCode)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.SupplierDeductions.DeductCode, dbo.DeductionCode.DeductionName, dbo.SupplierDeductions.StartYear, dbo.SupplierDeductions.StartMonth, dbo.SupplierDeductions.StartDate, dbo.SupplierDeductions.SupplierCode, dbo.Supplier.SupplierName, dbo.SupplierDeductions.RouteNo, dbo.SupplierDeductions.PrincipalAmount, dbo.SupplierDeductions.NoOfMonths, dbo.SupplierDeductions.NoBags, dbo.SupplierDeductions.CostPerBag, dbo.SupplierDeductions.CloseYesNo FROM dbo.SupplierDeductions INNER JOIN dbo.Supplier ON dbo.SupplierDeductions.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.DeductionCode ON dbo.SupplierDeductions.DeductCode = dbo.DeductionCode.DeductionCode WHERE (dbo.SupplierDeductions.StartYear = '" + pYear + "') AND (dbo.SupplierDeductions.StartMonth = '" + pMonth + "') AND (dbo.SupplierDeductions.DeductCode LIKE '" + pFertiCode + "') AND (dbo.SupplierDeductions.DeductionGroupCode = 'FET')", CommandType.Text);

            da.Fill(ds, "FertilizerIssueSummary");
            return ds;
        }

        // New Overload method of getFertlizerIssuesSummary
        // and new parameter name as fertilizer code(fetiCode)
        // K.G.Sachintha Udara
        // 2016.10.05
        // previous parameter list =(Int32 Year, Int32 Month, Boolean ProcessStatus, String SupplierCode, string route)
        public DataSet getFertlizerIssuesSummary(Int32 Year, Int32 Month, Boolean ProcessStatus, String SupplierCode, string route, string fertiCode)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            //da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.FertilizerIssued.YearCode, dbo.FertilizerIssued.MonthCode, dbo.FertilizerIssued.IssueDate, dbo.FertilizerIssued.SupplierCode, dbo.Supplier.SupplierName, dbo.FertilizerIssued.FertilizerIssued, dbo.FertilizerIssued.Remarks FROM dbo.FertilizerIssued INNER JOIN dbo.Supplier ON dbo.FertilizerIssued.SupplierCode = dbo.Supplier.SupplierCode WHERE (dbo.FertilizerIssued.CancelEntry = 0) AND (dbo.FertilizerIssued.Processed = '" + ProcessStatus + "') AND (dbo.FertilizerIssued.YearCode = '" + Year + "') AND (dbo.FertilizerIssued.MonthCode = '" + Month + "') AND (dbo.FertilizerIssued.SupplierCode = '" + SupplierCode + "')", CommandType.Text);
            //da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.FertilizerIssued.YearCode, dbo.FertilizerIssued.MonthCode, dbo.FertilizerIssued.IssueDate, dbo.FertilizerIssued.SupplierCode, dbo.Supplier.SupplierName, dbo.FertilizerIssued.FertilizerIssued, dbo.FertilizerIssued.Remarks,dbo.FertilizerIssued.NoofBags FROM dbo.FertilizerIssued INNER JOIN dbo.Supplier ON dbo.FertilizerIssued.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.Route ON dbo.FertilizerIssued.RouteNo = dbo.Route.RouteNo AND dbo.Supplier.TownCode = dbo.Route.TownCode WHERE        (dbo.FertilizerIssued.Processed = 0) AND (dbo.FertilizerIssued.YearCode = '" + Year + "') AND (dbo.FertilizerIssued.MonthCode = '" + Month + "') AND (dbo.Supplier.TownCode = '" + route + "') AND (dbo.FertilizerIssued.FertilizerCode = '"+fertiCode+"')", CommandType.Text);
            da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.FertilizerIssued.YearCode, dbo.FertilizerIssued.MonthCode, dbo.FertilizerIssued.IssueDate, dbo.FertilizerIssued.SupplierCode, dbo.Supplier.SupplierName, dbo.FertilizerIssued.FertilizerIssued, dbo.FertilizerIssued.Remarks, dbo.FertilizerIssued.NoofBags, dbo.FertilizerIssued.RouteNo, dbo.FertilizerIssued.FertilizerCode FROM dbo.FertilizerIssued INNER JOIN dbo.Supplier ON dbo.FertilizerIssued.SupplierCode = dbo.Supplier.SupplierCode WHERE (dbo.FertilizerIssued.CancelEntry = 0) AND (dbo.FertilizerIssued.Processed = 'False') AND (dbo.FertilizerIssued.YearCode = '" + Year + "') AND (dbo.FertilizerIssued.MonthCode = '" + Month + "') AND (dbo.FertilizerIssued.SupplierCode = '" + SupplierCode + "') AND (dbo.FertilizerIssued.FertilizerCode = '" + fertiCode + "')", CommandType.Text);
            da.Fill(ds, "FertilizerIssueSummary");
            return ds;
        }

        public DataSet getBankPaymentSummary(int pYear, int pMonth)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            //da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.Supplier.SupplierName, dbo.MonthlyPayments.SupplierCode, dbo.Bank.BankName, dbo.Supplier.AccountNo, dbo.MonthlyPayments.FinalBalance,dbo.Supplier.BankBranch FROM dbo.MonthlyPayments INNER JOIN dbo.Supplier ON dbo.MonthlyPayments.SupplierCode = dbo.Supplier.SupplierCode AND dbo.MonthlyPayments.RouteNo = dbo.Supplier.TownCode INNER JOIN dbo.Bank ON dbo.Supplier.BankCode = dbo.Bank.BankCode WHERE (dbo.MonthlyPayments.Year = '" + Year + "') AND (dbo.MonthlyPayments.Month = '" + Month + "') AND (dbo.MonthlyPayments.FinalBalance <> 0)ORDER BY ABS(dbo.MonthlyPayments.SupplierCode)", CommandType.Text);
            //da.SelectCommand = SQLHelper.CreateCommand("SELECT TOP (100) PERCENT dbo.Supplier.SupplierName, dbo.MonthlyPayments.SupplierCode, dbo.Bank.BankName, dbo.Supplier.AccountNo, dbo.MonthlyPayments.FinalBalance, dbo.Supplier.BankBranch FROM dbo.MonthlyPayments INNER JOIN dbo.Supplier ON dbo.MonthlyPayments.SupplierCode = dbo.Supplier.SupplierCode AND dbo.MonthlyPayments.RouteNo = dbo.Supplier.TownCode INNER JOIN dbo.Bank ON dbo.Supplier.BankCode = dbo.Bank.BankCode WHERE (dbo.MonthlyPayments.Year = '"+  Year +"') AND (dbo.MonthlyPayments.Month = '"+ Month +"') AND (dbo.MonthlyPayments.FinalBalance > 0) AND (dbo.Supplier.AccountNo <> '') AND (dbo.Supplier.BankBranch <> N'NA')ORDER BY ABS(dbo.MonthlyPayments.SupplierCode)", CommandType.Text);
            //da.SelectCommand = SQLHelper.CreateCommand("SELECT  TOP (100) PERCENT dbo.Supplier.SupplierName, dbo.MonthlyPayments.SupplierCode, dbo.Bank.BankName, dbo.Supplier.AccountNo,dbo.MonthlyPayments.FinalBalance, dbo.Supplier.BankBranch, dbo.Branch.BranchCode FROM dbo.MonthlyPayments INNER JOIN dbo.Supplier ON dbo.MonthlyPayments.SupplierCode = dbo.Supplier.SupplierCode AND dbo.MonthlyPayments.RouteNo = dbo.Supplier.TownCode INNER JOIN dbo.Bank ON dbo.Supplier.BankCode = dbo.Bank.BankCode LEFT OUTER JOIN dbo.Branch ON dbo.Supplier.BankBranch = dbo.Branch.BankCode WHERE (dbo.MonthlyPayments.Year = '"+ Year +"') AND (dbo.MonthlyPayments.Month = '"+ Month +"') AND (dbo.MonthlyPayments.FinalBalance > 0) AND (dbo.Supplier.AccountNo <> 'NA') AND (dbo.Supplier.BankBranch <> 'NA')ORDER BY ABS(dbo.MonthlyPayments.SupplierCode)", CommandType.Text);
            //IF BANK CODE AND BRANCH CODE 'NA'
            //da.SelectCommand = SQLHelper.CreateCommand("SELECT        dbo.Supplier.SupplierName, dbo.MonthlyPaymentSummary.SupplierCode, dbo.Bank.BankName, dbo.Supplier.AccountNo,  dbo.MonthlyPaymentSummary.NetPay AS FinalBalance, dbo.Supplier.BankBranch, dbo.BankBranch.BranchName FROM            dbo.Bank INNER JOIN dbo.Supplier ON dbo.Bank.BankCode = dbo.Supplier.BankCode INNER JOIN dbo.MonthlyPaymentSummary ON dbo.Supplier.SupplierCode = dbo.MonthlyPaymentSummary.SupplierCode INNER JOIN dbo.BankBranch ON dbo.Supplier.BankBranch = dbo.BankBranch.BranchCode AND dbo.Supplier.BankCode = dbo.BankBranch.BankCode WHERE        (dbo.Supplier.AccountNo <> 'NA') AND (dbo.Supplier.BankBranch <> 'NA') AND (dbo.MonthlyPaymentSummary.Year = '" + pYear + "') AND  (dbo.MonthlyPaymentSummary.Month = '" + pMonth + "') AND (dbo.MonthlyPaymentSummary.NetPay > 0)", CommandType.Text);
            //Not filtering for Bank Code and Branch code
            da.SelectCommand = SQLHelper.CreateCommand("SELECT        dbo.Supplier.SupplierName, dbo.MonthlyPaymentSummary.SupplierCode, dbo.Bank.BankName, dbo.Supplier.AccountNo,  dbo.MonthlyPaymentSummary.PaymentDue AS FinalBalance, dbo.Supplier.BankBranch, dbo.BankBranch.BranchName FROM dbo.Bank INNER JOIN dbo.Supplier ON dbo.Bank.BankCode = dbo.Supplier.BankCode INNER JOIN dbo.MonthlyPaymentSummary ON dbo.Supplier.SupplierCode = dbo.MonthlyPaymentSummary.SupplierCode INNER JOIN dbo.BankBranch ON dbo.Supplier.BankBranch = dbo.BankBranch.BranchCode AND dbo.Supplier.BankCode = dbo.BankBranch.BankCode WHERE        (dbo.MonthlyPaymentSummary.Year = '" + pYear + "') AND (dbo.MonthlyPaymentSummary.Month = '" + pMonth + "') AND (dbo.MonthlyPaymentSummary.PaymentDue > 0)  AND (dbo.Supplier.SalarySendBank = 1)", CommandType.Text);

            da.Fill(ds, "BankPaymentSummary");
            return ds;
        }
        public Decimal getBankPaymentSummaryTotal(Int32 Year, Int32 Month)
        {
            Decimal decBankTotal = 0;
            DataSet ds = new DataSet();
            ds = SQLHelper.FillDataSet("SELECT   sum( dbo.MonthlyPayments.FinalBalance) as tot FROM         dbo.MonthlyPayments INNER JOIN dbo.Supplier ON dbo.MonthlyPayments.SupplierCode = dbo.Supplier.SupplierCode AND dbo.MonthlyPayments.RouteNo = dbo.Supplier.TownCode INNER JOIN dbo.Bank ON dbo.Supplier.BankCode = dbo.Bank.BankCode LEFT OUTER JOIN dbo.Branch ON dbo.Supplier.BankBranch = dbo.Branch.BankCode WHERE     (dbo.MonthlyPayments.Year = '" + Year + "') AND (dbo.MonthlyPayments.Month = '" + Month + "') AND (dbo.MonthlyPayments.FinalBalance > 0) AND  (dbo.Supplier.AccountNo <> 'NA') AND (dbo.Supplier.BankBranch <> 'NA') ", CommandType.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                decBankTotal = Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString());
            }
            return decBankTotal;
        }
        // edited by sachintha 2016.10.14
        // for illukthanna special perpus
        public Decimal getBankPaymentSummaryTotalIlluk(Int32 Year, Int32 Month)
        {
            Decimal decBankTotal = 0;
            DataSet ds = new DataSet();
            ds = SQLHelper.FillDataSet("SELECT   sum( dbo.MonthlyPayments.FinalBalance) as tot FROM         dbo.MonthlyPayments INNER JOIN dbo.Supplier ON dbo.MonthlyPayments.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.Bank ON dbo.Supplier.BankCode = dbo.Bank.BankCode LEFT OUTER JOIN dbo.Branch ON dbo.Supplier.BankBranch = dbo.Branch.BankCode WHERE     (dbo.MonthlyPayments.Year = '" + Year + "') AND (dbo.MonthlyPayments.Month = '" + Month + "') AND (dbo.MonthlyPayments.FinalBalance > 0) AND  (dbo.Supplier.AccountNo <> 'NA') AND (dbo.Supplier.BankBranch <> 'NA') ", CommandType.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                decBankTotal = Convert.ToDecimal(ds.Tables[0].Rows[0][0].ToString());
            }
            return decBankTotal;
        }

        public DataTable getSupplierPaymentsAll(Int32 Year, Int32 Month)
        {
            String strErrorSupp = "";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            #region unwanted

            //da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.MonthlyPayments.Year, dbo.MonthlyPayments.Month, dbo.MonthlyPayments.SupplierCode, dbo.Supplier.SupplierName, dbo.MonthlyPayments.TotalGreenLeaf, dbo.MonthlyPayments.TotalAmount, dbo.MonthlyPayments.AdvanceTaken, dbo.MonthlyPayments.FertilizerTaken, dbo.MonthlyPayments.MadeTeaTaken, dbo.MonthlyPayments.StampDutyDeduction, dbo.Bank.BankName, dbo.Supplier.AccountNo, dbo.MonthlyPayments.FinalBalance, dbo.Route.RouteNo,dbo.MonthlyPayments.TransportDeduction,dbo.MonthlyPayments.Incentive, dbo.MonthlyPayments.LoanAmount, dbo.MonthlyPayments.OtherPayment FROM dbo.MonthlyPayments INNER JOIN dbo.Supplier ON dbo.MonthlyPayments.SupplierCode = dbo.Supplier.SupplierCode AND dbo.MonthlyPayments.RouteNo = dbo.Supplier.TownCode INNER JOIN dbo.Bank ON dbo.Supplier.BankCode = dbo.Bank.BankCode INNER JOIN dbo.Route ON dbo.MonthlyPayments.RouteNo = dbo.Route.TownCode WHERE (dbo.MonthlyPayments.Year = '" + Year + "') AND (dbo.MonthlyPayments.Month = '" + Month + "')", CommandType.Text);
            //da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.MonthlyPayments.Year, dbo.MonthlyPayments.Month, dbo.MonthlyPayments.SupplierCode, dbo.Supplier.SupplierName, dbo.MonthlyPayments.TotalGreenLeaf, dbo.MonthlyPayments.TotalAmount, dbo.MonthlyPayments.AdvanceTaken, dbo.MonthlyPayments.FertilizerTaken, dbo.MonthlyPayments.MadeTeaTaken, dbo.MonthlyPayments.StampDutyDeduction, dbo.Bank.BankName, dbo.Supplier.AccountNo, dbo.MonthlyPayments.FinalBalance, dbo.MonthlyPayments.TransportDeduction, dbo.MonthlyPayments.Incentive, dbo.MonthlyPayments.LoanAmount, dbo.MonthlyPayments.OtherPayment, CASE WHEN dbo.MadeTeaIssued.NBTRate IS NULL THEN 0.00 ELSE dbo.MadeTeaIssued.NBTRate END AS NBTRate FROM dbo.MonthlyPayments INNER JOIN dbo.Supplier ON dbo.MonthlyPayments.SupplierCode = dbo.Supplier.SupplierCode AND dbo.MonthlyPayments.RouteNo = dbo.Supplier.TownCode INNER JOIN dbo.Bank ON dbo.Supplier.BankCode = dbo.Bank.BankCode INNER JOIN dbo.Route ON dbo.MonthlyPayments.RouteNo = dbo.Route.TownCode INNER JOIN dbo.MadeTeaIssued ON dbo.MonthlyPayments.SupplierCode = dbo.MadeTeaIssued.SupplierCode AND dbo.Supplier.SupplierCode = dbo.MadeTeaIssued.SupplierCode AND dbo.Route.RouteNo = dbo.MadeTeaIssued.RouteNo WHERE (dbo.MonthlyPayments.Year = '" + Year + "') AND (dbo.MonthlyPayments.Month = '" + Month + "')", CommandType.Text);
            //da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.MonthlyPayments.Year, dbo.MonthlyPayments.Month, dbo.MonthlyPayments.SupplierCode, dbo.Supplier.SupplierName, dbo.MonthlyPayments.TotalGreenLeaf,dbo.MonthlyPayments.TotalAmount, dbo.MonthlyPayments.AdvanceTaken, dbo.MonthlyPayments.FertilizerTaken, dbo.MonthlyPayments.MadeTeaTaken, dbo.MonthlyPayments.StampDutyDeduction, dbo.Bank.BankName, dbo.Supplier.AccountNo, dbo.MonthlyPayments.FinalBalance, dbo.MonthlyPayments.RouteNo, dbo.MonthlyPayments.TransportDeduction, dbo.MonthlyPayments.Incentive, dbo.MonthlyPayments.LoanAmount, dbo.MonthlyPayments.OtherPayment, CASE WHEN dbo.MadeTeaIssued.NBTRate IS NULL THEN 0.00 ELSE dbo.MadeTeaIssued.NBTRate END AS NBTRate FROM         dbo.MonthlyPayments INNER JOIN dbo.Supplier ON dbo.MonthlyPayments.SupplierCode = dbo.Supplier.SupplierCode AND dbo.MonthlyPayments.RouteNo = dbo.Supplier.TownCode INNER JOIN dbo.Bank ON dbo.Supplier.BankCode = dbo.Bank.BankCode INNER JOIN dbo.Route ON dbo.MonthlyPayments.RouteNo = dbo.Route.TownCode INNER JOIN dbo.MadeTeaIssued ON dbo.MonthlyPayments.SupplierCode = dbo.MadeTeaIssued.SupplierCode AND  dbo.Supplier.SupplierCode = dbo.MadeTeaIssued.SupplierCode AND dbo.Route.RouteNo = dbo.MadeTeaIssued.RouteNo WHERE     (dbo.MonthlyPayments.Year = '" + Year + "') AND (dbo.MonthlyPayments.Month = '" + Month + "')", CommandType.Text);
            //da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.MonthlyPayments.Year, dbo.MonthlyPayments.Month, dbo.MonthlyPayments.SupplierCode, dbo.Supplier.SupplierName, dbo.MonthlyPayments.TotalGreenLeaf, dbo.MonthlyPayments.TotalAmount, dbo.MonthlyPayments.AdvanceTaken, dbo.MonthlyPayments.FertilizerTaken, dbo.MonthlyPayments.MadeTeaTaken, dbo.MonthlyPayments.StampDutyDeduction, dbo.Bank.BankName, dbo.Supplier.AccountNo, dbo.MonthlyPayments.FinalBalance, dbo.MonthlyPayments.RouteNo, dbo.MonthlyPayments.TransportDeduction, dbo.MonthlyPayments.Incentive, dbo.MonthlyPayments.LoanAmount, dbo.MonthlyPayments.OtherPayment, CASE WHEN dbo.MadeTeaIssued.NBTRate IS NULL THEN 0.00 ELSE dbo.MadeTeaIssued.NBTRate END AS NBTRate, dbo.MonthlyParameters.StampDutyDeductionAmount FROM dbo.MonthlyPayments INNER JOIN dbo.Supplier ON dbo.MonthlyPayments.SupplierCode = dbo.Supplier.SupplierCode AND dbo.MonthlyPayments.RouteNo = dbo.Supplier.TownCode INNER JOIN dbo.Bank ON dbo.Supplier.BankCode = dbo.Bank.BankCode INNER JOIN dbo.Route ON dbo.MonthlyPayments.RouteNo = dbo.Route.TownCode INNER JOIN dbo.MadeTeaIssued ON dbo.MonthlyPayments.SupplierCode = dbo.MadeTeaIssued.SupplierCode AND dbo.Supplier.SupplierCode = dbo.MadeTeaIssued.SupplierCode AND dbo.Route.RouteNo = dbo.MadeTeaIssued.RouteNo INNER JOIN dbo.MonthlyParameters ON dbo.MadeTeaIssued.YearCode = dbo.MonthlyParameters.YearCode AND dbo.MadeTeaIssued.MonthCode = dbo.MonthlyParameters.MonthCode WHERE (dbo.MonthlyPayments.Year = '"+ Year +"') AND (dbo.MonthlyPayments.Month = '"+ Month +"')", CommandType.Text);
            // da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.MonthlyPayments.Year, dbo.MonthlyPayments.Month, dbo.MonthlyPayments.SupplierCode, dbo.Supplier.SupplierName, dbo.MonthlyPayments.TotalGreenLeaf, dbo.MonthlyPayments.TotalAmount, dbo.MonthlyPayments.AdvanceTaken, dbo.MonthlyPayments.FertilizerTaken, dbo.MonthlyPayments.MadeTeaTaken,  dbo.MonthlyPayments.StampDutyDeduction, dbo.Bank.BankName, dbo.Supplier.AccountNo, dbo.MonthlyPayments.FinalBalance,  dbo.MonthlyPayments.TransportDeduction, dbo.MonthlyPayments.Incentive, dbo.MonthlyPayments.LoanAmount, dbo.MonthlyPayments.OtherPayment, dbo.Compnay.NBTRate, dbo.MonthlyPayments.RouteNo FROM dbo.MonthlyPayments INNER JOIN dbo.Supplier ON dbo.MonthlyPayments.SupplierCode = dbo.Supplier.SupplierCode AND dbo.MonthlyPayments.RouteNo = dbo.Supplier.TownCode INNER JOIN dbo.Bank ON dbo.Supplier.BankCode = dbo.Bank.BankCode INNER JOIN dbo.Route ON dbo.MonthlyPayments.RouteNo = dbo.Route.TownCode CROSS JOIN dbo.Compnay WHERE (dbo.MonthlyPayments.Year = '"+ Year +"') AND (dbo.MonthlyPayments.Month = '"+ Month +"')", CommandType.Text);

            #endregion

            da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.MonthlyPayments.Year, dbo.MonthlyPayments.Month, dbo.MonthlyPayments.SupplierCode, dbo.Supplier.SupplierName, dbo.MonthlyPayments.TotalGreenLeaf,dbo.MonthlyPayments.TotalAmount, dbo.MonthlyPayments.AdvanceTaken, dbo.MonthlyPayments.FertilizerTaken, dbo.MonthlyPayments.MadeTeaTaken, dbo.MonthlyPayments.StampDutyDeduction, dbo.Supplier.AccountNo, dbo.MonthlyPayments.FinalBalance, dbo.MonthlyPayments.TransportDeduction,  dbo.MonthlyPayments.Incentive, dbo.MonthlyPayments.LoanAmount, dbo.MonthlyPayments.OtherPayment, dbo.MonthlyPayments.RouteNo, dbo.Route.RouteNo AS Expr1 FROM dbo.MonthlyPayments INNER JOIN dbo.Supplier ON dbo.MonthlyPayments.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.Route ON dbo.MonthlyPayments.RouteNo = dbo.Route.TownCode WHERE (dbo.MonthlyPayments.Year = " + Year + ") AND (dbo.MonthlyPayments.Month = " + Month + ")", CommandType.Text);

            da.Fill(ds, "SupplierPayments");

            Int32 PreviousYear = new DateTime(Year, Month, 1).AddMonths(-1).Year;
            Int32 PreviousMonth = new DateTime(Year, Month, 1).AddMonths(-1).Month;

            DataTable dt = new DataTable("Details");

            dt.Columns.Add(new DataColumn("Year"));
            dt.Columns.Add(new DataColumn("Month"));
            dt.Columns.Add(new DataColumn("SupplierCode"));
            dt.Columns.Add(new DataColumn("SupplierName"));
            dt.Columns.Add(new DataColumn("GreenLeaf"));
            dt.Columns.Add(new DataColumn("GreenLeafAmount"));
            dt.Columns.Add(new DataColumn("Advance"));
            dt.Columns.Add(new DataColumn("Fertilizer"));
            dt.Columns.Add(new DataColumn("TeaIssues"));
            dt.Columns.Add(new DataColumn("Stamp"));
            dt.Columns.Add(new DataColumn("AccountNo"));
            dt.Columns.Add(new DataColumn("FinalBalance"));
            dt.Columns.Add(new DataColumn("Transport"));
            dt.Columns.Add(new DataColumn("Incentive"));
            dt.Columns.Add(new DataColumn("Loan"));
            dt.Columns.Add(new DataColumn("Other"));
            dt.Columns.Add(new DataColumn("route"));

            dt.Columns.Add(new DataColumn("FertlizerBalance"));//17
            dt.Columns.Add(new DataColumn("CashBalance"));//18
            dt.Columns.Add(new DataColumn("BFCoinsBalance"));//19
            dt.Columns.Add(new DataColumn("FertlizerCD"));//20
            dt.Columns.Add(new DataColumn("CoinsBalanceCD"));//21
            dt.Columns.Add(new DataColumn("LoanBalanceCD"));//22
            dt.Columns.Add(new DataColumn("BFLoanBalance"));//23
            dt.Columns.Add(new DataColumn("NBTRate"));//24

            dt.Columns.Add(new DataColumn("TransportDed"));//25
            dt.Columns.Add(new DataColumn("payslip"));//26
            dt.Columns.Add(new DataColumn("routeName"));//27



            //dt.Columns.Add(new DataColumn("Incentive"));
            //dt.Columns.Add(new DataColumn("TransprtIncentive"));
            String val;
            DataRow dtrow;
            for (Int32 i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                try
                {
                    dtrow = dt.NewRow();
                    if (ds.Tables[0].Rows[i][2].ToString() == "3984")
                        val = "";
                    dtrow[0] = ds.Tables[0].Rows[i][0].ToString();
                    dtrow[1] = ds.Tables[0].Rows[i][1].ToString();
                    dtrow[2] = ds.Tables[0].Rows[i][2].ToString();
                    dtrow[3] = ds.Tables[0].Rows[i][3].ToString();
                    dtrow[4] = ds.Tables[0].Rows[i][4].ToString();
                    dtrow[5] = ds.Tables[0].Rows[i][5].ToString();
                    dtrow[6] = ds.Tables[0].Rows[i][6].ToString();
                    dtrow[7] = ds.Tables[0].Rows[i][7].ToString();


                    //This bellow proccess terminated
                    //Terminated user = K.G.Sachintha Udara
                    //Terminated Date = 2016.10.06
                    //Terminated Start

                    //Decimal Bal = getCashBalance(Year, Month, ds.Tables[0].Rows[i][16].ToString(), ds.Tables[0].Rows[i][2].ToString());
                    //if (Bal > 0)
                    //    dtrow[18] = Convert.ToDecimal(ds.Tables[0].Rows[i][6].ToString()) - getCashBalance(Year, Month, ds.Tables[0].Rows[i][16].ToString(), ds.Tables[0].Rows[i][2].ToString());
                    //else
                    //    dtrow[18] = Convert.ToDecimal(ds.Tables[0].Rows[i][6].ToString()) + getCashBalance(Year, Month, ds.Tables[0].Rows[i][16].ToString(), ds.Tables[0].Rows[i][2].ToString());
                    //Terminated End


                    //dtrow[7] = Convert.ToDecimal(ds.Tables[0].Rows[i][7].ToString()) - getFETBFBalance(Year, Month, ds.Tables[0].Rows[i][16].ToString(), ds.Tables[0].Rows[i][2].ToString(), false);

                    //Decimal BalNew = Convert.ToDecimal(ds.Tables[0].Rows[i][7].ToString()) - getFETBFBalanceNew(Year, Month, ds.Tables[0].Rows[i][16].ToString(), ds.Tables[0].Rows[i][2].ToString());

                    //dtrow[7] = 0;
                    //if (BalNew > 0)
                    //    dtrow[7] = BalNew;

                    dtrow[8] = ds.Tables[0].Rows[i][8].ToString();
                    dtrow[9] = ds.Tables[0].Rows[i][9].ToString();
                    dtrow[10] = ds.Tables[0].Rows[i][10].ToString();
                    dtrow[11] = ds.Tables[0].Rows[i][11].ToString();
                    dtrow[12] = ds.Tables[0].Rows[i][12].ToString();
                    dtrow[13] = ds.Tables[0].Rows[i][13].ToString();
                    dtrow[14] = ds.Tables[0].Rows[i][14].ToString();
                    dtrow[15] = ds.Tables[0].Rows[i][15].ToString();
                    dtrow[16] = ds.Tables[0].Rows[i][16].ToString();

                    //dtrow[16] = getFertlizerBalance(Year, Month, ds.Tables[0].Rows[i][16].ToString(), ds.Tables[0].Rows[i][2].ToString(), false);
                    dtrow[17] = getFETBFBalanceNew(Year, Month, ds.Tables[0].Rows[i][16].ToString(), ds.Tables[0].Rows[i][2].ToString());   //getFETBFBalance(Year, Month, ds.Tables[0].Rows[i][16].ToString(), ds.Tables[0].Rows[i][2].ToString(), false);
                    dtrow[18] = getCashBalance(Year, Month, ds.Tables[0].Rows[i][16].ToString(), ds.Tables[0].Rows[i][2].ToString());
                    dtrow[19] = getBFCoinBalance(Year, Month, ds.Tables[0].Rows[i][16].ToString(), ds.Tables[0].Rows[i][2].ToString(), false);

                    //dtrow[19] = getFertlizerBalance(Year, Month, ds.Tables[0].Rows[i][16].ToString(), ds.Tables[0].Rows[i][2].ToString(),true);
                    //dtrow[20] = getFETCDBalance(Year, Month, ds.Tables[0].Rows[i][2].ToString());    //getFETBFBalance(Year, Month, ds.Tables[0].Rows[i][16].ToString(), ds.Tables[0].Rows[i][2].ToString(), true);
                    dtrow[21] = getBFCoinBalance(Year, Month, ds.Tables[0].Rows[i][16].ToString(), ds.Tables[0].Rows[i][2].ToString(), true);
                    //dtrow[21] = Convert.ToDecimal(ds.Tables[0].Rows[i][15].ToString());   //-getLoanBFBalance(Year, Month, ds.Tables[0].Rows[i][16].ToString(), ds.Tables[0].Rows[i][2].ToString());
                    //dtrow[22] = ds.Tables[0].Rows[i][16].ToString();
                    //dtrow[22] = getLoanBalance(Year, Month, ds.Tables[0].Rows[i][16].ToString(), ds.Tables[0].Rows[i][2].ToString());
                    dtrow[23] = getLoanBFBalance(Year, Month, ds.Tables[0].Rows[i][16].ToString(), ds.Tables[0].Rows[i][2].ToString());
                    //dtrow[25] = ds.Tables[0].Rows[i][17].ToString();
                    //need to be check route code
                    //dtrow[25] = gettransportForIlluk(ds.Tables[0].Rows[i][17].ToString(), ds.Tables[0].Rows[i][2].ToString(), Month, Year);
                    // dtrow[25] = myTran.getTransportDeduction(Year, Month, ds.Tables[0].Rows[i][2].ToString(), ds.Tables[0].Rows[i][17].ToString());
                    dtrow[26] = getPayslipCharg(Year, Month, ds.Tables[0].Rows[i][17].ToString());
                    dtrow[27] = getCount(Year, Month);

                    //getLoanBalance
                    dt.Rows.Add(dtrow);
                }
                catch (Exception ex)
                {
                    String Errror = strErrorSupp;
                }
            }

            return dt;
        }

        public Decimal getLoanBFBalance(Int32 Year, Int32 Month, String RouteNo, String SupplierCode)
        {
            DateTime PreviousMonthDate = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month)).AddMonths(-1);
            Int32 LastYear = PreviousMonthDate.Year;
            Int32 LastMonth = PreviousMonthDate.Month;

            Decimal Distance = 0;
            //SqlDataReader dataReader;
            //dataReader = SQLHelper.ExecuteReader("SELECT SUM(Amount) AS Balance FROM dbo.SupplierLoans WHERE (YearCode = '" + LastYear + "') AND (SupplierCode = '" + SupplierCode + "') AND (MonthCode = '" + Month + "') AND (RouteNo = '" + RouteNo + "')", CommandType.Text);

            //while (dataReader.Read())
            //{
            //    if (!dataReader.IsDBNull(0))
            //    {
            //        Distance = dataReader.GetDecimal(0);
            //    }
            //}
            //dataReader.Close();

            //dataReader = SQLHelper.ExecuteReader("SELECT LoanSettled FROM dbo.LoanSettlement WHERE (YearCode = '" + Year + "') AND (ProcessMonth = '" + Month + "') AND (SupplierCode = '" + SupplierCode + "') AND (MonthCode = '" + Month + "') AND (RouteNo = '" + RouteNo + "')", CommandType.Text);

            //while (dataReader.Read())
            //{
            //    if (!dataReader.IsDBNull(0))
            //    {
            //        Distance = Distance - dataReader.GetDecimal(0);
            //    }
            //}
            //dataReader.Close();

            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT dbo.BFBalances.LoanBalance FROM dbo.BFBalances INNER JOIN dbo.Route ON dbo.BFBalances.RouteNo = dbo.Route.TownCode WHERE (dbo.Route.RouteNo = '" + RouteNo + "') AND (dbo.BFBalances.SupplierCode = '" + SupplierCode + "') AND (dbo.BFBalances.Year = '" + LastYear + "') AND (dbo.BFBalances.Month = '" + LastMonth + "')", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    Distance = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();


            return Distance;
        }
        public Decimal getFETBFBalanceNew(Int32 Year, Int32 Month, String RouteNo, String SupplierCode)
        {
            DateTime PreviousMonthDate = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month)).AddMonths(-1);
            Int32 LastYear = PreviousMonthDate.Year;
            Int32 LastMonth = PreviousMonthDate.Month;

            Decimal Distance = 0;
            SqlDataReader dataReader;
            //dataReader = SQLHelper.ExecuteReader("SELECT dbo.BFBalances.FertilizerBalance FROM dbo.BFBalances INNER JOIN dbo.Route ON dbo.BFBalances.RouteNo = dbo.Route.TownCode WHERE (dbo.Route.RouteNo = '" + RouteNo + "') AND (dbo.BFBalances.SupplierCode = '" + SupplierCode + "') AND (dbo.BFBalances.Year = '" + LastYear + "') AND (dbo.BFBalances.Month = '" + LastMonth + "')", CommandType.Text);
            dataReader = SQLHelper.ExecuteReader("SELECT dbo.MonthlyPayments.FertilizerTaken FROM dbo.MonthlyPayments INNER JOIN dbo.Route ON dbo.MonthlyPayments.RouteNo = dbo.Route.TownCode INNER JOIN dbo.Supplier ON dbo.MonthlyPayments.SupplierCode = dbo.Supplier.SupplierCode WHERE     (dbo.MonthlyPayments.SupplierCode = '" + SupplierCode + "') AND (dbo.MonthlyPayments.Year = '" + Year + "') AND (dbo.MonthlyPayments.Month = '" + Month + "')AND (dbo.Route.TownCode = '" + RouteNo + "')", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    Distance = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();

            return Distance;
        }

        public decimal getPayslipCharg()
        {
            decimal payslip = 0;
            SqlDataReader oSqlDataReader;
            oSqlDataReader = SQLHelper.ExecuteReader("SELECT PaySlipCharge FROM [dbo].[FixedPaymentSettings]", CommandType.Text);
            while (oSqlDataReader.Read())
            {
                if (!oSqlDataReader.IsDBNull(0))
                    payslip = oSqlDataReader.GetDecimal(0);
                else
                    payslip = 0;
            }
            oSqlDataReader.Close();
            return payslip;
        }


        //============================================================

        public decimal getCount(int year, int month)
        {
            int Count = 0;
            SqlDataReader oSqlDataReader;
            oSqlDataReader = SQLHelper.ExecuteReader("SELECT DISTINCT COUNT(SupplierCode) AS Expr1 FROM MonthlyPayments WHERE (Year = '" + year + "') AND (Month = '" + month + "') AND (TotalGreenLeaf > 0)", CommandType.Text);
            while (oSqlDataReader.Read())
            {
                if (!oSqlDataReader.IsDBNull(0))
                {
                    Count = oSqlDataReader.GetInt32(0);
                }
            }
            oSqlDataReader.Close();
            return Count;


        }

        public decimal getPayslipCharg(int year, int month, string routCode)
        {
            decimal payslip = 0;
            SqlDataReader oSqlDataReader;
            oSqlDataReader = SQLHelper.ExecuteReader("SELECT  DISTINCT COUNT(RouteNo) AS Expr1, RouteNo FROM MonthlyPayments WHERE     (Year = '" + year + "') AND (Month = '" + month + "') AND (TotalGreenLeaf > 0) AND (RouteNo = '" + routCode + "')GROUP BY RouteNo", CommandType.Text);
            while (oSqlDataReader.Read())
            {
                if (!oSqlDataReader.IsDBNull(0))
                {
                    payslip = oSqlDataReader.GetInt32(0);
                }
            }
            oSqlDataReader.Close();
            return payslip;
        }


        public Decimal getFETBFBalance(Int32 Year, Int32 Month, String RouteNo, String SupplierCode, Boolean CurrentMonth)
        {
            Decimal Distance = 0;

            if (CurrentMonth == false)
            {
                DateTime PreviousMonthDate = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month)).AddMonths(-1);
                Int32 LastYear = PreviousMonthDate.Year;
                Int32 LastMonth = PreviousMonthDate.Month;


                SqlDataReader dataReader;
                dataReader = SQLHelper.ExecuteReader("SELECT SUM(FertilizerIssued) AS Balance FROM dbo.FertilizerIssued WHERE (YearCode = '" + LastYear + "') AND (SupplierCode = '" + SupplierCode + "') AND (MonthCode = '" + LastMonth + "') AND (RouteNo = '" + RouteNo + "')", CommandType.Text);

                while (dataReader.Read())
                {
                    if (!dataReader.IsDBNull(0))
                    {
                        Distance = dataReader.GetDecimal(0);
                    }
                }
                dataReader.Close();

                dataReader = SQLHelper.ExecuteReader("SELECT dbo.FertilizerSettlement.FertilizerSettled FROM dbo.FertilizerSettlement INNER JOIN dbo.Route ON dbo.FertilizerSettlement.RouteNo = dbo.Route.TownCode WHERE (dbo.FertilizerSettlement.YearCode = '" + Year + "') AND (dbo.FertilizerSettlement.ProcessMonth = '" + Month + "') AND (dbo.FertilizerSettlement.SupplierCode = '" + SupplierCode + "') AND (dbo.FertilizerSettlement.MonthCode = '" + LastMonth + "') AND (dbo.Route.RouteNo = '" + RouteNo + "')", CommandType.Text);

                while (dataReader.Read())
                {
                    if (!dataReader.IsDBNull(0))
                    {
                        Distance = Distance - dataReader.GetDecimal(0);
                    }
                }
                dataReader.Close();
            }
            if (CurrentMonth == true)
            {
                DateTime PreviousMonthDate = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month)).AddMonths(-1);
                Int32 LastYear = PreviousMonthDate.Year;
                Int32 LastMonth = PreviousMonthDate.Month;

                SqlDataReader dataReader;
                dataReader = SQLHelper.ExecuteReader("SELECT SUM(FertilizerIssued) AS Balance FROM dbo.FertilizerIssued WHERE (YearCode = '" + LastYear + "') AND (SupplierCode = '" + SupplierCode + "') AND (MonthCode = '" + Month + "') AND (RouteNo = '" + RouteNo + "')", CommandType.Text);

                while (dataReader.Read())
                {
                    if (!dataReader.IsDBNull(0))
                    {
                        Distance = dataReader.GetDecimal(0);
                    }
                }
                dataReader.Close();

                dataReader = SQLHelper.ExecuteReader("SELECT dbo.FertilizerSettlement.FertilizerSettled FROM dbo.FertilizerSettlement INNER JOIN dbo.Route ON dbo.FertilizerSettlement.RouteNo = dbo.Route.TownCode WHERE (dbo.FertilizerSettlement.YearCode = '" + Year + "') AND (dbo.FertilizerSettlement.ProcessMonth = '" + Month + "') AND (dbo.FertilizerSettlement.SupplierCode = '" + SupplierCode + "') AND (dbo.Route.RouteNo = '" + RouteNo + "')", CommandType.Text);

                while (dataReader.Read())
                {
                    if (!dataReader.IsDBNull(0))
                    {
                        Distance = Distance - dataReader.GetDecimal(0);
                    }
                }
                dataReader.Close();
            }

            return Distance;
        }

        public Decimal getSupplierIncentives(Int32 Year, Int32 Month, String RouteNo, String SupplierCode)
        {
            Decimal Distance = 0;

            SqlDataReader dataReader;

            //dataReader = SQLHelper.ExecuteReader("SELECT SUM(Incentive) AS Expr1 FROM dbo.SupplierIncentives WHERE (Year = '" + Year + "') AND (Month = '" + Month + "') AND (RouteNo = '" + RouteNo + "') AND (SupplierCode = '" + SupplierCode + "')", CommandType.Text);
            //dataReader = SQLHelper.ExecuteReader("SELECT SUM(dbo.IncentiveLevels.IncentivePerKilo * dbo.DailyGreenLeaf.NetWeight) AS Incentive, dbo.IncentiveLevels.RouteNo,dbo.DailyGreenLeaf.SupplierCode FROM dbo.DailyGreenLeaf INNER JOIN dbo.IncentiveLevels ON dbo.DailyGreenLeaf.RouteNo = dbo.IncentiveLevels.RouteNo WHERE (dbo.DailyGreenLeaf.NetWeight BETWEEN dbo.IncentiveLevels.LeafFrom AND dbo.IncentiveLevels.LeafTo) AND (dbo.IncentiveLevels.RouteNo = '"+ RouteNo +"') AND (dbo.DailyGreenLeaf.SupplierCode = '"+ SupplierCode +"') GROUP BY dbo.IncentiveLevels.RouteNo, dbo.DailyGreenLeaf.SupplierCode", CommandType.Text);
            dataReader = SQLHelper.ExecuteReader("SELECT SUM(Incentive)  AS TOT FROM SupplierIncentives WHERE (Year = '" + Year + "') AND (Month = '" + Month + "') AND (RouteNo = '" + RouteNo + "') AND (SupplierCode = '" + SupplierCode + "')", CommandType.Text);
            //+ SUM(transportIncentive)
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    Distance = dataReader.GetDecimal(0);//Distance + 

                }
            }
            dataReader.Close();


            return Distance;
        }
        //SACHINTHA -20161028
        //REMOVE ROUTE FROM FILTERING
        public Decimal getSupplierIncentives(Int32 Year, Int32 Month, String SupplierCode)
        {
            Decimal Distance = 0;

            SqlDataReader dataReader;

            dataReader = SQLHelper.ExecuteReader("SELECT SUM(Incentive) AS TOT FROM dbo.SupplierIncentives WHERE (Year = '" + Year + "') AND (Month = '" + Month + "') AND (SupplierCode = '" + SupplierCode + "') AND (Approval = 1)", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    Distance = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();

            return Distance;
        }

        //SACHINTHA -20161028
        //REMOVE ROUTE FROM FILTERING
        public decimal getSupplierIncentivesSlabs(int Year, int Month, string Supcode, bool isIncentiveRouteWise)
        {
            decimal Distance = 0;
            SqlDataReader dataReader;
            if (isIncentiveRouteWise)
                dataReader = SQLHelper.ExecuteReader("SELECT dbo.DailyGreenLeaf.NetWeight, dbo.IncentiveLevels.IncentivePerKilo FROM dbo.DailyGreenLeaf RIGHT OUTER JOIN dbo.IncentiveLevels ON dbo.DailyGreenLeaf.RouteNo = dbo.IncentiveLevels.RouteNo WHERE (dbo.DailyGreenLeaf.NetWeight BETWEEN dbo.IncentiveLevels.LeafFrom AND dbo.IncentiveLevels.LeafTo) AND (YEAR(dbo.DailyGreenLeaf.CollectedDate) = '" + Year + "') AND (MONTH(dbo.DailyGreenLeaf.CollectedDate) = '" + Month + "') AND (dbo.DailyGreenLeaf.SupplierCode = '" + Supcode + "') AND (dbo.DailyGreenLeaf.Approval = 1)", CommandType.Text);
            else
                dataReader = SQLHelper.ExecuteReader("SELECT ISNULL(SUM(dbo.DailyGreenLeaf.NetWeight * dbo.IncentiveLevels.IncentivePerKilo), 0) AS Expr1 FROM dbo.DailyGreenLeaf RIGHT OUTER JOIN dbo.IncentiveLevels ON dbo.DailyGreenLeaf.SupplierCode = dbo.IncentiveLevels.SupCode AND dbo.DailyGreenLeaf.RouteNo = dbo.IncentiveLevels.RouteNo WHERE (dbo.DailyGreenLeaf.NetWeight BETWEEN dbo.IncentiveLevels.LeafFrom AND dbo.IncentiveLevels.LeafTo) AND (YEAR(dbo.DailyGreenLeaf.CollectedDate)  = '" + Year + "') AND (MONTH(dbo.DailyGreenLeaf.CollectedDate) = '" + Month + "') AND (dbo.DailyGreenLeaf.SupplierCode = '" + Supcode + "') AND (dbo.DailyGreenLeaf.Approval = 1)", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    Distance = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();
            return Distance;
        }



        public Decimal getCashBalance(Int32 Year, Int32 Month, String RouteNo, String SupplierCode)
        {
            Decimal Distance = 0;
            DateTime PreviousMonthDate = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month)).AddMonths(-1);
            Int32 LastYear = PreviousMonthDate.Year;
            Int32 LastMonth = PreviousMonthDate.Month;
            SqlDataReader dataReader;

            dataReader = SQLHelper.ExecuteReader("SELECT dbo.BFBalances.CashBalance AS Expr1, dbo.Route.RouteNo FROM dbo.BFBalances INNER JOIN dbo.Route ON dbo.BFBalances.RouteNo = dbo.Route.TownCode WHERE     (dbo.BFBalances.Year = '" + Year + "') AND (dbo.BFBalances.Month = '" + LastMonth + "')AND (dbo.Route.TownCode = '" + RouteNo + "') AND (dbo.BFBalances.CashBalance < 0) AND (dbo.BFBalances.SupplierCode = '" + SupplierCode + "')", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    Distance = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();

            return Distance;
        }

        public Decimal getCasHAdvancedBalance(Int32 Year, Int32 Month, String RouteNo, String SupplierCode)
        {
            Decimal Distance = 0;
            DateTime PreviousMonthDate = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month)).AddMonths(-1);
            Int32 LastYear = PreviousMonthDate.Year;
            Int32 LastMonth = PreviousMonthDate.Month;
            SqlDataReader dataReader;

            dataReader = SQLHelper.ExecuteReader("SELECT dbo.MonthlyPayments.AdvanceTaken FROM dbo.MonthlyPayments INNER JOIN dbo.Route ON dbo.MonthlyPayments.RouteNo = dbo.Route.TownCode INNER JOIN dbo.Supplier ON dbo.MonthlyPayments.SupplierCode = dbo.Supplier.SupplierCode WHERE     (dbo.MonthlyPayments.SupplierCode = '" + SupplierCode + "') AND (dbo.MonthlyPayments.Year = '" + Year + "') AND (dbo.MonthlyPayments.Month = '" + Month + "') AND (dbo.Route.TownCode = '" + RouteNo + "')", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    Distance = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();
            return Distance;
        }

        public Decimal getBFCoinBalance(Int32 Year, Int32 Month, String RouteNo, String SupplierCode, Boolean CurrentMonth)
        {
            DateTime PreviousMonthDate = new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month)).AddMonths(-1);

            Int32 LastYear = PreviousMonthDate.Year;
            Int32 LastMonth = PreviousMonthDate.Month;

            if (CurrentMonth == true)
            {
                LastYear = Year;
                LastMonth = Month;
            }

            Decimal Distance = 0;

            SqlDataReader dataReader;

            dataReader = SQLHelper.ExecuteReader("SELECT SUM(dbo.BFBalances.BFCoins) AS Expr1 FROM dbo.BFBalances INNER JOIN dbo.Route ON dbo.BFBalances.RouteNo = dbo.Route.TownCode WHERE (dbo.BFBalances.Year = '" + LastYear + "') AND (dbo.BFBalances.Month = '" + LastMonth + "') AND (dbo.Route.RouteNo = '" + RouteNo + "') AND (dbo.BFBalances.SupplierCode = '" + SupplierCode + "')", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    Distance = Distance + dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();


            return Distance;
        }
        public DataSet getSupplierPaymentsAll(String BankCode, Int32 Year, Int32 Month)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.MonthlyPayments.Year, dbo.MonthlyPayments.Month, dbo.MonthlyPayments.SupplierCode, dbo.Supplier.SupplierName, dbo.MonthlyPayments.TotalGreenLeaf, dbo.MonthlyPayments.TotalAmount, dbo.MonthlyPayments.AdvanceTaken, dbo.MonthlyPayments.FertilizerTaken, dbo.MonthlyPayments.MadeTeaTaken, dbo.MonthlyPayments.OtherCharges, dbo.MonthlyPayments.StampDutyDeduction, dbo.MonthlyPayments.PaySilpCharge, dbo.MonthlyPayments.TransportDeduction, dbo.Bank.BankName, dbo.Supplier.AccountNo, dbo.MonthlyPayments.UnionCharge, dbo.MonthlyPayments.OtherAddition,dbo.MonthlyPayments.StationaryAmount FROM dbo.MonthlyPayments INNER JOIN dbo.Supplier ON dbo.MonthlyPayments.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.Bank ON dbo.Supplier.BankCode = dbo.Bank.BankCode WHERE (dbo.MonthlyPayments.Year = '" + Year + "') AND (dbo.MonthlyPayments.Month = '" + Month + "') AND (dbo.Supplier.BankCode = '" + BankCode + "')", CommandType.Text);

            da.Fill(ds, "SupplierPayments");
            return ds;
        }
        public DataSet getSupplierPayments(Int32 Year, Int32 Month, String SupplierCode)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.MonthlyPayments.Year, dbo.MonthlyPayments.Month, dbo.MonthlyPayments.SupplierCode, dbo.Supplier.SupplierName, dbo.MonthlyPayments.TotalGreenLeaf, dbo.MonthlyPayments.TotalAmount, dbo.MonthlyPayments.AdvanceTaken, dbo.MonthlyPayments.FertilizerTaken, dbo.MonthlyPayments.MadeTeaTaken, dbo.MonthlyPayments.OtherCharges, dbo.MonthlyPayments.StampDutyDeduction, dbo.MonthlyPayments.PaySilpCharge, dbo.MonthlyPayments.TransportDeduction, dbo.Bank.BankName, dbo.Supplier.AccountNo, dbo.MonthlyPayments.UnionCharge, dbo.MonthlyPayments.OtherAddition, dbo.MonthlyPayments.StationaryAmount FROM dbo.MonthlyPayments INNER JOIN dbo.Supplier ON dbo.MonthlyPayments.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.Bank ON dbo.Supplier.BankCode = dbo.Bank.BankCode WHERE (dbo.MonthlyPayments.Year = '" + Year + "') AND (dbo.MonthlyPayments.Month = '" + Month + "') AND (dbo.MonthlyPayments.SupplierCode = '" + SupplierCode + "')", CommandType.Text);

            da.Fill(ds, "SupplierPayments");
            return ds;
        }
        public DataSet getSupplierPayments(Int32 Year, Int32 Month, String SupplierCode, String BankCode)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.MonthlyPayments.Year, dbo.MonthlyPayments.Month, dbo.MonthlyPayments.SupplierCode, dbo.Supplier.SupplierName, dbo.MonthlyPayments.TotalGreenLeaf, dbo.MonthlyPayments.TotalAmount, dbo.MonthlyPayments.AdvanceTaken, dbo.MonthlyPayments.FertilizerTaken, dbo.MonthlyPayments.MadeTeaTaken, dbo.MonthlyPayments.OtherCharges, dbo.MonthlyPayments.StampDutyDeduction, dbo.MonthlyPayments.PaySilpCharge, dbo.MonthlyPayments.TransportDeduction, dbo.Bank.BankName, dbo.Supplier.AccountNo, dbo.MonthlyPayments.UnionCharge, dbo.MonthlyPayments.OtherAddition,dbo.MonthlyPayments.StationaryAmount FROM dbo.MonthlyPayments INNER JOIN dbo.Supplier ON dbo.MonthlyPayments.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.Bank ON dbo.Supplier.BankCode = dbo.Bank.BankCode WHERE (dbo.MonthlyPayments.Year = '" + Year + "') AND (dbo.MonthlyPayments.Month = '" + Month + "') AND (dbo.Supplier.BankCode = '" + BankCode + "') AND (dbo.MonthlyPayments.SupplierCode = '" + SupplierCode + "') AND (dbo.MonthlyPayments.TotalGreenLeaf > 0)", CommandType.Text);

            da.Fill(ds, "SupplierPayments");
            return ds;
        }
        public DataSet getSupplierPayments(Int32 Year, Int32 Month)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Year"));
            dt.Columns.Add(new DataColumn("MonthCode"));
            dt.Columns.Add(new DataColumn("SupplierCode"));
            dt.Columns.Add(new DataColumn("SupplierName"));
            dt.Columns.Add(new DataColumn("TotalValue"));
            dt.Columns.Add(new DataColumn("1000"));
            dt.Columns.Add(new DataColumn("500"));
            dt.Columns.Add(new DataColumn("100"));
            dt.Columns.Add(new DataColumn("50"));
            dt.Columns.Add(new DataColumn("20"));
            dt.Columns.Add(new DataColumn("10"));
            dt.Columns.Add(new DataColumn("Balance"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT dbo.MonthlyPayments.Year, dbo.MonthlyPayments.Month, dbo.MonthlyPayments.SupplierCode, dbo.Supplier.SupplierName, dbo.MonthlyPayments.TotalAmount - dbo.MonthlyPayments.AdvanceTaken - dbo.MonthlyPayments.FertilizerTaken - dbo.MonthlyPayments.MadeTeaTaken - dbo.MonthlyPayments.OtherCharges - dbo.MonthlyPayments.StampDutyDeduction - dbo.MonthlyPayments.PaySilpCharge - dbo.MonthlyPayments.TransportDeduction AS Balance FROM dbo.MonthlyPayments INNER JOIN dbo.Supplier ON dbo.MonthlyPayments.SupplierCode = dbo.Supplier.SupplierCode WHERE (dbo.MonthlyPayments.Year = '" + Year + "') AND (dbo.MonthlyPayments.Month = '" + Month + "')", CommandType.Text);

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
                    dtrow[2] = dataReader.GetString(2).ToString();
                }
                if (!dataReader.IsDBNull(3))
                {
                    dtrow[3] = dataReader.GetString(3);
                }
                if (!dataReader.IsDBNull(4))
                {
                    dtrow[4] = dataReader.GetDecimal(4);
                }
                if (dtrow[4] != null)
                {
                    Decimal TotalValue = Convert.ToDecimal(dtrow[4]);
                    Int32 my1000 = Convert.ToInt32(System.Math.Floor(TotalValue / 1000));

                    dtrow[5] = my1000;

                    Decimal Balance = TotalValue - my1000 * 1000;

                    Int32 my500 = Convert.ToInt32(System.Math.Floor(Balance / 500));
                    dtrow[6] = my500;

                    Balance = Balance - (my500 * 500);

                    Int32 my100 = Convert.ToInt32(System.Math.Floor(Balance / 100));
                    dtrow[7] = my100;

                    Balance = Balance - (my100 * 100);

                    Int32 my50 = Convert.ToInt32(System.Math.Floor(Balance / 50));
                    dtrow[8] = my50;

                    Balance = Balance - (my50 * 50);

                    Int32 my20 = Convert.ToInt32(System.Math.Floor(Balance / 20));
                    dtrow[9] = my20;

                    Balance = Balance - (my20 * 20);

                    Int32 my10 = Convert.ToInt32(System.Math.Floor(Balance / 10));
                    dtrow[10] = my10;

                    Balance = Balance - (my10 * 10);
                    dtrow[11] = Balance;

                    dt.Rows.Add(dtrow);
                }


            }
            dataReader.Close();

            DataSet dataSetReport = new DataSet();
            dt.TableName = "CoinAnalysis";

            dataSetReport.Tables.Add(dt);

            return dataSetReport;
        }
        public DataSet getRouteSummary(Int32 Year, Int32 Month)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.MonthlyPayments.Year, dbo.MonthlyPayments.Month, dbo.Supplier.SupplierName, dbo.MonthlyPayments.TotalGreenLeaf, dbo.MonthlyPayments.TotalAmount, dbo.MonthlyPayments.AdvanceTaken, dbo.MonthlyPayments.FertilizerTaken, dbo.MonthlyPayments.MadeTeaTaken, dbo.MonthlyPayments.OtherCharges, dbo.MonthlyPayments.StampDutyDeduction, dbo.MonthlyPayments.PaySilpCharge, dbo.MonthlyPayments.TransportDeduction, dbo.Route.RouteNo FROM dbo.MonthlyPayments INNER JOIN dbo.Supplier ON dbo.MonthlyPayments.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.Route ON dbo.Supplier.TownCode = dbo.Route.TownCode WHERE (dbo.MonthlyPayments.Year = '" + Year + "') AND (dbo.MonthlyPayments.Month = '" + Month + "')", CommandType.Text);

            da.Fill(ds, "RouteSummary");
            return ds;
        }
        public DataSet getRouteSummary(Int32 Year, Int32 Month, String Route)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.MonthlyPayments.Year, dbo.MonthlyPayments.Month, dbo.Supplier.SupplierName, dbo.MonthlyPayments.TotalGreenLeaf, dbo.MonthlyPayments.TotalAmount, dbo.MonthlyPayments.AdvanceTaken, dbo.MonthlyPayments.FertilizerTaken, dbo.MonthlyPayments.MadeTeaTaken, dbo.MonthlyPayments.OtherCharges, dbo.MonthlyPayments.StampDutyDeduction, dbo.MonthlyPayments.PaySilpCharge, dbo.MonthlyPayments.TransportDeduction, dbo.Route.RouteNo FROM dbo.MonthlyPayments INNER JOIN dbo.Supplier ON dbo.MonthlyPayments.SupplierCode = dbo.Supplier.SupplierCode INNER JOIN dbo.Route ON dbo.Supplier.TownCode = dbo.Route.TownCode WHERE (dbo.MonthlyPayments.Year = '" + Year + "') AND (dbo.MonthlyPayments.Month = '" + Month + "') AND (dbo.Route.RouteNo = '" + Route + "')", CommandType.Text);

            da.Fill(ds, "RouteSummary");
            return ds;
        }
        public DataSet getAdjustments(Int32 Year, Int32 Month)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            da.SelectCommand = SQLHelper.CreateCommand("SELECT TOP (100) PERCENT dbo.DailyGreenLeafEdit.RouteNo, dbo.DailyGreenLeafEdit.CollectedDate, dbo.DailyGreenLeafEdit.SupplierCode, dbo.Supplier.SupplierName, dbo.DailyGreenLeafEdit.OriginalLeaf, dbo.DailyGreenLeafEdit.NewLeaf, dbo.DailyGreenLeafEdit.Reason, dbo.DailyGreenLeafEdit.UserID, dbo.DailyGreenLeafEdit.CreateDateTime, MONTH(dbo.DailyGreenLeafEdit.CollectedDate) AS Month, YEAR(dbo.DailyGreenLeafEdit.CollectedDate) AS Year FROM dbo.DailyGreenLeafEdit INNER JOIN dbo.Supplier ON dbo.DailyGreenLeafEdit.SupplierCode = dbo.Supplier.SupplierCode WHERE (MONTH(dbo.DailyGreenLeafEdit.CollectedDate) = '" + Month + "') AND (YEAR(dbo.DailyGreenLeafEdit.CollectedDate) = '" + Year + "') ORDER BY dbo.DailyGreenLeafEdit.CollectedDate", CommandType.Text);

            da.Fill(ds, "Adjustments");
            return ds;
        }
        public Decimal getrate(Int32 Year, Int32 Month)
        {
            Decimal Distance = 0;

            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT KiloRate FROM dbo.MonthlyParameters WHERE (YearCode = '" + Year + "') AND (MonthCode = '" + Month + "')", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    Distance = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();
            return Distance;
        }
        public Decimal getAdvanceRate()
        {
            Decimal Distance = 0;

            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT AdvancePerKiloRate FROM [dbo].[FixedPaymentSettings]", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    Distance = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();
            return Distance;
        }
        public Decimal getOpeningBalance(Int32 Year, Int32 Month, String Route, String SupplierCode)
        {
            Decimal Distance = 0;
            Int32 PreviousMonth = new DateTime(Year, Month, 1).AddMonths(-1).Month;
            Int32 PreviousYear = new DateTime(Year, Month, 1).AddMonths(-1).Year;

            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT SUM(FertilizerBalance - CashBalance + LoanBalance) AS Expr1 FROM dbo.BFBalances WHERE (RouteNo = '" + Route + "') AND (SupplierCode = '" + SupplierCode + "') AND (Year = '" + PreviousYear + "') AND (Month = '" + PreviousMonth + "')", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    Distance = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();
            return Distance;
        }
        public DataSet getPaymentSlip(Int32 Year, Int32 Month, String RouteCode)
        {
            DataSet ds = new DataSet();

            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.MonthlyPayments.RouteNo, dbo.MonthlyPayments.SupplierCode, dbo.Supplier.SupplierName, dbo.MonthlyPayments.TotalGreenLeaf, dbo.MonthlyPayments.Year, dbo.Month.MonthName, dbo.Route.RouteNo AS RouteName, dbo.MonthlyParameters.KiloRate, dbo.MonthlyPayments.TotalAmount, dbo.viewGreenLeaf.Day, dbo.viewGreenLeaf.NetWeight FROM dbo.MonthlyPayments INNER JOIN dbo.Supplier ON dbo.MonthlyPayments.SupplierCode = dbo.Supplier.SupplierCode AND dbo.MonthlyPayments.RouteNo = dbo.Supplier.TownCode INNER JOIN dbo.Month ON dbo.MonthlyPayments.Month = dbo.Month.MonthCode INNER JOIN dbo.Route ON dbo.MonthlyPayments.RouteNo = dbo.Route.TownCode INNER JOIN dbo.MonthlyParameters ON dbo.MonthlyPayments.Year = dbo.MonthlyParameters.YearCode AND dbo.MonthlyPayments.Month = dbo.MonthlyParameters.MonthCode INNER JOIN dbo.viewGreenLeaf ON dbo.MonthlyPayments.Year = dbo.viewGreenLeaf.Year AND dbo.MonthlyPayments.Month = dbo.viewGreenLeaf.Month AND dbo.MonthlyPayments.SupplierCode = dbo.viewGreenLeaf.SupplierCode AND dbo.MonthlyPayments.RouteNo = dbo.viewGreenLeaf.TownCode WHERE (dbo.MonthlyPayments.RouteNo = 'HED') AND (dbo.MonthlyPayments.Year = '" + Year + "') AND (dbo.MonthlyPayments.Month = '" + Month + "') AND (dbo.MonthlyPayments.TotalGreenLeaf <> 0)", CommandType.Text);

            da.Fill(ds, "Salaries");

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("RegNo"));
            dt.Columns.Add(new DataColumn("Factory"));
            dt.Columns.Add(new DataColumn("Extent"));
            dt.Columns.Add(new DataColumn("SupplierCode"));
            dt.Columns.Add(new DataColumn("SupplierName"));
            dt.Columns.Add(new DataColumn("GreenLeaf"));
            dt.Columns.Add(new DataColumn("RatePaid"));
            dt.Columns.Add(new DataColumn("Year"));
            dt.Columns.Add(new DataColumn("Month"));
            dt.Columns.Add(new DataColumn("OtherAddition"));
            dt.Columns.Add(new DataColumn("Route"));
            dt.Columns.Add(new DataColumn("CollectedDate"));


            DataRow dtrow;
            SqlDataReader dataReader;
            SqlDataReader dataReaderNew;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT dbo.Factory.RegNo, dbo.Factory.FactoryName, dbo.Factory.Extent, dbo.DailyGreenLeaf.SupplierCode, dbo.Supplier.SupplierName, SUM(dbo.DailyGreenLeaf.NetWeight) AS Leaf, YEAR(dbo.DailyGreenLeaf.CollectedDate) AS YearCode, MONTH(dbo.DailyGreenLeaf.CollectedDate) AS MonthCode FROM dbo.Supplier INNER JOIN dbo.DailyGreenLeaf ON dbo.Supplier.SupplierCode = dbo.DailyGreenLeaf.SupplierCode CROSS JOIN dbo.Factory WHERE (dbo.DailyGreenLeaf.Processed = 1) GROUP BY dbo.Factory.RegNo, dbo.Factory.FactoryName, dbo.Factory.Extent, dbo.DailyGreenLeaf.SupplierCode, dbo.Supplier.SupplierName, YEAR(dbo.DailyGreenLeaf.CollectedDate), MONTH(dbo.DailyGreenLeaf.CollectedDate) HAVING      (YEAR(dbo.DailyGreenLeaf.CollectedDate) = '" + Year + "') AND (MONTH(dbo.DailyGreenLeaf.CollectedDate) = '" + Month + "')", CommandType.Text);

            while (dataReader.Read())
            {
                dtrow = dt.NewRow();

                if (!dataReader.IsDBNull(0))
                {
                    dtrow[0] = dataReader.GetString(0);
                }
                if (!dataReader.IsDBNull(1))
                {
                    dtrow[1] = dataReader.GetString(1);
                }
                if (!dataReader.IsDBNull(2))
                {
                    dtrow[2] = dataReader.GetDecimal(2);
                }
                if (!dataReader.IsDBNull(3))
                {
                    dtrow[3] = dataReader.GetString(3);
                }
                if (!dataReader.IsDBNull(4))
                {
                    dtrow[4] = dataReader.GetString(4);
                }
                if (!dataReader.IsDBNull(5))
                {
                    dtrow[5] = dataReader.GetDecimal(5);
                }
                dtrow[6] = getrate(Year, Month);
                //if (!dataReader.IsDBNull(6))
                //{
                //    //dtrow[6] = dataReader.GetDecimal(6);

                //}
                if (!dataReader.IsDBNull(6))
                {
                    dtrow[7] = dataReader.GetInt32(6);
                }
                if (!dataReader.IsDBNull(7))
                {
                    dtrow[8] = dataReader.GetInt32(7);
                }
                dtrow[9] = 0;

                dataReaderNew = SQLHelper.ExecuteReader("SELECT OtherAddition FROM dbo.MonthlyPayments WHERE (Year = '" + Year + "') AND (Month = '" + Month + "') AND (SupplierCode = '" + dataReader.GetString(3) + "')", CommandType.Text);
                while (dataReaderNew.Read())
                {
                    if (!dataReaderNew.IsDBNull(0))
                    {
                        dtrow[9] = dataReaderNew.GetDecimal(0);
                    }
                }
                dataReaderNew.Close();

                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            dt.TableName = "Header";
            ds.Tables.Add(dt);

            dt.Dispose();

            DataTable dtDetail = new DataTable();
            dtDetail.Columns.Add(new DataColumn("Date"));
            dtDetail.Columns.Add(new DataColumn("Kilos"));
            dtDetail.Columns.Add(new DataColumn("SupplierCode"));
            dtDetail.Columns.Add(new DataColumn("Year"));
            dtDetail.Columns.Add(new DataColumn("Month"));

            dtrow = dtDetail.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT DAY(CollectedDate) AS Date, NetWeight, SupplierCode FROM dbo.DailyGreenLeaf WHERE (Processed = 1) AND (YEAR(CollectedDate) = '" + Year + "') AND (MONTH(CollectedDate) = '" + Month + "')", CommandType.Text);

            while (dataReader.Read())
            {
                dtrow = dtDetail.NewRow();
                if (!dataReader.IsDBNull(0))
                {
                    dtrow[0] = dataReader.GetInt32(0);
                }
                if (!dataReader.IsDBNull(1))
                {
                    dtrow[1] = dataReader.GetDecimal(1);
                }
                if (!dataReader.IsDBNull(2))
                {
                    dtrow[2] = dataReader.GetString(2);
                }
                dtrow[3] = Year.ToString();
                dtrow[4] = Month.ToString();

                dtDetail.Rows.Add(dtrow);
            }
            dataReader.Close();
            dtDetail.TableName = "Details";
            ds.Tables.Add(dtDetail);
            dtDetail.Dispose();

            DataTable dtSummary = new DataTable();
            dtSummary.Columns.Add(new DataColumn("SupplierCode"));
            dtSummary.Columns.Add(new DataColumn("TotalGreenLeaf"));
            dtSummary.Columns.Add(new DataColumn("TotalAmount"));
            dtSummary.Columns.Add(new DataColumn("AdvanceTaken"));
            dtSummary.Columns.Add(new DataColumn("FertilizerTaken"));
            dtSummary.Columns.Add(new DataColumn("MadeTeaTaken"));
            dtSummary.Columns.Add(new DataColumn("OtherCharges"));
            dtSummary.Columns.Add(new DataColumn("StampDutyDeduction"));
            dtSummary.Columns.Add(new DataColumn("PaySilpCharge"));
            dtSummary.Columns.Add(new DataColumn("TransportDeduction"));
            dtSummary.Columns.Add(new DataColumn("Union"));
            dtSummary.Columns.Add(new DataColumn("Stationary"));
            dtSummary.Columns.Add(new DataColumn("OtherAddition"));
            dtSummary.Columns.Add(new DataColumn("Year"));
            dtSummary.Columns.Add(new DataColumn("Month"));

            dtrow = dtSummary.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT SupplierCode, TotalGreenLeaf, TotalAmount, AdvanceTaken, FertilizerTaken, MadeTeaTaken, OtherCharges, StampDutyDeduction, PaySilpCharge, TransportDeduction,UnionCharge,StationaryAmount,OtherAddition FROM dbo.MonthlyPayments WHERE (Year = '" + Year + "') AND (Month = '" + Month + "')", CommandType.Text);

            while (dataReader.Read())
            {
                dtrow = dtSummary.NewRow();
                if (!dataReader.IsDBNull(0))
                {
                    dtrow[0] = dataReader.GetString(0);
                }
                if (!dataReader.IsDBNull(1))
                {
                    dtrow[1] = dataReader.GetDecimal(1);
                }
                if (!dataReader.IsDBNull(2))
                {
                    dtrow[2] = dataReader.GetDecimal(2);
                }
                if (!dataReader.IsDBNull(3))
                {
                    dtrow[3] = dataReader.GetDecimal(3);
                }
                if (!dataReader.IsDBNull(4))
                {
                    dtrow[4] = dataReader.GetDecimal(4);
                }
                if (!dataReader.IsDBNull(5))
                {
                    dtrow[5] = dataReader.GetDecimal(5);
                }
                if (!dataReader.IsDBNull(6))
                {
                    dtrow[6] = dataReader.GetDecimal(6);
                }
                if (!dataReader.IsDBNull(7))
                {
                    dtrow[7] = dataReader.GetDecimal(7);
                }
                if (!dataReader.IsDBNull(8))
                {
                    dtrow[8] = dataReader.GetDecimal(8);
                }
                if (!dataReader.IsDBNull(9))
                {
                    dtrow[9] = dataReader.GetDecimal(9);
                }
                if (!dataReader.IsDBNull(10))
                {
                    dtrow[10] = dataReader.GetDecimal(10);
                }
                if (!dataReader.IsDBNull(11))
                {
                    dtrow[11] = dataReader.GetDecimal(11);
                }
                if (!dataReader.IsDBNull(12))
                {
                    dtrow[12] = dataReader.GetDecimal(12);
                }
                dtrow[13] = Year.ToString();
                dtrow[14] = Month.ToString();

                dtSummary.Rows.Add(dtrow);
            }
            dataReader.Close();
            dtSummary.TableName = "Payments";
            ds.Tables.Add(dtSummary);

            dtSummary.Dispose();

            return ds;
        }


        //=========================================2015-10-05=======================================================

        //public DataTable getPaymentSlipS(int year, int month, string routeCode)
        //{
        //    DataTable dt = new DataTable("PaymentTbl");
        //    dt.Columns.Add(new DataColumn("RegNo"));//0

        //    dt.Columns.Add(new DataColumn("Factory"));//1
        //    dt.Columns.Add(new DataColumn("Extent"));//2
        //    dt.Columns.Add(new DataColumn("SupplierCode"));//3
        //    dt.Columns.Add(new DataColumn("SupplierName"));//4
        //    dt.Columns.Add(new DataColumn("Year"));//5
        //    dt.Columns.Add(new DataColumn("Month"));//6
        //    dt.Columns.Add(new DataColumn("Route"));//7
        //    dt.Columns.Add(new DataColumn("CollectedDate"));//8
        //    dt.Columns.Add(new DataColumn("GLCollected"));//9
        //    dt.Columns.Add(new DataColumn("kiloRate"));//10
        //    dt.Columns.Add(new DataColumn("TotLeaf"));//11
        //    dt.Columns.Add(new DataColumn("incentive"));//12

        //    DataRow dtrow;
        //    SqlDataReader dataReader;
        //    SqlDataReader dataReaderNew;
        //    SqlDataReader datareader1;
        //    dtrow = dt.NewRow();

        //    dataReader = SQLHelper.ExecuteReader("SELECT dbo.Factory.RegNo, dbo.Factory.FactoryName, dbo.Factory.Extent, dbo.DailyGreenLeaf.SupplierCode, dbo.Supplier.SupplierName,YEAR(dbo.DailyGreenLeaf.CollectedDate) AS YearCode, MONTH(dbo.DailyGreenLeaf.CollectedDate) AS MonthCode, dbo.DailyGreenLeaf.RouteNo, dbo.DailyGreenLeaf.CollectedDate,dbo.DailyGreenLeaf.NetWeight  FROM dbo.Supplier INNER JOIN dbo.DailyGreenLeaf ON dbo.Supplier.SupplierCode = dbo.DailyGreenLeaf.SupplierCode CROSS JOIN dbo.Factory GROUP BY dbo.Factory.RegNo, dbo.Factory.FactoryName, dbo.Factory.Extent, dbo.DailyGreenLeaf.SupplierCode,dbo.DailyGreenLeaf.NetWeight, dbo.Supplier.SupplierName, YEAR(dbo.DailyGreenLeaf.CollectedDate), MONTH(dbo.DailyGreenLeaf.CollectedDate), dbo.DailyGreenLeaf.RouteNo,(dbo.DailyGreenLeaf.CollectedDate) HAVING      (YEAR(dbo.DailyGreenLeaf.CollectedDate) = '" + year + "') AND (MONTH(dbo.DailyGreenLeaf.CollectedDate) = '" + month + "') AND (dbo.DailyGreenLeaf.RouteNo = '" + routeCode + "') ", CommandType.Text);
        //    while (dataReader.Read())
        //    {
        //        dtrow = dt.NewRow();

        //        if (!dataReader.IsDBNull(0))
        //        {
        //            dtrow[0] = dataReader.GetString(0);
        //        }
        //        if (!dataReader.IsDBNull(1))
        //        {
        //            dtrow[1] = dataReader.GetString(1);
        //        }
        //        if (!dataReader.IsDBNull(2))
        //        {
        //            dtrow[2] = dataReader.GetDecimal(2);
        //        }
        //        if (!dataReader.IsDBNull(3))
        //        {
        //            dtrow[3] = dataReader.GetString(3);
        //        }
        //        if (!dataReader.IsDBNull(4))
        //        {
        //            dtrow[4] = dataReader.GetString(4);
        //        }
        //        if (!dataReader.IsDBNull(5))
        //        {
        //            dtrow[5] = dataReader.GetInt32(5);
        //        }

        //        if (!dataReader.IsDBNull(6))
        //        {
        //            dtrow[6] = dataReader.GetInt32(6);
        //        }

        //        if (!dataReader.IsDBNull(7))
        //        {
        //            dtrow[7] = dataReader.GetString(7);
        //        }
        //        if (!dataReader.IsDBNull(8))
        //        {
        //            dtrow[8] = dataReader.GetDateTime(8);
        //        }
        //        if (!dataReader.IsDBNull(9))
        //        {
        //            dtrow[9] = dataReader.GetDecimal(9);
        //        }

        //        dtrow[10] = 0;

        //        DataTable odt = new DataTable("TotalKilo");
        //        odt.Columns.Add("totKilo");

        //        dataReaderNew = SQLHelper.ExecuteReader("SELECT KiloRate FROM MonthlyParameters where YearCode='" + year + "' AND MonthCode='" + month + "'", CommandType.Text);

        //        while (dataReaderNew.Read())
        //        {
        //            dtrow[10] = dataReaderNew.GetDecimal(0);

        //        }
        //        dataReaderNew.Close();


        //        dtrow[11] = 0;
        //        DataTable odts = new DataTable("sumoKilos");
        //        odts.Columns.Add("sumOfkilos");

        //        datareader1 = SQLHelper.ExecuteReader("SELECT  SUM(NetWeight) AS Total FROM  dbo.DailyGreenLeaf GROUP BY RouteNo, YEAR(CollectedDate), MONTH(CollectedDate) HAVING (RouteNo = '"+ routeCode +"') AND (YEAR(CollectedDate) = '"+ year +"') AND (MONTH(CollectedDate) = '"+ month +"')", CommandType.Text);

        //        while (datareader1.Read())
        //        {
        //            dtrow[11] = datareader1.GetDecimal(0);

        //        }
        //                //dtrow[13] = totalGreenLeaf(month, year, dataReader.GetString(10), dataReader.GetString(3));

        //       dtrow[12] = getIncentives(year,month,dataReader.GetString(3),routeCode);

        //        datareader1.Close();
        //        dt.Rows.Add(dtrow);

        //    }
        //    dataReader.Close();
        //    return dt; 

        //}

        // updated above code by sachintha udara
        // 2016.10.19 
        //start

        public DataTable getPaymentSlipS(int year, int month, string routeCode)
        {
            //return SQLHelper.FillDataSet("SELECT f.[RegNo],f.[FactoryName],f.[Extent],ps.[SupplierCode],s.[SupplierName],ps.[Year],ps.[Month],ps.[TownCode] ,ps.[GreenLeafKillo],ps.[GreenLeafRate],ps.[GreenLeafValue],ps.[Incentive],ps.[OtherAddition],ps.[TotalEarning],ps.[TotalDeduction],ps.[PaymentDue],ps.[NetPay] FROM [dbo].[MonthlyPaymentSummary] ps, [dbo].[Supplier] s CROSS JOIN [dbo].[Factory] f WHERE S.SupplierCode = ps.SupplierCode AND ps.Year = " + year + " AND ps.Month = " + month + " AND ps.TownCode = '" + routeCode + "' ORDER BY CONVERT(int, ps.[SupplierCode])", CommandType.Text).Tables[0];
            return SQLHelper.FillDataSet("SELECT f.RegNo, f.FactoryName, f.Extent, ps.SupplierCode, s.SupplierName, ps.Year, ps.Month, ps.RouteCode, ps.GreenLeafKillo, ps.GreenLeafRate, ps.GreenLeafValue, ps.Incentive, ps.OtherAddition, ps.TotalEarning, ps.TotalDeduction, ps.PaymentDue, ps.NetPay FROM dbo.Factory AS f CROSS JOIN dbo.Supplier AS s INNER JOIN dbo.MonthlyPaymentSummary AS ps ON s.SupplierCode = ps.SupplierCode WHERE (ps.Year = " + year + ") AND (ps.Month = " + month + ") AND (ps.RouteCode = '" + routeCode + "') AND (ps.GreenLeafKillo + ps.GreenLeafValue + ps.Incentive + ps.OtherAddition + ps.CFCoinBalance + ps.Fertilizer + ps.Transport + ps.Loan + ps.CashAdvance + ps.PaySlip+ ps.OtherDeduction + ps.MadeTea + ps.StampDuty + ps.CFDebtBalance > 0) ORDER BY CONVERT(int, ps.SupplierCode)", CommandType.Text).Tables[0];

        }
        //end


        public decimal totalGreenLeaf(int month, int year, string route, string supCode)
        {
            decimal totaGreen = 0;
            SqlDataReader dtReader;

            dtReader = SQLHelper.ExecuteReader("SELECT TotalGreenLeaf FROM dbo.MonthlyPayments WHERE (RouteNo = '" + route + "') AND (Year = '" + year + "') AND (Month = '" + month + "') AND (SupplierCode = '" + supCode + "')", CommandType.Text);

            while (dtReader.Read())
            {
                totaGreen = dtReader.GetDecimal(0);

            }
            return totaGreen;

        }




        public DataTable getAdvancePayableReport(Int32 Year, Int32 Month, DateTime ToDate, String RouteCode, String RouteName)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("SupplierCode"));
            dt.Columns.Add(new DataColumn("SupplierName"));
            dt.Columns.Add(new DataColumn("Leaf"));
            dt.Columns.Add(new DataColumn("OPBalance"));
            dt.Columns.Add(new DataColumn("Advance"));
            dt.Columns.Add(new DataColumn("Fertilizer"));
            dt.Columns.Add(new DataColumn("Tea"));
            dt.Columns.Add(new DataColumn("AdvanceAmount"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();
            dataReader = SQLHelper.ExecuteReader("SELECT SupplierCode, SupplierName FROM dbo.Supplier WHERE (TownCode = '" + RouteCode + "') AND (InactiveSupplier = 0)", CommandType.Text);

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
                dtrow[2] = getLeaf(Year, Month, ToDate.Date, dataReader.GetString(0).Trim(), RouteCode);
                dtrow[3] = getOpeningBalance(Year, Month, RouteCode, dataReader.GetString(0).Trim());

                dtrow[4] = getCurrentMonthAdvances(Year, Month, ToDate, dataReader.GetString(0).Trim(), RouteCode);
                dtrow[5] = getCurrentMonthFertilizer(Year, Month, ToDate, dataReader.GetString(0).Trim(), RouteCode);
                dtrow[6] = getCurrentMonthTeaIssues(Year, Month, ToDate, dataReader.GetString(0).Trim(), RouteCode);
                dtrow[7] = getAdvanceRate() * getLeaf(Year, Month, ToDate.Date, dataReader.GetString(0).Trim(), RouteCode);
                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }

        public DataTable getDayWiseGreenLeaf(Int32 Year, Int32 Month, String RouteCode)
        {
            BLSupplier mySupplier = new BLSupplier();

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Day"));
            dt.Columns.Add(new DataColumn("Leaf"));
            dt.Columns.Add(new DataColumn("SupplierCode"));

            DataRow dtrow;
            SqlDataReader dataReader;

            Int32 Days = DateTime.DaysInMonth(Year, Month);

            for (Int32 i = 1; i <= Days; i++)
            {
                DateTime MyDate = new DateTime(Year, Month, i);

                DataTable dtSupplier = mySupplier.ListActiveSuppliers(RouteCode);
                if (dtSupplier.Rows.Count > 0)
                {
                    for (Int32 iSupplier = 0; iSupplier <= dtSupplier.Rows.Count - 1; iSupplier++)
                    {
                        dtrow = dt.NewRow();
                        dtrow[0] = i;
                        dtrow[1] = 0;
                        dtrow[2] = dtSupplier.Rows[iSupplier][0].ToString();

                        dataReader = SQLHelper.ExecuteReader("SELECT SUM(NetWeight) AS GL FROM dbo.DailyGreenLeaf WHERE (RouteNo = '" + RouteCode + "') AND (CollectedDate = CONVERT(DATETIME, '" + MyDate + "',102)) AND (SupplierCode = '" + dtSupplier.Rows[iSupplier][0].ToString() + "')", CommandType.Text);
                        while (dataReader.Read())
                        {
                            if (!dataReader.IsDBNull(0))
                            {
                                dtrow[1] = dataReader.GetDecimal(0);
                            }
                        }
                        dataReader.Close();

                        dt.Rows.Add(dtrow);
                    }
                }
            }
            return dt;
        }
        public Decimal getFertilizerSummaryBalance(Int32 Year, Int32 Month, String SupplierCode, String RouteCode)
        {
            Decimal Fertilizer = 0;
            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT FertilizerTaken FROM dbo.MonthlyPayments WHERE (Year = '" + Year + "') AND (Month = '" + Month + "') AND (SupplierCode = '" + SupplierCode + "') AND (RouteNo = '" + RouteCode + "')", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    Fertilizer = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();

            Fertilizer = Fertilizer - getFETBFBalanceNew(Year, Month, RouteCode, SupplierCode);
            if (Fertilizer > 0)
                return Fertilizer;
            else
                return 0;
        }
        public Decimal getTeaIssues(Int32 Year, Int32 Month, String SupplierCode, String RouteCode)
        {
            Decimal Fertilizer = 0;
            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT MadeTeaTaken FROM dbo.MonthlyPayments WHERE (Year = '" + Year + "') AND (Month = '" + Month + "') AND (SupplierCode = '" + SupplierCode + "') AND (RouteNo = '" + RouteCode + "')", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    Fertilizer = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();

            return Fertilizer;
        }
        public Decimal getTransport(Int32 Year, Int32 Month, String SupplierCode, String RouteCode)
        {
            Decimal Fertilizer = 0;
            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT TransportDeduction FROM dbo.MonthlyPayments WHERE (Year = '" + Year + "') AND (Month = '" + Month + "') AND (SupplierCode = '" + SupplierCode + "') AND (RouteNo = '" + RouteCode + "')", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    Fertilizer = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();

            return Fertilizer;
        }
        public Decimal getStampDuty(Int32 Year, Int32 Month, String SupplierCode, String RouteCode)
        {
            Decimal Fertilizer = 0;
            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT StampDutyDeduction FROM dbo.MonthlyPayments WHERE (Year = '" + Year + "') AND (Month = '" + Month + "') AND (SupplierCode = '" + SupplierCode + "') AND (RouteNo = '" + RouteCode + "')", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    Fertilizer = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();

            return Fertilizer;
        }

        public Decimal getIncentives(Int32 Year, Int32 Month, String SupplierCode, String RouteCode)
        {
            BLTown myTown = new BLTown();
            myTown.StrTownName = RouteCode;
            String RouteCodeNew = myTown.getTownCodeByName();
            Decimal Fertilizer = 0;
            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT Incentive FROM dbo.MonthlyPayments WHERE (Year = '" + Year + "') AND (Month = '" + Month + "') AND (SupplierCode = '" + SupplierCode + "') AND (RouteNo = '" + RouteCodeNew + "')", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    Fertilizer = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();

            return Fertilizer;
        }

        public Decimal getIncentive(Int32 Year, Int32 Month, String SupplierCode, String RouteCode)
        {
            Decimal Fertilizer = 0;
            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT Incentive FROM dbo.MonthlyPayments WHERE (Year = '" + Year + "') AND (Month = '" + Month + "') AND (SupplierCode = '" + SupplierCode + "') AND (RouteNo = '" + RouteCode + "')", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    Fertilizer = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();

            return Fertilizer;
        }

        //public DataTable getSalarySlipDetailItems(Int32 Year, Int32 Month, String RouteCode, String RouteActualCode)
        //{
        //    Supplier mySupplier = new Supplier();
        //    Route myRoute = new Route();
        //    Town myTown = new Town();

        //    DataTable dt = new DataTable();
        //    dt.Columns.Add(new DataColumn("Item"));
        //    dt.Columns.Add(new DataColumn("Amount"));
        //    dt.Columns.Add(new DataColumn("SupplierCode"));

        //    DataRow dtrow;

        //    myTown.StrTownName = RouteCode;
        //    String RouteCodeNew = myTown.getTownCodeByName();

        //    DataTable dtSupplier = mySupplier.ListActiveSuppliers(RouteCodeNew);
        //    if (dtSupplier.Rows.Count > 0)
        //    {
        //        for (Int32 i = 0; i <= dtSupplier.Rows.Count - 1; i++)
        //        {
        //            dtrow = dt.NewRow();
        //            //dtrow[0] = "Cash Balance";
        //            //dtrow[0] = "Cash Balance";
        //            dtrow[0] = "b f. ys`. uqo,";

        //            Decimal CashBalance = getCashBalance(Year, Month, RouteActualCode, dtSupplier.Rows[i][0].ToString());
        //            dtrow[1] = CashBalance;
        //            dtrow[2] = dtSupplier.Rows[i][0].ToString();
        //            dt.Rows.Add(dtrow);

        //            dtrow = dt.NewRow();
        //            //dtrow[0] = "Fertilizer Balance";

        //            dtrow[0] = "fmdfydr";
        //            Decimal FetBalance = getFETBFBalanceNew(Year, Month, RouteActualCode, dtSupplier.Rows[i][0].ToString());
        //            dtrow[1] = FetBalance;
        //            dtrow[2] = dtSupplier.Rows[i][0].ToString();
        //            dt.Rows.Add(dtrow);

        //            dtrow = dt.NewRow();
        //            //dtrow[0] = "CashAdvanced";
        //            dtrow[0] = "uqo,a w;a;sldrus";

        //            Decimal CashAdvanceBalance = getCasHAdvancedBalance(Year, Month, RouteActualCode, dtSupplier.Rows[i][0].ToString());
        //            dtrow[1] = CashAdvanceBalance;
        //            dtrow[2] = dtSupplier.Rows[i][0].ToString();
        //            dt.Rows.Add(dtrow);

        //            dtrow = dt.NewRow();


        //            //dtrow[0] = "Fertilizer";
        //            dtrow[0] = "b f. fmdfydr";
        //            dtrow[1] = getFertilizerSummaryBalance(Year, Month, dtSupplier.Rows[i][0].ToString(), RouteActualCode);
        //            dtrow[2] = dtSupplier.Rows[i][0].ToString();
        //            dt.Rows.Add(dtrow);

        //            dtrow = dt.NewRow();
        //            //dtrow[0] = "TeaIssues";
        //            dtrow[0] = "f;afld<";
        //            dtrow[1] = getTeaIssues(Year, Month, dtSupplier.Rows[i][0].ToString(), RouteActualCode);
        //            dtrow[2] = dtSupplier.Rows[i][0].ToString();
        //            dt.Rows.Add(dtrow);

        //            dtrow = dt.NewRow();
        //            //dtrow[0] = "Transport";
        //            dtrow[0] = "m%jdyk";
        //            dtrow[1] = getTransport(Year, Month, dtSupplier.Rows[i][0].ToString(), RouteActualCode);
        //            dtrow[2] = dtSupplier.Rows[i][0].ToString();
        //            dt.Rows.Add(dtrow);

        //            dtrow = dt.NewRow();
        //            //dtrow[0] = "Stamp";
        //            dtrow[0] = "uqoaor";
        //            dtrow[1] = getStampDuty(Year, Month, dtSupplier.Rows[i][0].ToString(), RouteActualCode);
        //            dtrow[2] = dtSupplier.Rows[i][0].ToString();
        //            dt.Rows.Add(dtrow);

        //            dtrow = dt.NewRow();
        //            //dtrow[0] = "Stationary";
        //            dtrow[0] = ",sms oQjH $ fjk;a";
        //            dtrow[1] = getPayslipCharg();
        //            dtrow[2] = dtSupplier.Rows[i][0].ToString();
        //            dt.Rows.Add(dtrow);
        //        }
        //    }
        //    dt.Dispose();
        //    return dt;
        //}

        //Edited new function k.g.sachintha udara
        //date  = 2016.10.18
        // salary deduction fuction.
        //start
        public DataTable getSalarySlipDetailItems(Int32 Year, Int32 Month, String RouteCode)
        {
            BLSupplier mySupplier = new BLSupplier();
            BLRoute myRoute = new BLRoute();

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Item"));
            dt.Columns.Add(new DataColumn("Amount"));
            dt.Columns.Add(new DataColumn("SupplierCode"));

            DataRow dtrow;

            DataTable dtSupplier = mySupplier.ListActiveSuppliers(RouteCode);
            if (dtSupplier.Rows.Count > 0)
            {
                for (Int32 i = 0; i <= dtSupplier.Rows.Count - 1; i++)
                {

                    SqlDataReader dataReader = SQLHelper.ExecuteReader("SELECT [Fertilizer],[Transport],[Loan],[CashAdvance],[PaySlip],[StampDuty],[MadeTea],[OtherDeduction],[CFDebtBalance] FROM [dbo].[MonthlyPaymentSummary] WHERE [Year]=" + Year + " AND [Month]=" + Month + " AND [SupplierCode]=" + dtSupplier.Rows[i][0].ToString() + " AND [RouteCode]='" + RouteCode + "' ", CommandType.Text);
                    // Fertilizer = 0 , Transport = 1, Loan = 2, CashAdvance = 3, payslip = 4, Stamp = 5, MadeTea = 6, OtherDeduction = 7, CFDebtBalance=8
                    while (dataReader.Read())
                    {
                        if (!dataReader.IsDBNull(3))
                        {
                            dtrow = dt.NewRow();
                            //dtrow[0] = "Cash Balance";
                            dtrow[0] = "uqo,a w;a;sldrï";
                            dtrow[1] = dataReader.GetDecimal(3);

                            dtrow[2] = dtSupplier.Rows[i][0].ToString();
                            dt.Rows.Add(dtrow);
                        }
                        if (!dataReader.IsDBNull(0))
                        {
                            dtrow = dt.NewRow();
                            //dtrow[0] = "Fertilizer Balance";
                            dtrow[0] = "fmdfydr";

                            dtrow[1] = dataReader.GetDecimal(0);
                            dtrow[2] = dtSupplier.Rows[i][0].ToString();
                            dt.Rows.Add(dtrow);
                        }
                        if (!dataReader.IsDBNull(6))
                        {
                            dtrow = dt.NewRow();
                            //dtrow[0] = "TeaIssues";
                            dtrow[0] = "f;afld<";

                            dtrow[1] = dataReader.GetDecimal(6);
                            dtrow[2] = dtSupplier.Rows[i][0].ToString();
                            dt.Rows.Add(dtrow);
                        }
                        if (!dataReader.IsDBNull(1))
                        {
                            dtrow = dt.NewRow();
                            //dtrow[0] = "Transport";
                            dtrow[0] = "m%jdyk";

                            dtrow[1] = dataReader.GetDecimal(1);
                            dtrow[2] = dtSupplier.Rows[i][0].ToString();
                            dt.Rows.Add(dtrow);
                        }
                        if (!dataReader.IsDBNull(5))
                        {
                            dtrow = dt.NewRow();
                            //dtrow[0] = "Stamp";
                            dtrow[0] = "uqoaor";

                            dtrow[1] = dataReader.GetDecimal(5);
                            dtrow[2] = dtSupplier.Rows[i][0].ToString();
                            dt.Rows.Add(dtrow);
                        }
                        if (!dataReader.IsDBNull(8))
                        {
                            dtrow = dt.NewRow();
                            //dtrow[0] = "LastMonthDebt";
                            dtrow[0] = "Kh";

                            dtrow[1] = dataReader.GetDecimal(8);
                            dtrow[2] = dtSupplier.Rows[i][0].ToString();
                            dt.Rows.Add(dtrow);
                        }
                        if (!dataReader.IsDBNull(4) && !dataReader.IsDBNull(7))
                        {
                            dtrow = dt.NewRow();
                            //dtrow[0] = "Stationary";
                            dtrow[0] = ",sms oQjH $ fjk;a";

                            dtrow[1] = dataReader.GetDecimal(4) + dataReader.GetDecimal(7);
                            dtrow[2] = dtSupplier.Rows[i][0].ToString();
                            dt.Rows.Add(dtrow);
                        }
                    }
                    dataReader.Close();
                }
            }
            dt.Dispose();
            return dt;
        }
        //end

        public Decimal getNextMonthBFCoins(Int32 Year, Int32 Month, String SupplierCode, String RouteCode)
        {
            Decimal Fertilizer = 0;
            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT BFCoins FROM dbo.BFBalances WHERE (RouteNo = '" + RouteCode + "') AND (SupplierCode = '" + SupplierCode + "') AND (Year = '" + Year + "') AND (Month = '" + Month + "')", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    Fertilizer = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();

            return Fertilizer;
        }
        public Decimal getNextMonthFertilizerDue(Int32 Year, Int32 Month, String SupplierCode, String RouteCode)
        {
            Decimal Fertilizer = 0;
            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT FertilizerBalance FROM dbo.BFBalances WHERE (RouteNo = '" + RouteCode + "') AND (SupplierCode = '" + SupplierCode + "') AND (Year = '" + Year + "') AND (Month = '" + Month + "')", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    Fertilizer = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();

            return Fertilizer;
        }
        public DataTable getAdvancePayableReport(Int32 Year, Int32 Month, DateTime ToDate, String RouteCode, String RouteName, String SupplierCode)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("SupplierCode"));
            dt.Columns.Add(new DataColumn("SupplierName"));
            dt.Columns.Add(new DataColumn("Leaf"));
            dt.Columns.Add(new DataColumn("OPBalance"));
            dt.Columns.Add(new DataColumn("Advance"));
            dt.Columns.Add(new DataColumn("Fertilizer"));
            dt.Columns.Add(new DataColumn("Tea"));
            dt.Columns.Add(new DataColumn("AdvanceAmount"));
            dt.Columns.Add(new DataColumn("Balance"));

            DataRow dtrow;
            SqlDataReader dataReader;
            dtrow = dt.NewRow();

            dataReader = SQLHelper.ExecuteReader("SELECT TownCode FROM dbo.Route WHERE (RouteNo = '" + RouteName + "')", CommandType.Text);
            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    RouteCode = dataReader.GetString(0).Trim();
                }
            }
            dataReader.Close();

            dataReader = SQLHelper.ExecuteReader("SELECT dbo.Supplier.SupplierCode, dbo.Supplier.SupplierName FROM dbo.Supplier INNER JOIN dbo.Route ON dbo.Supplier.TownCode = dbo.Route.TownCode WHERE (dbo.Supplier.InactiveSupplier = 0) AND (dbo.Route.RouteNo = '" + RouteName + "') AND (dbo.Supplier.SupplierCode = '" + SupplierCode + "')", CommandType.Text);

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
                dtrow[2] = getLeaf(Year, Month, ToDate.Date, dataReader.GetString(0).Trim(), RouteCode);
                dtrow[3] = getOpeningBalance(Year, Month, RouteCode, dataReader.GetString(0).Trim());

                dtrow[4] = getCurrentMonthAdvances(Year, Month, ToDate, dataReader.GetString(0).Trim(), RouteCode);
                dtrow[5] = getCurrentMonthFertilizer(Year, Month, ToDate, dataReader.GetString(0).Trim(), RouteCode);
                dtrow[6] = getCurrentMonthTeaIssues(Year, Month, ToDate, dataReader.GetString(0).Trim(), RouteCode);
                dtrow[7] = getAdvanceRate() * getLeaf(Year, Month, ToDate.Date, dataReader.GetString(0).Trim(), RouteCode);
                Decimal Balance = getAdvanceRate() * getLeaf(Year, Month, ToDate.Date, dataReader.GetString(0).Trim(), RouteCode) - (getOpeningBalance(Year, Month, RouteCode, dataReader.GetString(0).Trim()) + getCurrentMonthAdvances(Year, Month, ToDate, dataReader.GetString(0).Trim(), RouteCode) + getCurrentMonthFertilizer(Year, Month, ToDate, dataReader.GetString(0).Trim(), RouteCode) + getCurrentMonthTeaIssues(Year, Month, ToDate, dataReader.GetString(0).Trim(), RouteCode));
                dtrow[8] = Balance.ToString("N2");
                dt.Rows.Add(dtrow);
            }
            dataReader.Close();
            return dt;
        }
        public Decimal getLeaf(Int32 Year, Int32 Month, DateTime ToDate, String SupplierCode, String RouteCode)
        {
            Decimal Distance = 0;
            DateTime FromDate = new DateTime(Year, Month, 1);
            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT SUM(dbo.DailyGreenLeaf.NetWeight) AS Expr1 FROM dbo.DailyGreenLeaf INNER JOIN dbo.Route ON dbo.DailyGreenLeaf.RouteNo = dbo.Route.RouteNo WHERE (dbo.Route.TownCode = '" + RouteCode + "') AND (dbo.DailyGreenLeaf.SupplierCode = '" + SupplierCode + "') AND (dbo.DailyGreenLeaf.CollectedDate BETWEEN CONVERT(DATETIME, '" + FromDate + "',102) AND CONVERT(DATETIME, '" + ToDate + "',102))", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    Distance = dataReader.GetDecimal(0);

                }

            }
            dataReader.Close();
            return Distance;
        }


        public Decimal getCurrentMonthAdvances(Int32 Year, Int32 Month, DateTime ToDate, String SupplierCode, String RouteCode)
        {
            Decimal Distance = 0;
            DateTime FromDate = new DateTime(Year, Month, 1);
            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT SUM(dbo.SupplierAdvances.AdvanceAmount) AS Expr1 FROM dbo.SupplierAdvances INNER JOIN dbo.Route ON dbo.SupplierAdvances.RouteNo = dbo.Route.RouteNo WHERE (dbo.Route.TownCode = '" + RouteCode + "') AND (dbo.SupplierAdvances.AdvanceIssueDate BETWEEN CONVERT(DATETIME, '" + FromDate + "',102) AND CONVERT(DATETIME, '" + ToDate + "',102)) AND (dbo.SupplierAdvances.SupplierCode = '" + SupplierCode + "') AND (dbo.SupplierAdvances.CancelEntry = 0)", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    Distance = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();
            return Distance;
        }
        public Decimal getCurrentMonthFertilizer(Int32 Year, Int32 Month, DateTime ToDate, String SupplierCode, String RouteCode)
        {
            Decimal Distance = 0;
            DateTime FromDate = new DateTime(Year, Month, 1);
            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT SUM(dbo.FertilizerIssued.FertilizerIssued) AS Expr1 FROM dbo.FertilizerIssued INNER JOIN dbo.Route ON dbo.FertilizerIssued.RouteNo = dbo.Route.RouteNo WHERE (dbo.FertilizerIssued.IssueDate BETWEEN CONVERT(DATETIME, '" + FromDate + "',102) AND CONVERT(DATETIME, '" + ToDate + "',102)) AND (dbo.FertilizerIssued.SupplierCode = '" + SupplierCode + "') AND (dbo.FertilizerIssued.CancelEntry = 0) AND (dbo.Route.TownCode = '" + RouteCode + "')", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    Distance = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();
            return Distance;
        }
        public Decimal getCurrentMonthTeaIssues(Int32 Year, Int32 Month, DateTime ToDate, String SupplierCode, String RouteCode)
        {
            Decimal Distance = 0;
            DateTime FromDate = new DateTime(Year, Month, 1);
            SqlDataReader dataReader;
            dataReader = SQLHelper.ExecuteReader("SELECT SUM(dbo.MadeTeaIssued.MadeTeaAmount) AS Expr1 FROM dbo.MadeTeaIssued INNER JOIN dbo.Route ON dbo.MadeTeaIssued.RouteNo = dbo.Route.RouteNo WHERE (dbo.MadeTeaIssued.IssueDate BETWEEN CONVERT(DATETIME, '" + FromDate + "',102) AND CONVERT(DATETIME, '" + ToDate + "',102)) AND (dbo.MadeTeaIssued.SupplierCode = '" + SupplierCode + "') AND (dbo.Route.TownCode = '" + RouteCode + "') AND (dbo.MadeTeaIssued.CancelEntry = 0)", CommandType.Text);

            while (dataReader.Read())
            {
                if (!dataReader.IsDBNull(0))
                {
                    Distance = dataReader.GetDecimal(0);
                }
            }
            dataReader.Close();
            return Distance;
        }
        public DataSet getDebitList(Int32 Year, Int32 Month, String RouteCode)
        {
            Int32 PreviousMonth = new DateTime(Year, Month, 1).AddMonths(-1).Month;
            Int32 PreviousYear = new DateTime(Year, Month, 1).AddMonths(-1).Year;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlCommand command = new SqlCommand();
            da.SelectCommand = SQLHelper.CreateCommand("SELECT dbo.BFBalances.SupplierCode, dbo.Supplier.SupplierName, dbo.BFBalances.FertilizerBalance, 0 - dbo.BFBalances.CashBalance AS CashBalance,  dbo.BFBalances.LoanBalance, dbo.Route.RouteNo FROM dbo.BFBalances INNER JOIN dbo.Supplier ON dbo.BFBalances.SupplierCode = dbo.Supplier.SupplierCode AND dbo.BFBalances.RouteNo = dbo.Supplier.TownCode INNER JOIN dbo.Route ON dbo.BFBalances.RouteNo = dbo.Route.TownCode WHERE (dbo.BFBalances.RouteNo LIKE '" + RouteCode + "') AND (dbo.BFBalances.Year = '" + Year + "') AND (dbo.BFBalances.Month = '" + Month + "')", CommandType.Text);
            da.Fill(ds, "DebitList");
            return ds;
        }

        //sachintha udara 2016-11-10 
        //*** make new method call MonthlySupCountRouteWise
        //pamrameters pYear , pMonth
        public DataTable MonthlySupCountRouteWise(int pYear, int pMonth)
        {
            return SQLHelper.FillDataSet("SELECT dbo.DailyGreenLeaf.RouteNo, dbo.Route.RouteName, COUNT(DISTINCT dbo.DailyGreenLeaf.SupplierCode) AS SupCount, SUM(dbo.DailyGreenLeaf.NetWeight) AS GreenLeafSum FROM dbo.DailyGreenLeaf INNER JOIN dbo.Route ON dbo.DailyGreenLeaf.RouteNo = dbo.Route.RouteCode WHERE (YEAR(dbo.DailyGreenLeaf.CollectedDate) = '" + pYear + "') AND (MONTH(dbo.DailyGreenLeaf.CollectedDate) = '" + pMonth + "') GROUP BY dbo.DailyGreenLeaf.RouteNo, dbo.Route.RouteName", CommandType.Text).Tables[0];
        }


        public DataSet GetSupplierPaymentForPaySlipGeneral(int payYear, int payMonth, string routeCode)
        {
            try
            {
                SqlParameter param = new SqlParameter();
                List<SqlParameter> paramList = new List<SqlParameter>();

                param = SQLHelper.CreateParameter("@PayYear", SqlDbType.Int);
                param.Value = payYear;
                paramList.Add(param);
                param = SQLHelper.CreateParameter("@PayMonth", SqlDbType.Int);
                param.Value = payMonth;
                paramList.Add(param);
                param = SQLHelper.CreateParameter("@RouteCode", SqlDbType.VarChar, 50);
                param.Value = routeCode;
                paramList.Add(param);
                DataSet ds;
                ds = SQLHelper.FillDataSet("GetSupplierPaymentForPaySlipGeneral", CommandType.StoredProcedure, paramList);
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet GetSupplierPaymentForPaySlipGreenLeaf(int payYear, int payMonth, string routeCode)
        {
            try
            {
                SqlParameter param = new SqlParameter();
                List<SqlParameter> paramList = new List<SqlParameter>();

                param = SQLHelper.CreateParameter("@PayYear", SqlDbType.Int);
                param.Value = payYear;
                paramList.Add(param);
                param = SQLHelper.CreateParameter("@PayMonth", SqlDbType.Int);
                param.Value = payMonth;
                paramList.Add(param);
                param = SQLHelper.CreateParameter("@RouteCode", SqlDbType.VarChar, 50);
                param.Value = routeCode;
                paramList.Add(param);
                DataSet ds;
                ds = SQLHelper.FillDataSet("GetSupplierPaymentForPaySlipGreenLeaf", CommandType.StoredProcedure, paramList);
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet GetSupplierPaymentForPaySlipThisMonthIssues(int payYear, int payMonth, string routeCode)
        {
            try
            {
                SqlParameter param = new SqlParameter();
                List<SqlParameter> paramList = new List<SqlParameter>();

                param = SQLHelper.CreateParameter("@PayYear", SqlDbType.Int);
                param.Value = payYear;
                paramList.Add(param);
                param = SQLHelper.CreateParameter("@PayMonth", SqlDbType.Int);
                param.Value = payMonth;
                paramList.Add(param);
                param = SQLHelper.CreateParameter("@RouteCode", SqlDbType.VarChar, 50);
                param.Value = routeCode;
                paramList.Add(param);
                DataSet ds;
                ds = SQLHelper.FillDataSet("GetSupplierPaymentForPaySlipThisMonthIssues", CommandType.StoredProcedure, paramList);
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //edited
        public DataSet getCashPaymentAllList(int pYear, int pMonth)
        {
            try
            {
                DataSet ds = new DataSet();
                string str = "SELECT Year,Month,dbo.MonthlyPaymentSummary.RouteCode,Route.RouteName,dbo.MonthlyPaymentSummary.SupplierCode,SupplierName,PaymentDue FROM dbo.MonthlyPaymentSummary INNER JOIN dbo.Supplier ON dbo.MonthlyPaymentSummary.SupplierCode=dbo.Supplier.SupplierCode INNER JOIN Route ON MonthlyPaymentSummary.RouteCode = Route.RouteCode WHERE dbo.MonthlyPaymentSummary.Year = '" + pYear + "' AND dbo.MonthlyPaymentSummary.Month = '" + pMonth + "' AND dbo.MonthlyPaymentSummary.PaymentMode = 'Cash' AND PaymentDue > 0";
                ds = SQLHelper.FillDataSet(str, CommandType.Text);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet getCashPaymentList(int pYear, int pMonth, string pRoute)
        {
            try
            {
                DataSet ds = new DataSet();
                string str = "SELECT Year,Month,dbo.MonthlyPaymentSummary.RouteCode,Route.RouteName,dbo.MonthlyPaymentSummary.SupplierCode,SupplierName,PaymentDue FROM dbo.MonthlyPaymentSummary INNER JOIN dbo.Supplier ON dbo.MonthlyPaymentSummary.SupplierCode=dbo.Supplier.SupplierCode INNER JOIN Route ON MonthlyPaymentSummary.RouteCode = Route.RouteCode WHERE dbo.MonthlyPaymentSummary.Year = '" + pYear + "' AND dbo.MonthlyPaymentSummary.Month = '" + pMonth + "' AND dbo.MonthlyPaymentSummary.RouteCode = '" + pRoute + "' AND dbo.MonthlyPaymentSummary.PaymentMode = 'Cash' AND PaymentDue > 0";
                ds = SQLHelper.FillDataSet(str, CommandType.Text);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Coin Analysis Report 

        DataTable data = new DataTable();

        public string Note;

        string[] values = { "5000", "2000", "1000", "500", "100", "50", "20", "10", "5", "2", "1", "0.50", "0.25", "0.10", "0.05" };
        string[] valuess = { "5000", "1000", "500", "100", "50", "20", "10", "5", "2", "1", "0.50", "0.25", "0.10", "0.05" };
        private double amount;

        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public DataTable getCashAmount(int pYear, int pMonth, string pRoute, int ChkNotes)
        {
            data.Clear();
            createTable(ChkNotes);

            string q = "SELECT SupplierCode,RouteCode,PaymentDue FROM dbo.MonthlyPaymentSummary WHERE Year = '" + pYear + "' AND Month ='" + pMonth + "' AND RouteCode='" + pRoute + "' AND PaymentMode = 'Cash' AND PaymentDue > 0";
            DataTable dt = SQLHelper.FillDataSet(q, CommandType.Text).Tables[0];



            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Amount = String.IsNullOrEmpty(dt.Rows[i]["PaymentDue"].ToString()) ? 0 : Convert.ToDouble(dt.Rows[i]["PaymentDue"].ToString());

                if (Amount != 0)
                {
                    cashamt(ChkNotes);
                }
            }
            return data;
        }

        public DataTable getCashAmountAll(int pYear, int pMonth ,int ChkNotes)
        {
            data.Clear();
            createTable(ChkNotes);
           
            string q = "SELECT SupplierCode,RouteCode,PaymentDue FROM dbo.MonthlyPaymentSummary WHERE Year = '" + pYear + "' AND Month ='" + pMonth + "' AND PaymentMode = 'Cash' AND PaymentDue > 0";
            DataTable dt = SQLHelper.FillDataSet(q, CommandType.Text).Tables[0];

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Amount = String.IsNullOrEmpty(dt.Rows[i]["PaymentDue"].ToString()) ? 0 : Convert.ToDouble(dt.Rows[i]["PaymentDue"].ToString());

                if (Amount != 0)
                {
                    cashamt(ChkNotes);
                }
            }
            return data;
        }

        private void findCoins(double value, int index)
        {

            int count = 0;

            count = (int)(Amount / value);
            Amount = Amount - (count * value);
            int preCount = string.IsNullOrEmpty(data.Rows[index]["count"].ToString()) ? 0 : Convert.ToInt32(data.Rows[index]["count"].ToString());
            data.Rows[index]["count"] = preCount + count;
        }

        public void cashamt(int ChkNotes)
        {
            if (ChkNotes == 1)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    findCoins(Convert.ToDouble(values[i]), i);
                }
            }
            else
            {
                for (int i = 0; i < valuess.Length; i++)
                {
                    findCoins(Convert.ToDouble(valuess[i]), i);
                }
            }
        }
                

        public void createTable(int ChkNotes)
        {
            if (ChkNotes == 1)
            {
                DataRow row;
                if (!data.Columns.Contains("value") || !data.Columns.Contains("count"))
                {
                    data.Columns.Add("value", typeof(string));
                    data.Columns.Add("count", typeof(string));
                }

                for (int i = 0; i < values.Length; i++)
                {
                    row = data.NewRow();
                    data.Rows.Add(row);
                    data.Rows[i]["value"] = values[i];
                }
            }
            else 
            {
                DataRow row;
                if (!data.Columns.Contains("value") || !data.Columns.Contains("count"))
                {
                    data.Columns.Add("value", typeof(string));
                    data.Columns.Add("count", typeof(string));
                }

                for (int i = 0; i < valuess.Length; i++)
                {
                    row = data.NewRow();
                    data.Rows.Add(row);
                    data.Rows[i]["value"] = valuess[i];
                }
            }
        }


        //Supplier Daily Green Leaf Supplied Report

        public DataTable getSelectSupplierDetails(string newSup, string FromDate, string ToDate)
        {
            DataTable data = new DataTable();
            data.Columns.Add("Date", typeof(string));
            string q = "SELECT CollectedDate, SUM (NetWeight) AS NetWeight,LeafType FROM DailyGreenLeaf WHERE SupplierCode ='" + newSup + "' AND CollectedDate >= '" + FromDate + "' AND CollectedDate <= '" + ToDate + "' GROUP BY CollectedDate ,LeafType ";
            DataTable dt = SQLHelper.FillDataSet(q, CommandType.Text).Tables[0];
            return dt;
        }

        //Supplier Green Leaf Summary Report

        public DataTable getSupplierSummaryDetails(string newSup, string FromDate, string ToDate)
        {
            //DataTable data = new DataTable();
            //data.Columns.Add("Date", typeof(string));
            //string q = "SELECT CollectedDate, SupplierCode,  WaterDeduction, CoarseLeafDeduction, OtherDeduction, ContainerDeduction, GrossWeight, NetWeight,LeafType FROM   DailyGreenLeaf WHERE  SupplierCode = '" + txtSupCode + "' AND CollectedDate >= '" + FromDate + "' AND CollectedDate <= '" + ToDate + "'";
            string q = "SELECT YEAR(CollectedDate) as Lyear,MONTH(CollectedDate) as Lmonth,LeafType,SUM(WaterDeduction) as Water,SUM(ContainerDeduction) as Container,SUM(CoarseLeafDeduction) as CourseLeaf,SUM(OtherDeduction) as Other,SUM(GrossWeight) AS gross,SUM(NetWeight) AS net FROM DailyGreenLeaf WHERE SupplierCode = '" + newSup + "' AND CollectedDate >= '" + FromDate + "' AND CollectedDate <= '" + ToDate + "' GROUP BY YEAR(CollectedDate), MONTH(CollectedDate),LeafType ORDER BY YEAR(CollectedDate), MONTH(CollectedDate)";
            DataTable dt = SQLHelper.FillDataSet(q, CommandType.Text).Tables[0];
            return dt;
        }

        //public DataTable getSupplierPaymentSummary(string FromDate, string ToDate) 
        //{
        //}

        public DataSet GetDeductionDetailReport(int intYear, int intMonth, String strRoute, String strSupp,String strDeductGroup,String strDeduct)
        {
            DataSet dsDeductDetails = new DataSet();
            dsDeductDetails = SQLHelper.FillDataSet("SELECT dbo.SupplierMonthDeductions.DeductYear, dbo.SupplierMonthDeductions.DeductMonth, dbo.SupplierMonthDeductions.Route,  dbo.SupplierMonthDeductions.SupplierCode, dbo.Supplier.SupplierName, dbo.SupplierMonthDeductions.DeductGroup, dbo.DeductionGroup.GroupName,  dbo.SupplierMonthDeductions.DeductCode, dbo.DeductionCode.DeductionName, dbo.SupplierMonthDeductions.Amount FROM dbo.DeductionCode INNER JOIN dbo.Supplier INNER JOIN dbo.SupplierMonthDeductions ON dbo.Supplier.SupplierCode = dbo.SupplierMonthDeductions.SupplierCode AND  dbo.Supplier.RouteCode = dbo.SupplierMonthDeductions.Route INNER JOIN dbo.DeductionGroup ON dbo.SupplierMonthDeductions.DeductGroup = dbo.DeductionGroup.DeductionGroupCode ON  dbo.DeductionCode.DeductionCode = dbo.SupplierMonthDeductions.DeductCode WHERE (dbo.SupplierMonthDeductions.DeductYear = '"+intYear+"') AND (dbo.SupplierMonthDeductions.DeductMonth = '"+intMonth+"') AND (dbo.SupplierMonthDeductions.Route like  '"+strRoute+"') AND (dbo.SupplierMonthDeductions.SupplierCode like '"+strSupp+"') AND (dbo.SupplierMonthDeductions.DeductGroup LIKE '"+strDeductGroup+"') AND  (dbo.SupplierMonthDeductions.DeductCode LIKE '"+strDeduct+"')", CommandType.Text);
            return dsDeductDetails;
        }

     
        public  DataSet getmastersetingforpayslip()
        {
            DataSet ds = new DataSet();
            ds = SQLHelper.FillDataSet("SELECT Name,Type  FROM [dbo].[BLMasterSettings] where Type = 'PrePrintedPaySlip'", CommandType.Text);
            //return SQLHelper.FillDataSet("SELECT f.[RegNo],f.[FactoryName],f.[Extent],ps.[SupplierCode],s.[SupplierName],ps.[Year],ps.[Month],ps.[TownCode] ,ps.[GreenLeafKillo],ps.[GreenLeafRate],ps.[GreenLeafValue],ps.[Incentive],ps.[OtherAddition],ps.[TotalEarning],ps.[TotalDeduction],ps.[PaymentDue],ps.[NetPay] FROM [dbo].[MonthlyPaymentSummary] ps, [dbo].[Supplier] s CROSS JOIN [dbo].[Factory] f WHERE S.SupplierCode = ps.SupplierCode AND ps.Year = " + year + " AND ps.Month = " + month + " AND ps.TownCode = '" + routeCode + "' ORDER BY CONVERT(int, ps.[SupplierCode])", CommandType.Text).Tables[0];
           
           return ds;
        }
    }
}
