# ProductCatalogWebAPIProject
A final C# course project

## Description / popis
Create an application for effective working with product catalog. In will be possible add, 
update and show products in application, by using REST API. Data import will be handled on daily base,
getting data from XML file.

Vytvorte aplikaci pro efektivní správu produktového katalogu, která umožòuje uživatelùm pridávat, 
upravovat a zobrazovat produkty prostrednictvím REST API. Import dat produktù bude probíhat automaticky 
jednou dennì z XML souboru pomocí pozadové služby.

### Structure / Struktura aplikace:
* API modul
* Jádro (Core) aplikace

### Main features / Hlavní funkce:
* Update product: Price update restriction - price may be updated only once in 12 hours
* Get product detail info
* Get list of all products and filtering by specific category
* Product import: Daily data import 

* Upravit produkt: Možnost úpravy informací o produktu, s omezením zmìny ceny maximálnì jednou za 12 hodin.
* Zobrazit detail produktu: Detailní informace o každém produktu.
* Zobrazit seznam produktù: Filtrace produktù podle kategorií a stránkování.
* Import produktù: Denní import s pravidly pro zachování stávající ceny pri shodì s existujícími daty.

#### Database / Databáze:
* Microsoft SQL Server
* Entity Framework

### Product format in app / Formát Produktu v aplikaci:
Id, Ean, Description, Quantity, Price, Currency, Categories

## Roadmap
* Creation of Database project (tables and dependencies) [DONE]
* Creation of DataAccess project using Dapper instead of EF, to be able access the data from MS SQL in C# code [DONE]
* Creation of CatalogAPI project, to set Swagger and different CRUD methods [DONE]
* Implementing complex property (List of categories) to ProductModel, sending and receiving data [DONE]
* Implementing the Price restriction when Price can be updated only once in 12 hours [DONE]
* Implementing GET filter method to get only products from specific category [DONE]
* Getting ready to implement pagination and daily import function [INPROGRESS]
