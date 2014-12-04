using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
//using Windows.Web.Http;
using System.Net.Http;
using Windows.Data.Json;

namespace NewyorkTimes_BestSellers.Models
{
    public class BestSeller : ObservableCollection<Book>
    {
        private static BestSeller current = null;

        public static BestSeller Current
        { 
            get
            {
                if (current == null)
                 current = new BestSeller();
                return current;
            }
        }

        private BestSeller()
        {
            LoadData();

        }

        public async void LoadData()
        {

           

            HttpClient client = new HttpClient();
            string url = "http://api.nytimes.com/svc/books/v2/lists//hardcover-fiction.json?&offset=&sortby=&sortorder=&api-key=76038659ae9258d87cfb6dc8d6f02d35::66739421";
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonData = await response.Content.ReadAsStringAsync();
            JsonObject jsonobject = JsonObject.Parse(jsonData);

            var resultObject = jsonobject.GetObject();
            var result = resultObject["results"].GetArray();

            foreach (var item in result)
            {
                JsonObject BookDetails = item.GetObject().GetNamedValue("book_details").GetArray()[0].GetObject();
                Book book = new Book();
                book.Title = BookDetails.GetNamedString("title");
                book.Description = BookDetails.GetNamedString("description");
                book.Author = BookDetails.GetNamedString("author");
                book.Price = BookDetails.GetNamedNumber("price", 0.00);
                book.Publisher = BookDetails.GetNamedString("publisher");
                Add(book);
            }
        }
    }
}
