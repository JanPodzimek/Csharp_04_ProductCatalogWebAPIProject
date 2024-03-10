# ProductCatalogWebAPIProject
A final C# course project

## Description
Vytvo�te aplikaci pro efektivn� spr�vu produktov�ho katalogu, kter� umo��uje u�ivatel�m p�id�vat, 
upravovat a zobrazovat produkty prost�ednictv�m REST API. Import dat produkt� bude prob�hat automaticky 
jednou denn� z XML souboru pomoc� pozadov� slu�by.

### Struktura aplikace:
API modul
J�dro (Core) aplikace

### Hlavn� funkce:
Upravit produkt: Mo�nost �pravy informac� o produktu, s omezen�m zm�ny ceny maxim�ln� jednou za 12 hodin.
Zobrazit detail produktu: Detailn� informace o ka�d�m produktu.
Zobrazit seznam produkt�: Filtrace produkt� podle kategori� a str�nkov�n�.
Import produkt�: Denn� import s pravidly pro zachov�n� st�vaj�c� ceny p�i shod� s existuj�c�mi daty.
Datab�ze:

Pou�it� Microsoft SQL Server a Entity Framework.

### Form�t Produktu v aplikaci:
Id, Ean, Description, Quantity, Price, Currency, Categories

## Roadmap
* Updated Readme information

