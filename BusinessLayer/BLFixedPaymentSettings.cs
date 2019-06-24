using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BoughtLeafDataAccess;

namespace BoughtLeafBusinessLayer
{
    public class BLFixedPaymentSettings
    {
        private Decimal decAdvancePaymentRate;

        public Decimal DecAdvancePaymentRate
        {
            get { return decAdvancePaymentRate; }
            set { decAdvancePaymentRate = value; }
        }
        private Decimal decPaySlipCharge;

        public Decimal DecPaySlipCharge
        {
            get { return decPaySlipCharge; }
            set { decPaySlipCharge = value; }
        }
        private decimal stampDutyLevel;

        public decimal StampDutyLevel
        {
            get { return stampDutyLevel; }
            set { stampDutyLevel = value; }
        }
        private decimal stampDutyAmount;

        public decimal StampDutyAmount
        {
            get { return stampDutyAmount; }
            set { stampDutyAmount = value; }
        }
        private decimal nbt;

        public decimal Nbt
        {
            get { return nbt; }
            set { nbt = value; }
        }

        public void UpdateSettings()
        {
            SQLHelper.ExecuteNonQuery("UPDATE FixedPaymentSettings set AdvancePaymentRate = '" + decAdvancePaymentRate + "',PaySlipCharge = '" + DecPaySlipCharge + "', StampDutyLevel = '" + stampDutyLevel + "',StampDutyAmount = '" + stampDutyAmount + "',NBTRate = '" + nbt + "', CreateDateTime = '" + DateTime.Now.Date + "'", CommandType.Text);
        }

        public DataTable GetStampDuty() 
        {
            return SQLHelper.FillDataSet("SELECT StampDutyLevel, StampDutyAmount from FixedPaymentSettings", CommandType.Text).Tables[0];
        }

        public DataTable ListSettings()
        {
            return SQLHelper.FillDataSet("SELECT [AdvancePaymentRate],[PaySlipCharge],[AdvancePercentage],[UnionCharge],[BoughtLeafAccount],[SupplierAccount],[StationaryCharge],[StampDutyLevel],[StampDutyAmount],[NBTRate] FROM [dbo].[FixedPaymentSettings]", CommandType.Text).Tables[0];
        }
    }
}
