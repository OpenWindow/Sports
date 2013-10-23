--DO NOT USE BELOW SCRIPT TO GENERATE Database Tables. Tables will be created using Entity Framework

--Print 'Processing Table Tournament'

---- Initial Table Version
--If Not Exists(Select id From sysobjects Where type='U' and name='Tournament')
--  Begin
--    -- Create Initial Version of Table
--    Create Table Tournament 
--	(TournamentId               int                         Identity(1,1),
--	 TournamentName             nvarchar(60)     Not Null,
--	 StartDate                  datetime         Not Null,
--	 EndDate                    datetime         Not Null,
--	 TournamentFlags            int              Not Null
--	 )
--  End

---- Get the Table Id to check all other objects
--Declare @TableId int
--Select @TableId = id From sysobjects Where [type]='U' and [name]='Tournament'

---- Primary Keys
--If Not Exists(Select id From sysobjects Where [type]='K' and [name] = 'xpkTournament')
--  Alter Table Tournament Add Constraint xpkTournament Primary Key (TournamentId)

---- Foreign Keys

---- Default Constraints
--If Not Exists(Select [id] From sysobjects Where [type]='D' and [name] = 'dfTournamentFlags')
--  Alter Table Tournament Add Constraint dfTournamentFlags Default 0 For TournamentFlags

---- Check Constraints

---- Indexes
--If Not Exists(Select [id] From sysindexes Where [id]=@TableId and [name]='xak1Tournament')
--  Create Unique Index xak1Tournament On Tournament (TournamentId)

---- Post Creation Table Column Changes

--Print 'Processing Table Team'

---- Initial Table Version
--If Not Exists(Select id From sysobjects Where type='U' and name='Team')
--  Begin
--    -- Create Initial Version of Table
--    Create Table Team 
--	(TeamId               int                         Identity(1,1),
--	 TeamName             nvarchar(60)     Not Null,
--	 TeamPOC              nvarchar(120)    Not Null,
--	 TournamentId         int              Not Null,
--	 TeamFlags            int              Not Null
--	 )
--  End

---- Get the Table Id to check all other objects
--Select @TableId = id From sysobjects Where [type]='U' and [name]='Team'

---- Primary Keys
--If Not Exists(Select id From sysobjects Where [type]='K' and [name] = 'xpkTeam')
--  Alter Table Team Add Constraint xpkTeam Primary Key (TeamId)

---- Foreign Keys
--If Not Exists(Select [id] From sysobjects Where [type]='F' and [name] = 'xfkTeam_TournamentId')
--  Alter Table Team Add Constraint xfkTeam_TournamentId Foreign Key (TournamentId) References Tournament (TournamentId) On Delete Cascade

---- Default Constraints
--If Not Exists(Select [id] From sysobjects Where [type]='D' and [name] = 'dfTeamFlags')
--  Alter Table Team Add Constraint dfTeamFlags Default 0 For TeamFlags

---- Check Constraints

---- Indexes
--If Not Exists(Select [id] From sysindexes Where [id]=@TableId and [name]='xak1Team')
--  Create Unique Index xak1Team On Team (TeamId)

---- Post Creation Table Column Changes