using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
        // Bana bir tane çalışacağım tabloyu ver "TEntity" bir de çalışacağım database contex'i ver "TContext". Ben ona göre çalışacağım demek yukarıdaki generic.
        // DbContext Microsoft EntityFrameworkCore'dan geliyor
    {
        // NOT 9. BÖLÜMDE: 

        // EfProductDal'dan class'ın içini kopyalayıp içeriği tamamen buraya yapıştırdık.
        // Product'larıTentity yaptık, NorthwindContext'leri de TContext yaptık.
        // Tamamen generic hale getirip her yerde kullanılabilecek şekilde bağımsız hale getirdik.
        public void Add(TEntity entity)
        {

            // IDisposable pattern implementation of c#
            // using i kullanmadan da new leyebiliriz ama bu kalıcı olur.
            // using silinmesini sağlar.
            // us yaz ---> using i seç ---> tab tab yap

            using (TContext context = new TContext()) // bunun meaili işi bitince bu Northwind nesnesini işi bitince Garbage Collector'a at denir.
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

                // git veritabanından yukarıda gönderdiğimiz product'tan bir tane nesneyle eşleştir.
                // ama bu bir ekleme olduğu için eşleştirmeyecek, direkt ekleyecek.
                // addedEntity.State = EntityState.Added(); ile eklenecek nesne konumuna getir ve ekle.
                // context.SaveChanges(); ve tüm işlemleri gerçekleştir.
            }

            // using'e yazdığımız nesneler, using bitince anında garbage collector'a gider ve "beni bellekten at" der. 
            // çünkü context nesnesi biraz pahalıdır.
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);

                // ürünler tablomdan filtrelemeye göre detaylı hepsini getir.

            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();

                //ternary kullandık
                // eğer filtreleme yoksa product'ın hepsini listeleyerek getir.
                // ama eğer filtre varsa, ne filtresi yazarsa ona göre getir ve listele
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
