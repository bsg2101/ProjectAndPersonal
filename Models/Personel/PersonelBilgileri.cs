using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using PROJETAKIP.Models.ProjeTakip;
using System.Security.Cryptography.X509Certificates;

namespace PROJETAKIP.Models.Personel
{
    public class PersonelBilgileri
    {
        public PersonelBilgileri()
        {
            this.PersonelProjeleris = new HashSet<PersonelProjeleri>();
        }


        [Key]
        public int PersonelBilgileriId { get; set; }

        [DisplayName("E-posta")]
        public string Eposta { get; set; }

        [DisplayName("Şifre")] //İsimlendirmeler
        [StringLength(50, ErrorMessage = "Maksimum uzunluk 50 karakterden fazla olamaz.")] //Kısıtlamalar
        public string Sifre { get; set; }

        [DisplayName("Yetki")]
        [StringLength(50, ErrorMessage = "Maksimum uzunluk 50 karakterden fazla olamaz.")]

        public string Yetki { get; set; }

        [DisplayName("Ad Soyad")]
        [StringLength(50, ErrorMessage = "Maksimum uzunluk 50 karakterden fazla olamaz.")]
        public string AdSoyad { get; set; }

        [DisplayName("Personel Görseli")]
        public string PersonelGorseli { get; set; }

        [DisplayName("TC Kimlik NO")]
        [StringLength(15, ErrorMessage = "Maksimum uzunluk 15 karakterden fazla olamaz.")]
        public string TCNO { get; set; }

        [DisplayName("Departmanı")]
        [StringLength(50, ErrorMessage = "Maksimum uzunluk 50 karakterden fazla olamaz.")]
        public string Departman { get; set; }

        [DisplayName("Görevi")]
        [StringLength(50, ErrorMessage = "Maksimum uzunluk 50 karakterden fazla olamaz.")]
        public string Gorev { get; set; }

        [DisplayName("Açıklama")]
        [StringLength(150, ErrorMessage = "Maksimum uzunluk 50 karakterden fazla olamaz.")]
        public string PozisyonAciklama { get; set; }

        [DisplayName("Telefon Numarası")]
        [StringLength(15, ErrorMessage = "Maksimum uzunluk 15 karakterden fazla olamaz.")]
        public string TelNo { get; set; }

        [DisplayName("Adres Bilgileri")]
        [StringLength(40, ErrorMessage = "Maksimum uzunluk 40 karakterden fazla olamaz.")]
        public string Adres { get; set; }

        [DisplayName("Medeni Hal")]
        [StringLength(25, ErrorMessage = "Maksimum uzunluk 25 karakterden fazla olamaz.")]
        public string MedeniHal { get; set; }

        [DisplayName("Yakınlık Bilgisi")]
        [StringLength(25, ErrorMessage = "Maksimum uzunluk 25 karakterden fazla olamaz.")]
        public string YakinBilgisi { get; set; }


        [DisplayName("Yakını TC NO")]
        [StringLength(15, ErrorMessage = "Maksimum uzunluk 15 karakterden fazla olamaz.")]
        public string YakinTC { get; set; }

        [DisplayName("Yakını Ad Soyad")]
        [StringLength(50, ErrorMessage = "Maksimum uzunluk 50 karakterden fazla olamaz.")]
        public string YakinAdSoyad { get; set; }

        [DisplayName("Yakını Tel NO")]
        [StringLength(25, ErrorMessage = "Maksimum uzunluk 25 karakterden fazla olamaz.")]
        public string YakinTel { get; set; }

        [DisplayName("Doğum Tarihi")]
        public DateTime dogumTarihi { get; set; }

        [DisplayName("İşe Giriş Tarihi")]
        public DateTime? IseGirisTarihi { get; set; }

        public virtual ICollection<PersonelProjeleri> PersonelProjeleris { get; set; }
    }
}