using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Product
    {
        public string articleId { get; set; }
        public string productId { get; set; }
        public string gtin { get; set; }
        public string nan { get; set; }
        public string version { get; set; }
        public string imageUrl { get; set; }
        public PriceInformation priceInformation { get; set; }
        public ProductInformation productInformation { get; set; }

        public NutrientInformation GetNutrientByName(string term)
        {
            bool isEnergy = term.ToLower() == "energie";

            foreach (NutrientInformation nutrientInfo in productInformation.nutrients[0].nutrientInformation)
            {
                if (nutrientInfo.nutrientType.text.ToLower() == term.ToLower())
                {
                    if (!isEnergy)
                    {
                        return nutrientInfo;
                    }
                    else
                    {
                        isEnergy = false;
                    }
                    
                }
            }

            return null;
        }
    }
}
