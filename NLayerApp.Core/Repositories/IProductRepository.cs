using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.Core.Repositories
{
    public interface IProductRepository:IGenericRepository<Product>
    {
        Task<List<Product>> GetProductWithCategory();//normalde geriye bir task dondugumuz zaman async method oldugunu belli etmek icin sonuna async yazilmazi lazimdir burda yapmamisiz sonra duzeltiriz

    }
}
