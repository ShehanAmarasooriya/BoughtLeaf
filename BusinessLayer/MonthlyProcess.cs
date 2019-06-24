using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BoughtLeafDataAccess;

namespace BoughtLeafBusinessLayer
{
    public class MonthlyProcess
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
        private String strSupplierCode;

        public String StrSupplierCode
        {
            get { return strSupplierCode; }
            set { strSupplierCode = value; }
        }
        private Decimal decTotalGreenLeaf;

        public Decimal DecTotalGreenLeaf
        {
            get { return decTotalGreenLeaf; }
            set { decTotalGreenLeaf = value; }
        }
        private Decimal decTotalAmount;

        public Decimal DecTotalAmount
        {
            get { return decTotalAmount; }
            set { decTotalAmount = value; }
        }
        private Decimal decAdvanceTaken;

        public Decimal DecAdvanceTaken
        {
            get { return decAdvanceTaken; }
            set { decAdvanceTaken = value; }
        }
        private Decimal decFertilizerTaken;

        public Decimal DecFertilizerTaken
        {
            get { return decFertilizerTaken; }
            set { decFertilizerTaken = value; }
        }
        private Decimal decMadeTeaTaken;

        public Decimal DecMadeTeaTaken
        {
            get { return decMadeTeaTaken; }
            set { decMadeTeaTaken = value; }
        }
        private Decimal decOtherCharges;

        public Decimal DecOtherCharges
        {
            get { return decOtherCharges; }
            set { decOtherCharges = value; }
        }
        private Decimal decStampDutyDeduction;

        public Decimal DecStampDutyDeduction
        {
            get { return decStampDutyDeduction; }
            set { decStampDutyDeduction = value; }
        }
        private Decimal decPaySilpCharge;

        public Decimal DecPaySilpCharge
        {
            get { return decPaySilpCharge; }
            set { decPaySilpCharge = value; }
        }

        private Decimal decTransportDeduction;

        public Decimal DecTransportDeduction
        {
            get { return decTransportDeduction; }
            set { decTransportDeduction = value; }
        }
        private Decimal decUnionCharge;

        public Decimal DecUnionCharge
        {
            get { return decUnionCharge; }
            set { decUnionCharge = value; }
        }
        private Decimal decOtherAddition;

        public Decimal DecOtherAddition
        {
            get { return decOtherAddition; }
            set { decOtherAddition = value; }
        }
        private Decimal decStationaryAmount;

        public Decimal DecStationaryAmount
        {
            get { return decStationaryAmount; }
            set { decStationaryAmount = value; }
        }

        private Decimal IncentivesAndSlabs;

        public Decimal IncentivesAndSlabs1
        {
            get { return IncentivesAndSlabs; }
            set { IncentivesAndSlabs = value; }
        }

        private Decimal decOtherDeductions;

        public Decimal DecOtherDeductions
        {
            get { return decOtherDeductions; }
            set { decOtherDeductions = value; }
        }

        
        public void UpdateMonthProcess(Int32 month)
        {
            SQLHelper.ExecuteNonQuery("UPDATE Month SET Process= 1 WHERE MonthCode='"+ month +"'", CommandType.Text);
        }

        public void UpdateMonthProcessToNewYear()
        {
            SQLHelper.ExecuteNonQuery("UPDATE Month SET Process= 0", CommandType.Text);
        }
    }
}
