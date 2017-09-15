using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class ProductInformation
    {
        public DescriptionInformation descriptionInformation { get; set; }
        public bool bio { get; set; }
        public List<Nutrient> nutrients { get; set; }
    }
}
