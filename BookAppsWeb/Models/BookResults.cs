using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookAppsWeb.Models
{
    // Class for keeping searchresults
    public class BookResults
    {
      
            public string Id { get; set; }
            public string Author { get; set; }
            public string Title { get; set; }          
            public string Genre { get; set; }
            public string Price { get; set; }
            public string Publish_Date { get; set; }
            public string Description { get; set; }

            public BookResults(string id, string author, string genre , string title , string price, string publish_Date, string desc)
            {
                this.Id = id;
                this.Author = author;
                this.Title = title;
                this.Genre = genre;
                this.Price = price;
                this.Publish_Date = publish_Date;
                this.Description = desc;
            }
    }
 }
