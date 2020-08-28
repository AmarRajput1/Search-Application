# Search-Application
An application to compare MSSQL Database vs Excel data handling using C#.NET

This application has been programmed using c# as a visual studio windows forms project. The purpose of this demonstration is to show communication and data sorting from two sources.

This application is able to search through an excel file to find a data table at the same time as search through an SQL database and return results from both sources based on pre-determined search criteria. The results of the search then populate a data grid view.

An example excel data file has been included in the bin/debug folder (Data.xlsx). Excel communication is managed with reference to 'EPPLus.dll' which can be downloaded from http://epplus.codeplex.com

An example schema has been included in the uppermost folder of the application to create the same data table in SQL management studio (called 'ResultsTableSchema.sql'). The database is named 'SearchResults' and the table is named 'ResultsTable'. Please feel free to change the connection string in accordance with prefered settings defined in line 21 on frmSearch.cs

The bulk of the code that handles communication with the SQL database and displays data from all sources on the main search form is found in file 'frmSearch.cs'

The designer for the main search form is found in file 'frmSearch.Designer.cs'

The code that handles communication with the Excel file is found in class 'ExcelComms.cs'
