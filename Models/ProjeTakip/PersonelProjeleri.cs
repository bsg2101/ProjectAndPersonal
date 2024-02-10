using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using PROJETAKIP.Models.Personel;

namespace PROJETAKIP.Models.ProjeTakip
{
    public class PersonelProjeleri
    {
        public PersonelProjeleri() 
        { 
            this.PersonelBilgileris= new HashSet<PersonelBilgileri>();
        }

        [Key]
        public int PersonelProjeId { get; set; }

        [DisplayName("Proje Başlığı")] //İsimlendirme
        [StringLength(100, ErrorMessage = "Maksimum uzunluk 100 karakterden fazla olamaz.")] //Kısıtlama
        public string ProjeBaslik { get; set; }

        [DisplayName("Proje Açıklaması")]
        public string ProjeAciklama { get; set; }

        [DisplayName("Oluşturma Tarihi")]
        public DateTime OlusturmaTarihi { get; set; }

        [DisplayName("Öncelik Durumu")]
        [StringLength(25, ErrorMessage = "Maksimum uzunluk 25 karakterden fazla olamaz.")]
        public string OncelikDurumu { get; set; }

        [DisplayName("Tamamlanma Oranı")]
        public int TamamlanmaOrani { get; set; }

        [DisplayName("Tamalanma Tarihi")]
        public DateTime? TamamlanmaTarihi { get; set; }

        [DisplayName("Tamamlanma Durumu")]
        public bool TamamlanmaDurumu { get; set; }

        public virtual ICollection<PersonelBilgileri> PersonelBilgileris { get; set; }
    }
}