﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //dal ve dao(javacılar kullanır data access object)
    // interface'in kendisi public değildir. Operasyonları public'tir.
    public interface IProductDal
    {

        List<Product> GetAll(); // Listenin hepsini getir

        void Add(Product product);
                                                                // buralar default public'tir interface'te.
        void Update(Product product);

        void Delete(Product product);

        List<Product> GetAllByCategory(int categoryId); // ürünleri kategoriye göre filtrele demek
    }
}
