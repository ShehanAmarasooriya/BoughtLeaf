IF COL_LENGTH('BLMasterRates','AccountNeeded') IS NULL
BEGIN
Alter table BLMasterRates
Add AccountNeeded bit not null default(0)
end

IF COL_LENGTH('BLMasterRates','AccountCode') IS NULL
BEGIN
Alter table BLMasterRates
Add AccountCode varchar(50) not null default('NA')
end

IF COL_LENGTH('BLMasterSettings','AccountNeeded') IS NULL
BEGIN
Alter table BLMasterSettings
Add AccountNeeded bit not null default(0)
end

IF COL_LENGTH('BLMasterSettings','AccountCode') IS NULL
BEGIN
Alter table BLMasterSettings
Add AccountCode varchar(50) not null default('NA')
end