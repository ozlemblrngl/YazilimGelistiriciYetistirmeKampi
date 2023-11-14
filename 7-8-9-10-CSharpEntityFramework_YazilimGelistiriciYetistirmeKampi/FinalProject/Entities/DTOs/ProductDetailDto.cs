using Core.Entities; // burada da .Entities'i eklememişti kendim ekledim.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ProductDetailDto : IDto

    // IDto yu oluşturmak için ampüle tıklıyoruz generate type 'IDto' içinde generate new type'ı seçiyoruz,
    // Public, interface diyoruz ismine IDto diyoruz, project olarak : Core'u işaretliyoruz,
    // Create new File yeri olarak da : Entities\IDto.cs diyoruz yani Core'daki Entities altına yapıyoruz.

    // Dikkat hem bu sayfanın using kısmında hem de IDto.cs'nin using kısmına Core.Entities şeklinde .Entities'i otomatik eklememişti kendim ekledim.

    // sen bir IDto'sun diyoruz çünkü burası bir tablo değil o nedenle IEntity yazmıyoruz.
    // DTO sadece tabloda birkaç kolon olabilir. DTO burada örn CategoryId tablosundaki name'leri prodoct'an alırken kullandığımız yerdir.
    // bu bakımdan IEntity tüm tablolarıa denk gelirken, IDto bağlanacak join edileceklere denk gelecek. O nedenle IDto interface'ini oluşturuyoruz.

    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName{ get; set; }
        public short UnitsInStock { get; set; }

    }
}
