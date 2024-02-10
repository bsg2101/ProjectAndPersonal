using PROJETAKIP.Models.DataContext;
using PROJETAKIP.Models.ProjeTakip;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROJETAKIP.Controllers
{
    public class PersonelProjeController : Controller
    {
        private ProjeTakipDBContext db = new ProjeTakipDBContext(); //Veri tabanı bağlantısı
        // GET: PersonelProje
        public ActionResult Index()
        {
            var ProjeListele = db.PersonelProjeleris.ToList();
            return View(ProjeListele);
        }

        public ActionResult create() 
        {
            ViewBag.PersonelBilgileriId = new SelectList(db.PersonelBilgileris, "PersonelBilgileriId", "AdSoyad");
            return View();
        }
        [HttpPost]
        public ActionResult create(PersonelProjeleri projeobj, int[] PersonelBilgileriId)
        {
            foreach(var x in PersonelBilgileriId) 
            { 
                projeobj.PersonelBilgileris.Add(db.PersonelBilgileris.Find(x));
            }
            projeobj.OlusturmaTarihi = DateTime.Now;
            db.PersonelProjeleris.Add(projeobj);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var projeobj= db.PersonelProjeleris.Find(id);
            return View(projeobj);
        }

        [HttpPost]

        public ActionResult Edit(PersonelProjeleri projeobj)
        {
            var projeDbobj = db.PersonelProjeleris.Find(projeobj.PersonelProjeId);
            projeDbobj.ProjeAciklama = projeobj.ProjeAciklama;
            projeDbobj.ProjeBaslik = projeobj.ProjeBaslik;
            projeDbobj.TamamlanmaOrani = projeobj.TamamlanmaOrani;
            projeDbobj.OncelikDurumu = projeobj.OncelikDurumu;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Tamamla(int id)
        {
            var projeobj = db.PersonelProjeleris.Find(id);
            projeobj.TamamlanmaDurumu = true;
            projeobj.TamamlanmaOrani = 100;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}