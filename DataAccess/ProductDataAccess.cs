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
            //XDocument.Load(Server.MapPath("/App_Data/PageData.xml"));
            //System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/yourXmlFile.xml")

            string assemblyFile = (
                new System.Uri(Assembly.GetExecutingAssembly().CodeBase)
                ).AbsolutePath;

            var xx = Directory.GetCurrentDirectory();
            //var yy = System.Web.Hosting.HostingEnvironment.MapPath("~/ProductsData.xml");
            //var zz = System.Web.HttpContext.Current.Server.MapPath("~/ProductsData.xml");

            

            string startupPath = AppDomain.CurrentDomain.RelativeSearchPath;

            var xxx = System.Web.HttpContext.Current.Request.PhysicalApplicationPath;
            var xxx1 = System.Web.HttpContext.Current.Request.ApplicationPath;
            var xxx2 = System.Web.HttpContext.Current.Request.FilePath;
            var xxx3 = System.Web.HttpContext.Current.Request.Path;
            var xxx4 = System.Web.HttpContext.Current.Request.PhysicalPath;
            var xxx5 = System.Web.HttpContext.Current.Request.CurrentExecutionFilePath;

            //xmlDoc.Load(@"~/DataAccess/ProductsData.xml");

            var appDomain = System.AppDomain.CurrentDomain;
            var basePath = appDomain.RelativeSearchPath ?? appDomain.BaseDirectory;
            Path.Combine(basePath, "Templates", "NotificatioEmail.cshtml");

            xmlDoc.Load(appDomain.BaseDirectory + "/Data/ProductsData.xml");
            //xmlDoc.Load("D:\\New folder\\ashraf\\e-commerce\\DataAccess\\ProductsData.xml");
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
