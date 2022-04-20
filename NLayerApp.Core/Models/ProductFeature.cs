using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.Core
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int ProductId { get; set; }//hangi ProductFeature in hangi product a ait oldugunu efcore bu sayede anlayacak
        public Product product { get; set; }//navigation prop
    }
}
