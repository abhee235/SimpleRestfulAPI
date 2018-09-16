# SimpleRestfulAPI
This implementation will demonstrate about Restful API which will read the data from csv file and save the data in csv file.

The location path of the file is given default in E: directory. Please put USCensus.csv file into E dirve of local computer or change
the path in code.And URL is hard coded.


====================== 
API link - http://localhost:54196/api/records 
==============================================



API Harness Page

==================================================
http://localhost:54196/ApiHarness.html
==================================================

Technology Stack:
==============================================================================================
4.6 .Net Framework.
ASP.net MVC 5.
WebApi 2
Jquery.js
Datatable.js.
================================================================================================= 



Brief About this project
===================================================================================================

THis project is using ASP.NET MVC 5 fromework along with Web API 2 to create RESTful serivces to extract Records (U.S) data.
1.Created an API where all the date is comming form csv file. 
2.CSV file is loaded into memory and saved as Datatable inside memory.
Caching is used to store data.
3.Data is transformed into Models to server.
4.Json Response is returned from api. 
5. Using Autofac for Dependency Injection.
6. Using Automaper for mapping Datatable into models.
7. Used Datatable.js to filter and soritng data on API.



====================================================================================================================================================================================

