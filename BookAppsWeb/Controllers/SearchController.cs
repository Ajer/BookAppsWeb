using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Xml;
using System.Xml.Linq;
using BookAppsWeb.Models;

namespace BookAppsWeb.Controllers
{

    // Web API for Book-data-searching
    public class SearchController : ApiController
    {


        // Id Search  GET: /api/Search?idSrchStr=val1&caseSens=val2
        [HttpGet]
        public IHttpActionResult GetSrchResultById(string idSrchStr, bool caseSens = false)
        {
            if (idSrchStr != null)
            {
                var t = Repository.SrchById(idSrchStr, caseSens);
                return Ok(t);
            }
            else
            {
                return null;   // Alternative: NotFound();
            }
        }


        // Title Search  GET: /api/Search?titleSrchStr=val1&caseSens=val2
        [HttpGet]
        public IHttpActionResult GetSrchResultByTitle(string titleSrchStr,bool caseSens = false)
        {

            if (titleSrchStr != null)
            {
                var t = Repository.SrchByKeyword(titleSrchStr,"title",caseSens);
                return Ok(t);
            }
            else
            {
                return null;
            }
        }

        
        // Author Search GET: /api/Search?authSrchStr=val1&caseSens=val2
        [HttpGet]
        public IHttpActionResult GetSrchResultByAuthor(string authSrchStr, bool caseSens = false)
        {

            if (authSrchStr != null)
            {
                var t = Repository.SrchByKeyword(authSrchStr,"author",caseSens);
                return Ok(t);
            }
            else
            {
                return null;
            }
        }

        //[HttpGet]
        // Get All Books  GET: /api/search
        //public IEnumerable<BookResults> GetAllBooks()
        //{
        //    var t = Repository.GetAllTitles();

        //    return t;
        //}
    }
}
