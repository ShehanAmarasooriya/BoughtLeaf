using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using BoughtLeafDataAccess;
using System.Data;

namespace BoughtLeafBusinessLayer
{
    public class BLRegisters
    {
        public DataSet getMonthlyDeductionSummaryDeductionCodewise(string Route,int pYear, int pMonth, string pSupCode, string DeductCode,String DeductGroup)
        {
            //return SQLHelper.FillDataSet("SELECT dbo.SupplierDeductionsSettlement.Suppliyer, dbo.Supplier.SupplierName, dbo.SupplierDeductionsSettlement.DeductionGroupCode, dbo.DeductionGroup.GroupName, SUM(dbo.SupplierDeductionsSettlement.Amount) AS Amount FROM dbo.DeductionGroup INNER JOIN dbo.SupplierDeductionsSettlement ON dbo.DeductionGroup.DeductionGroupCode = dbo.SupplierDeductionsSettlement.DeductionGroupCode INNER JOIN dbo.Supplier ON dbo.SupplierDeductionsSettlement.Suppliyer = dbo.Supplier.SupplierCode WHERE (dbo.SupplierDeductionsSettlement.Suppliyer LIKE '" + pSupCode + "') AND (dbo.SupplierDeductionsSettlement.DeductYear = '" + pYear + "') AND (dbo.SupplierDeductionsSettlement.DeductMonth = '" + pMonth + "') GROUP BY dbo.Supplier.SupplierName, dbo.SupplierDeductionsSettlement.Suppliyer, dbo.SupplierDeductionsSettlement.DeductionGroupCode, dbo.DeductionGroup.GroupName", CommandType.Text);
            return SQLHelper.FillDataSet("SELECT dbo.SupplierDeductions.RouteNo, dbo.Route.RouteName, dbo.SupplierDeductions.StartYear, dbo.SupplierDeductions.StartMonth,  dbo.SupplierDeductions.SupplierCode, dbo.Supplier.SupplierName, dbo.SupplierDeductions.DeductionGroupCode, dbo.DeductionGroup.GroupName,  dbo.SupplierDeductions.DeductCode, dbo.DeductionCode.DeductionName, dbo.SupplierDeductions.StartDate, dbo.SupplierDeductions.DeductAmount,  dbo.SupplierDeductions.NoBags, dbo.SupplierDeductions.CostPerBag, dbo.SupplierDeductions.CostPerBagCommission, dbo.SupplierDeductions.NoOfMonths,dbo.SupplierDeductions.FixedDeductionId, dbo.SupplierDeductions.BalanceAmount FROM            dbo.SupplierDeductions INNER JOIN dbo.Supplier ON dbo.SupplierDeductions.SupplierCode = dbo.Supplier.SupplierCode AND dbo.SupplierDeductions.RouteNo = dbo.Supplier.RouteCode INNER JOIN dbo.Route ON dbo.Supplier.RouteCode = dbo.Route.RouteCode INNER JOIN dbo.DeductionGroup ON dbo.SupplierDeductions.DeductionGroupCode = dbo.DeductionGroup.DeductionGroupCode INNER JOIN dbo.DeductionCode ON dbo.SupplierDeductions.DeductCode = dbo.DeductionCode.DeductionCode AND  dbo.SupplierDeductions.DeductionGroupCode = dbo.DeductionCode.DeductionGroupCode WHERE        (dbo.SupplierDeductions.StartYear = '" + pYear + "') AND (dbo.SupplierDeductions.StartMonth = '" + pMonth + "') AND (dbo.SupplierDeductions.SupplierCode LIKE '" + pSupCode + "') AND  (dbo.SupplierDeductions.DeductionGroupCode LIKE '" + DeductGroup + "') AND (dbo.SupplierDeductions.DeductCode LIKE '" + DeductCode + "') AND  (dbo.SupplierDeductions.RouteNo LIKE '" + Route + "')", CommandType.Text);
        }

