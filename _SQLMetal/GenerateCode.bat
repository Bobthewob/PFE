@echo **********************************************************************
@echo * Genere le code                                                     *
@echo **********************************************************************
call "C:\Program Files (x86)\Microsoft SDKs\Windows\v10.0A\bin\NETFX 4.6.1 Tools\SqlMetal.exe" /server:(localdb)\MSSQLLocalDB  /database:GDA  /code:../STM.GDA.DataAccess/GDA_DataAccess.cs /pluralize  /context:GDA_Context /namespace:STM.GDA.DataAccess /views /functions /sprocs > log.txt && type log.txt

@echo.
pause