using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {

            // IDisposable pattern implementation of c#
            // using i kullanmadan da new leyebiliriz ama bu kalıcı olur.
            // using silinmesini sağlar.
            // us yaz ---> using i seç ---> tab tab yap

            using (NorthwindContext context = new NorthwindContext()) // bunun meaili işi bitince bu Northwind nesnesini işi bitince Garbage Collector'a at denir.
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

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext()) 
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);

                // ürünler tablomdan filtrelemeye göre detaylı hepsini getir.

            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null 
                    ? context.Set<Product>().ToList()
                    : context.Set<Product>().Where(filter).ToList();
               
                //ternary kullandık
                // eğer filtreleme yoksa product'ın hepsini listeleyerek getir.
                // ama eğer filtre varsa, ne filtresi yazarsa ona göre getir ve listele
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

            }
        }
    }
}
