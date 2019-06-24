


ALTER PROCEDURE [dbo].[spCalculateBLPayment]
(
 @FromDate DATETIME,@ToDate DATETIME,@Route VARCHAR(50),@SupplierCode varchar(50), @userId VARCHAR(50),
 @state VARCHAR(50) OUTPUT
)
AS
BEGIN

/*V0.06 */
/*CALCULATE BOUGHT LEAF PAYMENT*/

DECLARE @TOTGL Decimal(18,2),@GLDays int
DECLARE @BLRATE DECIMAL(18,2)
DECLARE @PROMonth int, @PROYear int
DECLARE @GLPAY DECIMAL(18,2)
DECLARE @OtherPayment Decimal(18,2)
DECLARE @IncentiveElevationAmount Decimal(18,2),@IncentiveElevationPerKiloRate Decimal(18,2)
DECLARE @IncentiveTransportAmount Decimal(18,2),@IncentiveTransportPerKiloRate Decimal(18,2)
DECLARE @IncentiveGoodLeafAmount Decimal(18,2),@IncentiveGoodLeafPerKiloRate Decimal(18,2),@GoodLeaf Decimal(18,2)
DECLARE @IncentiveSlabRate Decimal(18,2),@IncentiveSlabAmount Decimal(18,2)
DECLARE @IncentiveTotal Decimal(18,2)
DECLARE @PreMonthDate DATETIME
DECLARE @EarningsBalance decimal(18,2)
DECLARE @LeafQualityRate decimal(18,2),@LeafQualityQty decimal(18,2),@LeafQualityAmount decimal(18,2)
DECLARE @TransportIncentiveEntitlement varchar(50)
DECLARE @CurLefTypes CURSOR,@CurSlabs CURSOR
DECLARE @MINChequeAmt decimal(18,2),@PaymentMode varchar(50)
DECLARE @FertilizerThisMonth DECIMAL(18,2),  @LastMonthFerti DECIMAL(18,2)

declare @IncentiveTransportAmountTransport decimal(18,2)
	declare @IncentiveTransportAmountSelf decimal(18,2)
	declare @IncentiveTransportAmountOther decimal(18,2)

set @GLDays=0
set @MINChequeAmt=0
SET @state='ERROR'
SET @FertilizerThisMonth=0
SET @LastMonthFerti=0

--


SET @PROYear=YEAR(@FROMDate)
set @PROMonth=MONTH(@FROMDate)
SET @IncentiveTotal=0
set @EarningsBalance=0
--SET @PreMonthDate=DATEADD(DD,-1,CONVERT(DATETIME,(CONVERT(VARCHAR(50),2017)+'-'+convert(varchar(50),7)+'-1'),102))
SET @PreMonthDate=DATEADD(DD,-1,@FromDate)


		SET @BLRATE=(SELECT KiloRate FROM dbo.MonthlySettings WHERE (MonthCode = @PROMonth) AND (YearCode = @PROYear))
	PRINT 'BL RATE'
	PRINT @BLRATE
		SET @TOTGL= (SELECT ISNULL(SUM(NetWeight),0) AS GreenLeafCollected FROM dbo.DailyGreenLeaf WHERE (CollectedDate BETWEEN  @FromDate AND @ToDate) AND (SupplierCode = @SupplierCode) AND  (Processed = 0))
		SET @GLDays= (SELECT ISNULL(count(CollectedDate),0) AS GLProvidedDays FROM dbo.DailyGreenLeaf WHERE (CollectedDate BETWEEN  @FromDate AND @ToDate) AND (SupplierCode = @SupplierCode) AND  (Processed = 0) AND (NetWeight>0) )
	PRINT 'TOT GL'
	PRINT @TOTGL
		SET @GLPAY=@TOTGL*@BLRATE
	PRINT 'GL PAY'
	PRINT @GLPAY

	--Other Payments
		IF EXISTS (SELECT ISNULL(sum( Amount),0) FROM dbo.OtherAdditions WHERE      (SupplierCode = @SupplierCode) AND (YearCode = @PROYear) AND (MonthCode = @PROMonth))
		BEGIN
			SET @OtherPayment= ISNULL((SELECT sum( Amount) FROM dbo.OtherAdditions WHERE      (SupplierCode = @SupplierCode) AND (YearCode = @PROYear) AND (MonthCode = @PROMonth) ),0)
		END
		ELSE
		BEGIN
			SET @OtherPayment=0
		END
	PRINT 'OTHER PAYMENT'
	PRINT @OtherPayment

/* Elivation Incentive Payment*/
		IF EXISTS (SELECT Incentive  FROM dbo.BLMasterSupplierIncentives WHERE (SupplierCode = @SupplierCode) AND (RouteNo = @Route) )
		BEGIN
			SET @IncentiveElevationPerKiloRate=(SELECT Incentive  FROM dbo.BLMasterSupplierIncentives WHERE  (SupplierCode = @SupplierCode) AND (RouteNo = @Route) )
			SET @IncentiveElevationAmount=@IncentiveElevationPerKiloRate*@TOTGL
		END
		ELSE 
		BEGIN
			SET @IncentiveElevationPerKiloRate=0
			SET @IncentiveElevationAmount=0
		END
	PRINT 'Elivation Incentive Rate'
	PRINT @IncentiveElevationPerKiloRate
	PRINT 'Elivation Incentive Amount'
	PRINT @IncentiveElevationAmount
