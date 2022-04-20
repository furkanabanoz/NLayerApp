using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.Core.Repositories
{//veri tabanina yapacagimiz tum temel sorgulari burada yapacagiz
    public interface IGenericRepository<T> where T : class
    {

        Task<T> GetByIdAsync(int id);
        //yazmis oldugumuz sorgular direkt db a gitmez mutlaka toList toListAssing gibi methodlari cagirirsaniz o zaman db a gider
        //biz ozellikle where methodundan geriye bir IQueryable donuyoruz ki biz dondukten sonra orderBy yapabiliriz baska sorgular yazabiliriz daha performasli calisabilmek icin


        IQueryable<T> GetAll();


        //async methodlarini kullanmamizin sebebi var olan tiredleri bloklamamk icin tiredleri daha efektif kullanmak icin


        //productRepository.where(x=>x.id>5).orderby.toList(); islemini altta iqueryable ile rahatlikla yapabiliyoruz(orderby dedigi siralama)
        IQueryable<T> Where(Expression<Func<T, bool>> expression); //biz burada veri tabanina bir sorgu yapmiyoruz sadece veri tabanina yapilacak olan sorguyu olusturuyoruz

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);//var mi yokmu diye sorgulayacak yapidir 
        Task AddAsync(T entity);//add burada memory e bir data yukledigi icin uzun suren bir islem oldugu icin async olmasi sart.
        Task AddRangeAsync(IEnumerable<T> entities);//birden fazla da kaydedebiliriz
        void Update(T entity);//update ya da remove ikisi de ayni bunlarin async methodlari yok, olmasina da gerek yok.
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);



    }
}
