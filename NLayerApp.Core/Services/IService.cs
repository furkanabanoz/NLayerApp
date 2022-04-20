using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.Core.Services
{//genericRepositorynin icerisindekileri alip yapisitirdik repository den farki updateleri async yapip voidleri task a cevirme ve getallasync yi degistirme
    public interface IService<T> where T:class
    {
        Task<T> GetByIdAsync(int id);

        Task <IEnumerable<T>> GetAllAsync();//tum datayi alan bir async method yaptik
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task<T> AddAsync(T entity);
        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task RemoveRange(IEnumerable<T> entities);




    }
}
