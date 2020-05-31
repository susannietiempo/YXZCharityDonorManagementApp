CREATE TABLE Gift (
  GiftId         int IDENTITY NOT NULL, 
  GiftDate       datetime NOT NULL, 
  ReceivedAmount money DEFAULT 0 NOT NULL, 
  GiftNote       varchar(255) NULL, 
  GiftType       varchar(50) NOT NULL, 
  Approach       varchar(50) NOT NULL, 
  Campaign       varchar(50) NOT NULL, 
  Fund           varchar(50) NOT NULL, 
  AccountId      int NOT NULL, 
  PRIMARY KEY (GiftId));
CREATE TABLE LogIn (
  LoginId  int IDENTITY NOT NULL, 
  UserId   int NOT NULL, 
  Password varchar(50) NOT NULL, 
  PRIMARY KEY (LoginId));
CREATE TABLE VolunteerProgram (
  ProgramId          int IDENTITY NOT NULL, 
  ProgramName        varchar(50) NOT NULL, 
  ProgramDescription varchar(255) NULL, 
  ProgramStartDate   datetime NOT NULL, 
  ProgramEndDate     date NOT NULL, 
  TargetHeadCount    int NULL, 
  TargetFund         varchar(50) NOT NULL, 
  IsActive           bit NOT NULL, 
  CONSTRAINT affliationId 
    PRIMARY KEY (ProgramId));
CREATE TABLE Account (
  AccountId          int IDENTITY NOT NULL, 
  Title              varchar(20) NULL, 
  FirstName          varchar(50) NULL, 
  MiddleName         varchar(50) NULL, 
  LastName           varchar(50) NULL, 
  OrganizationName   varchar(100) NULL, 
  KeyName			 varchar(max) NOT NULL, 
  Suffix             varchar(20) NULL, 
  StreetAddress      varchar(100) NOT NULL, 
  Gender             varchar(20) NULL, 
  Email              varchar(255) NULL, 
  BirthDate          date NULL, 
  PhoneNumber        varchar(30) NULL, 
  ConstituencyTypeId int NOT NULL, 
  IsInactive         bit NOT NULL, 
  DateAdded          datetime NOT NULL, 
  City               varchar(50) NOT NULL, 
  Province           varchar(20) NOT NULL, 
  PostalCode           varchar(20) NOT NULL, 
  Country            varchar(20) NOT NULL, 
  PRIMARY KEY (AccountId));
CREATE TABLE ConstituencyType (
  ConstituencyTypeId   int IDENTITY NOT NULL, 
  ConstituencyTypeName varchar(50) NOT NULL, 
  PRIMARY KEY (ConstituencyTypeId));
CREATE TABLE [User] (
  UserId    int IDENTITY NOT NULL, 
  UserName  varchar(50) NOT NULL, 
  FirstName varchar(50) NOT NULL, 
  LastName  varchar(50) NOT NULL, 
  PRIMARY KEY (UserId));
CREATE TABLE VolunteerAssignment (
  ProgramId      int NOT NULL, 
  AccountId      int NOT NULL, 
  HoursCompleted float(10) NOT NULL, 
  HoursSignedUp  int NULL, 
  PRIMARY KEY (ProgramId, 
  AccountId));

ALTER TABLE LogIn ADD CONSTRAINT FKLogInUser FOREIGN KEY (UserId) REFERENCES [User] (UserId);
ALTER TABLE Account ADD CONSTRAINT FKAccountConstituencyType FOREIGN KEY (ConstituencyTypeId) REFERENCES ConstituencyType (ConstituencyTypeId);
ALTER TABLE Gift ADD CONSTRAINT FKGiftAccount FOREIGN KEY (AccountId) REFERENCES Account (AccountId);
ALTER TABLE VolunteerAssignment ADD CONSTRAINT FKVolunteerassignmentVolunteerprogram FOREIGN KEY (ProgramId) REFERENCES VolunteerProgram (ProgramId);
ALTER TABLE VolunteerAssignment ADD CONSTRAINT FKVolunteerassignmentAccount FOREIGN KEY (AccountId) REFERENCES Account (AccountId);


