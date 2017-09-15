using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;

namespace Main
{
    class ReweProdukt
    {
        public QuantityContained kcal { get; set; }
        public QuantityContained fett { get; set; }
        public QuantityContained kohlenhydrate { get; set; }
        public QuantityContained eiweiß { get; set; }
        public QuantityContained salz { get; set; }

        SearchQuery query = null;
        Product product = null;
        public string price { get; set; }
        public string productName { get; set; }
        public decimal cents { get; set; }
        public string imgUrl { get; set; }
        public string servingSize { get; set; }
        public string servingEinheit { get; set; }

        public ReweProdukt(string id)
        {
            WebClient client = new WebClient();
            client.Proxy = null;
            client.Encoding = Encoding.UTF8;
            string list = client.DownloadString("https://mobile-api.rewe.de/mobile/products/details-by-productid?storeId=241108&productId=" + id);

            query = JsonConvert.DeserializeObject<SearchQuery>(list);
            product = query.GetProduct();

            kcal = product.GetNutrientByName("Energie").quantityContained;
            fett = product.GetNutrientByName("Fett").quantityContained;
            kohlenhydrate = product.GetNutrientByName("Kohlenhydrate").quantityContained;
            eiweiß = product.GetNutrientByName("Eiweiß").quantityContained;
            salz = product.GetNutrientByName("Salz").quantityContained;
            cents = int.Parse(product.priceInformation.regularPrice);
            price = String.Format("{0:0.00}", cents / 100);
            productName = product.productInformation.descriptionInformation.productName + " // " + product.productInformation.descriptionInformation.regulatedProductName;
            imgUrl = product.imageUrl;
            servingSize = product.productInformation.nutrients[0].servingSize.value;
            servingEinheit = product.productInformation.nutrients[0].servingSize.uomShortText;
        }

        public void Print()
        {
            Console.WriteLine("=== Produkt ===");
            Console.WriteLine("Name\t" + productName);
            Console.WriteLine("kcal\t" + kcal.value);
            Console.WriteLine("fett\t" + fett.value);
            Console.WriteLine("kohlenhydrate\t" + kohlenhydrate.value);
            Console.WriteLine("eiweiss\t" + eiweiß.value);
            Console.WriteLine("salz\t" + salz.value);
        }
    }
}
