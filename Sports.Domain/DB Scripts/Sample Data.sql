-- Use this file to insert sample data for new databases..

Set Identity_insert Tournament On

Insert Into Tournament (TournamentId, TournamentName, StartDate, EndDate, TournamentFlags)
			    Values (1, 'Tournament I', '01/01/2011', '09/30/2011', 0),(2, 'Tournament II', '01/01/2012', '09/30/2012', 0),(3, 'Tournament III', '01/01/2013', '09/30/2013', 0)

Set Identity_insert Tournament Off