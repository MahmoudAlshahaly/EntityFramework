using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using static D10LINQ.ListGenerators;
namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument customerXml= XDocument.Load(@"C:\Users\Eng-Mahmoud Ahmed\Desktop\EntityFramework\Day3\Linq\Linq\bin\Debug\net5.0\Customers.xml");
            var customers = customerXml.Descendants("customer");

            //var customerlist = customerXml.Descendants("customer").Select(d => new {
            //    id = d.Element("Id").Value,
            //    Name = d.Element("Name").Value,
            //    address = d.Element("address").Value,
            //    city = d.Element("city").Value,
            //    postalcode = d.Element("postalcode").Value,
            //    country = d.Element("country").Value,
            //    phone = d.Element("phone").Value,
            //    fax = d.Element("fax").Value,
            //    orders = d.Element("orders").Value,
            //}).ToList();

            var productOut = ProductList.FindAll(a => a.UnitsInStock == 0);
            foreach (var item in productOut)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(" -----------------------------------------------------------------------");

            var productINStock = ProductList.FindAll(a => a.UnitsInStock > 0 && a.UnitPrice >3);
            foreach (var item in productINStock)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(" -----------------------------------------------------------------------");


            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };


            for (int i = 0; i < Arr.Length; i++)
            {
                if (Arr[i].Length < i)
                {
                    Console.WriteLine(Arr[i]);
                }
            }
            //Console.ReadLine();
            Console.WriteLine(" -----------------------------------------------------------------------");

            var productFirtOutOFstock = ProductList.FirstOrDefault(a=>a.UnitsInStock == 0) ;
        
            Console.WriteLine(productFirtOutOFstock);

            Console.WriteLine(" -----------------------------------------------------------------------");


            var productFirstgreater1000 = ProductList.FirstOrDefault(a => a.UnitPrice > 1000);
            Console.WriteLine(productFirstgreater1000);


            Console.WriteLine(" -----------------------------------------------------------------------");

            int[] Arr2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var secondnumber=Arr2.Where(a=>a >5 ).ElementAt(1);

            Console.WriteLine(" -----------------------------------------------------------------------");
            var unquiecat = ProductList.Select(a => new { category = a.Category }).Distinct();
            foreach (var item in unquiecat)
            {
                Console.WriteLine(item);

            }


            Console.WriteLine(" -----------------------------------------------------------------------");

            //var customrs = customerXml.Element("customers").Elements("customer").Select(a=>a.Attribute("name").Value);
            var customr = customers.GroupBy(a => a.Element("name").Value.First()).Where(b => b.Count() == 1).Select(b => b.Key);
 
            var product = ProductList.GroupBy(a=>a.ProductName.First()).Where(b => b.Count()==1).Select(b=>b.Key);

            var cccc = customr.Union(product);
            foreach (var item in cccc)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(" -----------------------------------------------------------------------");


            var commoncust = customers.GroupBy(a => a.Element("name").Value.First()).Where(b => b.Count() == 1).Select(b => b.Key);

            var commonpro = ProductList.GroupBy(a => a.ProductName.First()).Where(b => b.Count() == 1).Select(b => b.Key);

            var intersect = commoncust.Intersect(commonpro);
            foreach (var item in intersect)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(" -----------------------------------------------------------------------");

            var expect = commonpro.Except(commoncust);
            foreach (var item in expect)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(" -----------------------------------------------------------------------");

            var commoncustlastthree = customers.GroupBy(a => a.Element("name").Value.Substring(a.Element("name").Value.Length - 3)).Where(b => b.Count() == 1).Select(b => b.Key);
            var commonprolastthree = ProductList.GroupBy(a => a.ProductName.Substring(a.ProductName.Length - 3)).Where(b => b.Count() == 1).Select(b => b.Key);
            var last3 = commoncustlastthree.Union(commonprolastthree);
            foreach (var item in last3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(" -----------------------------------------------------------------------");

            int[] Arr3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var numofodd = Arr3.Where(a => a % 2 == 0);
            foreach (var item in numofodd)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(" -----------------------------------------------------------------------");


           var customrWithOrder= customers.Select(a =>  new
            {
                cutomer = a.Element("name").Value,
                orders = a.Descendants("order").Count()
            });
            foreach (var item in customrWithOrder)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(" -----------------------------------------------------------------------");
            var categoryWithproduct =ProductList.Select(a => new
            {
                category = a.Category,
                product = a.ProductName.Count()
            });
            foreach (var item in categoryWithproduct)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(" -----------------------------------------------------------------------");

            int[] Arr4 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var sum = Arr4.Sum();
            Console.WriteLine(sum);

            Console.WriteLine(" -----------------------------------------------------------------------");

            var categoryWithtotalprice = ProductList.GroupBy(p => p.Category,p => p.UnitsInStock,(key, g) => new { category = key, UnitsInStock = g.Sum() });

            foreach (var item in categoryWithtotalprice)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(" -----------------------------------------------------------------------");

            StreamReader sr = new StreamReader(@"C:\Users\Eng-Mahmoud Ahmed\Desktop\EntityFramework\Day3\Linq\Linq\bin\Debug\net5.0\dictionary_english.txt");

            var a = new { id=100,name="ahmed"};
            var b = new { id=100,name= "yasser" };
            Console.WriteLine(a.Equals(b));

            DB.DATABASE.LOG = LOG => Debug.WriteLine(LOG);

            var t = ProductList.Where(a=>a.ProductID>5);
            var te = ProductList.ToList().Where(a=>a.ProductID>5);
            Debug.
            Console.WriteLine();
        }
    }
}
