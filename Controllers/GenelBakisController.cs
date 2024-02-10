using PROJETAKIP.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROJETAKIP.Controllers
{
    public class GenelBakisController : Controller
    {
        private ProjeTakipDBContext db = new ProjeTakipDBContext(); //Veri tabanı bağlantısı
        // GET: GenelBakis
        public ActionResult Index()
        {
            int ProjeSayisi = db.PersonelProjeleris.Count();
            ViewBag.ProjeSayisi = ProjeSayisi;


            int tamamlanmisProje = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == true).Count();
            ViewBag.TamamlanmisProje = tamamlanmisProje;

            var yuksekOncelikliProjeler = db.PersonelProjeleris.Where(p => p.OncelikDurumu == "Yüksek Öncelikli").Count();
            ViewBag.YuksekOncelikli = yuksekOncelikliProjeler;

            var ortaOncelikliProjeler = db.PersonelProjeleris.Where(p => p.OncelikDurumu == "Orta Öncelikli").Count();
            ViewBag.OrtaOncelikli = ortaOncelikliProjeler;

            var dusukOncelikliProjeler = db.PersonelProjeleris.Where(p => p.OncelikDurumu == "Düşük Öncelikli").Count();
            ViewBag.DusukOncelik = dusukOncelikliProjeler;

            var basarili_yuksek = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == true && p.OncelikDurumu == "Yüksek Öncelikli").Count();
            ViewBag.Basarili_Yuksek = basarili_yuksek;

            var basarili_orta = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == true && p.OncelikDurumu == "Orta Öncelikli").Count();
            ViewBag.Basarili_Orta = basarili_orta;

            var basarili_dusuk = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == true && p.OncelikDurumu == "Düşük Öncelikli").Count();
            ViewBag.Basarili_Dusuk = basarili_dusuk;

            int tamamlanmamisProje = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == false).Count();
            ViewBag.TamamlanmamisProje = tamamlanmamisProje;

            var personelProjeListesi = db.PersonelProjeleris.ToList();
            var personelTamamlanmisProjeSayisi = new Dictionary<int, int>(); //Perosnelid ve tamamlanmış proje sayısı çiftini bir arada tut

            foreach (var personel in db.PersonelBilgileris.ToList())
            {
                int tamamlanmisProjeSayisi = 0;
                foreach (var proje in personel.PersonelProjeleris)
                {
                    if (proje.TamamlanmaDurumu == true)
                    {
                        tamamlanmisProjeSayisi++;
                    }
                }
                personelTamamlanmisProjeSayisi[personel.PersonelBilgileriId] = tamamlanmisProjeSayisi;
            }

            var siraliPersonelListesi = personelTamamlanmisProjeSayisi.OrderByDescending(x => x.Value); // tamamlanmış proje sayısına göre personelleri sırala
            var enCokTamamlananPersonelId = siraliPersonelListesi.First().Key; // en çol tamamlama sayısına sahip personeli al
            var enCokTamamlananPersonel = db.PersonelBilgileris.FirstOrDefault(p => p.PersonelBilgileriId == enCokTamamlananPersonelId);
            ViewBag.enCokTamamlayanPersonelBilgisi = enCokTamamlananPersonel.AdSoyad;

            int enCokProjeTamamlayanPersonelProjeSayisi = personelTamamlanmisProjeSayisi[enCokTamamlananPersonelId];
            ViewBag.enCOkProjeTamamlayanPersonelinProjeSayisi = enCokProjeTamamlayanPersonelProjeSayisi;
            return View();
        }

        public ActionResult GenelIstatistik()
        {
            var personeller = db.PersonelBilgileris.ToList();
            var personelProjeleri = db.PersonelProjeleris.ToList();
            var tamamlananProjeSayisi = new Dictionary<int, int>();
            var tamamlanmayanProjeSayisi = new Dictionary<int, int>();
            var toplamProjeSayisi = new Dictionary<int, int>();

            foreach (var personel in personeller)
            {
                int tamamlananProje = 0;
                int tamamlanmayanProje = 0;
                int toplamProje = 0;
                foreach (var proje in personelProjeleri)
                {
                    if (proje.PersonelBilgileris.Contains(personel))
                    {
                        toplamProje++;
                        if (proje.TamamlanmaDurumu)
                        {
                            tamamlananProje++;
                        }
                        else
                        {
                            tamamlanmayanProje++;
                        }
                    }
                }

                tamamlananProjeSayisi[personel.PersonelBilgileriId] = tamamlananProje;
                tamamlanmayanProjeSayisi[personel.PersonelBilgileriId] = tamamlanmayanProje;
                toplamProjeSayisi[personel.PersonelBilgileriId] = toplamProje;
            }

            ViewBag.TamamlananProjeSayisi = tamamlananProjeSayisi;
            ViewBag.TamamlanmayanProjeSayisi = tamamlanmayanProjeSayisi;
            ViewBag.ToplamProjeSayisi = toplamProjeSayisi;


            int ProjeSayisi = db.PersonelProjeleris.Count();
            ViewBag.ProjeSayisi = ProjeSayisi;

            int personelSayisi = db.PersonelBilgileris.Count();
            ViewBag.PersonelSayisi = personelSayisi;

            int tamamlanmisProje = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == true).Count();
            ViewBag.TamamlanmisProje = tamamlanmisProje;

            int tamamlanmamisProje = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == false).Count();
            ViewBag.TamamlanmamisProje = tamamlanmamisProje;

            var basarisiz_yuksek = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == false && p.OncelikDurumu == "Yüksek Öncelikli").Count();
            ViewBag.Basarisiz_Yuksek = basarisiz_yuksek;

            var basarisiz_orta = db.PersonelProjeleris.Where(p => p.TamamlanmaDurumu == false && p.OncelikDurumu == "Orta Öncelikli").Count();
            ViewBag.Basarisiz_Orta = basarisiz_orta;

            return View(personeller);
        }

    }
}