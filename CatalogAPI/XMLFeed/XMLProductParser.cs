using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace CatalogAPI.XMLFeed;

public class XMLProductParser
{
    private string SourcePathLocal { get; set; } = @"C:\Users\jan.podzimek\Documents\AlzaTrade\SkoleniCSharp\ProductCatalogWebAPIProject\CatalogAPI\XMLFeed\ProductFeed.xml";
    private string SourcePathRemote { get; set; } = @"https://cdn.alza.cz/Foto/Trade/Feeds/JendaProductImport.xml";

    public XMLProductParser()
    {
    }

    public List<ProductPutModel> ParseXml()
    {
        try
        {
            XDocument doc = XDocument.Load(SourcePathLocal); 

            List<ProductPutModel> products = doc.Descendants("Product").Select(p => new ProductPutModel
            {
                Ean = p.Element("EAN")?.Value,
                Description = p.Element("DESCRIPTION")?.Value,
                PriceUpdated = DateTime.MinValue,
                Price = int.Parse(p.Element("PRICE").Value),
                Quantity = int.Parse(p.Element("QUANTITY").Value)
            }).ToList();

            return products;
        }
        catch (XmlException exception)
        {
            throw new Exception(exception.Message, exception);
        }
    }
}
