﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Domain;

namespace DataAccess
{
    public class ProductDataAccess
    {
        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("D:\\New folder\\ashraf\\e-commerce\\DataAccess\\ProductsData.xml");
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
