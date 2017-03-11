using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using DataAccess.Interface;
using Domain;

namespace DataAccess
{
    public class ProductDataAccess : IProductDataAccess
    {
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            XmlDocument xmlDoc = new XmlDocument();
            var appDomain = System.AppDomain.CurrentDomain;
            xmlDoc.Load(appDomain.BaseDirectory + "/Data/ProductsData.xml");
            
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("product");
            foreach (XmlNode node in nodeList)
            {
                var product = new Product();
                product.Id = int.Parse(node.SelectSingleNode("Id").InnerText);
                product.Name = node.SelectSingleNode("Name").InnerText;
                product.Price = float.Parse( node.SelectSingleNode("Price").InnerText);
                product.ImagePath = node.SelectSingleNode("ImagePath").InnerText;

                products.Add(product);
            }

            return products;
        }
    }
}
