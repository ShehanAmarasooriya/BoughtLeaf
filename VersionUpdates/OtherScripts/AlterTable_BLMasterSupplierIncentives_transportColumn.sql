ALTER TABLE BLMasterSupplierIncentives
ALTER COLUMN transportIncentive DECIMAL(18,2)  NOT NULL  

ALTER TABLE BLMasterSupplierIncentives ADD CONSTRAINT DF_transportIncentive DEFAULT (0) FOR transportIncentive