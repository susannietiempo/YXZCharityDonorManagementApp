Select * from Gift

INSERT INTO dbo.Account
SELECT * FROM dbo.Account
Drop table dbo.Acccount

Update Account
SET isInActive = 0
Where AccountId in (1,23, 30, 21, 6, 2);

Drop database XYZCharity

SELECT TOP(10) KeyName, GiftDate, ReceivedAmount FROM Gift INNER JOIN Account ON Gift.AccountId = Account.AccountId ORDER BY GiftDate DESC

 EXEC sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT all'
 EXEC sp_msforeachtable 'ALTER TABLE ? CHECK CONSTRAINT all'

 Insert into VolunteerAssignment (ProgramId, AccountId, HoursSignedUp, HoursCompleted)
 Values
 (2, 6, 5, 5),
(2, 7, 6, 6),
(2, 8, 3, 2),
(2, 9, 10, 8),
(2, 10, 5, 5),
(2, 11, 5, 4),
(2, 12, 5, 5),
(2, 13, 3, 3),
(1, 4, 20, 15),
(1, 3, 15, 13),
(1, 5, 20, 20),
(1, 6, 10, 8),
(1, 8, 5, 2),
(1, 18, 10, 5),
(3, 15, 20, 15),
(3, 16, 15, 13),
(3, 17, 20, 20),
(3, 18, 10, 8),
(3, 19, 5, 2),
(4, 1, 10, 7),
(4, 2, 5, 2),
(4, 13, 5, 5),
(7, 2, 10, 8),
(7, 3, 15, 10),
(7, 6, 20, 20),
(7, 16, 10, 5),
(7, 15, 10, 5)

Delete FROM  VolunteerAssignment
