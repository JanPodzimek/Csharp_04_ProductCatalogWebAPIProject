# ProductCatalogWebAPIProject
A final C# course project

## Description
Vytvoøte aplikaci pro efektivní správu produktového katalogu, která umožòuje uživatelùm pøidávat, 
upravovat a zobrazovat produkty prostøednictvím REST API. Import dat produktù bude probíhat automaticky 
jednou dennì z XML souboru pomocí pozadové služby.

### Struktura aplikace:
API modul
Jádro (Core) aplikace

### Hlavní funkce:
Upravit produkt: Možnost úpravy informací o produktu, s omezením zmìny ceny maximálnì jednou za 12 hodin.
Zobrazit detail produktu: Detailní informace o každém produktu.
Zobrazit seznam produktù: Filtrace produktù podle kategorií a stránkování.
Import produktù: Denní import s pravidly pro zachování stávající ceny pøi shodì s existujícími daty.
Databáze:

Použití Microsoft SQL Server a Entity Framework.

### Formát Produktu v aplikaci:
Id, Ean, Description, Quantity, Price, Currency, Categories

## Roadmap
* Updated Readme information

