using Microsoft.EntityFrameworkCore;
using NLayerApp.Core;
using NLayerApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetSingleCategoryByWithProductsAsync(int categoryId)
        {
            return await _context.Categories.Include(x=>x.Products).Where(x=>x.Id == categoryId).SingleOrDefaultAsync();
            //firsOrDefaultAsync ile SingleOrDefaultAsync farki => first, eger tam yazan yerin ustunde ki x.Id den 4 5 tane varsa ilkini bulur dondurur.
            //sinngle dersek eger bu id den where icerisindeki kosulu karsilayan birden fazla satir bulursa hata doner.
        }
    }
}
