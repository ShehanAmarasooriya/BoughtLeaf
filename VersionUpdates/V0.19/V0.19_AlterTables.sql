IF COL_LENGTH('Supplier','PaymodeActive') is null
BEGIN
Alter table dbo.Supplier
add PaymodeActive bit not null default (0)
END
update 


update            dbo.Supplier
set PaymodeActive=1
WHERE        (SalarySendBank = 1) AND (LEN(AccountNo) > 0)

update            dbo.Supplier
set PaymodeActive=1
WHERE        (SalarySendBank = 1) AND (LEN(AccountNo) > 0)
