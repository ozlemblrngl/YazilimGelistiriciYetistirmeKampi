using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    // Buraya da Using Core.Entities 'i ekleyip, Using.Abstract.Entities'i siliyoruz.
    public class Category : IEntity

    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
