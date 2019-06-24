IF COL_LENGTH('BLMasterSupplierIncentives','RegularIncentive') is null
BEGIN
Alter table dbo.BLMasterSupplierIncentives
add RegularIncentive decimal(18,2) not null default (0)
END


IF COL_LENGTH('MonthlyPaymentSummary','RegularIncentive') is null
begin
Alter table dbo.MonthlyPaymentSummary
ADD RegularIncentive decimal(18,2) not null default(0)
end