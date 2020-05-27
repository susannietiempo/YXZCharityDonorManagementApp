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
  Title              char(5) NULL, 
  FirstName          varchar(50) DEFAULT '""' NOT NULL, 
  MiddleName         varchar(50) NULL, 
  LastName           varchar(50) DEFAULT '""' NOT NULL, 
  OrganizationName   varchar(100) DEFAULT '""' NOT NULL, 
  Suffix             char(5) NULL, 
  StreetAddress      varchar(100) NOT NULL, 
  Gender             char(20) NOT NULL, 
  Email              varchar(255) NULL, 
  BirthDate          date NOT NULL, 
  PhoneNumber        char(20) NULL, 
  ConstituencyTypeId int NOT NULL, 
  IsInactive         bit NOT NULL, 
  DateAdded          datetime NOT NULL, 
  City               varchar(50) NOT NULL, 
  Province           char(5) NOT NULL, 
  Country            char(20) DEFAULT '=Canada' NOT NULL, 
  PRIMARY KEY (AccountId));
CREATE TABLE ConstituencyType (
  ConstituencyTypeId   int IDENTITY NOT NULL, 
  ConstituencyTypeName varchar(50) NOT NULL, 
  PRIMARY KEY (ConstituencyTypeId));
CREATE TABLE Gender (
  GenderId          int IDENTITY NOT NULL, 
  GenderName        varchar(50) NOT NULL, 
  GenderDescription varchar(255) NULL, 
  PRIMARY KEY (GenderId));
CREATE TABLE [User] (
  UserId    int IDENTITY NOT NULL, 
  UserName  varchar(50) NOT NULL, 
  FirstName varchar(50) NOT NULL, 
  LastName  varchar(50) NOT NULL, 
  AccountId int NOT NULL, 
  PRIMARY KEY (UserId));
CREATE TABLE VolunteerAssignment (
  ProgramId      int NOT NULL, 
  AccountId      int NOT NULL, 
  HoursCompleted float(10) DEFAULT =0 NOT NULL, 
  HoursSignedUp  int NULL, 
  PRIMARY KEY (ProgramId, 
  AccountId));
ALTER TABLE LogIn ADD CONSTRAINT FKLogIn882434 FOREIGN KEY (UserId) REFERENCES [User] (UserId);
ALTER TABLE Account ADD CONSTRAINT FKAccount371406 FOREIGN KEY (ConstituencyTypeId) REFERENCES ConstituencyType (ConstituencyTypeId);
ALTER TABLE Gift ADD CONSTRAINT FKGift430584 FOREIGN KEY (AccountId) REFERENCES Account (AccountId);
ALTER TABLE VolunteerAssignment ADD CONSTRAINT FKVolunteerA171722 FOREIGN KEY (ProgramId) REFERENCES VolunteerProgram (ProgramId);
ALTER TABLE VolunteerAssignment ADD CONSTRAINT FKVolunteerA201962 FOREIGN KEY (AccountId) REFERENCES Account (AccountId);