/*END  Elivation Incentive Payment*/

	--SET @IncentiveGoodLeafPerKiloRate=1
	SET @GoodLeaf=0
	SET @IncentiveGoodLeafAmount=0

	/*Leaf Type Cursor*/
		DECLARE @LeafRate decimal(18,2)
		DECLARE @LeafType Varchar(50)
		DECLARE @LeafName Varchar(50)
	
		SET @GoodLeaf=0
		SET @IncentiveGoodLeafAmount=0 
	
			SET @CurLefTypes=CURSOR FOR 
			SELECT  Amount, Type, Name FROM dbo.BLMasterRates WHERE (Type = 'LeafQuality')
			OPEN @CurLefTypes
			FETCH NEXT
			FROM @CurLefTypes INTO @LeafRate,@LeafType,@LeafName
			WHILE @@FETCH_STATUS =0
			BEGIN
	
			IF EXISTS(SELECT ISNULL(SUM(NetWeight),0) AS Expr1 FROM dbo.DailyGreenLeaf WHERE   (SupplierCode = @SupplierCode) AND (RouteNo = @Route) AND (LeafType = @LeafName) AND (CollectedDate BETWEEN CONVERT(DATETIME, @FromDate, 102) AND CONVERT(DATETIME, @ToDate, 102)) )	
			BEGIN

	
				SET @LeafQualityRate=(SELECT TOP (1) Amount FROM dbo.BLMasterRates WHERE (Type = @LeafType) AND (Name = @LeafName))	
				IF(@LeafQualityRate>0)
				BEGIN
						SET @LeafQualityQty=(SELECT ISNULL(SUM(NetWeight),0) AS Expr1 FROM dbo.DailyGreenLeaf WHERE   (SupplierCode = @SupplierCode) AND (RouteNo = @Route) AND (LeafType = @LeafName) AND (CollectedDate BETWEEN CONVERT(DATETIME, @FromDate, 102) AND CONVERT(DATETIME, @ToDate, 102)) )
						SET @GoodLeaf=@GoodLeaf+@LeafQualityQty
						SET @LeafQualityAmount=	@LeafQualityRate*@LeafQualityQty
						SET @IncentiveGoodLeafAmount=@IncentiveGoodLeafAmount+@LeafQualityAmount
				
		
						PRINT 'Leaf Incentive  -Rate - GL- Incentive'
						PRINT @LeafQualityRate
						PRINT @LeafQualityQty
						PRINT @LeafQualityAmount	
				
						IF NOT EXISTS (SELECT * FROM [dbo].[BLMonthIncentivesDetails] WHERE ([LeafYear] =@PROYear) AND ([LeafMonth]=@PROMonth) AND  ([Route] =@Route) AND  ([SuppliyerCode] =@SupplierCode) AND ([IncentiveType]='LeafQuality') AND	([Type2]=@LeafType))
						BEGIN
							INSERT INTO [dbo].[BLMonthIncentivesDetails]
										([LeafYear] ,[LeafMonth] ,[Route] ,[SuppliyerCode] ,[IncentiveType] ,[Type2] ,[LeafRate] ,[LeafQuantity] ,[Amount] ,[CreateDateTime] ,[UserID])
							VALUES
										(@PROYear,@PROMonth ,@Route ,@SupplierCode  ,'LeafQuality' , @LeafType ,@LeafRate ,@LeafQualityQty ,@LeafQualityAmount ,GETDATE() ,@userId)
						END
				END
				ELSE
				BEGIN
				SET @LeafQualityQty=0
						SET @GoodLeaf=@GoodLeaf+@LeafQualityQty
						SET @LeafQualityAmount=	@LeafQualityRate*@LeafQualityQty
						SET @IncentiveGoodLeafAmount=@IncentiveGoodLeafAmount+@LeafQualityAmount
				END

				--INSERT INTO [dbo].[BLLeafTypeIncentives]
				--	   ([LeafYear] ,[LeafMonth] ,[Route] ,[SuppliyerCode] ,[LeafType] ,[LeafRate] ,[LeafQuantity] ,[Amount] ,[CreateDateTime] ,[UserID])
				-- VALUES
				--	   (@PROYear,@PROMonth ,@Route ,@SupplierCode ,@LeafType ,@LeafRate ,@LeafQualityQty ,@LeafQualityAmount ,GETDATE() ,@userId)

			END
	

			FETCH NEXT
			FROM @CurLefTypes INTO  @LeafRate,@LeafType,@LeafName
			END
			CLOSE @CurLefTypes	
	/*END Leaf Type Cursor*/

	/*Slab Incentive*/	
	DECLARE @SuppliyerSlabCode varchar(50)
	SET @SuppliyerSlabCode=NULL
	SET @IncentiveSlabAmount=0
	IF EXISTS (SELECT SlabIncentiveCode FROM dbo.Supplier WHERE (RouteCode = @Route) AND (SupplierCode =@SupplierCode) AND (SlabIncentiveCode IS NOT NULL) and (SlabIncentiveCode<>'NA'))
	BEGIN
		SET @SuppliyerSlabCode=(SELECT SlabIncentiveCode FROM dbo.Supplier WHERE (RouteCode = @Route) AND (SupplierCode = @SupplierCode) AND (SlabIncentiveCode IS NOT NULL))
			
		DECLARE @SlabCode VARCHAR(50),@SlabFrom INT ,@SlabTo INT ,@SlabIncentiveRate DECIMAL(18,2)
		DECLARE @Slabqty decimal(18,2),@ThisSlabAmount decimal(18,2),@QtyForSlab decimal(18,2)
		
				
		set @Slabqty=@TOTGL
			SET @CurSlabs=CURSOR FOR 
				SELECT SlabInsentiveDetails.Code, SlabInsentiveDetails.[From], SlabInsentiveDetails.[To], SlabInsentiveDetails.Insentive 
				FROM SlabInsentiveDetails INNER JOIN SlabInsentiveHeader ON SlabInsentiveDetails.Code = SlabInsentiveHeader.Code
				GROUP BY SlabInsentiveDetails.Code, SlabInsentiveDetails.[From], SlabInsentiveDetails.[To], SlabInsentiveDetails.Insentive, SlabInsentiveHeader.Code
				HAVING        (SlabInsentiveDetails.Code = @SuppliyerSlabCode)
				ORDER BY SlabInsentiveDetails.[To] 
			OPEN @CurSlabs
			FETCH NEXT
			FROM @CurSlabs INTO @SlabCode,@SlabFrom,@SlabTo,@SlabIncentiveRate
			WHILE @@FETCH_STATUS =0
			BEGIN
			set @Slabqty=0
			set @QtyForSlab=0
			set @ThisSlabAmount=0
				--IF(@TOTGL>=@SlabFrom )
				--BEGIN				
				 
				--	 if(@TOTGL<=@SlabTo)
				--	 begin
				--		set @Slabqty=@TOTGL
				--		set @ThisSlabAmount=(@Slabqty-@SlabFrom)*@SlabIncentiveRate
				--		SET @IncentiveSlabAmount=@IncentiveSlabAmount+(@Slabqty-@SlabFrom)*@SlabIncentiveRate
				--		set @QtyForSlab=@Slabqty-@SlabFrom
				--		IF NOT EXISTS (SELECT * FROM [dbo].[BLMonthIncentivesDetails] WHERE ([LeafYear] =@PROYear) AND ([LeafMonth]=@PROMonth) AND  ([Route] =@Route) AND  ([SuppliyerCode] =@SupplierCode) AND ([IncentiveType]='LeafQuality') AND	([Type2]=@LeafType))
				--		BEGIN
				--			INSERT INTO [dbo].[BLMonthIncentivesDetails]
				--						([LeafYear] ,[LeafMonth] ,[Route] ,[SuppliyerCode] ,[IncentiveType] ,[Type2] ,[LeafRate] ,[LeafQuantity] ,[Amount] ,[CreateDateTime] ,[UserID])
				--			VALUES
				--						(@PROYear,@PROMonth ,@Route ,@SupplierCode  ,'Slab' , convert(varchar(10),@SuppliyerSlabCode)+'_'+convert(varchar(10),@SlabFrom)+'_'+convert(varchar(10),@SlabTo) ,@SlabIncentiveRate ,@QtyForSlab ,@ThisSlabAmount ,GETDATE() ,@userId)
				--		END
				--	 end
				--	 else
				--	 begin
				--		set @Slabqty=@SlabTo
				--		set @ThisSlabAmount=(@Slabqty-@SlabFrom)*@SlabIncentiveRate
				--		SET @IncentiveSlabAmount=@IncentiveSlabAmount+(@Slabqty-@SlabFrom)*@SlabIncentiveRate
				--		set @QtyForSlab=@Slabqty-@SlabFrom
				--		IF NOT EXISTS (SELECT * FROM [dbo].[BLMonthIncentivesDetails] WHERE ([LeafYear] =@PROYear) AND ([LeafMonth]=@PROMonth) AND  ([Route] =@Route) AND  ([SuppliyerCode] =@SupplierCode) AND ([IncentiveType]='LeafQuality') AND	([Type2]=@LeafType))
				--		BEGIN
				--			INSERT INTO [dbo].[BLMonthIncentivesDetails]
				--						([LeafYear] ,[LeafMonth] ,[Route] ,[SuppliyerCode] ,[IncentiveType] ,[Type2] ,[LeafRate] ,[LeafQuantity] ,[Amount] ,[CreateDateTime] ,[UserID])
				--			VALUES
				--						(@PROYear,@PROMonth ,@Route ,@SupplierCode   ,'Slab' ,  convert(varchar(10),@SuppliyerSlabCode)+'_'+convert(varchar(10),@SlabFrom)+'_'+convert(varchar(10),@SlabTo) ,@SlabIncentiveRate ,@QtyForSlab ,@ThisSlabAmount ,GETDATE() ,@userId)
				--		END
				--	 end
				--END

				IF(@TOTGL>=@SlabFrom )
				BEGIN				
				 
					 if(@TOTGL<@SlabTo)
					 begin
					 print 'slab Incentive-------------'
					 print 'totGL'
					 print @TOTGL
					 print 'SlabIncentiveRate'
					 print @SlabIncentiveRate

						set @Slabqty=@TOTGL
						set @ThisSlabAmount=(@TOTGL)*@SlabIncentiveRate
						SET @IncentiveSlabAmount=(@TOTGL)*@SlabIncentiveRate
						set @QtyForSlab=@TOTGL
						 print 'IncentiveSlabAmount--'
						print @IncentiveSlabAmount
						IF NOT EXISTS (SELECT * FROM [dbo].[BLMonthIncentivesDetails] WHERE ([LeafYear] =@PROYear) AND ([LeafMonth]=@PROMonth) AND  ([Route] =@Route) AND  ([SuppliyerCode] =@SupplierCode) AND ([IncentiveType]='LeafQuality') AND	([Type2]=@LeafType))
						BEGIN
							INSERT INTO [dbo].[BLMonthIncentivesDetails]
										([LeafYear] ,[LeafMonth] ,[Route] ,[SuppliyerCode] ,[IncentiveType] ,[Type2] ,[LeafRate] ,[LeafQuantity] ,[Amount] ,[CreateDateTime] ,[UserID])
							VALUES
										(@PROYear,@PROMonth ,@Route ,@SupplierCode  ,'Slab' , convert(varchar(10),@SuppliyerSlabCode)+'_'+convert(varchar(10),@SlabFrom)+'_'+convert(varchar(10),@SlabTo) ,@SlabIncentiveRate ,@QtyForSlab ,@ThisSlabAmount ,GETDATE() ,@userId)
						END
					 end
					 --else
					 --begin
						--set @Slabqty=@SlabTo
						--set @ThisSlabAmount=(@Slabqty-@SlabFrom)*@SlabIncentiveRate
						--SET @IncentiveSlabAmount=@IncentiveSlabAmount+(@Slabqty-@SlabFrom)*@SlabIncentiveRate
						--set @QtyForSlab=@Slabqty-@SlabFrom
						--IF NOT EXISTS (SELECT * FROM [dbo].[BLMonthIncentivesDetails] WHERE ([LeafYear] =@PROYear) AND ([LeafMonth]=@PROMonth) AND  ([Route] =@Route) AND  ([SuppliyerCode] =@SupplierCode) AND ([IncentiveType]='LeafQuality') AND	([Type2]=@LeafType))
						--BEGIN
						--	INSERT INTO [dbo].[BLMonthIncentivesDetails]
						--				([LeafYear] ,[LeafMonth] ,[Route] ,[SuppliyerCode] ,[IncentiveType] ,[Type2] ,[LeafRate] ,[LeafQuantity] ,[Amount] ,[CreateDateTime] ,[UserID])
						--	VALUES
						--				(@PROYear,@PROMonth ,@Route ,@SupplierCode   ,'Slab' ,  convert(varchar(10),@SuppliyerSlabCode)+'_'+convert(varchar(10),@SlabFrom)+'_'+convert(varchar(10),@SlabTo) ,@SlabIncentiveRate ,@QtyForSlab ,@ThisSlabAmount ,GETDATE() ,@userId)
						--END
					 --end
				END

	

			FETCH NEXT
			FROM @CurSlabs INTO  @SlabCode,@SlabFrom,@SlabTo,@SlabIncentiveRate
			END
			CLOSE @CurSlabs	
			END
	/*END Slab Incentive*/

	

	--Good Leaf Incentive
	
	
		----IF EXISTS ( SELECT SUM(GreenLeafCollected) AS Expr1 FROM dbo.DailyGreenLeaf WHERE (LeafType = 'Good') AND (CollectedDate BETWEEN CONVERT(DATETIME, @FromDate, 102) AND CONVERT(DATETIME, @ToDate, 102)) AND  (SupplierCode = @SupplierCode))
		----BEGIN	
		----	SET @GoodLeaf=( SELECT ISNULL(SUM(GreenLeafCollected),0) AS Expr1 FROM dbo.DailyGreenLeaf WHERE (LeafType = 'Good') AND (CollectedDate BETWEEN CONVERT(DATETIME, @FromDate, 102) AND CONVERT(DATETIME, @ToDate, 102)) AND  (SupplierCode = @SupplierCode))
		----	SET @IncentiveGoodLeafAmount=@GoodLeaf*@IncentiveGoodLeafPerKiloRate
		----END
		----ELSE 
		----BEGIN
		----	SET @GoodLeaf=0
		----	SET @IncentiveGoodLeafAmount=0
		----END

	PRINT 'Good Leaf Incentive - GL -Rate- Incentive'
	PRINT @GoodLeaf
	PRINT @IncentiveGoodLeafPerKiloRate
	PRINT @IncentiveGoodLeafAmount

	/*Transport Incentive*/
	/*Transport Incentive Settings*/
	--Table BLMasterSettings
	--Type TransportIncentiveEntitlement
	--Name 
		--ALL	-All Transport Types
		--SELF	- Only Self Transport Type
		--FAC	- Only Factory Transport Type
		--Other - Only Other Type
    /**/
	set @TransportIncentiveEntitlement='ALL'
		if exists (SELECT TOP (1) Name AS Expr2 FROM dbo.BLMasterSettings WHERE (Type = 'TransportIncentiveEntitlement'))
		begin
			set @TransportIncentiveEntitlement=(SELECT TOP (1) Name AS Expr2 FROM dbo.BLMasterSettings WHERE (Type = 'TransportIncentiveEntitlement'))
		end	
	
	DECLARE @FactoryLeafQty decimal(18,2)
	DECLARE @SELFLeafQty decimal(18,2)
	DECLARE @OtherLeafQty decimal(18,2)
	declare @IncentiveTransportAmountFactoryRate decimal(18,2)
	declare @IncentiveTransportAmountSelfRate decimal(18,2)
	declare @IncentiveTransportAmountOtherRate decimal(18,2)
	SET  @FactoryLeafQty=0
	set @OtherLeafQty=0

	set @IncentiveTransportAmountFactoryRate=0
	set @IncentiveTransportAmountSelfRate=0
	set @IncentiveTransportAmountOtherRate=0
	if exists (SELECT Amount FROM dbo.BLMasterRates WHERE (Type = 'TransportType') AND (Name = 'Self'))
	begin
	set @IncentiveTransportAmountSelfRate=isnull((SELECT Amount FROM dbo.BLMasterRates WHERE (Type = 'TransportType') AND (Name = 'Self')),0)
	end
	if exists (SELECT Amount FROM dbo.BLMasterRates WHERE (Type = 'TransportType') AND (Name = 'Factory'))
	begin
	set @IncentiveTransportAmountFactoryRate=isnull((SELECT Amount FROM dbo.BLMasterRates WHERE (Type = 'TransportType') AND (Name = 'Factory')),0)
	
	if exists (SELECT Amount FROM dbo.BLMasterRates WHERE (Type = 'TransportType') AND (Name = 'Other'))
	begin
	set @IncentiveTransportAmountOtherRate=isnull((SELECT Amount FROM dbo.BLMasterRates WHERE (Type = 'TransportType') AND (Name = 'Other')),0)
	end
	
	--if transport incentive transport type wise
	if(@TransportIncentiveEntitlement='TYPEWISE')
	BEGIN
			if exists (SELECT ISNULL(SUM(NetWeight), 0) AS SELFQTY FROM dbo.DailyGreenLeaf WHERE (SupplierCode = @SupplierCode) AND (RouteNo = @Route) AND (CollectedDate BETWEEN CONVERT(DATETIME, @FromDate, 102) AND CONVERT(DATETIME, @ToDate, 102)) AND (TransportType = 'Self'))
			begin
				SET @SELFLeafQty=(SELECT ISNULL(SUM(NetWeight), 0) AS SELFQTY FROM dbo.DailyGreenLeaf WHERE (SupplierCode = @SupplierCode) AND (RouteNo = @Route) AND (CollectedDate BETWEEN CONVERT(DATETIME, @FromDate, 102) AND CONVERT(DATETIME, @ToDate, 102)) AND (TransportType = 'Self'))
				if(@SELFLeafQty>0)
				begin
				IF NOT EXISTS (SELECT * FROM [dbo].[BLMonthIncentivesDetails] WHERE ([LeafYear] =@PROYear) AND ([LeafMonth]=@PROMonth) AND  ([Route] =@Route) AND  ([SuppliyerCode] =@SupplierCode) AND ([IncentiveType]='Transport') AND	([Type2]='Self'))
					BEGIN
						INSERT INTO [dbo].[BLMonthIncentivesDetails]
									([LeafYear] ,[LeafMonth] ,[Route] ,[SuppliyerCode] ,[IncentiveType] ,[Type2] ,[LeafRate] ,[LeafQuantity] ,[Amount] ,[CreateDateTime] ,[UserID])
						VALUES
									(@PROYear,@PROMonth ,@Route ,@SupplierCode  ,'Transport' , 'Self' ,@IncentiveTransportAmountSelfRate ,@SELFLeafQty,@SELFLeafQty*@IncentiveTransportAmountSelfRate ,GETDATE() ,@userId)
					END
				end
			end
			else
			begin
				SET @SELFLeafQty=0
			end

			if exists (SELECT ISNULL(SUM(NetWeight), 0) AS SELFQTY FROM dbo.DailyGreenLeaf WHERE (SupplierCode = @SupplierCode) AND (RouteNo = @Route) AND (CollectedDate BETWEEN CONVERT(DATETIME, @FromDate, 102) AND CONVERT(DATETIME, @ToDate, 102)) AND (TransportType = 'Factory'))
			begin
				SET @FactoryLeafQty=(SELECT ISNULL(SUM(NetWeight), 0) AS SELFQTY FROM dbo.DailyGreenLeaf WHERE (SupplierCode = @SupplierCode) AND (RouteNo = @Route) AND (CollectedDate BETWEEN CONVERT(DATETIME, @FromDate, 102) AND CONVERT(DATETIME, @ToDate, 102)) AND (TransportType = 'Factory'))
				if(@FactoryLeafQty>0)
				begin
				IF NOT EXISTS (SELECT * FROM [dbo].[BLMonthIncentivesDetails] WHERE ([LeafYear] =@PROYear) AND ([LeafMonth]=@PROMonth) AND  ([Route] =@Route) AND  ([SuppliyerCode] =@SupplierCode) AND ([IncentiveType]='Transport') AND	([Type2]='Factory'))
					BEGIN
						INSERT INTO [dbo].[BLMonthIncentivesDetails]
									([LeafYear] ,[LeafMonth] ,[Route] ,[SuppliyerCode] ,[IncentiveType] ,[Type2] ,[LeafRate] ,[LeafQuantity] ,[Amount] ,[CreateDateTime] ,[UserID])
						VALUES
									(@PROYear,@PROMonth ,@Route ,@SupplierCode  ,'Transport' , 'Factory' ,@IncentiveTransportAmountFactoryRate ,@FactoryLeafQty,@FactoryLeafQty*@IncentiveTransportAmountFactoryRate ,GETDATE() ,@userId)
					END
				end
			end
			else
			begin
				SET @FactoryLeafQty=0
			end

			if exists (SELECT ISNULL(SUM(NetWeight), 0) AS SELFQTY FROM dbo.DailyGreenLeaf WHERE (SupplierCode = @SupplierCode) AND (RouteNo = @Route) AND (CollectedDate BETWEEN CONVERT(DATETIME, @FromDate, 102) AND CONVERT(DATETIME, @ToDate, 102)) AND (TransportType = 'Other'))
			begin
				SET @OtherLeafQty=(SELECT ISNULL(SUM(NetWeight), 0) AS SELFQTY FROM dbo.DailyGreenLeaf WHERE (SupplierCode = @SupplierCode) AND (RouteNo = @Route) AND (CollectedDate BETWEEN CONVERT(DATETIME, @FromDate, 102) AND CONVERT(DATETIME, @ToDate, 102)) AND (TransportType = 'Other'))
				if(@OtherLeafQty>0)
				begin
				IF NOT EXISTS (SELECT * FROM [dbo].[BLMonthIncentivesDetails] WHERE ([LeafYear] =@PROYear) AND ([LeafMonth]=@PROMonth) AND  ([Route] =@Route) AND  ([SuppliyerCode] =@SupplierCode) AND ([IncentiveType]='Transport') AND	([Type2]='Other'))
					BEGIN
						INSERT INTO [dbo].[BLMonthIncentivesDetails]
									([LeafYear] ,[LeafMonth] ,[Route] ,[SuppliyerCode] ,[IncentiveType] ,[Type2] ,[LeafRate] ,[LeafQuantity] ,[Amount] ,[CreateDateTime] ,[UserID])
						VALUES
									(@PROYear,@PROMonth ,@Route ,@SupplierCode  ,'Transport' , 'Other' ,@IncentiveTransportAmountOtherRate ,@OtherLeafQty,@OtherLeafQty*@IncentiveTransportAmountOtherRate ,GETDATE() ,@userId)
					END
				end
			end
			else
			begin
				SET @OtherLeafQty=0
			end
			if exists (SELECT ISNULL(SUM(NetWeight), 0) AS SELFQTY FROM dbo.DailyGreenLeaf WHERE (SupplierCode = @SupplierCode) AND (RouteNo = @Route) AND (CollectedDate BETWEEN CONVERT(DATETIME, @FromDate, 102) AND CONVERT(DATETIME, @ToDate, 102)) AND (TransportType IN ( 'Self','Factory','Other')))
			begin
				SET @IncentiveTransportAmount=(@SELFLeafQty*@IncentiveTransportAmountSelfRate)+(@FactoryLeafQty*@IncentiveTransportAmountFactoryRate)+(@OtherLeafQty*@IncentiveTransportAmountOtherRate)
				
			END
	END
	ELSE
	BEGIN
			SET @SELFLeafQty=0
				IF EXISTS (SELECT transportIncentive FROM dbo.BLMasterSupplierIncentives WHERE (RouteNo = @Route) AND (SupplierCode = @SupplierCode) AND (transportIncentive>0))
				BEGIN
					SET @IncentiveTransportPerKiloRate=(SELECT transportIncentive FROM dbo.BLMasterSupplierIncentives WHERE (RouteNo = @Route) AND (SupplierCode = @SupplierCode))	
					SET @FactoryLeafQty=0
					SET @SELFLeafQty=0
					SET @IncentiveTransportAmount=0

						IF (@TransportIncentiveEntitlement='ALL')
						BEGIN		
									
							SET @IncentiveTransportAmount=@IncentiveTransportPerKiloRate*@TOTGL
							IF NOT EXISTS (SELECT * FROM [dbo].[BLMonthIncentivesDetails] WHERE ([LeafYear] =@PROYear) AND ([LeafMonth]=@PROMonth) AND  ([Route] =@Route) AND  ([SuppliyerCode] =@SupplierCode) AND ([IncentiveType]='Transport') AND	([Type2]='ALL'))
							BEGIN
								INSERT INTO [dbo].[BLMonthIncentivesDetails]
											([LeafYear] ,[LeafMonth] ,[Route] ,[SuppliyerCode] ,[IncentiveType] ,[Type2] ,[LeafRate] ,[LeafQuantity] ,[Amount] ,[CreateDateTime] ,[UserID])
								VALUES
											(@PROYear,@PROMonth ,@Route ,@SupplierCode  ,'Transport' , 'ALL' ,@IncentiveTransportPerKiloRate ,@TOTGL ,@IncentiveTransportAmount ,GETDATE() ,@userId)
							END
						END
						ELSE IF (@TransportIncentiveEntitlement='SELF')
						BEGIN
							IF EXISTS(SELECT ISNULL(SUM(NetWeight), 0) AS SELFQTY FROM dbo.DailyGreenLeaf WHERE (SupplierCode = @SupplierCode) AND (RouteNo = @Route) AND (CollectedDate BETWEEN CONVERT(DATETIME, @FromDate, 102) AND CONVERT(DATETIME, @ToDate, 102)) AND (TransportType = 'Self'))
							BEGIN
							SET @SELFLeafQty=(SELECT ISNULL(SUM(NetWeight), 0) AS SELFQTY FROM dbo.DailyGreenLeaf WHERE (SupplierCode = @SupplierCode) AND (RouteNo = @Route) AND (CollectedDate BETWEEN CONVERT(DATETIME, @FromDate, 102) AND CONVERT(DATETIME, @ToDate, 102)) AND (TransportType = 'Self'))
							SET @IncentiveTransportAmount=@IncentiveTransportPerKiloRate*@SELFLeafQty

							IF NOT EXISTS (SELECT * FROM [dbo].[BLMonthIncentivesDetails] WHERE ([LeafYear] =@PROYear) AND ([LeafMonth]=@PROMonth) AND  ([Route] =@Route) AND  ([SuppliyerCode] =@SupplierCode) AND ([IncentiveType]='Transport') AND	([Type2]='Self'))
							BEGIN
								INSERT INTO [dbo].[BLMonthIncentivesDetails]
											([LeafYear] ,[LeafMonth] ,[Route] ,[SuppliyerCode] ,[IncentiveType] ,[Type2] ,[LeafRate] ,[LeafQuantity] ,[Amount] ,[CreateDateTime] ,[UserID])
								VALUES
											(@PROYear,@PROMonth ,@Route ,@SupplierCode  ,'Transport' , 'SELF' ,@IncentiveTransportPerKiloRate ,@SELFLeafQty ,@IncentiveTransportAmount ,GETDATE() ,@userId)
							END

							END
							ELSE
							BEGIN
								SET @SELFLeafQty=0
								SET @IncentiveTransportAmount=0
							END
						END
						ELSE IF(@TransportIncentiveEntitlement='Factory')
						BEGIN
							IF EXISTS(SELECT ISNULL(SUM(NetWeight), 0) AS SELFQTY FROM dbo.DailyGreenLeaf WHERE (SupplierCode = @SupplierCode) AND (RouteNo = @Route) AND (CollectedDate BETWEEN CONVERT(DATETIME, @FromDate, 102) AND CONVERT(DATETIME, @ToDate, 102)) AND (TransportType = 'Factory'))
							BEGIN
								SET @FactoryLeafQty=(SELECT ISNULL(SUM(NetWeight), 0) AS SELFQTY FROM dbo.DailyGreenLeaf WHERE (SupplierCode = @SupplierCode) AND (RouteNo = @Route) AND (CollectedDate BETWEEN CONVERT(DATETIME, @FromDate, 102) AND CONVERT(DATETIME, @ToDate, 102)) AND (TransportType = 'Factory'))
								SET @IncentiveTransportAmount=@IncentiveTransportPerKiloRate*@FactoryLeafQty

								IF NOT EXISTS (SELECT * FROM [dbo].[BLMonthIncentivesDetails] WHERE ([LeafYear] =@PROYear) AND ([LeafMonth]=@PROMonth) AND  ([Route] =@Route) AND  ([SuppliyerCode] =@SupplierCode) AND ([IncentiveType]='Transport') AND	([Type2]='Factory'))
								BEGIN
									INSERT INTO [dbo].[BLMonthIncentivesDetails]
												([LeafYear] ,[LeafMonth] ,[Route] ,[SuppliyerCode] ,[IncentiveType] ,[Type2] ,[LeafRate] ,[LeafQuantity] ,[Amount] ,[CreateDateTime] ,[UserID])
									VALUES
												(@PROYear,@PROMonth ,@Route ,@SupplierCode  ,'Transport' , 'Factory' ,@IncentiveTransportPerKiloRate ,@FactoryLeafQty ,@IncentiveTransportAmount ,GETDATE() ,@userId)
								END
							END
							ELSE
							BEGIN
								SET @FactoryLeafQty=0
								SET @IncentiveTransportAmount=0
							END
						END
						ELSE IF(@TransportIncentiveEntitlement='Other')
						BEGIN
							IF EXISTS(SELECT ISNULL(SUM(NetWeight), 0) AS SELFQTY FROM dbo.DailyGreenLeaf WHERE (SupplierCode = @SupplierCode) AND (RouteNo = @Route) AND (CollectedDate BETWEEN CONVERT(DATETIME, @FromDate, 102) AND CONVERT(DATETIME, @ToDate, 102)) AND (TransportType = 'Other'))
							BEGIN
								SET @FactoryLeafQty=(SELECT ISNULL(SUM(NetWeight), 0) AS SELFQTY FROM dbo.DailyGreenLeaf WHERE (SupplierCode = @SupplierCode) AND (RouteNo = @Route) AND (CollectedDate BETWEEN CONVERT(DATETIME, @FromDate, 102) AND CONVERT(DATETIME, @ToDate, 102)) AND (TransportType = 'Other'))
								SET @IncentiveTransportAmount=@IncentiveTransportPerKiloRate*@FactoryLeafQty

								IF NOT EXISTS (SELECT * FROM [dbo].[BLMonthIncentivesDetails] WHERE ([LeafYear] =@PROYear) AND ([LeafMonth]=@PROMonth) AND  ([Route] =@Route) AND  ([SuppliyerCode] =@SupplierCode) AND ([IncentiveType]='Transport') AND	([Type2]='Other'))
								BEGIN
									INSERT INTO [dbo].[BLMonthIncentivesDetails]
												([LeafYear] ,[LeafMonth] ,[Route] ,[SuppliyerCode] ,[IncentiveType] ,[Type2] ,[LeafRate] ,[LeafQuantity] ,[Amount] ,[CreateDateTime] ,[UserID])
									VALUES
												(@PROYear,@PROMonth ,@Route ,@SupplierCode  ,'Transport' , 'Other' ,@IncentiveTransportPerKiloRate ,@FactoryLeafQty ,@IncentiveTransportAmount ,GETDATE() ,@userId)
								END
							END
							ELSE
							BEGIN
								SET @FactoryLeafQty=0
								SET @IncentiveTransportAmount=0
							END
						END
						ELSE
						BEGIN
							SET @IncentiveTransportAmount=0
						END
				
				END
				ELSE 
				BEGIN
					SET @IncentiveTransportPerKiloRate=0
					SET @IncentiveTransportAmount=0
				END
	END
	

	END
	PRINT 'Transport Incentive Rate'
	PRINT @IncentiveTransportPerKiloRate
	PRINT 'Transport Incentive Amount'
	PRINT @IncentiveTransportAmount

	--set @IncentiveElevationAmount=@IncentiveElevationAmount+@IncentiveTransportAmount
	----------------------

	
	/*
	TOTAL INCENTIVE=ELEVATION+GOODLEAF+SLAB+TRANSPORT
	*/
	SET @IncentiveTotal=@IncentiveElevationAmount+@IncentiveGoodLeafAmount+@IncentiveSlabAmount+@IncentiveTransportAmount
	PRINT 'INCENTIVE TOTAL'
	PRINT @IncentiveTotal

	--PREVIOUS COINS-----------
	DECLARE @CoinsAmount DECIMAL(18,2)
	SET @CoinsAmount=0
	SET @CoinsAmount=ISNULL((SELECT  ISNULL(CoinAmount,0) FROM  dbo.BLMadeUpCoins WHERE (ProYear = YEAR(@PreMonthDate)) AND (ProMonth = MONTH(@PreMonthDate)) AND (SupplierCode =@SupplierCode)),0)

	PRINT 'PREVIOUS COINS'
	PRINT @CoinsAmount

  
  DECLARE @TOTEarnings DECIMAL(18,2)
	SET @TOTEarnings=0 
	SET @TOTEarnings=@GLPAY+@OtherPayment+@IncentiveTotal
	PRINT 'TOT EARNINGS'
	PRINT @TOTEarnings

	set @EarningsBalance=@TOTEarnings

