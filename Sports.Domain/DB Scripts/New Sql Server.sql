Create Login SportsUser With PASSWORD = 'gH738$$f50_*hDws', DEFAULT_DATABASE = master
Go

Create Role SportsRole
Go

Create User SportsUser From Login SportsUser 
Go

exec sp_addrolemember 'SportsRole', 'SportsUser' 
Go