using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Web.Hosting;

namespace BookAppsWeb.Models
{

    // Back-end class for dealing with the searches
    // and create results 
    public class Repository
    {
        private static XElement theDoc;


        static Repository()
        {
            // Gets an hosting independent path to "~/App_Data/books.xml"
            string pth = HostingEnvironment.MapPath("~/App_Data/books.xml");

            theDoc = XElement.Load(pth); 
        }


        // Generic search function for all kinds of "main element searches" in Book.xml-data.
        // Param srch is the searchstring, key = "author"/"title"/"genre"/"description" (main elements) etc 
        // casesensitive search: caseSens = true/false
        public static List<BookResults> SrchByKeyword(string srch,string key,bool caseSensitive)
        {
            IEnumerable<XElement> res;
            if (caseSensitive)
            {
                res = from bk in theDoc.Elements("book")
                      where bk.Element(key).Value.Contains(srch)
                      select bk;
            }
            else 
            {
                res = from bk in theDoc.Elements("book")
                          where bk.Element(key).Value.ToLower().Contains(srch.ToLower())
                          select bk;
            }
            
            return listResult(res);
        }


        // Search function for Id's
        // Param Id is the searchstring
        public static List<BookResults> SrchById(string Id,bool caseSensitive)
        {
            IEnumerable<XElement> res;
            if (caseSensitive)
            {
                res = from bk in theDoc.Elements("book")
                      where (string)bk.Attribute("id").Value == Id
                      select bk;
            }
            else
            {
                res = from bk in theDoc.Elements("book")
                      where (string)bk.Attribute("id").Value == Id.ToUpper()
                      select bk;
            }                

            return listResult(res);
        }

        
        // Creates a list of BookResults
        private static List<BookResults> listResult(IEnumerable<XElement> xElem)
        {
            var l = new List<BookResults>();
            foreach(var x in xElem)
            {
            
                var id = x.Attribute("id").Value;


                var t = x.Element("title").Value;
                var a = x.Element("author").Value;
                var g = x.Element("genre").Value;

                var p = x.Element("price").Value;
                var pd = x.Element("publish_date").Value;

                var d = x.Element("description").Value;

                l.Add(new BookResults(id,a,g,t,p,pd,d));
            }
            return l;
        }

       


        // Gets all books
        public static List<BookResults> GetAllTitles()
        {
            var res= from bk in theDoc.Elements("book")
                         select bk;

            return listResult(res);
        }


        //public static void Add(XElement Element)
        //{
        //      IEnumerable<XElement> books = theDoc.Elements();
        //}

        // public static void Remove(XElement Element)
        //{
        //}
    }
}