/*--DEDUCTIONS---------*/

--PREVIOUS DEBTS-----------
	DECLARE @DebtsAmount DECIMAL(18,2)
	SET @DebtsAmount=0
	--SET @DebtsAmount=ISNULL((SELECT  ISNULL(DebtsAmount,0) FROM  dbo.BLDebtors WHERE (ProYear = YEAR(@PreMonthDate)) AND (ProMonth = MONTH(@PreMonthDate)) AND (SupplierCode =@SupplierCode)),0)
	set @DebtsAmount=isnull((SELECT       isnull(sum( CFDebtBalance),0) FROM dbo.MonthlyPaymentSummary WHERE (Month = MONTH(@PreMonthDate)) AND (Year = YEAR(@PreMonthDate)) AND (SupplierCode = @SupplierCode) AND (RouteCode = @Route) ),0)
	PRINT 'PREVIOUS DEBTS'
	print @PreMonthDate
	PRINT @DebtsAmount

	set @EarningsBalance=@EarningsBalance-@DebtsAmount

/*TRANSPORT DEDUCTION*/
	IF EXISTS (SELECT CollectedDate, SupplierCode, NetWeight, TransportCode FROM dbo.DailyGreenLeaf WHERE (CollectedDate BETWEEN CONVERT(DATETIME, @FromDate, 102) AND CONVERT(DATETIME, @ToDate, 102)) AND (SupplierCode = @SupplierCode))
	BEGIN
			DECLARE @TransportDeduction DECIMAL(18,2)
			SET @TransportDeduction =(select sum(TrCost) from (SELECT        NetWeight * ISNULL
								 ((SELECT        trnCost
									 FROM            dbo.TransportCost
									 WHERE        (trnCode = dbo.DailyGreenLeaf.TransportCode)), 0) AS TrCost
							FROM            dbo.DailyGreenLeaf
							WHERE        (CollectedDate BETWEEN CONVERT(DATETIME, @FromDate, 102) AND CONVERT(DATETIME, @ToDate, 102)) AND (SupplierCode = @SupplierCode)) as T1)
		
	END
	ELSE
	BEGIN
		SET  @TransportDeduction =0
	END

	PRINT 'Transport Deduction'
	PRINT @TransportDeduction

	set @EarningsBalance=@EarningsBalance-@TransportDeduction


	--DELETE FROM [dbo].[SupplierMonthDeductions] WHERE [DeductYear]=@PROYear AND [DeductMonth]=@PROMonth AND [Route] LIKE @Route AND [SupplierCode]=@SupplierCode

	INSERT INTO [dbo].[SupplierMonthDeductions] ([DeductYear] ,[DeductMonth] ,[Route] ,[SupplierCode] ,[DeductGroup] ,[DeductCode] ,[Amount])
     VALUES (@PROYear ,@PROMonth ,@Route ,@SupplierCode ,'TRANSPORT' ,'TRANSPORT' ,@TransportDeduction)

	 
	 --DELETE FROM [dbo].[SupplierMonthDeductions] WHERE ([DeductYear]=@PROYear) AND ([DeductMonth]=@PROMonth) AND ([Route] LIKE @Route)

	 /**/

	 ---DEDUCTIONS----------------
	 Declare @PriorityDeduction bit
	 set @PriorityDeduction=0
	 

			DECLARE @CashAdvDedut DECIMAL(18,2), @FertiDeduct  DECIMAL(18,2), @LoanDeduct  DECIMAL(18,2), @OtherDeduct  DECIMAL(18,2), @TeaDeduct  DECIMAL(18,2), @StationaryDeduct  DECIMAL(18,2), @WelfareDeduct  DECIMAL(18,2)
			DECLARE @curDeductions cursor
			DECLARE @DeductionGroupCode VARCHAR(50), @DeductCode VARCHAR(50),@DeductAmount DECIMAL(18,2) , @GroupPriority INT, @DeductPriority INT,@DeductBalanceAmount DECIMAL(18,2) , @FixedDeductionId int, @DeductionStartDate datetime
			SET @CashAdvDedut=0
			SET @FertiDeduct=0
			SET @LoanDeduct=0
			SET @OtherDeduct=0
			SET @TeaDeduct=0
			SET @StationaryDeduct=0
			SET @WelfareDeduct=0

	if(@PriorityDeduction=1)
	 begin

			SET @curDeductions = CURSOR FOR 
						SELECT        TOP (100) PERCENT dbo.SupplierDeductions.DeductionGroupCode, dbo.SupplierDeductions.DeductCode, dbo.SupplierDeductions.DeductAmount, 
												 dbo.DeductionGroup.Priority AS GroupPriority, dbo.DeductionCode.Priority AS CodePriority, dbo.SupplierDeductions.BalanceAmount,  dbo.SupplierDeductions.FixedDeductionId, dbo.SupplierDeductions.StartDate
						FROM            dbo.SupplierDeductions INNER JOIN
												 dbo.DeductionCode ON dbo.SupplierDeductions.DeductCode = dbo.DeductionCode.DeductionCode AND 
												 dbo.SupplierDeductions.DeductionGroupCode = dbo.DeductionCode.DeductionGroupCode INNER JOIN
												 dbo.DeductionGroup ON dbo.DeductionCode.DeductionGroupCode = dbo.DeductionGroup.DeductionGroupCode
						WHERE        (dbo.SupplierDeductions.BalanceAmount > 0) AND (dbo.SupplierDeductions.CloseYesNo = 0) AND (dbo.SupplierDeductions.SupplierCode = @SupplierCode)  AND (dbo.SupplierDeductions.DeductionGroupCode<>'FET')
						ORDER BY GroupPriority, CodePriority, dbo.SupplierDeductions.StartDate
			OPEN @curDeductions
			FETCH NEXT
			FROM @curDeductions INTO @DeductionGroupCode,@DeductCode,@DeductAmount,@GroupPriority,@DeductPriority,@DeductBalanceAmount,@FixedDeductionId, @DeductionStartDate 
			WHILE @@FETCH_STATUS =0
			BEGIN
			print '------Non Fertilizer------'
			print '--Deduction---'
			print @DeductCode
				if(@DeductAmount>@DeductBalanceAmount) 
				begin
					if(@DeductBalanceAmount<0)
					begin
						set @DeductAmount=0
					end
					else
					begin
						set @DeductAmount=@DeductBalanceAmount
					end
				end
			 IF(@DeductionGroupCode='FET')
			BEGIN
					print @DeductCode
					print @DeductAmount
					IF(@EarningsBalance>=@DeductAmount)
					BEGIN
							if not exists (select * from [dbo].[SupplierMonthDeductions] where ([DeductYear]=@PROYear) and ([DeductMonth]=@PROMonth) and ([Route]=@Route) and ([SupplierCode]=@SupplierCode) and ([DeductGroup]=@DeductionGroupCode) and ([DeductCode]=@DeductCode) and (DeductionRef=@FixedDeductionId))
							begin
								INSERT INTO [dbo].[SupplierMonthDeductions] ([DeductYear] ,[DeductMonth] ,[Route] ,[SupplierCode] ,[DeductGroup] ,[DeductCode] ,[Amount],DeductionRef)
								VALUES (@PROYear ,@PROMonth ,@Route ,@SupplierCode ,@DeductionGroupCode ,@DeductCode ,@DeductAmount,@FixedDeductionId)
							end
							else
							begin
								UPDATE [dbo].[SupplierMonthDeductions]
								SET [Amount]=[Amount]+@DeductAmount
								WHERE ([DeductYear]=@PROYear) and ([DeductMonth]=@PROMonth) and ([Route]=@Route) and ([SupplierCode]=@SupplierCode) and ([DeductGroup]=@DeductionGroupCode) and ([DeductCode]=@DeductCode) and (DeductionRef=@FixedDeductionId)
							end
					 
							 set @EarningsBalance=@EarningsBalance-	@DeductAmount

						UPDATE            dbo.SupplierDeductions
						SET DeductedYear=@PROYear,DeductedMonth=@PROMonth,DeductedAmount=@DeductAmount 
						WHERE (dbo.SupplierDeductions.BalanceAmount > 0) AND (dbo.SupplierDeductions.CloseYesNo = 0) AND (dbo.SupplierDeductions.SupplierCode = @SupplierCode) and (DeductionGroupCode=@DeductionGroupCode) and (DeductCode=@DeductCode) and (FixedDeductionId=@FixedDeductionId) and (StartDate=@DeductionStartDate)
					END
					ELSE IF(@EarningsBalance<@DeductAmount) AND (@EarningsBalance>0)
					BEGIN

							if not exists (select * from [dbo].[SupplierMonthDeductions] where ([DeductYear]=@PROYear) and ([DeductMonth]=@PROMonth) and ([Route]=@Route) and ([SupplierCode]=@SupplierCode) and ([DeductGroup]=@DeductionGroupCode) and ([DeductCode]=@DeductCode) and (DeductionRef=@FixedDeductionId))
							begin
								INSERT INTO [dbo].[SupplierMonthDeductions] ([DeductYear] ,[DeductMonth] ,[Route] ,[SupplierCode] ,[DeductGroup] ,[DeductCode] ,[Amount],DeductionRef)
								 VALUES (@PROYear ,@PROMonth ,@Route ,@SupplierCode ,@DeductionGroupCode ,@DeductCode ,@EarningsBalance,@FixedDeductionId)
							 end
							else
							begin
								UPDATE [dbo].[SupplierMonthDeductions]
								SET [Amount]=[Amount]+@EarningsBalance
								WHERE ([DeductYear]=@PROYear) and ([DeductMonth]=@PROMonth) and ([Route]=@Route) and ([SupplierCode]=@SupplierCode) and ([DeductGroup]=@DeductionGroupCode) and ([DeductCode]=@DeductCode) and (DeductionRef=@FixedDeductionId)
							end
					

							UPDATE            dbo.SupplierDeductions
							SET DeductedYear=@PROYear,DeductedMonth=@PROMonth,DeductedAmount=@EarningsBalance 
							WHERE (dbo.SupplierDeductions.BalanceAmount > 0) AND (dbo.SupplierDeductions.CloseYesNo = 0) AND (dbo.SupplierDeductions.SupplierCode = @SupplierCode) and (DeductionGroupCode=@DeductionGroupCode) and (DeductCode=@DeductCode) and (FixedDeductionId=@FixedDeductionId) and (StartDate=@DeductionStartDate)

							INSERT INTO [dbo].[BLSkippedDeduction]
						   ([Route] ,[Year] ,[Month] ,[SuppliyerCode] ,[SupplierName] ,[DeductionGroup] ,[DeductionCode] ,[DeductionName] ,[DeductionAmount]
						   ,[Skipped] ,[UserID] ,[CreatedDateTime],ExpectedDeductAmount,DeductionRef)
							 VALUES
						   (@Route ,@PROYear ,@PROMonth ,@SupplierCode ,@SupplierCode ,@DeductionGroupCode ,@DeductCode ,@DeductCode ,(@DeductAmount-@EarningsBalance)
						   ,1 ,@userId ,getdate(),@DeductAmount,@FixedDeductionId)

							set @EarningsBalance=	@EarningsBalance-@EarningsBalance	
				
					END
					ELSE 
					BEGIN
				
								INSERT INTO [dbo].[BLSkippedDeduction]
							   ([Route] ,[Year] ,[Month] ,[SuppliyerCode] ,[SupplierName] ,[DeductionGroup] ,[DeductionCode] ,[DeductionName] ,[DeductionAmount]
							   ,[Skipped] ,[UserID] ,[CreatedDateTime],ExpectedDeductAmount,DeductionRef)
								 VALUES
							   (@Route ,@PROYear ,@PROMonth ,@SupplierCode ,@SupplierCode ,@DeductionGroupCode ,@DeductCode ,@DeductCode ,@DeductAmount
							   ,1 ,@userId ,getdate(),@DeductAmount,@FixedDeductionId)
					END
				END
				ELSE
				BEGIN
					if not exists (select * from [dbo].[SupplierMonthDeductions] where ([DeductYear]=@PROYear) and ([DeductMonth]=@PROMonth) and ([Route]=@Route) and ([SupplierCode]=@SupplierCode) and ([DeductGroup]=@DeductionGroupCode) and ([DeductCode]=@DeductCode) and (DeductionRef=@FixedDeductionId))
					begin
						INSERT INTO [dbo].[SupplierMonthDeductions] ([DeductYear] ,[DeductMonth] ,[Route] ,[SupplierCode] ,[DeductGroup] ,[DeductCode] ,[Amount],DeductionRef)
						VALUES (@PROYear ,@PROMonth ,@Route ,@SupplierCode ,@DeductionGroupCode ,@DeductCode ,@DeductAmount,@FixedDeductionId)
					end
					else
					begin
						UPDATE [dbo].[SupplierMonthDeductions]
						SET [Amount]=[Amount]+@DeductAmount
						WHERE ([DeductYear]=@PROYear) and ([DeductMonth]=@PROMonth) and ([Route]=@Route) and ([SupplierCode]=@SupplierCode) and ([DeductGroup]=@DeductionGroupCode) and ([DeductCode]=@DeductCode) and (DeductionRef=@FixedDeductionId)
					end

					UPDATE            dbo.SupplierDeductions
					SET DeductedYear=@PROYear,DeductedMonth=@PROMonth,DeductedAmount=@DeductAmount 
					WHERE (dbo.SupplierDeductions.BalanceAmount > 0) AND (dbo.SupplierDeductions.CloseYesNo = 0) AND (dbo.SupplierDeductions.SupplierCode = @SupplierCode) and (DeductionGroupCode=@DeductionGroupCode) and (DeductCode=@DeductCode) and (FixedDeductionId=@FixedDeductionId) and (StartDate=@DeductionStartDate)

					set @EarningsBalance=@EarningsBalance-	@DeductAmount
					 
				END	

			FETCH NEXT
			FROM @curDeductions INTO  @DeductionGroupCode,@DeductCode,@DeductAmount,@GroupPriority,@DeductPriority,@DeductBalanceAmount,@FixedDeductionId, @DeductionStartDate 
			END
			CLOSE @curDeductions
		end
		else
		begin
			SET @curDeductions = CURSOR FOR 
						SELECT        TOP (100) PERCENT dbo.SupplierDeductions.DeductionGroupCode, dbo.SupplierDeductions.DeductCode, dbo.SupplierDeductions.DeductAmount, 
												 dbo.DeductionGroup.Priority AS GroupPriority, dbo.DeductionCode.Priority AS CodePriority, dbo.SupplierDeductions.BalanceAmount,  dbo.SupplierDeductions.FixedDeductionId, dbo.SupplierDeductions.StartDate
						FROM            dbo.SupplierDeductions INNER JOIN
												 dbo.DeductionCode ON dbo.SupplierDeductions.DeductCode = dbo.DeductionCode.DeductionCode AND 
												 dbo.SupplierDeductions.DeductionGroupCode = dbo.DeductionCode.DeductionGroupCode INNER JOIN
												 dbo.DeductionGroup ON dbo.DeductionCode.DeductionGroupCode = dbo.DeductionGroup.DeductionGroupCode
						WHERE        (dbo.SupplierDeductions.BalanceAmount > 0) AND (dbo.SupplierDeductions.CloseYesNo = 0) AND (dbo.SupplierDeductions.SupplierCode = @SupplierCode)  AND (dbo.SupplierDeductions.DeductionGroupCode<>'FET')
						ORDER BY GroupPriority, CodePriority, dbo.SupplierDeductions.StartDate
			OPEN @curDeductions
			FETCH NEXT
			FROM @curDeductions INTO @DeductionGroupCode,@DeductCode,@DeductAmount,@GroupPriority,@DeductPriority,@DeductBalanceAmount,@FixedDeductionId, @DeductionStartDate 
			WHILE @@FETCH_STATUS =0
			BEGIN
			print '------Non Fertilizer------'
			print '--Deduction---'
			print @DeductCode
				if(@DeductAmount>@DeductBalanceAmount) 
				begin
					if(@DeductBalanceAmount<0)
					begin
						set @DeductAmount=0
					end
					else
					begin
						set @DeductAmount=@DeductBalanceAmount
					end
				end
			 IF(@DeductionGroupCode='FET')
			BEGIN
					print @DeductCode
					print @DeductAmount
					--IF(@EarningsBalance>=@DeductAmount)
					--BEGIN
							if not exists (select * from [dbo].[SupplierMonthDeductions] where ([DeductYear]=@PROYear) and ([DeductMonth]=@PROMonth) and ([Route]=@Route) and ([SupplierCode]=@SupplierCode) and ([DeductGroup]=@DeductionGroupCode) and ([DeductCode]=@DeductCode) and (DeductionRef=@FixedDeductionId))
							begin
								INSERT INTO [dbo].[SupplierMonthDeductions] ([DeductYear] ,[DeductMonth] ,[Route] ,[SupplierCode] ,[DeductGroup] ,[DeductCode] ,[Amount],DeductionRef)
								VALUES (@PROYear ,@PROMonth ,@Route ,@SupplierCode ,@DeductionGroupCode ,@DeductCode ,@DeductAmount,@FixedDeductionId)
							end
							else
							begin
								UPDATE [dbo].[SupplierMonthDeductions]
								SET [Amount]=[Amount]+@DeductAmount
								WHERE ([DeductYear]=@PROYear) and ([DeductMonth]=@PROMonth) and ([Route]=@Route) and ([SupplierCode]=@SupplierCode) and ([DeductGroup]=@DeductionGroupCode) and ([DeductCode]=@DeductCode) and (DeductionRef=@FixedDeductionId)
							end
					 
							 set @EarningsBalance=@EarningsBalance-	@DeductAmount

						UPDATE            dbo.SupplierDeductions
						SET DeductedYear=@PROYear,DeductedMonth=@PROMonth,DeductedAmount=@DeductAmount 
						WHERE (dbo.SupplierDeductions.BalanceAmount > 0) AND (dbo.SupplierDeductions.CloseYesNo = 0) AND (dbo.SupplierDeductions.SupplierCode = @SupplierCode) and (DeductionGroupCode=@DeductionGroupCode) and (DeductCode=@DeductCode) and (FixedDeductionId=@FixedDeductionId) and (StartDate=@DeductionStartDate)
					--END
					--ELSE IF(@EarningsBalance<@DeductAmount) AND (@EarningsBalance>0)
					--BEGIN

					--		if not exists (select * from [dbo].[SupplierMonthDeductions] where ([DeductYear]=@PROYear) and ([DeductMonth]=@PROMonth) and ([Route]=@Route) and ([SupplierCode]=@SupplierCode) and ([DeductGroup]=@DeductionGroupCode) and ([DeductCode]=@DeductCode) and (DeductionRef=@FixedDeductionId))
					--		begin
					--			INSERT INTO [dbo].[SupplierMonthDeductions] ([DeductYear] ,[DeductMonth] ,[Route] ,[SupplierCode] ,[DeductGroup] ,[DeductCode] ,[Amount],DeductionRef)
					--			 VALUES (@PROYear ,@PROMonth ,@Route ,@SupplierCode ,@DeductionGroupCode ,@DeductCode ,@EarningsBalance,@FixedDeductionId)
					--		 end
					--		else
					--		begin
					--			UPDATE [dbo].[SupplierMonthDeductions]
					--			SET [Amount]=[Amount]+@EarningsBalance
					--			WHERE ([DeductYear]=@PROYear) and ([DeductMonth]=@PROMonth) and ([Route]=@Route) and ([SupplierCode]=@SupplierCode) and ([DeductGroup]=@DeductionGroupCode) and ([DeductCode]=@DeductCode) and (DeductionRef=@FixedDeductionId)
					--		end
					

					--		UPDATE            dbo.SupplierDeductions
					--		SET DeductedYear=@PROYear,DeductedMonth=@PROMonth,DeductedAmount=@EarningsBalance 
					--		WHERE (dbo.SupplierDeductions.BalanceAmount > 0) AND (dbo.SupplierDeductions.CloseYesNo = 0) AND (dbo.SupplierDeductions.SupplierCode = @SupplierCode) and (DeductionGroupCode=@DeductionGroupCode) and (DeductCode=@DeductCode) and (FixedDeductionId=@FixedDeductionId) and (StartDate=@DeductionStartDate)

					--		INSERT INTO [dbo].[BLSkippedDeduction]
					--	   ([Route] ,[Year] ,[Month] ,[SuppliyerCode] ,[SupplierName] ,[DeductionGroup] ,[DeductionCode] ,[DeductionName] ,[DeductionAmount]
					--	   ,[Skipped] ,[UserID] ,[CreatedDateTime],ExpectedDeductAmount,DeductionRef)
					--		 VALUES
					--	   (@Route ,@PROYear ,@PROMonth ,@SupplierCode ,@SupplierCode ,@DeductionGroupCode ,@DeductCode ,@DeductCode ,(@DeductAmount-@EarningsBalance)
					--	   ,1 ,@userId ,getdate(),@DeductAmount,@FixedDeductionId)

					--		set @EarningsBalance=	@EarningsBalance-@EarningsBalance	
				
					--END
					--ELSE 
					--BEGIN
				
					--			INSERT INTO [dbo].[BLSkippedDeduction]
					--		   ([Route] ,[Year] ,[Month] ,[SuppliyerCode] ,[SupplierName] ,[DeductionGroup] ,[DeductionCode] ,[DeductionName] ,[DeductionAmount]
					--		   ,[Skipped] ,[UserID] ,[CreatedDateTime],ExpectedDeductAmount,DeductionRef)
					--			 VALUES
					--		   (@Route ,@PROYear ,@PROMonth ,@SupplierCode ,@SupplierCode ,@DeductionGroupCode ,@DeductCode ,@DeductCode ,@DeductAmount
					--		   ,1 ,@userId ,getdate(),@DeductAmount,@FixedDeductionId)
					--END
				END
				ELSE
				BEGIN
					if not exists (select * from [dbo].[SupplierMonthDeductions] where ([DeductYear]=@PROYear) and ([DeductMonth]=@PROMonth) and ([Route]=@Route) and ([SupplierCode]=@SupplierCode) and ([DeductGroup]=@DeductionGroupCode) and ([DeductCode]=@DeductCode) and (DeductionRef=@FixedDeductionId))
					begin
						INSERT INTO [dbo].[SupplierMonthDeductions] ([DeductYear] ,[DeductMonth] ,[Route] ,[SupplierCode] ,[DeductGroup] ,[DeductCode] ,[Amount],DeductionRef)
						VALUES (@PROYear ,@PROMonth ,@Route ,@SupplierCode ,@DeductionGroupCode ,@DeductCode ,@DeductAmount,@FixedDeductionId)
					end
					else
					begin
						UPDATE [dbo].[SupplierMonthDeductions]
						SET [Amount]=[Amount]+@DeductAmount
						WHERE ([DeductYear]=@PROYear) and ([DeductMonth]=@PROMonth) and ([Route]=@Route) and ([SupplierCode]=@SupplierCode) and ([DeductGroup]=@DeductionGroupCode) and ([DeductCode]=@DeductCode) and (DeductionRef=@FixedDeductionId)
					end

					UPDATE            dbo.SupplierDeductions
					SET DeductedYear=@PROYear,DeductedMonth=@PROMonth,DeductedAmount=@DeductAmount 
					WHERE (dbo.SupplierDeductions.BalanceAmount > 0) AND (dbo.SupplierDeductions.CloseYesNo = 0) AND (dbo.SupplierDeductions.SupplierCode = @SupplierCode) and (DeductionGroupCode=@DeductionGroupCode) and (DeductCode=@DeductCode) and (FixedDeductionId=@FixedDeductionId) and (StartDate=@DeductionStartDate)

					set @EarningsBalance=@EarningsBalance-	@DeductAmount
					 
				END	

			FETCH NEXT
			FROM @curDeductions INTO  @DeductionGroupCode,@DeductCode,@DeductAmount,@GroupPriority,@DeductPriority,@DeductBalanceAmount,@FixedDeductionId, @DeductionStartDate 
			END
			CLOSE @curDeductions
		end


	 /**/
	
	--/*Deduct System Deductions*/
	--DECLARE @SystemDeductId  INT, @SysDeductionGroup VARCHAR(50), @SysDeduction VARCHAR(50), @SysDeductAmount DECIMAL(18,2)
	--print 'Earning balance bf sysDedu'
	--print @EarningsBalance		
	--print 'SYSDEDUCT'

	--				SET @curSysDeduct=CURSOR FOR 
	--				SELECT     SystemDeductId, DeductionGroup, Deduction, DeductAmount
	--				FROM         BLSysDeductions
	--				WHERE     (Active = 1)
				
	--				OPEN @curSysDeduct
	--				FETCH NEXT
	--				FROM @curSysDeduct INTO @SystemDeductId, @SysDeductionGroup, @SysDeduction, @SysDeductAmount
	--				WHILE @@FETCH_STATUS =0
	--				BEGIN
	--					if(@TOTGL>0)
	--					begin
							
	--								if not exists (select * from [dbo].BLSysDeductions where [EmpNo]=@eid and [DeductYear]=@ProcessYear and [DeductMonth]=@ProcessMonth and [DeductGroupId]=@SysDeductionGroup and [DeductId]=@SysDeduction )
	--								begin
	--										INSERT INTO SupplierDeductions( DeductionGroupCode, RouteNo, DeductCode, SupplierCode, DeductAmount, NoOfMonths, StartMonth,StartYear,StartDate,NoBags,CostPerBag,CostPerBagCommission,UserId,PrincipalAmount,BalanceAmount,RecoveredAmount,RecoveredInstallments,CloseYesNo,Guarantor1Div,Guarantor1,Guarantor2Div,Guarantor2,Fixed)
	--										VALUES (@SysDeductionGroup,@Route,@SysDeduction,@SupplierCode,@DeductAmount,1,@PROYear, @PROMonth,GETDATE(),0,0,0,@UserId,@SysDeductAmount,@SysDeductAmount,0,0,0,'NA','NA','NA','NA',0)
		
	--								end		
	--								else
	--								begin
	--										delete from [dbo].BLSysDeductions where [EmpNo]=@eid and [DeductYear]=@ProcessYear and [DeductMonth]=@ProcessMonth and [DeductGroupId]=@SysDeductionGroup and [DeductId]=@SysDeduction 
	--										INSERT INTO [dbo].BLSysDeductions
	--										([EmpNo] ,[DeductYear],[DeductMonth],[DeductGroupId],[DeductId],[Description],[Amount],[CancelYesNo]
	--										,[UserId],DivisionId)
	--										VALUES
	--										(@eid,@ProcessYear ,@ProcessMonth ,@SysDeductionGroup ,@SysDeduction ,'SysDeductions' ,@SysDeductAmount ,0
	--										,@userId,@divisionId)
	--								end	
	--								SET @EarningsBalance=@EarningsBalance-@SysDeductAmount
	--					end	
	--					else
	--					begin

	--							print 'skiped'
	--					end				
	--				FETCH NEXT
	--				FROM @curSysDeduct INTO @SystemDeductId, @SysDeductionGroup, @SysDeductionId, @SysDeductAmount
	--				END
	--				CLOSE @curSysDeduct
	--/*end**System Deductions*/
	

	--PAYSLIP DEDUCTIONS-------
	DECLARE @PaySlipDeduction DECIMAL(18,2)
	IF EXISTS (SELECT DeductAmount FROM dbo.BLSysDeductions WHERE (DeductionGroup = 'STA') AND (Deduction = 'RECEIPT'))
	BEGIN
		IF(@TOTGL>0)
		BEGIN
		SET @PaySlipDeduction =(SELECT DeductAmount FROM dbo.BLSysDeductions WHERE (DeductionGroup = 'STA') AND (Deduction = 'RECEIPT'))
		END
		ELSE
		BEGIN
		SET @PaySlipDeduction =0
		END
		set @EarningsBalance=@EarningsBalance-	@PaySlipDeduction
	END


	
	--STAMP DUTY DEDUCTIONS----
	DECLARE @StampDuty decimal(18,2)
	set @StampDuty=0
	IF(@TOTEarnings>=25000)
	BEGIN
		set @StampDuty=25
	END
	set @EarningsBalance=@EarningsBalance-	@StampDuty

	---DEDUCTIONS----------------
	--DECLARE @CashAdvDedut DECIMAL(18,2), @FertiDeduct  DECIMAL(18,2), @LoanDeduct  DECIMAL(18,2), @OtherDeduct  DECIMAL(18,2), @TeaDeduct  DECIMAL(18,2)
	--DECLARE @curDeductions cursor
	--DECLARE @DeductionGroupCode VARCHAR(50), @DeductCode VARCHAR(50),@DeductAmount DECIMAL(18,2) , @GroupPriority INT, @DeductPriority INT
	SET @CashAdvDedut=0
	SET @FertiDeduct=0
	SET @LoanDeduct=0
	SET @OtherDeduct=0
	SET @TeaDeduct=0
	SET @StationaryDeduct  =0
	SET @WelfareDeduct =0

	if(@PriorityDeduction=1)
	 begin

			SET @curDeductions = CURSOR FOR 
						SELECT        TOP (100) PERCENT dbo.SupplierDeductions.DeductionGroupCode, dbo.SupplierDeductions.DeductCode, dbo.SupplierDeductions.DeductAmount, 
												 dbo.DeductionGroup.Priority AS GroupPriority, dbo.DeductionCode.Priority AS CodePriority, dbo.SupplierDeductions.BalanceAmount,  dbo.SupplierDeductions.FixedDeductionId, dbo.SupplierDeductions.StartDate
						FROM            dbo.SupplierDeductions INNER JOIN
												 dbo.DeductionCode ON dbo.SupplierDeductions.DeductCode = dbo.DeductionCode.DeductionCode AND 
												 dbo.SupplierDeductions.DeductionGroupCode = dbo.DeductionCode.DeductionGroupCode INNER JOIN
												 dbo.DeductionGroup ON dbo.DeductionCode.DeductionGroupCode = dbo.DeductionGroup.DeductionGroupCode
						WHERE        (dbo.SupplierDeductions.BalanceAmount > 0) AND (dbo.SupplierDeductions.CloseYesNo = 0) AND (dbo.SupplierDeductions.SupplierCode = @SupplierCode) AND (dbo.SupplierDeductions.DeductionGroupCode='FET')
						ORDER BY GroupPriority, CodePriority
			OPEN @curDeductions
			FETCH NEXT
			FROM @curDeductions INTO @DeductionGroupCode,@DeductCode,@DeductAmount,@GroupPriority,@DeductPriority,@DeductBalanceAmount,@FixedDeductionId, @DeductionStartDate 
			WHILE @@FETCH_STATUS =0
			BEGIN
			print '------Fertilizer------'
			print '--Deduction---'
			print @DeductCode
			if(@DeductAmount>@DeductBalanceAmount) 
				begin
					if(@DeductBalanceAmount<0)
					begin
						set @DeductAmount=0
					end
					else
					begin
						set @DeductAmount=@DeductBalanceAmount
					end
				end

			 IF(@DeductionGroupCode='FET')
			BEGIN
				print @DeductCode
				-------------
				--if not exists (select * from [dbo].[SupplierMonthDeductions] where ([DeductYear]=@PROYear) and ([DeductMonth]=@PROMonth) and ([Route]=@Route) and ([SupplierCode]=@SupplierCode) and ([DeductGroup]=@DeductionGroupCode) and ([DeductCode]=@DeductCode) and (DeductionRef=@FixedDeductionId))
				--	begin
				--	print @DeductCode
				--	print 'insert'
				--	print @FixedDeductionId
				--	print @DeductAmount
				--		INSERT INTO [dbo].[SupplierMonthDeductions] ([DeductYear] ,[DeductMonth] ,[Route] ,[SupplierCode] ,[DeductGroup] ,[DeductCode] ,[Amount],DeductionRef)
				--		VALUES (@PROYear ,@PROMonth ,@Route ,@SupplierCode ,@DeductionGroupCode ,@DeductCode ,@DeductAmount,@FixedDeductionId)
				--	end
				--	else
				--	begin
				--	print @DeductCode
				--	print 'update'
				--	print  @FixedDeductionId
				--	print @DeductAmount
				--		UPDATE [dbo].[SupplierMonthDeductions]
				--		SET [Amount]=[Amount]+@DeductAmount
				--		WHERE ([DeductYear]=@PROYear) and ([DeductMonth]=@PROMonth) and ([Route]=@Route) and ([SupplierCode]=@SupplierCode) and ([DeductGroup]=@DeductionGroupCode) and ([DeductCode]=@DeductCode) and (DeductionRef=@FixedDeductionId)
				--	end
				-------------------

					IF(@EarningsBalance>=@DeductAmount)
					BEGIN
							if not exists (select * from [dbo].[SupplierMonthDeductions] where ([DeductYear]=@PROYear) and ([DeductMonth]=@PROMonth) and ([Route]=@Route) and ([SupplierCode]=@SupplierCode) and ([DeductGroup]=@DeductionGroupCode) and ([DeductCode]=@DeductCode) and (DeductionRef=@FixedDeductionId))
							begin
					
							print 'insert earning 1'
							print @FixedDeductionId
							print @DeductAmount
								INSERT INTO [dbo].[SupplierMonthDeductions] ([DeductYear] ,[DeductMonth] ,[Route] ,[SupplierCode] ,[DeductGroup] ,[DeductCode] ,[Amount],DeductionRef)
									 VALUES (@PROYear ,@PROMonth ,@Route ,@SupplierCode ,@DeductionGroupCode ,@DeductCode ,@DeductAmount,@FixedDeductionId)
							end
							else
							begin
							print 'update earning 1'
							print @FixedDeductionId
							print @DeductAmount
								UPDATE [dbo].[SupplierMonthDeductions]
								SET [Amount]=[Amount]+@DeductAmount
								WHERE ([DeductYear]=@PROYear) and ([DeductMonth]=@PROMonth) and ([Route]=@Route) and ([SupplierCode]=@SupplierCode) and ([DeductGroup]=@DeductionGroupCode) and ([DeductCode]=@DeductCode) and (DeductionRef=@FixedDeductionId)
							end 
									 set @EarningsBalance=@EarningsBalance-	@DeductAmount

								UPDATE            dbo.SupplierDeductions
								SET DeductedYear=@PROYear,DeductedMonth=@PROMonth,DeductedAmount=@DeductAmount 
								WHERE (dbo.SupplierDeductions.BalanceAmount > 0) AND (dbo.SupplierDeductions.CloseYesNo = 0) AND (dbo.SupplierDeductions.SupplierCode = @SupplierCode) and (DeductionGroupCode=@DeductionGroupCode) and (DeductCode=@DeductCode) and (FixedDeductionId=@FixedDeductionId) and (StartDate=@DeductionStartDate)
					END
					ELSE IF(@EarningsBalance<@DeductAmount) AND (@EarningsBalance>0)
					BEGIN
							if not exists (select * from [dbo].[SupplierMonthDeductions] where ([DeductYear]=@PROYear) and ([DeductMonth]=@PROMonth) and ([Route]=@Route) and ([SupplierCode]=@SupplierCode) and ([DeductGroup]=@DeductionGroupCode) and ([DeductCode]=@DeductCode) and (DeductionRef=@FixedDeductionId))
							begin
							print 'insert earning 2'
							print @FixedDeductionId
							print @DeductAmount
								INSERT INTO [dbo].[SupplierMonthDeductions] ([DeductYear] ,[DeductMonth] ,[Route] ,[SupplierCode] ,[DeductGroup] ,[DeductCode] ,[Amount],DeductionRef)
									 VALUES (@PROYear ,@PROMonth ,@Route ,@SupplierCode ,@DeductionGroupCode ,@DeductCode ,@EarningsBalance,@FixedDeductionId)
							end
							else
							begin
							print 'update earning 2'
							print @FixedDeductionId
							print @DeductAmount
								UPDATE [dbo].[SupplierMonthDeductions]
								SET [Amount]=[Amount]+@EarningsBalance
								WHERE ([DeductYear]=@PROYear) and ([DeductMonth]=@PROMonth) and ([Route]=@Route) and ([SupplierCode]=@SupplierCode) and ([DeductGroup]=@DeductionGroupCode) and ([DeductCode]=@DeductCode) and (DeductionRef=@FixedDeductionId)
							end 
					

									UPDATE            dbo.SupplierDeductions
									SET DeductedYear=@PROYear,DeductedMonth=@PROMonth,DeductedAmount=@EarningsBalance 
									WHERE (dbo.SupplierDeductions.BalanceAmount > 0) AND (dbo.SupplierDeductions.CloseYesNo = 0) AND (dbo.SupplierDeductions.SupplierCode = @SupplierCode) and (DeductionGroupCode=@DeductionGroupCode) and (DeductCode=@DeductCode) and (FixedDeductionId=@FixedDeductionId) and (StartDate=@DeductionStartDate)

									INSERT INTO [dbo].[BLSkippedDeduction]
								   ([Route] ,[Year] ,[Month] ,[SuppliyerCode] ,[SupplierName] ,[DeductionGroup] ,[DeductionCode] ,[DeductionName] ,[DeductionAmount] ,[Skipped] ,[UserID] ,[CreatedDateTime],ExpectedDeductAmount,DeductionRef)
									 VALUES
								   (@Route ,@PROYear ,@PROMonth ,@SupplierCode ,@SupplierCode ,@DeductionGroupCode ,@DeductCode ,@DeductCode ,(@DeductAmount-@EarningsBalance)
								   ,1 ,@userId ,getdate(),@DeductAmount,@FixedDeductionId)

									set @EarningsBalance=	@EarningsBalance-@EarningsBalance	
				
					END
					ELSE 
					BEGIN
					print 'insert earning 3'
					print @FixedDeductionId
					print @DeductAmount
								INSERT INTO [dbo].[BLSkippedDeduction]
							   ([Route] ,[Year] ,[Month] ,[SuppliyerCode] ,[SupplierName] ,[DeductionGroup] ,[DeductionCode] ,[DeductionName] ,[DeductionAmount]
							   ,[Skipped] ,[UserID] ,[CreatedDateTime],ExpectedDeductAmount,DeductionRef)
								 VALUES
							   (@Route ,@PROYear ,@PROMonth ,@SupplierCode ,@SupplierCode ,@DeductionGroupCode ,@DeductCode ,@DeductCode ,@DeductAmount
							   ,1 ,@userId ,getdate(),@DeductAmount,@FixedDeductionId)

							   UPDATE            dbo.SupplierDeductions
							   SET DeductedYear=@PROYear,DeductedMonth=@PROMonth,DeductedAmount=0 
							   WHERE (dbo.SupplierDeductions.BalanceAmount > 0) AND (dbo.SupplierDeductions.CloseYesNo = 0) AND (dbo.SupplierDeductions.SupplierCode = @SupplierCode) and (DeductionGroupCode=@DeductionGroupCode) and (DeductCode=@DeductCode) and (FixedDeductionId=@FixedDeductionId) and (StartDate=@DeductionStartDate)
					END
				END
				ELSE
				BEGIN
					if not exists (select * from [dbo].[SupplierMonthDeductions] where ([DeductYear]=@PROYear) and ([DeductMonth]=@PROMonth) and ([Route]=@Route) and ([SupplierCode]=@SupplierCode) and ([DeductGroup]=@DeductionGroupCode) and ([DeductCode]=@DeductCode) and (DeductionRef=@FixedDeductionId))
					begin
					INSERT INTO [dbo].[SupplierMonthDeductions] ([DeductYear] ,[DeductMonth] ,[Route] ,[SupplierCode] ,[DeductGroup] ,[DeductCode] ,[Amount],DeductionRef)
					VALUES (@PROYear ,@PROMonth ,@Route ,@SupplierCode ,@DeductionGroupCode ,@DeductCode ,@DeductAmount,@FixedDeductionId)
					end
					else
					begin
						UPDATE [dbo].[SupplierMonthDeductions]
						SET [Amount]=[Amount]+@DeductAmount
						WHERE ([DeductYear]=@PROYear) and ([DeductMonth]=@PROMonth) and ([Route]=@Route) and ([SupplierCode]=@SupplierCode) and ([DeductGroup]=@DeductionGroupCode) and ([DeductCode]=@DeductCode) and (DeductionRef=@FixedDeductionId)
					end 

					UPDATE            dbo.SupplierDeductions
					SET DeductedYear=@PROYear,DeductedMonth=@PROMonth,DeductedAmount=@DeductAmount 
					WHERE (dbo.SupplierDeductions.BalanceAmount > 0) AND (dbo.SupplierDeductions.CloseYesNo = 0) AND (dbo.SupplierDeductions.SupplierCode = @SupplierCode) and (DeductionGroupCode=@DeductionGroupCode) and (DeductCode=@DeductCode) and (FixedDeductionId=@FixedDeductionId) and (StartDate=@DeductionStartDate)
					 
				END	

			FETCH NEXT
			FROM @curDeductions INTO  @DeductionGroupCode,@DeductCode,@DeductAmount,@GroupPriority,@DeductPriority,@DeductBalanceAmount,@FixedDeductionId, @DeductionStartDate 
			END
			CLOSE @curDeductions
		end
		else
		begin
				SET @curDeductions = CURSOR FOR 
						SELECT        TOP (100) PERCENT dbo.SupplierDeductions.DeductionGroupCode, dbo.SupplierDeductions.DeductCode, dbo.SupplierDeductions.DeductAmount, 
												 dbo.DeductionGroup.Priority AS GroupPriority, dbo.DeductionCode.Priority AS CodePriority, dbo.SupplierDeductions.BalanceAmount,  dbo.SupplierDeductions.FixedDeductionId, dbo.SupplierDeductions.StartDate
						FROM            dbo.SupplierDeductions INNER JOIN
												 dbo.DeductionCode ON dbo.SupplierDeductions.DeductCode = dbo.DeductionCode.DeductionCode AND 
												 dbo.SupplierDeductions.DeductionGroupCode = dbo.DeductionCode.DeductionGroupCode INNER JOIN
												 dbo.DeductionGroup ON dbo.DeductionCode.DeductionGroupCode = dbo.DeductionGroup.DeductionGroupCode
						WHERE        (dbo.SupplierDeductions.BalanceAmount > 0) AND (dbo.SupplierDeductions.CloseYesNo = 0) AND (dbo.SupplierDeductions.SupplierCode = @SupplierCode) AND (dbo.SupplierDeductions.DeductionGroupCode='FET')
						ORDER BY GroupPriority, CodePriority
			OPEN @curDeductions
			FETCH NEXT
			FROM @curDeductions INTO @DeductionGroupCode,@DeductCode,@DeductAmount,@GroupPriority,@DeductPriority,@DeductBalanceAmount,@FixedDeductionId, @DeductionStartDate 
			WHILE @@FETCH_STATUS =0
			BEGIN
			print '------Fertilizer------'
			print '--Deduction---'
			print @DeductCode
			if(@DeductAmount>@DeductBalanceAmount) 
				begin
					if(@DeductBalanceAmount<0)
					begin
						set @DeductAmount=0
					end
					else
					begin
						set @DeductAmount=@DeductBalanceAmount
					end
				end

			 IF(@DeductionGroupCode='FET')
			BEGIN
				print @DeductCode
				-------------
				--if not exists (select * from [dbo].[SupplierMonthDeductions] where ([DeductYear]=@PROYear) and ([DeductMonth]=@PROMonth) and ([Route]=@Route) and ([SupplierCode]=@SupplierCode) and ([DeductGroup]=@DeductionGroupCode) and ([DeductCode]=@DeductCode) and (DeductionRef=@FixedDeductionId))
				--	begin
				--	print @DeductCode
				--	print 'insert'
				--	print @FixedDeductionId
				--	print @DeductAmount
				--		INSERT INTO [dbo].[SupplierMonthDeductions] ([DeductYear] ,[DeductMonth] ,[Route] ,[SupplierCode] ,[DeductGroup] ,[DeductCode] ,[Amount],DeductionRef)
				--		VALUES (@PROYear ,@PROMonth ,@Route ,@SupplierCode ,@DeductionGroupCode ,@DeductCode ,@DeductAmount,@FixedDeductionId)
				--	end
				--	else
				--	begin
				--	print @DeductCode
				--	print 'update'
				--	print  @FixedDeductionId
				--	print @DeductAmount
				--		UPDATE [dbo].[SupplierMonthDeductions]
				--		SET [Amount]=[Amount]+@DeductAmount
				--		WHERE ([DeductYear]=@PROYear) and ([DeductMonth]=@PROMonth) and ([Route]=@Route) and ([SupplierCode]=@SupplierCode) and ([DeductGroup]=@DeductionGroupCode) and ([DeductCode]=@DeductCode) and (DeductionRef=@FixedDeductionId)
				--	end
				-------------------

					--IF(@EarningsBalance>=@DeductAmount)
					--BEGIN
							if not exists (select * from [dbo].[SupplierMonthDeductions] where ([DeductYear]=@PROYear) and ([DeductMonth]=@PROMonth) and ([Route]=@Route) and ([SupplierCode]=@SupplierCode) and ([DeductGroup]=@DeductionGroupCode) and ([DeductCode]=@DeductCode) and (DeductionRef=@FixedDeductionId))
							begin
					
							print 'insert earning 1'
							print @FixedDeductionId
							print @DeductAmount
								INSERT INTO [dbo].[SupplierMonthDeductions] ([DeductYear] ,[DeductMonth] ,[Route] ,[SupplierCode] ,[DeductGroup] ,[DeductCode] ,[Amount],DeductionRef)
									 VALUES (@PROYear ,@PROMonth ,@Route ,@SupplierCode ,@DeductionGroupCode ,@DeductCode ,@DeductAmount,@FixedDeductionId)
							end
							else
							begin
							print 'update earning 1'
							print @FixedDeductionId
							print @DeductAmount
								UPDATE [dbo].[SupplierMonthDeductions]
								SET [Amount]=[Amount]+@DeductAmount
								WHERE ([DeductYear]=@PROYear) and ([DeductMonth]=@PROMonth) and ([Route]=@Route) and ([SupplierCode]=@SupplierCode) and ([DeductGroup]=@DeductionGroupCode) and ([DeductCode]=@DeductCode) and (DeductionRef=@FixedDeductionId)
							end 
									 set @EarningsBalance=@EarningsBalance-	@DeductAmount

								UPDATE            dbo.SupplierDeductions
								SET DeductedYear=@PROYear,DeductedMonth=@PROMonth,DeductedAmount=@DeductAmount 
								WHERE (dbo.SupplierDeductions.BalanceAmount > 0) AND (dbo.SupplierDeductions.CloseYesNo = 0) AND (dbo.SupplierDeductions.SupplierCode = @SupplierCode) and (DeductionGroupCode=@DeductionGroupCode) and (DeductCode=@DeductCode) and (FixedDeductionId=@FixedDeductionId) and (StartDate=@DeductionStartDate)
					--END
					--ELSE IF(@EarningsBalance<@DeductAmount) AND (@EarningsBalance>0)
					--BEGIN
					--		if not exists (select * from [dbo].[SupplierMonthDeductions] where ([DeductYear]=@PROYear) and ([DeductMonth]=@PROMonth) and ([Route]=@Route) and ([SupplierCode]=@SupplierCode) and ([DeductGroup]=@DeductionGroupCode) and ([DeductCode]=@DeductCode) and (DeductionRef=@FixedDeductionId))
					--		begin
					--		print 'insert earning 2'
					--		print @FixedDeductionId
					--		print @DeductAmount
					--			INSERT INTO [dbo].[SupplierMonthDeductions] ([DeductYear] ,[DeductMonth] ,[Route] ,[SupplierCode] ,[DeductGroup] ,[DeductCode] ,[Amount],DeductionRef)
					--				 VALUES (@PROYear ,@PROMonth ,@Route ,@SupplierCode ,@DeductionGroupCode ,@DeductCode ,@EarningsBalance,@FixedDeductionId)
					--		end
					--		else
					--		begin
					--		print 'update earning 2'
					--		print @FixedDeductionId
					--		print @DeductAmount
					--			UPDATE [dbo].[SupplierMonthDeductions]
					--			SET [Amount]=[Amount]+@EarningsBalance
					--			WHERE ([DeductYear]=@PROYear) and ([DeductMonth]=@PROMonth) and ([Route]=@Route) and ([SupplierCode]=@SupplierCode) and ([DeductGroup]=@DeductionGroupCode) and ([DeductCode]=@DeductCode) and (DeductionRef=@FixedDeductionId)
					--		end 
					

					--				UPDATE            dbo.SupplierDeductions
					--				SET DeductedYear=@PROYear,DeductedMonth=@PROMonth,DeductedAmount=@EarningsBalance 
					--				WHERE (dbo.SupplierDeductions.BalanceAmount > 0) AND (dbo.SupplierDeductions.CloseYesNo = 0) AND (dbo.SupplierDeductions.SupplierCode = @SupplierCode) and (DeductionGroupCode=@DeductionGroupCode) and (DeductCode=@DeductCode) and (FixedDeductionId=@FixedDeductionId) and (StartDate=@DeductionStartDate)

					--				INSERT INTO [dbo].[BLSkippedDeduction]
					--			   ([Route] ,[Year] ,[Month] ,[SuppliyerCode] ,[SupplierName] ,[DeductionGroup] ,[DeductionCode] ,[DeductionName] ,[DeductionAmount] ,[Skipped] ,[UserID] ,[CreatedDateTime],ExpectedDeductAmount,DeductionRef)
					--				 VALUES
					--			   (@Route ,@PROYear ,@PROMonth ,@SupplierCode ,@SupplierCode ,@DeductionGroupCode ,@DeductCode ,@DeductCode ,(@DeductAmount-@EarningsBalance)
					--			   ,1 ,@userId ,getdate(),@DeductAmount,@FixedDeductionId)

					--				set @EarningsBalance=	@EarningsBalance-@EarningsBalance	
				
					--END
					--ELSE 
					--BEGIN
					--print 'insert earning 3'
					--print @FixedDeductionId
					--print @DeductAmount
					--			INSERT INTO [dbo].[BLSkippedDeduction]
					--		   ([Route] ,[Year] ,[Month] ,[SuppliyerCode] ,[SupplierName] ,[DeductionGroup] ,[DeductionCode] ,[DeductionName] ,[DeductionAmount]
					--		   ,[Skipped] ,[UserID] ,[CreatedDateTime],ExpectedDeductAmount,DeductionRef)
					--			 VALUES
					--		   (@Route ,@PROYear ,@PROMonth ,@SupplierCode ,@SupplierCode ,@DeductionGroupCode ,@DeductCode ,@DeductCode ,@DeductAmount
					--		   ,1 ,@userId ,getdate(),@DeductAmount,@FixedDeductionId)

					--		   UPDATE            dbo.SupplierDeductions
					--		   SET DeductedYear=@PROYear,DeductedMonth=@PROMonth,DeductedAmount=0 
					--		   WHERE (dbo.SupplierDeductions.BalanceAmount > 0) AND (dbo.SupplierDeductions.CloseYesNo = 0) AND (dbo.SupplierDeductions.SupplierCode = @SupplierCode) and (DeductionGroupCode=@DeductionGroupCode) and (DeductCode=@DeductCode) and (FixedDeductionId=@FixedDeductionId) and (StartDate=@DeductionStartDate)
					--END
				END
				ELSE
				BEGIN
					if not exists (select * from [dbo].[SupplierMonthDeductions] where ([DeductYear]=@PROYear) and ([DeductMonth]=@PROMonth) and ([Route]=@Route) and ([SupplierCode]=@SupplierCode) and ([DeductGroup]=@DeductionGroupCode) and ([DeductCode]=@DeductCode) and (DeductionRef=@FixedDeductionId))
					begin
					INSERT INTO [dbo].[SupplierMonthDeductions] ([DeductYear] ,[DeductMonth] ,[Route] ,[SupplierCode] ,[DeductGroup] ,[DeductCode] ,[Amount],DeductionRef)
					VALUES (@PROYear ,@PROMonth ,@Route ,@SupplierCode ,@DeductionGroupCode ,@DeductCode ,@DeductAmount,@FixedDeductionId)
					end
					else
					begin
						UPDATE [dbo].[SupplierMonthDeductions]
						SET [Amount]=[Amount]+@DeductAmount
						WHERE ([DeductYear]=@PROYear) and ([DeductMonth]=@PROMonth) and ([Route]=@Route) and ([SupplierCode]=@SupplierCode) and ([DeductGroup]=@DeductionGroupCode) and ([DeductCode]=@DeductCode) and (DeductionRef=@FixedDeductionId)
					end 

					UPDATE            dbo.SupplierDeductions
					SET DeductedYear=@PROYear,DeductedMonth=@PROMonth,DeductedAmount=@DeductAmount 
					WHERE (dbo.SupplierDeductions.BalanceAmount > 0) AND (dbo.SupplierDeductions.CloseYesNo = 0) AND (dbo.SupplierDeductions.SupplierCode = @SupplierCode) and (DeductionGroupCode=@DeductionGroupCode) and (DeductCode=@DeductCode) and (FixedDeductionId=@FixedDeductionId) and (StartDate=@DeductionStartDate)
					 
				END	

			FETCH NEXT
			FROM @curDeductions INTO  @DeductionGroupCode,@DeductCode,@DeductAmount,@GroupPriority,@DeductPriority,@DeductBalanceAmount,@FixedDeductionId, @DeductionStartDate 
			END
			CLOSE @curDeductions
		end

	--declare @DepositSuppliyerContribution decimal(18,2)
	--declare @DepositFactoryContribution decimal(18,2)
	--declare @SuppliyerContributionRate decimal(18,2)
	--declare @FactoryContributionRate decimal(18,2)
	--set @SuppliyerContributionRate=(select DepositRate from Supplier where (RouteCode=@Route) and  (SupplierCode=@SupplierCode) and (DepositRequired='YES') and (DepositRequired is not null) and (DepositRate is not null))
	--set @FactoryContributionRate=(select Amount from BLMasterRates where Type='FacContribution')
	--if exists (select * from Supplier where (RouteCode=@Route) and  (SupplierCode=@SupplierCode) and (DepositRequired='YES') and (DepositRate>0) )
	--begin
	--	if exists (select * from DeductionGroup where (DeductionGroupCode='OTHER'))
	--	begin
	--		if exists (select * from DeductionCode where (DeductionCode='DEPOSIT'))
	--		begin
	--			set @DepositSuppliyerContribution=@TOTGL*@SuppliyerContributionRate
	--			set @DepositFactoryContribution=@TOTGL*@FactoryContributionRate
	--			 INSERT INTO [dbo].[SupplierMonthDeductions] ([DeductYear] ,[DeductMonth] ,[Route] ,[SupplierCode] ,[DeductGroup] ,[DeductCode] ,[Amount],DeductionRef)
	--			VALUES (@PROYear ,@PROMonth ,@Route ,@SupplierCode ,'OTHER' ,'DEPOSIT' ,@DepositSuppliyerContribution,0)
	--			if exists (select * from BLSupplierDepositFund where (DepositedYear=@PROYear) and (DepositedMonth=@PROMonth) and (SupplierCode=@SupplierCode) and (Route=@Route) and (Narration='Factory'))
	--			begin
	--			delete  from BLSupplierDepositFund where (DepositedYear=@PROYear) and (DepositedMonth=@PROMonth) and (SupplierCode=@SupplierCode) and (Route=@Route)
	--				INSERT INTO [dbo].[BLSupplierDepositFund]
	--					   ([DepositedYear] ,[DepositedMonth] ,[SupplierCode] ,[Route] ,[Amount] ,[DepositCalculatedQty] ,[Narration] ,[Rate])
	--				 VALUES
	--					   (@PROYear ,@PROMonth ,@SupplierCode ,@Route ,@DepositSuppliyerContribution ,@TOTGL, 'SUPPLIER' ,@SuppliyerContributionRate)
	--				INSERT INTO [dbo].[BLSupplierDepositFund]
	--					   ([DepositedYear] ,[DepositedMonth] ,[SupplierCode] ,[Route] ,[Amount] ,[DepositCalculatedQty] ,[Narration] ,[Rate])
	--				 VALUES
	--					   (@PROYear ,@PROMonth ,@SupplierCode ,@Route ,@DepositFactoryContribution ,@TOTGL, 'FACTORY' ,@FactoryContributionRate)
	--			end

				
	--		end
	--	end
	--end 
		
		



	SET @CashAdvDedut=ISNULL((SELECT  sum(Amount) FROM dbo.SupplierMonthDeductions WHERE (DeductGroup = 'CASHADV') AND (DeductYear = @PROYear) AND (DeductMonth = @PROMonth) AND (SupplierCode = @SupplierCode) AND (Route=@Route)),0)
	print 'CashAdvance'
	print @CashAdvDedut
	SET @FertiDeduct=ISNULL((SELECT  sum(Amount) FROM dbo.SupplierMonthDeductions WHERE (DeductGroup = 'FET') AND (DeductYear = @PROYear) AND (DeductMonth = @PROMonth) AND (SupplierCode = @SupplierCode) AND (Route=@Route)),0)
	print 'Fertilizer'
	print @FertiDeduct	
	print 'Fertilizer'
	print @FertiDeduct
				--FERTILIZER OUTSTANDING---------------
	if exists (SELECT DeductAmount AS Expr1 FROM  dbo.SupplierDeductions WHERE (BalanceAmount > 0) AND (CloseYesNo = 0) AND (DeductionGroupCode = 'FET') AND (StartDate < CONVERT(DATETIME, @FromDate, 102)) AND (SupplierCode = @SupplierCode) AND (RouteNo = @Route))
	begin
		SET @LastMonthFerti=(SELECT TOP (100) PERCENT SUM(DeductAmount) AS Expr1
									FROM            dbo.SupplierDeductions
									WHERE        (BalanceAmount > 0) AND (CloseYesNo = 0) AND (DeductionGroupCode = 'FET') AND (StartDate < CONVERT(DATETIME, @FromDate, 102)) AND (SupplierCode = @SupplierCode) AND (RouteNo = @Route))
	end
	else
	begin
		SET @LastMonthFerti=0
	end

	print 'Fertilizer From Last Months'
	print @FertilizerThisMonth
	SET @FertilizerThisMonth=@FertiDeduct-@LastMonthFerti
	PRINT 'THISMONTH FERTILIZER'
	PRINT @FertilizerThisMonth

	print '@FertilizerThisMonth'
	print @FertilizerThisMonth
	print '@FertiDeduct'
	print @FertiDeduct
	print '@LastMonthFerti'
	print @LastMonthFerti
		

	SET @OtherDeduct=ISNULL((SELECT  sum(Amount) FROM dbo.SupplierMonthDeductions WHERE (DeductGroup = 'OTHER') AND (DeductYear = @PROYear) AND (DeductMonth = @PROMonth) AND (SupplierCode =@SupplierCode AND (Route=@Route))),0)

	SET @LoanDeduct=ISNULL((SELECT  sum(Amount) FROM dbo.SupplierMonthDeductions WHERE (DeductGroup = 'LOAN') AND (DeductYear = @PROYear) AND (DeductMonth = @PROMonth) AND (SupplierCode = @SupplierCode AND (Route=@Route))),0)
	print 'Loan'
	print @LoanDeduct
	SET @TeaDeduct=ISNULL((SELECT  sum(Amount) FROM dbo.SupplierMonthDeductions WHERE (DeductGroup = 'TEA') AND (DeductYear = @PROYear) AND (DeductMonth = @PROMonth) AND (SupplierCode = @SupplierCode) AND (Route=@Route)),0)
	print 'Tea'
	print @TeaDeduct
	SET @StationaryDeduct =ISNULL((SELECT  sum(Amount) FROM dbo.SupplierMonthDeductions WHERE (DeductGroup = 'STA') AND (DeductYear = @PROYear) AND (DeductMonth = @PROMonth) AND (SupplierCode = @SupplierCode) AND (Route=@Route)),0)
	print 'Stationary'
	print @StationaryDeduct
	SET @WelfareDeduct =ISNULL((SELECT  sum(Amount) FROM dbo.SupplierMonthDeductions WHERE (DeductGroup = 'WEL') AND (DeductYear = @PROYear) AND (DeductMonth = @PROMonth) AND (SupplierCode = @SupplierCode) AND (Route=@Route)),0)
	print 'welfare'
	print @WelfareDeduct
	print 'debtsAmount'
	print @DebtsAmount
	print 'Transport Deduction'
	print @TransportDeduction
	print 'Other'
	print @OtherDeduct
	print 'payslipDeduction'
	print @PaySlipDeduction
	print 'stampduty'
	print @StampDuty
	DECLARE @TOTDeductions DECIMAL(18,2)
	SET @TOTDeductions=@DebtsAmount+@TransportDeduction+@CashAdvDedut+@FertiDeduct+@LoanDeduct+@OtherDeduct+@TeaDeduct+@PaySlipDeduction+@StampDuty+@StationaryDeduct+@WelfareDeduct
	PRINT 'TOT DEDUCTIONS1'
	PRINT @TOTDeductions
	


	
	IF EXISTS (SELECT Amount FROM dbo.BLMasterRates WHERE (Type = 'MinChequeAmt'))
	BEGIN
	SET @MINChequeAmt=(SELECT Amount FROM dbo.BLMasterRates WHERE (Type = 'MinChequeAmt'))
	END

	--NETPAY------------
	DECLARE @NetPay DECIMAL(18,2),@PaymentDue DECIMAL(18,2)
	DECLARE @CFDebts DECIMAL(18,2),@CFCoins DECIMAL(18,2)
	SET @NetPay=0
	SET @PaymentDue=0
	SET @CFDebts=0
	SET @CFCoins=0
	SET @NetPay=@TOTEarnings-@TOTDeductions


	if exists (select * from Supplier where (RouteCode=@Route) and  (SupplierCode=@SupplierCode) and (DepositRequired='YES') and (DepositRate>0) )
	begin
		if(@NetPay>0)
		begin
			declare @DepositSuppliyerContribution decimal(18,2)
			declare @DepositFactoryContribution decimal(18,2)
			declare @SuppliyerContributionRate decimal(18,2)
			declare @FactoryContributionRate decimal(18,2)
			set @SuppliyerContributionRate=isnull((select DepositRate from Supplier where (RouteCode=@Route) and  (SupplierCode=@SupplierCode) and (DepositRequired='YES') and (DepositRequired is not null) and (DepositRate is not null)),0)
			set @FactoryContributionRate=isnull((select Amount from BLMasterRates where Type='FacContribution'),0)
			
				if exists (select * from DeductionGroup where (DeductionGroupCode='OTHER'))
				begin
					if exists (select * from DeductionCode where (DeductionCode='DEPOSIT'))
					begin
						set @DepositSuppliyerContribution=@TOTGL*@SuppliyerContributionRate

						if(@DepositSuppliyerContribution<=@NetPay)
						begin
							set @DepositFactoryContribution=@TOTGL*@FactoryContributionRate
						end
						else
						--if partly recovery true
						begin
							set @DepositSuppliyerContribution=@NetPay-(@NetPay%@SuppliyerContributionRate)
							set @DepositFactoryContribution=@DepositSuppliyerContribution/@SuppliyerContributionRate*@FactoryContributionRate
						end

						--set @DepositFactoryContribution=@TOTGL*@FactoryContributionRate

						 INSERT INTO [dbo].[SupplierMonthDeductions] ([DeductYear] ,[DeductMonth] ,[Route] ,[SupplierCode] ,[DeductGroup] ,[DeductCode] ,[Amount],DeductionRef)
						VALUES (@PROYear ,@PROMonth ,@Route ,@SupplierCode ,'OTHER' ,'DEPOSIT' ,@DepositSuppliyerContribution,0)

						if exists (select * from BLSupplierDepositFund where (DepositedYear=@PROYear) and (DepositedMonth=@PROMonth) and (SupplierCode=@SupplierCode) and (Route=@Route) and (Narration='Factory'))
						begin
						delete  from BLSupplierDepositFund where (DepositedYear=@PROYear) and (DepositedMonth=@PROMonth) and (SupplierCode=@SupplierCode) and (Route=@Route)
							INSERT INTO [dbo].[BLSupplierDepositFund]
								   ([DepositedYear] ,[DepositedMonth] ,[SupplierCode] ,[Route] ,[Amount] ,[DepositCalculatedQty] ,[Narration] ,[Rate])
							 VALUES
								   (@PROYear ,@PROMonth ,@SupplierCode ,@Route ,@DepositSuppliyerContribution ,@TOTGL, 'SUPPLIER' ,@SuppliyerContributionRate)
							INSERT INTO [dbo].[BLSupplierDepositFund]
								   ([DepositedYear] ,[DepositedMonth] ,[SupplierCode] ,[Route] ,[Amount] ,[DepositCalculatedQty] ,[Narration] ,[Rate])
							 VALUES
								   (@PROYear ,@PROMonth ,@SupplierCode ,@Route ,@DepositFactoryContribution ,@TOTGL, 'FACTORY' ,@FactoryContributionRate)
						end
						else
						begin
							INSERT INTO [dbo].[BLSupplierDepositFund]
								   ([DepositedYear] ,[DepositedMonth] ,[SupplierCode] ,[Route] ,[Amount] ,[DepositCalculatedQty] ,[Narration] ,[Rate])
							 VALUES
								   (@PROYear ,@PROMonth ,@SupplierCode ,@Route ,@DepositSuppliyerContribution ,@TOTGL, 'SUPPLIER' ,@SuppliyerContributionRate)
							INSERT INTO [dbo].[BLSupplierDepositFund]
								   ([DepositedYear] ,[DepositedMonth] ,[SupplierCode] ,[Route] ,[Amount] ,[DepositCalculatedQty] ,[Narration] ,[Rate])
							 VALUES
								   (@PROYear ,@PROMonth ,@SupplierCode ,@Route ,@DepositFactoryContribution ,@TOTGL, 'FACTORY' ,@FactoryContributionRate)
						end

				
					
				end
			end
		end
		SET @OtherDeduct=ISNULL((SELECT  sum(Amount) FROM dbo.SupplierMonthDeductions WHERE (DeductGroup = 'OTHER') AND (DeductYear = @PROYear) AND (DeductMonth = @PROMonth) AND (SupplierCode =@SupplierCode AND (Route=@Route))),0)
		print 'Other_ Recalculate'
		SET @TOTDeductions=@DebtsAmount+@TransportDeduction+@CashAdvDedut+@FertiDeduct+@LoanDeduct+@OtherDeduct+@TeaDeduct+@PaySlipDeduction+@StampDuty+@StationaryDeduct+@WelfareDeduct
		PRINT 'TOT DEDUCTIONS'
		PRINT @TOTDeductions
		SET @NetPay=@TOTEarnings-@TOTDeductions
		PRINT 'NET PAY AFTER DEPOSIT'
		PRINT @NetPay

	end
	IF(@NetPay>0)
	BEGIN
		SET @PaymentDue=@NetPay
		SET @CFDebts=0
		IF EXISTS (SELECT  PaymentMode FROM dbo.Supplier WHERE (SupplierCode =@SupplierCode) AND (RouteCode = @Route) AND (PaymentMode IS NOT NULL) AND (PaymentMode <> 'NA'))
		BEGIN		
		 SET @PaymentMode=(SELECT  PaymentMode FROM dbo.Supplier WHERE (SupplierCode =@SupplierCode) AND (RouteCode = @Route) AND (PaymentMode IS NOT NULL) AND (PaymentMode <> 'NA')) 
		END
		ELSE
		BEGIN		
			IF(@PaymentDue>=@MINChequeAmt)
			BEGIN
				set @PaymentMode='CHEQUE'
			END
			ELSE
			BEGIN
				set @PaymentMode='CASH'
			END
		END
		
	END
	ELSE
	BEGIN
		SET @PaymentDue=0
		IF EXISTS (SELECT  PaymentMode FROM dbo.Supplier WHERE (SupplierCode =@SupplierCode) AND (RouteCode = @Route) AND (PaymentMode IS NOT NULL) AND (PaymentMode <> 'NA'))
		BEGIN		
		 SET @PaymentMode=(SELECT  PaymentMode FROM dbo.Supplier WHERE (SupplierCode =@SupplierCode) AND (RouteCode = @Route) AND (PaymentMode IS NOT NULL) AND (PaymentMode <> 'NA')) 
		END
		ELSE
		BEGIN
		 SET @PaymentMode='CASH'
		END
		print 'debts amount'
		print 'total earnings'
		print @TOTEarnings
		print 'Tot Deduction'
		print @TOTDeductions
		SET @CFDebts=(@TOTEarnings-@TOTDeductions)*-1
		if exists (select * from dbo.BLDebtors where (Route=@Route) and (SupplierCode=@SupplierCode) and (ProYear=@PROMonth) and (ProMonth=@PROMonth))
		begin
		 delete from dbo.BLDebtors  where (Route=@Route) and (SupplierCode=@SupplierCode) and (ProYear=@PROMonth) and (ProMonth=@PROMonth)
		 INSERT INTO dbo.BLDebtors( Route, SupplierCode, ProYear, ProMonth, DebtsAmount)
			VALUES(@Route,@SupplierCode,@PROYear,@PROMonth,@CFDebts)
		end
		else
		begin
			INSERT INTO dbo.BLDebtors( Route, SupplierCode, ProYear, ProMonth, DebtsAmount)
			VALUES(@Route,@SupplierCode,@PROYear,@PROMonth,@CFDebts)
		end
		
		PRINT 'this month DEBTS on insert'
	PRINT @CFDebts
          
	END

