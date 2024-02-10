using PROJETAKIP.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROJETAKIP.Controllers
{
    public class ProjeRaporlariController : Controller
    {
        public ProjeTakipDBContext db = new ProjeTakipDBContext();
        // GET: ProjeRaporlari
        public ActionResult TamamlanmisOncelikGruplari()
        {
            return View();
        }
        public ActionResult VisualizeTamamlanmisDurumGruplari()
        {
            return Json(OncelikGrupTipi(), JsonRequestBehavior.AllowGet);
        }
        public List<ClassOncelikDurumAnaliz> OncelikGrupTipi()
        {
            ;
            List<ClassOncelikDurumAnaliz> snf = new List<ClassOncelikDurumAnaliz>();
            using (var c = new ProjeTakipDBContext())
                snf= c.PersonelProjeleris.Where(x=>x.TamamlanmaDurumu==true).GroupBy(p=>p.OncelikDurumu).Select(x=> new ClassOncelikDurumAnaliz
                {
                    onceliktipi =x.Key,
                    oncelikadeti=x.Count(),
                }).ToList();
            
            return snf;
        }


        
        // GET: ProjeRaporlari
        public ActionResult TamamlanmamisOncelikGruplari()
        {
            return View();
        }
        public ActionResult VisualizeTamamlanmayanDurumGruplari()
        {
            return Json(OncelikTamamlanmayanGrupTipi(), JsonRequestBehavior.AllowGet);
        }
        public List<ClassOncelikDurumAnaliz> OncelikTamamlanmayanGrupTipi()
        {
            ;
            List<ClassOncelikDurumAnaliz> snf = new List<ClassOncelikDurumAnaliz>();
            using (var c = new ProjeTakipDBContext())
                snf = c.PersonelProjeleris.Where(x => x.TamamlanmaDurumu == false).GroupBy(p => p.OncelikDurumu).Select(x => new ClassOncelikDurumAnaliz
                {
                    onceliktipi = x.Key,
                    oncelikadeti = x.Count(),
                }).ToList();

            return snf;
        }
        public ActionResult GenelProjeRaporlari()
        {
            return View();
        }

        public ActionResult CanliDestek()
        {
            var destek = db.PersonelBilgileris.Where(x => x.Departman == "Yazılım");
            return View(destek.ToList());
        }  
    }
}