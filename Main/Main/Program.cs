using Newtonsoft.Json;
using System;
using System.Net;
namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Fetchlist();
            Console.ReadLine();
        }

        private static void Fetchlist()
        {
            int page = 1;
            int maxPage = 1;
            string startPage = "https://mobile-api.rewe.de/mobile/products/search?withFacets=true&storeId=241108&objectsPerPage=250&page=";
            WebClient client = new WebClient();

            QueryList initQuery = JsonConvert.DeserializeObject<QueryList>(client.DownloadString(startPage + page.ToString()));
            maxPage = initQuery.pageCount;
            ExcelController excel = new ExcelController(@"XLS PATH");

            for (page = 1; page <= maxPage; page++)
            {
                Console.WriteLine("=== CRAWLING PAGE " + page + "/" + maxPage + "===");
                QueryList query = JsonConvert.DeserializeObject<QueryList>(client.DownloadString(startPage + page.ToString()));
                foreach (Product product in query.products)
                {
                    try
                    {
                        ReweProdukt curProduct = new ReweProdukt(product.productId);
                        excel.InsertRow(curProduct);
                }
                    catch { continue; }
            }
            }

            Console.ReadLine();
        }
    }
}