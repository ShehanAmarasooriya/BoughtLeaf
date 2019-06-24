

UPDATE            dbo.BLMasterRates
SET AccountNeeded=	1
WHERE        (Type IN ('LeafQuality', 'TransportType'))


UPDATE            BLMasterSettings
SET AccountNeeded=1
WHERE        (Type = 'TransportType')