# ProductCatalogWebAPIProject
A final C# course project

## Description / popis
Create an application for effective working with product catalog. In will be possible add, 
update and show products in application, by using REST API. Data import will be handled on daily base,
getting data from XML file.

Vytvorte aplikaci pro efektivn� spr�vu produktov�ho katalogu, kter� umo��uje u�ivatel�m prid�vat, 
upravovat a zobrazovat produkty prostrednictv�m REST API. Import dat produkt� bude prob�hat automaticky 
jednou denn� z XML souboru pomoc� pozadov� slu�by.

### Structure / Struktura aplikace:
* API modul
* J�dro (Core) aplikace

### Main features / Hlavn� funkce:
* Update product: Price update restriction - price may be updated only once in 12 hours
* Get product detail info
* Get list of all products and filtering by specific category
* Product import: Daily data import 

* Upravit produkt: Mo�nost �pravy informac� o produktu, s omezen�m zm�ny ceny maxim�ln� jednou za 12 hodin.
* Zobrazit detail produktu: Detailn� informace o ka�d�m produktu.
* Zobrazit seznam produkt�: Filtrace produkt� podle kategori� a str�nkov�n�.
* Import produkt�: Denn� import s pravidly pro zachov�n� st�vaj�c� ceny pri shod� s existuj�c�mi daty.

#### Database / Datab�ze:
* Microsoft SQL Server
* Entity Framework

### Product format in app / Form�t Produktu v aplikaci:
Id, Ean, Description, Quantity, Price, Currency, Categories

## Roadmap
* Creation of Database project (tables and dependencies) [DONE]
* Creation of DataAccess project using Dapper instead of EF, to be able access the data from MS SQL in C# code [DONE]
* Creation of CatalogAPI project, to set Swagger and different CRUD methods [DONE]
* Implementing complex property (List of categories) to ProductModel, sending and receiving data [DONE]
* Implementing the Price restriction when Price can be updated only once in 12 hours [DONE]
* Implementing GET filter method to get only products from specific category [DONE]
* Getting ready to implement pagination and daily import function [INPROGRESS]
