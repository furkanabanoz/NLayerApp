using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.Core
{//category 1-n product
 //product 1-1 ProductFeature
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }//product in da bir tane CategoryId cardir diyoruz EntitiyFramewok otomatikmen algiliyor bunun category nin id oldugunu ona gore tablo olusturuyor
        public Category Category { get; set; }//navigation prop
        public ProductFeature ProductFeature { get; set; }//navigation prop

    }
}