        public DataSet getMonthlyDeductionRegisterWithLeafTodate(string Route, int pYear, int pMonth, string pSupCode, string DeductCode, string DeductGroup)
        {
            DateTime dtStart = new DateTime(pYear, pMonth, 1);
            DateTime dtEnd = dtStart.AddMonths(1).AddDays(-1);
            //return SQLHelper.FillDataSet("SELECT dbo.SupplierDeductionsSettlement.Suppliyer, dbo.Supplier.SupplierName, dbo.SupplierDeductionsSettlement.DeductionGroupCode, dbo.DeductionGroup.GroupName, SUM(dbo.SupplierDeductionsSettlement.Amount) AS Amount FROM dbo.DeductionGroup INNER JOIN dbo.SupplierDeductionsSettlement ON dbo.DeductionGroup.DeductionGroupCode = dbo.SupplierDeductionsSettlement.DeductionGroupCode INNER JOIN dbo.Supplier ON dbo.SupplierDeductionsSettlement.Suppliyer = dbo.Supplier.SupplierCode WHERE (dbo.SupplierDeductionsSettlement.Suppliyer LIKE '" + pSupCode + "') AND (dbo.SupplierDeductionsSettlement.DeductYear = '" + pYear + "') AND (dbo.SupplierDeductionsSettlement.DeductMonth = '" + pMonth + "') GROUP BY dbo.Supplier.SupplierName, dbo.SupplierDeductionsSettlement.Suppliyer, dbo.SupplierDeductionsSettlement.DeductionGroupCode, dbo.DeductionGroup.GroupName", CommandType.Text);
            return SQLHelper.FillDataSet("SELECT dbo.SupplierDeductions.RouteNo, dbo.Route.RouteName, dbo.SupplierDeductions.StartYear, dbo.SupplierDeductions.StartMonth,   dbo.SupplierDeductions.SupplierCode, dbo.Supplier.SupplierName, dbo.SupplierDeductions.DeductionGroupCode, dbo.DeductionGroup.GroupName,   dbo.SupplierDeductions.DeductCode, dbo.DeductionCode.DeductionName, dbo.SupplierDeductions.StartDate, dbo.SupplierDeductions.DeductAmount,  dbo.SupplierDeductions.NoBags, dbo.SupplierDeductions.CostPerBag, dbo.SupplierDeductions.CostPerBagCommission, dbo.SupplierDeductions.NoOfMonths, dbo.SupplierDeductions.FixedDeductionId, dbo.SupplierDeductions.BalanceAmount,  (SELECT        SUM(NetWeight) AS Expr1 FROM            dbo.DailyGreenLeaf WHERE        (CollectedDate BETWEEN CONVERT(DATETIME, '"+dtStart+"', 102) AND CONVERT(DATETIME, '"+dtEnd+"', 102)) AND (SupplierCode = dbo.SupplierDeductions.SupplierCode) AND (RouteNo = dbo.SupplierDeductions.RouteNo)) as TodateGL FROM            dbo.SupplierDeductions INNER JOIN dbo.Supplier ON dbo.SupplierDeductions.SupplierCode = dbo.Supplier.SupplierCode  AND dbo.SupplierDeductions.RouteNo = dbo.Supplier.RouteCode INNER JOIN dbo.Route ON dbo.Supplier.RouteCode = dbo.Route.RouteCode  INNER JOIN dbo.DeductionGroup ON dbo.SupplierDeductions.DeductionGroupCode = dbo.DeductionGroup.DeductionGroupCode INNER JOIN dbo.DeductionCode ON  dbo.SupplierDeductions.DeductCode = dbo.DeductionCode.DeductionCode AND  dbo.SupplierDeductions.DeductionGroupCode = dbo.DeductionCode.DeductionGroupCode  WHERE        (dbo.SupplierDeductions.StartYear = '" + pYear + "') AND (dbo.SupplierDeductions.StartMonth = '" + pMonth + "')  AND (dbo.SupplierDeductions.SupplierCode LIKE '" + pSupCode + "') AND  (dbo.SupplierDeductions.DeductionGroupCode LIKE '"+DeductGroup+"')  AND (dbo.SupplierDeductions.DeductCode LIKE '" + DeductCode + "') AND  (dbo.SupplierDeductions.RouteNo LIKE '" + Route + "')", CommandType.Text);
        }
    }
}