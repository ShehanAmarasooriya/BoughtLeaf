IF NOT EXISTS (Select * from  [AgalawatteBoughtLeafDB].[dbo].[Factory] where [FactoryName]='Delgoda Tea Factory')

begin

       INSERT INTO [dbo].[Factory]

           ([FactoryCode] ,[FactoryName] ,[RegNo] ,[Extent])

     VALUES

           ('ttf','Delgoda Tea Factory' ,0 ,0.00)

end

IF NOT EXISTS (Select * from  [dbo].[BLMasterSettings] where [Type]='PrePrintedPaySlip')

begin

 INSERT INTO [dbo].[BLMasterSettings]

           ([Code] ,[Name] ,[Type] )

     VALUES

           (1,'No' ,'PrePrintedPaySlip')
end
else
begin

update [dbo].[BLMasterSettings]

set [Name]='Yes'

where [Type]='PrePrinted pay slip'

end