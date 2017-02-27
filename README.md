# mssql-to-csv
.NET console application for converting Microsoft SQL Server database to csv file

1. Open the solution by Visual Studio.
2. Change [App.config](https://github.com/karavanjo/mssql-to-csv/blob/master/MsSqlToCsv/App.config) - replace example connection strings to your connection strings.
3. Run the application.
4. All tables and views for each database will be exported to directory `Debug` or `Release` in following structure:

| Name        | Type           |
| ------------- |-------------|
| database_1      | directory |
| database_2      | directory |
| database_1.zip | file      |
| database_2.zip | file      |

Each directory will be contained .csv files - one per each table/view from database.  
Each .zip file will be contained archived directory.
