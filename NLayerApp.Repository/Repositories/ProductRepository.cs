using Microsoft.EntityFrameworkCore;
using NLayerApp.Core;
using NLayerApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.Repository.Repositories
{//productRepository uzerinden hem generic repository ye erismek hemde generic repositorynin icinde yazili olan methodlari bir daha yazmamak icin generic repository`i atasinif oalrak aliyoruz ve interfaceimizi yazip oradan gelecek olan methodlari da gormuuyoruz 

    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductWithCategory()
        {
            //eager loading yaptik include ile verilari cekerek
            return await _context.Products.Include(x=>x.Category).ToListAsync();
        }
    } 
    //bir de lazy loading vardir
}
