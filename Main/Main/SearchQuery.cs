using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class SearchQuery
    {
        public List<Product> products { get; set; }

        public Product GetProduct()
        {
            return products[0];
        }
    }
}
