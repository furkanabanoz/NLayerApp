using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.Core
{
    //bir category de birden cok product olabilecegini gosteriyoruz
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }//Navigation prop cunku biz  Categoryden products lara gidebiliriz 
    }
}