--NO ROUND UP FOR SALARY
print 'tot incentives'
print @IncentiveGoodLeafAmount
print @IncentiveElevationAmount
print @IncentiveSlabAmount

PRINT 'PREVIOUS DEBTS on insert'
	print @PreMonthDate
	PRINT @DebtsAmount
	--INSERT SUMMARY ENTRY
	--DELETE FROM [dbo].[MonthlyPaymentSummary] WHERE ([Year]=@PROYear) AND ([Month]=@PROMonth) AND ([SupplierCode]=@SupplierCode) AND ([RouteCode]=@Route)
	INSERT INTO [dbo].[MonthlyPaymentSummary]
			   ([Year] ,[Month] ,[SupplierCode] ,[RouteCode] ,[GreenLeafKillo] ,[GreenLeafRate] ,[GreenLeafValue] ,[Incentive] ,[OtherAddition],[BFCoin] ,[BFDebt] 
			   ,[TotalEarning] ,[Fertilizer] ,[Transport] ,[Loan] ,[CashAdvance] ,[PaySlip] ,[StampDuty] ,[MadeTea] ,[OtherDeduction] ,[CFDebtBalance],[CFCoinBalance] ,[TotalDeduction],StationaryDeduction,WelfareDeduction
			   ,[PaymentDue] ,[NetPay]  ,[FertilizerOutstading] ,[LoanOutstanding] ,[EditUser] ,[EditDateTime],GoodLeafIncentive,GoodLeafKilos,ElivationIncentive,ElivationKilos,SlabIncentive,PaymentMode,LeafDays,TransportIncentive,ThisMonthFerti)
		 VALUES
			   (@PROYear ,@PROMonth ,@SupplierCode ,@Route ,@TOTGL ,@BLRATE ,@GLPAY ,@IncentiveTotal ,@OtherPayment ,@CoinsAmount ,@DebtsAmount
			   ,@TOTEarnings ,@FertiDeduct ,@TransportDeduction ,@LoanDeduct ,@CashAdvDedut ,@PaySlipDeduction ,@StampDuty ,@TeaDeduct ,@OtherDeduct ,@CFDebts,@CFCoins ,@TOTDeductions,@StationaryDeduct,@WelfareDeduct
			   ,@PaymentDue ,@NetPay    ,@LastMonthFerti ,0 ,@userId ,GETDATE(),@IncentiveGoodLeafAmount,@GoodLeaf,@IncentiveElevationAmount,@TOTGL,@IncentiveSlabAmount,@PaymentMode,@GLDays,@IncentiveTransportAmount,@FertilizerThisMonth)
	SET @state='DONE'

END













